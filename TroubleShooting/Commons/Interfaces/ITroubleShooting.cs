using System.Collections.Generic;

namespace TroubleShooting.Commons.Interfaces
{
    public interface ITroubleShooting
    {
        string Suggestion { get; }

        string Result { get; }

        bool Check();
    }

    public static class TroubleShootingHelper
    {
        public static string Summary(this IList<ITroubleShooting> troubleShootings)
        {
            return string.Format("Check {0} items, Passed {1} items UnPassed {2} items.");
            //int success = troubleShootings.Count(item => item.Check());
        }
    }
}