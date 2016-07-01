using System;
using System.Linq;
using TroubleShooting.Commons.DataAccess;
using TroubleShooting.Commons.Interfaces;

namespace TroubleShooting.Commons.TroubleShootings.Database
{
    public class VersionCheck : ITroubleShooting, IDisposable
    {
        private readonly AMDataContext _context;

        public VersionCheck(string connection)
        {
            _context = new AMDataContext(connection);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public string Suggestion
        {
            get
            {
                if (Result != null && Result.Contains("2005"))
                {
                    return "We were not support SQL Server 2005 anymore.";
                }
                return string.Empty;
            }
        }


        public string Result { get; private set; }

        public bool Check()
        {
            try
            {
                Result = _context.Database.SqlQuery<string>("select @@version").ToList()[0];
                return true;
            }
            catch (Exception ex)
            {
                Result = "Exception happened, Error:" + ex.Message;
                return false;
            }
        }
    }
}