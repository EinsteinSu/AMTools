using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Caliburn.Micro;

namespace CaseProcesser.Common
{
    public class ModelBase : PropertyChangedBase
    {
        [Display(AutoGenerateField = false), NotMapped]
        public new bool IsNotifying
        {
            get { return base.IsNotifying; }
            set { base.IsNotifying = value; }
        }
    }
}