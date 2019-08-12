using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Task
    {
        public Task()
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

        public Task CopyTask()
        {
            var taskCopy = new Task
            {
                Caption = Caption,
                Addition = Addition,
                Link = Link,
                Pad = Pad
            };

            taskCopy.Tags = new List<string>();
            foreach(var tag in Tags)
            {
                taskCopy.Tags.Add(tag);
            }

            return taskCopy;
        }
    }
}
