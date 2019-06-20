using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic
{
    public class Entry
    {
        public int Id { get; set; }
        public string Caption { get; set; }

        public string Addition { get; set; }

        public string Link { get; set; }

        // check in setter, if we have such tag already
        public List<string> Tags { get; set; }

        public bool IsDone { get; set; }
    }
}
