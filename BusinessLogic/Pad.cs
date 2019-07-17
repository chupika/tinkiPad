using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class Pad : IEntriesProvider
    {
        public const int EntryCapacity = 25;

        public Pad()
        {
            ActiveEntryIndex = -1;
        }

        public ICollection<Entry> Entries { get; set; }

        public int Id { get; set; }

        // check in setter, if we have not such page
        public int ActivePageIndex { get; set; }

        // check in setter, if we have not such task
        public int ActiveEntryIndex { get; set; }

        public void AddEntry(Entry entry)
        {
            if (Entries == null)
            {
                Entries = new List<Entry>();
            }

            entry.Pad = this;
            Entries.Add(entry);
        }

        public IEnumerable<Entry> GetEntries()
        {
            return Entries.ToList();
        }

        public Entry GetActiveEntry()
        {
            if (ActiveEntryIndex == -1)
            {
                return null;
            }

            return Entries.ElementAt(ActiveEntryIndex);
        }

        public IEnumerable<Entry> GetActivePageEntries()
        {
            return GetEntriesFromPage(ActivePageIndex);
        }

        public IEnumerable<Entry> GetEntriesFromPage(int pageIndex)
        {
            var offset = pageIndex * EntryCapacity;
            return Entries.ToList().GetRange(offset, EntryCapacity);
        }

        public void ResetActiveTask()
        {
            ActiveEntryIndex = -1;
        }
    }
}
