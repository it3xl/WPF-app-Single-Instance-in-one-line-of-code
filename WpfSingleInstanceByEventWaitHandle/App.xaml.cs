using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace WpfSingleInstanceByEventWaitHandle
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{



		protected override void OnStartup(StartupEventArgs e)
		{
			WpfSingleInstance.Make("MyWpfApplication",this);

			base.OnStartup(e);
		}

	}
}
