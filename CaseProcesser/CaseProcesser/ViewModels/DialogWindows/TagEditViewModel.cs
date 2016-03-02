using CaseProcesser.Models;
using Supeng.Wpf.Common.DialogWindows.ViewModels;

namespace CaseProcesser.ViewModels.DialogWindows
{
    public class TagEditViewModel : EntityEditViewModelBase<Tag>
    {
        public TagEditViewModel(Tag tag)
        {
            Data = tag;
        }

        protected override string TemplateName
        {
            get { return "TagWindow"; }
        }
    }
}