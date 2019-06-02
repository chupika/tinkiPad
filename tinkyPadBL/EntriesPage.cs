using System;
using System.Collections.Generic;
using System.Text;

namespace tinkyPadBL
{
    public class EntriesPage
    {
        private List<Entry> _entries = new List<Entry>();

        public const int EntryCapacity = 25;

        public void AddEntry(Entry entry)
        {
            if (_entries.Count >= EntryCapacity)
            {
                throw new InvalidOperationException("Entry cannot be added because the page is full. Page capacity is " + EntryCapacity);
            }

            _entries.Add(entry);
        }

        public List<Entry> GetEntries()
        {
            return _entries;
        }
    }
}
