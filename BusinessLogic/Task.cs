using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class Task
    {
        public int Id { get; set; }

        public string Caption { get; set; }

        public string Addition { get; set; }

        public string Link { get; set; }

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

            return taskCopy;
        }
    }
}
