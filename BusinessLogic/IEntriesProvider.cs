using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    interface IEntriesProvider
    {
        List<Entry> GetActivePageEntries();
    }
}
