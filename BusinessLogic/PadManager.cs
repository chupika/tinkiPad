using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class PadManager
    {
        private readonly Pad _pad;
        private readonly Paginator _paginator;

        public PadManager(Pad pad)
        {
            _pad = pad;
            _paginator = new Paginator(pad);
        }

        public void CompleteTask()
        {
            var activeTask = _pad.GetActiveTask();

            if (activeTask == null)
            {
                // probably should throw exception instead
                return;
            }

            activeTask.IsDone = true;
            _pad.ResetActiveTask();
        }

        public void InterruptTask()
        {
            var activeTask = _pad.GetActiveTask();

            if (activeTask == null)
            {
                // probably should throw exception instead
                return;
            }

            activeTask.IsDone = true;
            _pad.ResetActiveTask();
            var taskContinue = activeTask.CopyTask();
            _pad.AddTask(taskContinue);
        }

        public void StartTaskById(int id)
        {
            var taskToStart = _pad.Tasks.Single(task => task.Id == id);
            StartTask(taskToStart);
        }

        public void StartTaskByIndex(int index)
        {
            var taskToStart = _pad.Tasks.ElementAt(index);
            StartTask(taskToStart);
        }

        public void TurnPage()
        {
            if (_pad.ActiveTaskIndex != -1)
            {
                throw new InvalidOperationException("Cannot activate next page, because an active task is in progress");
            }

            if (_paginator.CountPendingPages() < 2)
            {
                throw new InvalidOperationException("Cannot activate next page, because pages amount is less than 2");
            }

            var nextPageIndex = _paginator.GetNextPendingPageIndex();
            _pad.ActivatePage(nextPageIndex);
        }

        public void KillPage()
        {
            if (_pad.ActiveTaskIndex != -1)
            {
                throw new InvalidOperationException("Cannot kill page because a task is in progress");
            }

            if (_paginator.CountPendingPages() <= 1)
            {
                throw new InvalidOperationException("Cannot kill single pending page");
            }

            if (_pad.TaskWasStartedThisTurn)
            {
                throw new InvalidOperationException("Cannot kill page that have been started this turn");
            }

            var tasksFromActivePage = _paginator.GetTasksFromActivePage();

            foreach(var task in tasksFromActivePage)
            {
                task.IsDone = true;
            }

            TurnPage();
        }

        private void StartTask(Task task)
        {
            if (task.IsDone)
            {
                throw new InvalidOperationException("Cannot start task, because it's done");
            }

            var activePageTasks = _paginator.GetTasksFromActivePage();

            if (!activePageTasks.Contains(task))
            {
                throw new InvalidOperationException("Cannot start task, because it's not in active page");
            }

            _pad.StartTask(task);
        }
    }
}
