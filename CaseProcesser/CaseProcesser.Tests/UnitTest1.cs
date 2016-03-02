using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using CaseProcesser.Common;
using CaseProcesser.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaseProcesser.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var db = new CaseContext();
            db.Cases.Add(new Case());
            db.SaveChanges();
            var data = db.Cases;
            Assert.IsTrue(data.Any());
        }
    }
}
