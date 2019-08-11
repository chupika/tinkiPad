using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class PadManager
    {
        private readonly Pad _pad;
        private readonly Paginator _paginator;

        public PadManager(Pad pad)
        {
            _pad = pad;
            _paginator = new Paginator(pad);
        }

        public void CompleteEntry()
        {
            var activeEntry = _pad.GetActiveEntry();

            if (activeEntry == null)
            {
                // probably should throw exception instead
                return;
            }

            activeEntry.IsDone = true;
            _pad.ResetActiveTask();
        }

        public void InterruptEntry()
        {
            var activeEntry = _pad.GetActiveEntry();

            if (activeEntry == null)
            {
                // probably should throw exception instead
                return;
            }

            activeEntry.IsDone = true;
            _pad.ResetActiveTask();
            var entryContinue = activeEntry.CopyEntry();
            _pad.AddEntry(entryContinue);
        }

        public void ChooseEntry(Guid id)
        {
            var entryToChoose = _pad.Entries.Single(entry => entry.GuidId == id);
            StartEntry(entryToChoose);
        }

        public void ChooseEntryByIndex(int index)
        {
            var entryToChoose = _pad.Entries.ElementAt(index);
            StartEntry(entryToChoose);
        }

        public void TurnPage()
        {
            if (_pad.ActiveEntryIndex != -1)
            {
                throw new InvalidOperationException("Cannot activate next page, because an active entry is in progress");
            }

            if (_paginator.CountPendingPages() < 2)
            {
                throw new InvalidOperationException("Cannot activate next page, because pages amount is less than 2");
            }

            var nextPageIndex = _paginator.GetNextPendingPageIndex();
            _pad.ActivatePage(nextPageIndex);
        }

        public void KillPage()
        {
            if (_pad.ActiveEntryIndex != -1)
            {
                throw new InvalidOperationException("Cannot kill page because a task is in progress");
            }

            if (_paginator.CountPendingPages() <= 1)
            {
                throw new InvalidOperationException("Cannot kill single pending page");
            }

            if (_pad.TaskWasStartedThisTurn)
            {
                throw new InvalidOperationException("Cannot kill page that have been started this turn");
            }

            var tasksFromActivePage = _pad.GetActivePageEntries();

            foreach(var task in tasksFromActivePage)
            {
                task.IsDone = true;
            }

            TurnPage();
        }

        private void StartEntry(Entry entry)
        {
            if (entry.IsDone)
            {
                throw new InvalidOperationException("Cannot choose entry, because it's done");
            }

            var activePageEntries = _pad.GetActivePageEntries();

            if (!activePageEntries.Contains(entry))
            {
                throw new InvalidOperationException("Cannot choose entry, because it's not in active page");
            }

            _pad.StartEntry(entry);
        }
    }
}
