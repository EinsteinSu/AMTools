using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CaseProcesser.Common;

namespace CaseProcesser.Models
{
    [ComplexType]
    public class Hotfix : ModelBase
    {
        private const string Url =
            "http://tfsreports.prod.quest.corp:8080/Windows%20Management/ArchiveManager/_workitems#_a=edit&id=";

        private string _bugId;
        private string _etaTime;
        private string _versions;

        [Display(Name = "Bug Url")]
        public string BugUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_bugId))
                    return string.Empty;
                return Url + _bugId;
            }
        }

        [Display(Name = "Bug Number"), MaxLength(20)]
        public string BugId
        {
            get { return _bugId; }
            set
            {
                if (value == _bugId) return;
                _bugId = value;
                NotifyOfPropertyChange(() => BugId);
            }
        }

        [Display(Name = "Hotfix Version"), MaxLength(20)]
        public string Versions
        {
            get { return _versions; }
            set
            {
                if (value == _versions) return;
                _versions = value;
                NotifyOfPropertyChange(() => Versions);
            }
        }

        [Display(Name = "ETA"), MaxLength(20)]
        public string EtaTime
        {
            get { return _etaTime; }
            set
            {
                if (value == _etaTime) return;
                _etaTime = value;
                NotifyOfPropertyChange(() => EtaTime);
            }
        }

        public string ToExportString()
        {
            if (!string.IsNullOrEmpty(_bugId))
            {
                return string.Format("Id:TFS#{0}\rVersion:{1}\rETA:{2}", _bugId, _versions, _etaTime);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}