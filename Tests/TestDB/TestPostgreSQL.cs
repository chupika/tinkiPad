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
            var entry0 = new Entry { Caption = "Entry0", Addition = "Addition0" };
            var entry1 = new Entry { Caption = "Entry1", Addition = "Addition1" };

            var pad = new Pad();

            using (var contextSetData = new ApplicationContext())
            {
                pad.AddEntry(entry0);
                pad.AddEntry(entry1);

                contextSetData.Pads.Add(pad);
                contextSetData.SaveChanges();
            }

            using (var contextGetData = new ApplicationContext())
            {
                var entries = contextGetData.Entries.Where(entry => entry.Pad.Id == pad.Id).ToList();
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

                var entries = db.Entries.ToList();

                Assert.IsNotNull(entries);
                Console.WriteLine("Entries count: " + entries.Count);
                Console.WriteLine("Entries list:");
                foreach (var entry in entries)
                {
                    Console.WriteLine($"Caption: {entry.Caption}, Addition: {entry.Addition}, Id: {entry.Id}");
                }
            }
        }
    }
}
