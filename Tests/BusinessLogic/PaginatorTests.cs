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
        public void GetTasksFromPage_WhenPadContainsIndexPage_ReturnsTasksFromThatPage(int pageIndex)
        {
            var pad = PadFiller.GetFullPad();
            var paginator = new Paginator(pad);
            var tasksFromPage = paginator.GetTasksFromPage(pageIndex).ToList();
            var allTasks = pad.GetTasks().ToList();
            foreach (var task in tasksFromPage)
            {
                var taskIndex = allTasks.IndexOf(task);
                var expectedPageIndex = taskIndex / Pad.TasksCapacity;
                Assert.Equal(pageIndex, expectedPageIndex);
            }
        }


    }
}
