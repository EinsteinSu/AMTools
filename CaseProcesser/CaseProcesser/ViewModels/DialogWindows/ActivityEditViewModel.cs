using CaseProcesser.Models;
using Supeng.Wpf.Common.DialogWindows.ViewModels;

namespace CaseProcesser.ViewModels.DialogWindows
{
    public class ActivityEditViewModel : EntityEditViewModelBase<Activity>
    {
        public ActivityEditViewModel(Activity activity)
        {
            Data = activity;
        }

        protected override string TemplateName
        {
            get { return "ActiveEditWindow"; }
        }
    }
}