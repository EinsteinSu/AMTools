using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CaseProcesser.Common;
using Newtonsoft.Json;

namespace CaseProcesser.Models
{
    public class Activity : ModelBase
    {
        private int _activityId;
        private DateTime _activeDate;
        private string _description;

        public Activity()
        {
            ActiveDate = DateTime.Now;
        }

        [Key, ScaffoldColumn(true), Display(AutoGenerateField = false)]
        public int ActivityId
        {
            get { return _activityId; }
            set
            {
                if (value == _activityId) return;
                _activityId = value;
                NotifyOfPropertyChange(() => ActivityId);
            }
        }

        [Display(Name = "Active Date")]
        public DateTime ActiveDate
        {
            get { return _activeDate; }
            set
            {
                if (value.Equals(_activeDate)) return;
                _activeDate = value;
                NotifyOfPropertyChange(() => ActiveDate);
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

        public string ToComment()
        {
            return string.Format("{0}[{1}]", _description, _activeDate);
        }

        [JsonIgnore]
        [Display(AutoGenerateField = false)]
        public virtual Case Case { get; set; }
    }

    public static class ActivitiesExtension
    {
        public static string ToComments(this IList<Activity> activities)
        {
            if (activities != null && activities.Any())
            {
                return activities.OrderByDescending(o => o.ActiveDate)
                    .Aggregate(string.Empty, (current, source) => current + string.Format("{0}\r", source.ToComment()));
            }
            return string.Empty;
        }
    }
}