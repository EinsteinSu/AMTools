using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Media;
using CaseProcesser.Common;
using Color = System.Drawing.Color;

namespace CaseProcesser.Models
{
    public class Case : ModelBase
    {
        private const string Url =
            "http://tfsreports.prod.quest.corp/reports/singlecase.aspx?id=";

        private string _amVersion;
        private ObservableCollection<Attachment> _attachments;
        private string _backlogId;
        private string _component;
        private string _crNumber;
        private string _customer;
        private string _description;
        private Environment _environment;
        private Hotfix _hotfix;
        private InternalStatus _internalStatus;
        private CaseLevel _level;
        private Location _location;
        private string _owner;
        private CaseStatus _status;
        private string _subject;
        private Tag _tag;
        private bool _toDo;

        public Case()
        {
            Tag = new Tag();
            Environment = new Environment();
            Activities = new ObservableCollection<Activity>();
            _attachments = new ObservableCollection<Attachment>();
            _hotfix = new Hotfix();
        }

        [Key, ScaffoldColumn(true)]
        [Display(AutoGenerateField = false)]
        public int CaseId { get; set; }

        [Display(AutoGenerateField = false)]
        public Tag Tag
        {
            get { return _tag; }
            set
            {
                if (value == _tag) return;
                _tag = value;
                NotifyOfPropertyChange(() => Tag);
            }
        }

        [NotMapped, Display(AutoGenerateField = false)]
        public SolidColorBrush BackColor
        {
            get { return _tag.Color.GetColor(); }
        }

        [Display(Name = "CR Number"), MaxLength(7)]
        public string CRNumber
        {
            get { return _crNumber; }
            set
            {
                if (value == _crNumber) return;
                _crNumber = value;
                NotifyOfPropertyChange(() => CRNumber);
            }
        }

        [Display(Name = "AM Version")]
        public string AMVersion
        {
            get { return _amVersion; }
            set
            {
                if (value == _amVersion) return;
                _amVersion = value;
                NotifyOfPropertyChange(() => AMVersion);
            }
        }

        [Display(Name = "Internal Status")]
        public InternalStatus InternalStatus
        {
            get { return _internalStatus; }
            set
            {
                if (value == _internalStatus) return;
                _internalStatus = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => InternalBackColor);
            }
        }

        [NotMapped, Display(AutoGenerateField = false)]
        public SolidColorBrush InternalBackColor
        {
            get
            {
                var color = InternalStatus.ToColor();
                return new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
            }
        }

        [MaxLength(100)]
        public string Customer
        {
            get { return _customer; }
            set
            {
                if (value == _customer) return;
                _customer = value;
                NotifyOfPropertyChange(() => Customer);
            }
        }

        [MaxLength(200)]
        public string Subject
        {
            get { return _subject; }
            set
            {
                if (value == _subject) return;
                _subject = value;
                NotifyOfPropertyChange(() => Subject);
            }
        }

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

        [Display(AutoGenerateField = false)]
        public Environment Environment
        {
            get { return _environment; }
            set
            {
                if (Equals(value, _environment)) return;
                _environment = value;
                NotifyOfPropertyChange(() => Environment);
            }
        }

        [MaxLength(20)]
        public string Component
        {
            get { return _component; }
            set
            {
                if (value == _component) return;
                _component = value;
                NotifyOfPropertyChange(() => Component);
            }
        }

        public CaseStatus Status
        {
            get { return _status; }
            set
            {
                if (value == _status) return;
                _status = value;
                NotifyOfPropertyChange(() => Status);
            }
        }

        public CaseLevel Level
        {
            get { return _level; }
            set
            {
                if (value == _level) return;
                _level = value;
                NotifyOfPropertyChange(() => Level);
            }
        }

        [MaxLength(20)]
        public string Owner
        {
            get { return _owner; }
            set
            {
                if (value == _owner) return;
                _owner = value;
                NotifyOfPropertyChange(() => Owner);
            }
        }

        [MaxLength(7)]
        public string BacklogId
        {
            get { return _backlogId; }
            set
            {
                if (value == _backlogId) return;
                _backlogId = value;
                NotifyOfPropertyChange(() => BacklogId);
            }
        }

        public Location Location
        {
            get { return _location; }
            set
            {
                if (value == _location) return;
                _location = value;
                NotifyOfPropertyChange(() => Location);
            }
        }

        [Display(AutoGenerateField = false)]
        public Hotfix Hotfix
        {
            get { return _hotfix; }
            set
            {
                if (Equals(value, _hotfix)) return;
                _hotfix = value;
                NotifyOfPropertyChange(() => Hotfix);
            }
        }

        [NotMapped, Display(AutoGenerateField = false)]
        public ObservableCollection<Attachment> Attachments
        {
            get { return _attachments; }
            set
            {
                if (Equals(value, _attachments)) return;
                _attachments = value;
                NotifyOfPropertyChange(() => Attachments);
            }
        }

        [Display(AutoGenerateField = false)]
        public ObservableCollection<Activity> Activities { get; set; }

        [Display(AutoGenerateField = false)]
        public string CurrentActivity
        {
            get
            {
                if (Activities.Any())
                {
                    return Activities.OrderByDescending(o => o.ActiveDate).First().ToComment();
                }
                return string.Empty;
            }
        }

        [Display(AutoGenerateField = false)]
        public string CaseUrl
        {
            get { return Url + CRNumber; }
        }
    }

    public enum Location
    {
        ACPC,
        EMEA,
        AMER
    }

    public enum InternalStatus
    {
        ToDo,
        Wating,
        Investigating,
        Reproducing,
        Debugging,
        Done
    }

    public static class InternalStatusExtensions
    {
        public static Color ToColor(this InternalStatus status)
        {
            switch (status)
            {
                case InternalStatus.ToDo:
                    return Color.OrangeRed;
                case InternalStatus.Wating:
                    return Color.Aqua;
                case InternalStatus.Investigating:
                case InternalStatus.Debugging:
                case InternalStatus.Reproducing:
                    return Color.Gold;
                case InternalStatus.Done:
                    return Color.Chartreuse;
                default:
                    return Color.Transparent;
            }
        }
    }

    public enum CaseStatus
    {
        FromSupport,
        WatiForSupport,
        DefectConfirmed,
        New,
        Closed
    }

    public static class CaseStatusExtensions
    {
        public static string ToInternalString(this CaseStatus status)
        {
            switch (status)
            {
                case CaseStatus.FromSupport:
                    return "Update From Support";
                case CaseStatus.DefectConfirmed:
                    return "Defect Confirmed";
                case CaseStatus.WatiForSupport:
                    return "Wait for Support";
                default:
                    return "New";
            }
        }

        public static Color ToColor(this CaseStatus status)
        {
            switch (status)
            {
                case CaseStatus.FromSupport:
                    return Color.DarkOrange;
                case CaseStatus.DefectConfirmed:
                    return Color.LimeGreen;
                case CaseStatus.WatiForSupport:
                    return Color.SteelBlue;
                default:
                    return Color.OrangeRed;
            }
        }
    }

    public enum CaseLevel
    {
        Level4,
        Level3,
        Level2,
        Level1
    }

    public static class CaseLevelExtensions
    {
        public static Color ToColor(this CaseLevel level)
        {
            switch (level)
            {
                case CaseLevel.Level1:
                    return Color.Red;
                case CaseLevel.Level2:
                    return Color.Orange;
                case CaseLevel.Level3:
                    return Color.Gold;
                default:
                    return Color.ForestGreen;
            }
        }
    }
}