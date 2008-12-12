using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSingleInstanceByEventWaitHandle
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{

		internal delegate void ProcessArgDelegate(String arg);
		internal static ProcessArgDelegate ProcessArg;


		public Window1()
		{
			ProcessArg = delegate(String arg)
			{
				ArgsRun.Text = arg;
			};

			this.Initialized += delegate(object sender, EventArgs e) {
				ArgsRun.Text = (String)Application.Current.Resources[WpfSingleInstance.StartArgKey];
				Application.Current.Resources.Remove(WpfSingleInstance.StartArgKey);
			};


			InitializeComponent();

		}

	}
}
