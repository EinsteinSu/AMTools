using System.Windows;
using Caliburn.Micro;
using CaseProcesser.ViewModels;

namespace CaseProcesser
{
    public class CaseProcesserBootstrapper : BootstrapperBase
    {
        public CaseProcesserBootstrapper()
        {
            Start();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainWindowViewModel>();
        }
    }
}