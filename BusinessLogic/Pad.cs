using System.Collections.Generic;

namespace BusinessLogic
{
    public class Pad
    {
        public const int EntryCapacity = 25;

        public readonly List<Entry> Entries = new List<Entry>();

        public int Id { get; set; }

        // check in setter, if we have not such page
        public int ActivePageIndex { get; set; }

        // check in setter, if we have not such task
        public int ActiveTaskIndex { get; set; }

        public List<Entry> GetActivePageEntries()
        {
            var offset = ActivePageIndex * EntryCapacity;
            return Entries.GetRange(offset, EntryCapacity);
        }

        public void AddEntry(Entry entry)
        {
            Entries.Add(entry);
        }
    }
}
