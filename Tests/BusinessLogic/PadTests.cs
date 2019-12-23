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
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        public void GetActiveTask_WhenActiveTaskIndexWasBeenSetInRangeOfTasksCount_ReturnNotNull(int activeTaskIndex)
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

            pad.ActiveTaskIndex = activeTaskIndex;
            pad.ResetActiveTask();
            Assert.IsNull(pad.GetActiveTask());
        }

        [TestMethod]
        public void TaskWasStartedThisTurn_WhenTurnPage_ReturnsFalse()
        {
            var pad = PadFiller.GetFullPad();
            var padManager = new PadManager(pad);

            padManager.TurnPage();

            Assert.IsFalse(pad.TaskWasStartedThisTurn);
        }

        [TestMethod]
        public void TaskWasStartedThisTurn_WhenStartTask_ReturnsTrue()
        {
            var pad = PadFiller.GetFullPad();

            pad.StartTaskByIndex(0);

            Assert.IsTrue(pad.TaskWasStartedThisTurn);
        }

        [TestMethod]
        public void WhenStartTask_ThenActiveTaskIndexReturnsIndexThisTask()
        {
            var pad = PadFiller.GetFullPad();
            var taskIndex = 5;

            pad.StartTaskByIndex(taskIndex);

            Assert.AreEqual(pad.ActiveTaskIndex, taskIndex);
        }
    }
}
