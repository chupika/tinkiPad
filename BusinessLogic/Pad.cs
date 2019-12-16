using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class Pad
    {
        public Pad()
        {
            ActiveTaskIndex = -1;
            Tasks = new List<Task>();
        }

        public ICollection<Task> Tasks { get; set; }

        public int Id { get; set; }

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

        public void ResetActiveTask()
        {
            ActiveTaskIndex = -1;
        }

        public void ActivatePage(int nextPageIndex)
        {
            ActivePageIndex = nextPageIndex;
            TaskWasStartedThisTurn = false;
        }

        //probably remove or replace by StartTaskById
        public void StartTask(Task taskToChoose)
        {
            var taskToStartIndex = Tasks.ToList().IndexOf(taskToChoose);
            StartTaskByIndex(taskToStartIndex);
        }

        public void StartTaskByIndex(int taskIndex)
        {
            ActiveTaskIndex = taskIndex;
            TaskWasStartedThisTurn = true;
        }
    }
}
