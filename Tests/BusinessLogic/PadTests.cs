using BusinessLogic;
using Xunit;
using System.Collections.Generic;

namespace Tests.BusinessLogic
{
    public class PadTests
    {
        [Fact]
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
            Assert.Null(pad.GetActiveTask());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
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
            Assert.Null(pad.GetActiveTask());
        }

        [Fact]
        public void TaskWasStartedThisTurn_WhenTurnPage_ReturnsFalse()
        {
            var pad = PadFiller.GetFullPad();
            var padManager = new PadManager(pad);

            padManager.TurnPage();

            Assert.False(pad.TaskWasStartedThisTurn);
        }

        [Fact]
        public void TaskWasStartedThisTurn_WhenStartTask_ReturnsTrue()
        {
            var pad = PadFiller.GetFullPad();

            pad.StartTaskByIndex(0);

            Assert.True(pad.TaskWasStartedThisTurn);
        }

        [Fact]
        public void WhenStartTask_ThenActiveTaskIndexReturnsIndexThisTask()
        {
            var pad = PadFiller.GetFullPad();
            var taskIndex = 5;

            pad.StartTaskByIndex(taskIndex);

            Assert.Equal(pad.ActiveTaskIndex, taskIndex);
        }
    }
}
