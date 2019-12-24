using BusinessLogic;
using DAL;
using Xunit;
using System;
using System.Linq;

namespace Tests.TestDB
{
    public class TestDB
    {
        [Fact(Skip = "only for saving to db test")]
        public void CreateAndSaveTasks()
        {
            var task0 = new Task { Caption = "Task0", Addition = "Addition0" };
            var task1 = new Task { Caption = "Task1", Addition = "Addition1" };

            var pad = new Pad();

            using (var contextSetData = new ApplicationContext())
            {
                pad.AddTask(task0);
                pad.AddTask(task1);

                contextSetData.Pads.Add(pad);
                contextSetData.SaveChanges();
            }

            using (var contextGetData = new ApplicationContext())
            {
                var tasks = contextGetData.Tasks.Where(task => task.Pad.Id == pad.Id).ToList();
                Assert.NotNull(tasks);
                Assert.True(tasks.Count >= 2, "Tasks count " + tasks.Count);

                Console.WriteLine("Tasks list:");
                foreach (var task in tasks)
                {
                    Console.WriteLine($"{task.Caption} - {task.Addition}");
                }
            }
        }

        [Fact(Skip = "only for saving to db test")]
        public void GetTask()
        {
            using (var db = new ApplicationContext())
            {
                var pads = db.Pads.ToList();
                Assert.NotNull(pads);

                if (pads.Count == 0)
                {
                    Console.WriteLine("Empty pad");
                    return;
                }

                var tasks = db.Tasks.ToList();

                Assert.NotNull(tasks);
                Console.WriteLine("Tasks count: " + tasks.Count);
                Console.WriteLine("Tasks list:");
                foreach (var task in tasks)
                {
                    Console.WriteLine($"Caption: {task.Caption}, Addition: {task.Addition}, Id: {task.Id}");
                }
            }
        }
    }
}
