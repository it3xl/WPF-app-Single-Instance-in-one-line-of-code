using System.Windows;

namespace WpfSingleInstanceByEventWaitHandle
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            WpfSingleInstance.Make("MyWpfApplication");

            base.OnStartup(e);
        }
    }
}
