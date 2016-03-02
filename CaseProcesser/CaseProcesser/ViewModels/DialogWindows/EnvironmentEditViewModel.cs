using CaseProcesser.Models;
using Supeng.Wpf.Common.DialogWindows.ViewModels;

namespace CaseProcesser.ViewModels.DialogWindows
{
    public class EnvironmentEditViewModel : EntityEditViewModelBase<Environment>
    {
        public EnvironmentEditViewModel(Environment environment)
        {
            Data = environment;
        }

        protected override string TemplateName
        {
            get { return "EnvironmentWindow"; }
        }
    }
}