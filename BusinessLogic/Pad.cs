using System;
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
            Entries = new List<Entry>();
            GuidId = Guid.NewGuid();
        }

        public ICollection<Entry> Entries { get; set; }

        // remove one of id or guidid
        public int Id { get; set; }

        public Guid GuidId { get; set; }

        // check in setter, if we have not such page
        public int ActivePageIndex { get; set; }

        // check in setter, if we have not such task
        public int ActiveEntryIndex { get; set; }

        public bool TaskWasStartedThisTurn { get; set; }

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

        // move to paginator
        public IEnumerable<Entry> GetActivePageEntries()
        {
            return GetEntriesFromPage(ActivePageIndex);
        }

        // move to paginator
        public IEnumerable<Entry> GetEntriesFromPage(int pageIndex)
        {
            var offset = pageIndex * EntryCapacity;
            return Entries.ToList().GetRange(offset, EntryCapacity);
        }

        public void ResetActiveTask()
        {
            ActiveEntryIndex = -1;
        }

        public void ActivatePage(int nextPageIndex)
        {
            ActivePageIndex = nextPageIndex;
            TaskWasStartedThisTurn = false;
        }

        public void StartEntry(Entry entryToChoose)
        {
            var entryToChooseIndex = Entries.ToList().IndexOf(entryToChoose);
            ActiveEntryIndex = entryToChooseIndex;
            TaskWasStartedThisTurn = true;
        }
    }
}
