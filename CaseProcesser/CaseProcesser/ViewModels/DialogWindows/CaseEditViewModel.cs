using System.Windows;
using CaseProcesser.Models;
using Supeng.Wpf.Common.DialogWindows.ViewModels;

namespace CaseProcesser.ViewModels.DialogWindows
{
    public class CaseEditViewModel : EntityEditViewModelBase<Case>
    {
        public CaseEditViewModel(Case c)
        {
            Data = c;
        }

        protected override string TemplateName
        {
            get { return "CaseEditWindow"; }
        }
    }
}
