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

        [TestMethod]
        public void WhenStartTask_ThenActiveTaskIndexReturnsIndexThisTask()
        {
            var pad = GetFullPad();
            var taskIndex = 5;

            pad.StartTaskByIndex(taskIndex);

            Assert.AreEqual(pad.ActiveTaskIndex, taskIndex);
        }

        private Pad GetFullPad()
        {
            var pad = new Pad();
            const int totalCountTasks = 70;

            for(var taskIndex = 0; taskIndex < totalCountTasks; taskIndex++)
            {
                var task = new Task();
                pad.AddTask(task);
            }

            return pad;
        }
    }
}
