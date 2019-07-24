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

        public IEnumerable<Entry> GetNextPendingPageEntries()
        {
            throw new NotImplementedException();
        }

        public int CountPendingPage()
        {
            throw new NotImplementedException();
        }
    }
}
