using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class Pad
    {
        public const int EntryCapacity = 25;

        public ICollection<Entry> Entries { get; set; }

        public int Id { get; set; }

        // check in setter, if we have not such page
        public int ActivePageIndex { get; set; }

        // check in setter, if we have not such task
        public int ActiveTaskIndex { get; set; }

        public List<Entry> GetActivePageEntries()
        {
            var offset = ActivePageIndex * EntryCapacity;
            return Entries.ToList<Entry>().GetRange(offset, EntryCapacity);
        }

        public void AddEntry(Entry entry)
        {
            if (Entries == null)
            {
                Entries = new List<Entry>();
            }
            entry.Pad = this;
            Entries.Add(entry);
        }
    }
}
