using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class PadManager
    {
        private Pad _pad;

        public PadManager(Pad pad)
        {
            _pad = pad;
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

        public void ChooseEntry(int id)
        {
            var entryToChoose = _pad.Entries.Single(entry => entry.Id == id);
            
            if (entryToChoose.IsDone)
            {
                throw new InvalidOperationException("Cannot choose entry, because it's done");
            }

            var activePageEntries = _pad.GetActivePageEntries();

            if (activePageEntries.Contains(entryToChoose))
            {
                throw new InvalidOperationException("Cannot choose entry, because it's not in active page");
            }

            var entryToChooseIndex = _pad.Entries.ToList().IndexOf(entryToChoose);
            _pad.ActiveEntryIndex = entryToChooseIndex;
        }

        public void NextActivePage()
        {
            if (_pad.ActiveEntryIndex != -1)
            {
                throw new InvalidOperationException("Cannot activate next page, because an active entry is in progress");
            }

            // Check if page is not single. Consider completed tasks
            throw new NotImplementedException();
        }

        public void KillPage()
        {
            throw new NotImplementedException();
        }
    }
}
