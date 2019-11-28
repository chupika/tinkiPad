using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Paginator
    {
        private readonly Pad _pad;

        public Paginator(Pad pad)
        {
            _pad = pad;
        }

        public IEnumerable<Task> GetTasksFromPage(int pageIndex)
        {
            var offset = pageIndex * Pad.TasksCapacity;
            return _pad.Tasks.ToList().GetRange(offset, Pad.TasksCapacity);
        }

        public int GetNextPendingPageIndex()
        {
            var nextPageIndex = _pad.ActivePageIndex + 1 % CountPages();

            while (nextPageIndex != _pad.ActivePageIndex)
	        {
                var tasksFromNextPage = GetTasksFromPage(nextPageIndex);
                if (tasksFromNextPage.Any(task => !task.IsDone))
                {
                    return nextPageIndex;
                }
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
            var countPages = (double)_pad.Tasks.Count() / Pad.TasksCapacity;
            return (int)Math.Ceiling(countPages);
        }
    }
}
