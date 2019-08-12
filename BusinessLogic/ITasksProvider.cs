using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    interface ITasksProvider
    {
        Task GetActiveTask();
        IEnumerable<Task> GetTasks();
        IEnumerable<Task> GetActivePageTasks();
        IEnumerable<Task> GetTasksFromPage(int pageIndex);
    }
}
