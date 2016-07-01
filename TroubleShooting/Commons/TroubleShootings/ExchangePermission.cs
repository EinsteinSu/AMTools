using System;
using TroubleShooting.Commons.Interfaces;

namespace TroubleShooting.Commons.TroubleShootings
{
    public class ExchangePermission : ITroubleShooting
    {
        public string Suggestion { get; }

        public string Result { get; }

        public bool Check()
        {
            throw new NotImplementedException();
        }
    }
}