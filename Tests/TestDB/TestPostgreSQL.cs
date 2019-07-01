using BusinessLogic;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Tests.TestDB
{
    [TestClass]
    public class TestPostgreSQL
    {
        [TestMethod]
        public void CreateAndSaveEntries()
        {
            using (var contextSetData = new ApplicationContext())
            {
                var entry0 = new Entry { Caption = "Entry0", Addition = "Addition0" };
                var entry1 = new Entry { Caption = "Entry1", Addition = "Addition1" };

                var pad = new Pad();

                pad.AddEntry(entry0);
                pad.AddEntry(entry1);

                contextSetData.Pads.Add(pad);
                contextSetData.SaveChanges();
            }

            using (var contextGetData = new ApplicationContext())
            {
                var pads = contextGetData.Pads.ToList();
                var entries = pads[0].Entries;
                Assert.IsNotNull(entries, "Entries are null");
                Assert.IsTrue(entries.Count >= 2, "Entries count " + entries.Count);

                Console.WriteLine("Entries list:");
                foreach (var entry in entries)
                {
                    Console.WriteLine($"{entry.Caption} - {entry.Addition}");
                }
            }
        }

        [TestMethod]
        public void GetEntries()
        {
            using (var db = new ApplicationContext())
            {
                var pads = db.Pads.ToList();
                Assert.IsNotNull(pads);

                if (pads.Count == 0)
                {
                    Console.WriteLine("Empty pad");
                    return;
                }

                Assert.IsNotNull(pads[0].Entries);
                Console.WriteLine("Entries count: " + pads[0].Entries.Count);
                Console.WriteLine("Entries list:");
                foreach (var entry in pads[0].Entries)
                {
                    Console.WriteLine($"Caption: {entry.Caption}, Addition: {entry.Addition}, Id: {entry.Id}");
                }
            }
        }
    }
}
