using System.Collections.Generic;

namespace BusinessLogic
{
    public class Pad
    {
        private List<EntriesPage> EntriesPages = new List<EntriesPage>();

        public int ActivePageIndex { get; set; }

        public int ActiveTaskIndex { get; set; }

        public List<Entry> GetActivePageEntries()
        {
            return EntriesPages[ActivePageIndex].GetEntries();
        }
    }
}
