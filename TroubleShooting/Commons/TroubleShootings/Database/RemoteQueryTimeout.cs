using System;

namespace TroubleShooting.Commons.TroubleShootings.Database
{
    public class RemoteQueryTimeout : ConfigurationTroubleShootingBase<int>
    {
        public RemoteQueryTimeout(string connection) : base(connection)
        {
        }

        protected override int ExpectValue
        {
            get { return 3600; }
        }

        protected override Func<int, bool> UnExpectFunc
        {
            get { return delegate(int value) { return value >= ExpectValue; }; }
        }

        protected override string ConfigurName
        {
            get { return "remote query timeout (s)"; }
        }
    }
}