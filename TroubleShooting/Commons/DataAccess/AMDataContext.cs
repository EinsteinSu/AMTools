using System.Data.Entity;

namespace TroubleShooting.Commons.DataAccess
{
    public class AMDataContext : DbContext
    {
        public AMDataContext(string connection) : base(connection)
        {
        }
    }
}