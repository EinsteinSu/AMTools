using System;

namespace TroubleShooting.Commons.TroubleShootings.Database
{
    public class ConnectionLimit : ConfigurationTroubleShootingBase<int>
    {
        public ConnectionLimit(string connection) : base(connection)
        {
        }

        protected override int ExpectValue
        {
            get { return 0; }
        }

        protected override Func<int, bool> UnExpectFunc
        {
            get
            {
                return delegate(int i)
                {
                    if (i == 0)
                        return true;
                    return false;
                };
            }
        }

        protected override string ConfigurName
        {
            get { return "user connections"; }
        }
    }
}