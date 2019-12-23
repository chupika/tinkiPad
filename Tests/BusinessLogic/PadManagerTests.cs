using Xunit;
using BusinessLogic;
using System;

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
            pad.ActiveTaskIndex = taskIndex;
            padManager.CompleteTask();
            Assert.Equal(-1, pad.ActiveTaskIndex);
        }

        public void TurnPage_WhenPendingPagesAreLessThanTwo_RaiseException()
        {
            throw new NotImplementedException();
        }
    }
}
