using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    class Paginator
    {
        private readonly Pad _pad;

        public Paginator(Pad pad)
        {
            _pad = pad;
        }

        public IEnumerable<Entry> GetEntriesFromPage(int pageIndex)
        {
            var offset = pageIndex * Pad.EntryCapacity;
            return _pad.Entries.ToList().GetRange(offset, Pad.EntryCapacity);
        }

        public int GetNextPendingPageIndex()
        {
            var nextPageIndex = _pad.ActivePageIndex + 1 % CountPages();

            while (nextPageIndex != _pad.ActivePageIndex)
	        {
                var entriesFromNextPage = GetEntriesFromPage(nextPageIndex);
                if (entriesFromNextPage.Any(entry => !entry.IsDone))
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
                var entriesFromNextPage = GetEntriesFromPage(nextPageIndex);
                if (entriesFromNextPage.Any(entry => !entry.IsDone))
                {
                    countPendingPages++;
                }

                return countPendingPages;
            }
        }

        public int CountPages()
        {
            return Math.Ceiling(_pad.Entries.Count() / Pad.EntryCapacity);
        }
    }
}
