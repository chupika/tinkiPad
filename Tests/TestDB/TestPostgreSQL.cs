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

                db.Entries.Add(entry0);
                db.Entries.Add(entry1);
                db.SaveChanges();

                var entries = db.Entries.ToList();
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
                var entries = db.Entries.ToList();
                Console.WriteLine("Entries list:");
                foreach (var entry in entries)
                {
                    Console.WriteLine($"Caption: {entry.Caption}, Addition: {entry.Addition}, Id: {entry.Id}");
                }
            }
        }
    }
}
