using System.Windows;

namespace WpfSingleInstanceByEventWaitHandle
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SingleInstanceWindow : Window
    {
        public SingleInstanceWindow()
        {
            WpfSingleInstance.Make("MyWpfApplication");

            InitializeComponent();

            MyLocationFullPath.Text = System.Reflection.Assembly.GetEntryAssembly().Location;
        }
    }
}
