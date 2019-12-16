using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class Paginator
    {
        private readonly Pad _pad;

        public Paginator(Pad pad)
        {
            _pad = pad;
            TasksCapacity = 25;
        }

        public int TasksCapacity { get; set; }

        public IEnumerable<Task> GetTasksFromPage(int pageIndex)
        {
            var offset = pageIndex * TasksCapacity;
            return _pad.Tasks.ToList().GetRange(offset, TasksCapacity);
        }

        public IEnumerable<Task> GetTasksFromActivePage()
        {
            if (_pad.ActivePageIndex == -1)
            {
                return new List<Task>();
            }

            var tasksFromActivePage = GetTasksFromPage(_pad.ActivePageIndex);
            return tasksFromActivePage;
        }

        public int GetNextPendingPageIndex()
        {
            var countPages = CountPages();
            var nextPageIndex = _pad.ActivePageIndex + 1 % countPages;

            while (nextPageIndex != _pad.ActivePageIndex)
	        {
                var tasksFromNextPage = GetTasksFromPage(nextPageIndex);
                if (tasksFromNextPage.Any(task => !task.IsDone))
                {
                    return nextPageIndex;
                }

                nextPageIndex = (nextPageIndex + 1) % countPages;
            }

            // create custom exceptions
            throw new InvalidOperationException("No other pages with pending tasks");
        }

        public int CountPendingPages()
        {
            var countPendingPages = 0;

            for (var pageIndex = 0; pageIndex < CountPages() - 1; pageIndex++)
            {
                var tasksFromNextPage = GetTasksFromPage(pageIndex);
                if (tasksFromNextPage.Any(task => !task.IsDone))
                {
                    countPendingPages++;
                }
            }

            return countPendingPages;
        }

        public int CountPages()
        {
            var countPages = (double)_pad.Tasks.Count() / TasksCapacity;
            return (int)Math.Ceiling(countPages);
        }
    }
}
