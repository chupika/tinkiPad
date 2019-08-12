using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class PadTests
    {
        [TestMethod]
        public void GetActiveTask_WhenActiveIndexWasBeenReseted_ReturnNull()
        {
            var pad = new Pad();
            pad.Tasks = new List<Task>
            {
                new Task(),
                new Task(),
                new Task(),
                new Task(),
                new Task(),
            };

            pad.ActiveTaskIndex = 3;
            pad.ResetActiveTask();
            Assert.IsNull(pad.GetActiveTask());
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(10)]
        public void GetActiveTask_WhenActiveEntryIndexWasBeenSetInRangeOfTasksCount_ReturnNotNull(int activeEntryIndex)
        {
            var pad = new Pad();
            pad.Tasks = new List<Task>
            {
                new Task(),
                new Task(),
                new Task(),
                new Task(),
                new Task(),
            };

            pad.ActiveTaskIndex = activeEntryIndex;
            pad.ResetActiveTask();
            Assert.IsNull(pad.GetActiveTask());
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

            padManager.StartTaskByIndex(0);

            Assert.IsTrue(pad.TaskWasStartedThisTurn);
        }

        private Pad GetFullPad()
        {
            var pad = new Pad();
            const int totalCountEntries = 70;

            for(var entryIndex = 0; entryIndex < totalCountEntries; entryIndex++)
            {
                var entry = new Task();
                pad.AddEntry(entry);
            }

            return pad;
        }
    }
}
