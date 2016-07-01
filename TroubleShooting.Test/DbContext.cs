using System;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TroubleShooting.Commons.DataAccess;
using TroubleShooting.Commons.TroubleShootings;
using TroubleShooting.Commons.TroubleShootings.Database;

namespace TroubleShooting.Test
{
    [TestClass]
    public class DbContextTest
    {
        private readonly SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder
        {
            DataSource = "DSGFSHW6H72",
            InitialCatalog = "dellcases",
            IntegratedSecurity = true
        };

        [TestMethod]
        public void TestConnection()
        {
            AMDataContext context = new AMDataContext(connection.ConnectionString);
            var item = context.Database.SqlQuery<string>("select @@version").ToList();
            Console.WriteLine(item[0]);
        }

        [TestMethod]
        public void VersionCheck()
        {
            var check = new VersionCheck(connection.ConnectionString);
            Assert.IsTrue(check.Check());
            Assert.IsTrue(check.Result.Contains("2014"));
        }
    }
}
