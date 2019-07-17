using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class PadTests
    {
        [TestMethod]
        public void GetActiveEntry_WhenActiveIndexWasBeenReseted_ReturnNull()
        {
            var pad = new Pad();
            pad.Entries = new List<Entry>
            {
                new Entry(),
                new Entry(),
                new Entry(),
                new Entry(),
                new Entry(),
            };

            pad.ActiveEntryIndex = 3;
            pad.ResetActiveTask();
            Assert.IsNull(pad.GetActiveEntry());
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(10)]
        public void GetActiveEntry_WhenActiveEntryIndexWasBeenSetInRangeOfEntriesCount_ReturnNotNull(int activeEntryIndex)
        {
            var pad = new Pad();
            pad.Entries = new List<Entry>
            {
                new Entry(),
                new Entry(),
                new Entry(),
                new Entry(),
                new Entry(),
            };

            pad.ActiveEntryIndex = activeEntryIndex;
            pad.ResetActiveTask();
            Assert.IsNull(pad.GetActiveEntry());
        }
    }
}
