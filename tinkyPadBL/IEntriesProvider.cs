using System;
using System.Collections.Generic;
using System.Text;

namespace tinkyPadBL
{
    interface IEntriesProvider
    {
        List<Entry> GetActivePageEntries();
    }
}
