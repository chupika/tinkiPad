using BusinessLogic;
using System.Linq;
using Xunit;

namespace Tests.BusinessLogic
{
    public class PaginatorTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        public void GetTaskFromPage_WhenPadContainsIndexPage_ReturnsTasksFromThatPage(int pageIndex)
        {
            var pad = PadFiller.GetFullPad();
            var paginator = new Paginator(pad);
            var tasksFromPage = paginator.GetTasksFromPage(pageIndex).ToList();

            foreach(var task in tasksFromPage)
            {
                var taskIndex = tasksFromPage.IndexOf(task);
                var expectedPageIndex = taskIndex / Pad.TasksCapacity;
                Assert.Equal(pageIndex, expectedPageIndex);
            }
        }
    }
}
