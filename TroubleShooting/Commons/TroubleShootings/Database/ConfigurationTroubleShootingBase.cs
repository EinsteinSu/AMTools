using System.Linq;

namespace TroubleShooting.Commons.TroubleShootings.Database
{
    public abstract class ConfigurationTroubleShootingBase<T> : DatabaseTroubleShootingBase<T> where T : struct
    {
        private const string Sql = "Select value_in_use from sys.configurations where name = @p0";

        public ConfigurationTroubleShootingBase(string connection) : base(connection)
        {
        }

        public override string Suggestion
        {
            get
            {
                if (!UnExpectFunc(Data))
                {
                    return string.Format("Suggestion configuraion value is :{0}", ExpectValue);
                }
                return string.Empty;
            }
        }

        public override string Result
        {
            get { return string.Format("{0}: {1}", ConfigurName, Data); }
        }

        protected override T Query()
        {
            return Context.Database.SqlQuery<T>(Sql, ConfigurName).ToList()[0];
        }
    }
}