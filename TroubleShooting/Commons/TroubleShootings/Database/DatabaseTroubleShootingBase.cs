using System;
using TroubleShooting.Commons.DataAccess;
using TroubleShooting.Commons.Interfaces;

namespace TroubleShooting.Commons.TroubleShootings.Database
{
    public abstract class DatabaseTroubleShootingBase<T> : ITroubleShooting, IDisposable where T : struct
    {
        protected readonly AMDataContext Context;
        protected T Data;
        protected abstract string ConfigurName { get; }

        protected DatabaseTroubleShootingBase(string connection)
        {
            Context = new AMDataContext(connection);
        }

        protected abstract T ExpectValue { get; }
        protected abstract Func<T, bool> UnExpectFunc { get; }
        

        public virtual string Suggestion
        {
            get
            {
                if (!UnExpectFunc(Data))
                {
                    return string.Format("Suggestion value is :{0}", ExpectValue);
                }
                return string.Empty;
            }
        }

        public virtual string Result
        {
            get { return string.Format("{0}: {1}", ConfigurName, Data); }
            private set { }
        }

        public bool Check()
        {
            try
            {
                Data = Query();
                return true;
            }
            catch (Exception ex)
            {
                Result = string.Format("Exception happened, Error:{0}", ex.Message);
                return false;
            }
        }

        protected abstract T Query();

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}