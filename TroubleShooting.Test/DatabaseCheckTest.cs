using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TroubleShooting.Commons.TroubleShootings.Database;

namespace TroubleShooting.Test
{
    [TestClass]
    public class DatabaseCheckTest
    {
        private readonly SqlConnectionStringBuilder _connection = new SqlConnectionStringBuilder
        {
            DataSource = "DSGFSHW6H72",
            InitialCatalog = "dellcases",
            IntegratedSecurity = true
        };

        [TestMethod]
        public void ConnectionLimitCheck()
        {
            Check(new ConnectionLimit(_connection.ConnectionString));
        }

        [TestMethod]
        public void DatabaseTimeoutCheck()
        {
            Check(new RemoteQueryTimeout(_connection.ConnectionString));
        }

        [TestMethod]
        public void MaxServerMemoryCheck()
        {
            Check(new MaxServerMemory(_connection.ConnectionString));
        }

        private void Check<T>(ConfigurationTroubleShootingBase<T> check) where T : struct
        {
            Assert.IsTrue(check.Check());
            Console.WriteLine(check.Result);
            Console.WriteLine(check.Suggestion);
        }
    }
}