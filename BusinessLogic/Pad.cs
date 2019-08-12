using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class Pad : ITasksProvider
    {
        public const int TasksCapacity = 25;

        public Pad()
        {
            ActiveTaskIndex = -1;
            Tasks = new List<Task>();
            GuidId = Guid.NewGuid();
        }

        public ICollection<Task> Tasks { get; set; }

        // remove one of id or guidid
        public int Id { get; set; }

        public Guid GuidId { get; set; }

        // check in setter, if we have not such page
        public int ActivePageIndex { get; set; }

        // check in setter, if we have not such task
        public int ActiveTaskIndex { get; set; }

        public bool TaskWasStartedThisTurn { get; set; }

        public void AddTask(Task task)
        {
            if (Tasks == null)
            {
                Tasks = new List<Task>();
            }

            task.Pad = this;
            Tasks.Add(task);
        }

        public IEnumerable<Task> GetTasks()
        {
            return Tasks.ToList();
        }

        public Task GetActiveTask()
        {
            if (ActiveTaskIndex == -1)
            {
                return null;
            }

            return Tasks.ElementAt(ActiveTaskIndex);
        }

        // move to paginator
        public IEnumerable<Task> GetActivePageTasks()
        {
            return GetTasksFromPage(ActivePageIndex);
        }

        // move to paginator
        public IEnumerable<Task> GetTasksFromPage(int pageIndex)
        {
            var offset = pageIndex * TasksCapacity;
            return Tasks.ToList().GetRange(offset, TasksCapacity);
        }

        public void ResetActiveTask()
        {
            ActiveTaskIndex = -1;
        }

        public void ActivatePage(int nextPageIndex)
        {
            ActivePageIndex = nextPageIndex;
            TaskWasStartedThisTurn = false;
        }

        public void StartTask(Task taskToChoose)
        {
            var taskToChooseIndex = Tasks.ToList().IndexOf(taskToChoose);
            ActiveTaskIndex = taskToChooseIndex;
            TaskWasStartedThisTurn = true;
        }
    }
}
