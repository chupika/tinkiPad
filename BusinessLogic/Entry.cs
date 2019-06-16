using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Entry
    {
        public string Caption { get; set; }

        public string Addition { get; set; }

        public string Link { get; set; }

        public HashSet<string> Tags { get; set; }

        public bool IsDone { get; set; }
    }
}
