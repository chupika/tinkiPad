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

        [TestMethod]
        public void TaskWasStartedThisTurn_WhenTurnPage_ReturnsFalse()
        {
            var pad = GetFullPad();
            var padManager = new PadManager(pad);

            padManager.TurnPage();

            Assert.IsFalse(pad.TaskWasStartedThisTurn);
        }

        [TestMethod]
        public void TaskWasStartedThisTurn_WhenStartTask_ReturnsTrue()
        {
            var pad = GetFullPad();
            var padManager = new PadManager(pad);

            padManager.ChooseEntryByIndex(0);

            Assert.IsTrue(pad.TaskWasStartedThisTurn);
        }

        private Pad GetFullPad()
        {
            var pad = new Pad();
            const int totalCountEntries = 70;

            for(var entryIndex = 0; entryIndex < totalCountEntries; entryIndex++)
            {
                var entry = new Entry();
                pad.AddEntry(entry);
            }

            return pad;
        }
    }
}
