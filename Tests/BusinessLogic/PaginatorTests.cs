using BusinessLogic;
using System;
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
                var expectedPageIndex = taskIndex / paginator.TasksCapacity;
                Assert.Equal(pageIndex, expectedPageIndex);
            }
        }

        [Fact]
        public void GetNextPendingPageIndex_WhenNoOtherPagesWithActiveTasks_ThrowsException()
        {
            var pad = PadFiller.GetFullPad();
            var paginator = new Paginator(pad);
            var tasks = pad.GetTasks();

            for (var taskIndex = paginator.TasksCapacity; taskIndex < tasks.Count(); taskIndex++)
            {
                tasks.ElementAt(taskIndex).IsDone = true;
            }

            pad.ActivePageIndex = 0;

            Assert.Throws<InvalidOperationException>(() => paginator.GetNextPendingPageIndex());
        }

        [Theory]
        [InlineData(0, 1, 25, 25)]
        [InlineData(0, 1, 30, 25)]
        [InlineData(0, 3, 75, 25)]
        [InlineData(0, 3, 99, 25)]
        [InlineData(0, 3, 30, 10)]
        [InlineData(1, 0, 5, 25)]
        [InlineData(1, 2, 55, 25)]
        public void GetNextPendingPageIndex_WhenOneTaskLeftUndoneNotInActivePage_ReturnsThatTaskIndex
            (int activePageIndex, int undoneTaskPageIndex, int undoneTaskIndex, int tasksCapacity)
        {
            var pad = PadFiller.GetFullPad();
            var tasks = pad.GetTasks();

            for (var taskIndex = 0; taskIndex < tasks.Count(); taskIndex++)
            {
                tasks.ElementAt(taskIndex).IsDone = undoneTaskIndex != taskIndex;
            }

            pad.ActivePageIndex = activePageIndex;

            var paginator = new Paginator(pad) { TasksCapacity = tasksCapacity };
            var nextPendingPage = paginator.GetNextPendingPageIndex();

            Assert.Equal(undoneTaskPageIndex, nextPendingPage);
        }

        [Theory]
        [InlineData(1, 0, 25, 25)]
        [InlineData(1, 25, 26, 25)]
        [InlineData(2, 10, 30, 25)]
        [InlineData(3, 10, 40, 10)]
        [InlineData(0, 0, 0, 25)]
        public void CountPendingPages_WhenTasksWereUndone_ReturnsCountPagesThatHaveTheseTasks
            (int pendingPagesCount, int undoneTaskIndexFrom, int undoneTaskIndexTo, int tasksCapacity)
        {
            var pad = PadFiller.GetFullPad();
            var tasks = pad.GetTasks();

            for (var taskIndex = 0; taskIndex < tasks.Count(); taskIndex++)
            {
                var isTaskInsideRange = undoneTaskIndexFrom <= taskIndex && taskIndex < undoneTaskIndexTo;
                tasks.ElementAt(taskIndex).IsDone = !isTaskInsideRange;
            }

            var paginator = new Paginator(pad) { TasksCapacity = tasksCapacity };
            var actualPendingPagesCount = paginator.CountPendingPages();

            Assert.Equal(actualPendingPagesCount, pendingPagesCount);
        }
    }
}
