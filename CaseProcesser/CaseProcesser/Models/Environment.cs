using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CaseProcesser.Common;

namespace CaseProcesser.Models
{
    [ComplexType]
    public class Environment:ModelBase
    {
        private string _exchangeVersion;
        private string _mApi;
        private string _osVersion;
        private string _description;
        private string _sqlServerVersion;

        [Display(Name = "Exchange Version")]
        public string ExchangeVersion
        {
            get { return _exchangeVersion; }
            set
            {
                if (value == _exchangeVersion) return;
                _exchangeVersion = value;
                NotifyOfPropertyChange(() => ExchangeVersion);
            }
        }

        [Display(Name = "MAPI Version")]
        public string MApi
        {
            get { return _mApi; }
            set
            {
                if (value == _mApi) return;
                _mApi = value;
                NotifyOfPropertyChange(() => MApi);
            }
        }

        [Display(Name = "OS Version")]
        public string OSVersion
        {
            get { return _osVersion; }
            set
            {
                if (value == _osVersion) return;
                _osVersion = value;
                NotifyOfPropertyChange(() => OSVersion);
            }
        }

        [Display(Name = "SQL Server Version")]
        public string SqlServerVersion
        {
            get { return _sqlServerVersion; }
            set
            {
                if (value == _sqlServerVersion) return;
                _sqlServerVersion = value;
                NotifyOfPropertyChange(() => SqlServerVersion);
            }
        }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) return;
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }
    }
}