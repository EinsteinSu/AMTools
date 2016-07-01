using System;

namespace TroubleShooting.Commons.TroubleShootings.Database
{
    public class MaxServerMemory : ConfigurationTroubleShootingBase<int>
    {
        public MaxServerMemory(string connection) : base(connection)
        {
        }

        protected override int ExpectValue
        {
            get { return 15884; }
        }

        protected override Func<int, bool> UnExpectFunc
        {
            get { return delegate(int value) { return value >= ExpectValue; }; }
        }

        protected override string ConfigurName
        {
            get { return "max server memory (MB)"; }
        }
    }
}