﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class EntriesProvider : IEntriesProvider
    {
        public List<Entry> GetActivePageEntries()
        {
            throw new NotImplementedException();
        }

        public Entry GetCurrentEntry()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entry> GetEntries()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entry> GetEntriesFromPage(int pageIndex)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Entry> IEntriesProvider.GetActivePageEntries()
        {
            throw new NotImplementedException();
        }
    }
}
