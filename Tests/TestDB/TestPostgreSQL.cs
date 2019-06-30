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
            using (var db = new ApplicationContext())
            {
                var entry0 = new Entry { Caption = "Entry0", Addition = "Addition0" };
                var entry1 = new Entry { Caption = "Entry1", Addition = "Addition1" };

                var pad = new Pad();

                pad.AddEntry(entry0);
                pad.AddEntry(entry1);

                db.Pads.Add(pad);
                db.SaveChanges();

                var pads = db.Pads.ToList();
                Assert.IsTrue(pads[0].Entries.Count >= 2);

                Console.WriteLine("Entries list:");
                foreach (var entry in pads[0].Entries)
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
