using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    interface IEntriesProvider
    {
        Entry GetActiveEntry();
        IEnumerable<Entry> GetEntries();
        IEnumerable<Entry> GetActivePageEntries();
        IEnumerable<Entry> GetEntriesFromPage(int pageIndex);
    }
}
