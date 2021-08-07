using System;
using System.Windows;

namespace WpfSingleInstanceByEventWaitHandle
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SingleInstanceWindow : Window
    {
        internal delegate void ProcessArgDelegate(string arg);
        internal static ProcessArgDelegate ProcessArg;

        public SingleInstanceWindow()
        {
            ProcessArg = delegate(string arg)
            {
                ArgsRun.Text = arg;
            };

            Initialized += delegate(object sender, EventArgs e) {
                ArgsRun.Text = (string)Application.Current.Resources[WpfSingleInstance.StartArgKey];
                Application.Current.Resources.Remove(WpfSingleInstance.StartArgKey);
            };

            InitializeComponent();
        }
    }
}
