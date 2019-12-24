using Xunit;
using BusinessLogic;
using System.Linq;

namespace Tests.BusinessLogic
{
    public class PadManagerTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void CompleteTask_ThenActiveTaskIndexIsReseted(int taskIndex)
        {
            var pad = PadFiller.GetFullPad();
            var padManager = new PadManager(pad);
            padManager.StartTaskByIndex(taskIndex);
            padManager.CompleteTask();
            Assert.Equal(-1, pad.ActiveTaskIndex);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void CompleteTask_ThenTaskThatWasActiveIsDone(int taskIndex)
        {
            var pad = PadFiller.GetFullPad();
            var padManager = new PadManager(pad);

            padManager.StartTaskByIndex(taskIndex);
            var task = pad.GetActiveTask();
            padManager.CompleteTask();

            Assert.True(task.IsDone);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void StartTaskByIndex_ThenActiveTaskHasThatIndex(int taskIndex)
        {
            var pad = PadFiller.GetFullPad();
            var padManager = new PadManager(pad);
            padManager.StartTaskByIndex(taskIndex);

            Assert.Equal(taskIndex, pad.ActiveTaskIndex);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void InterruptTask_ThenActiveTaskIndexIsReseted(int taskIndex)
        {
            var pad = PadFiller.GetFullPad();
            var padManager = new PadManager(pad);
            padManager.StartTaskByIndex(taskIndex);
            padManager.InterruptTask();
            Assert.Equal(-1, pad.ActiveTaskIndex);
        }

        [Fact]
        public void InterruptTask_WhenTaskWasStarted_ThenTaskWasAdded()
        {
            var pad = PadFiller.GetFullPad();
            var padManager = new PadManager(pad);
            const int taskIndexToStart = 0;
            padManager.StartTaskByIndex(taskIndexToStart);
            var taskCountBeforeInterrupt = pad.Tasks.Count;
            padManager.InterruptTask();
            Assert.Equal(taskCountBeforeInterrupt + 1, pad.Tasks.Count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void InterruptTask_WhenTaskWasStarted_ThenTaskWasCopied(int taskIndex)
        {
            var pad = PadFiller.GetFullPad();
            var padManager = new PadManager(pad);
            padManager.StartTaskByIndex(taskIndex);
            padManager.InterruptTask();

            var taskThatWasInterrupted = pad.Tasks.ElementAt(taskIndex);
            var lastTask = pad.Tasks.Last();

            Assert.Equal(taskThatWasInterrupted.Caption, lastTask.Caption);
            Assert.Equal(taskThatWasInterrupted.Addition, lastTask.Addition);
            Assert.Equal(taskThatWasInterrupted.Link, lastTask.Link);
        }
    }
}
