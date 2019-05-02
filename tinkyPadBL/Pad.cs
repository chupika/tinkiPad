using System;
using System.Collections.Generic;
using System.Text;

namespace tinkyPadBL
{
    public class Pad
    {
        private List<EntriesPage> EntriesPages = new List<EntriesPage>();

        public int ActivePageIndex { get; set; }

        public int ActiveTaskIndex { get; set; }
    }
}
