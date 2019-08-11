using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Entry
    {
        public Entry()
        {
            GuidId = Guid.NewGuid();
        }

        // remove one of id or guidid
        public int Id { get; set; }

        public Guid GuidId { get; set; }

        public string Caption { get; set; }

        public string Addition { get; set; }

        public string Link { get; set; }

        // check in setter, if we have such tag already
        public List<string> Tags { get; set; }

        public bool IsDone { get; set; }

        public Pad Pad { get; set; }

        public Entry CopyEntry()
        {
            var entryCopy = new Entry
            {
                Caption = Caption,
                Addition = Addition,
                Link = Link,
                Pad = Pad
            };

            entryCopy.Tags = new List<string>();
            foreach(var tag in Tags)
            {
                entryCopy.Tags.Add(tag);
            }

            return entryCopy;
        }
    }
}
