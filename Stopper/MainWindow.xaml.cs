using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Stopper
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		DispatcherTimer dispatcherTimer = new DispatcherTimer();
		Stopwatch stopWatch = new Stopwatch();
		string currentTime = string.Empty;
		int btnSzamlalo = 1;
		public MainWindow()
		{
			InitializeComponent();
			dispatcherTimer.Tick += new EventHandler(dt_Tick);
			dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
		}
		void dt_Tick(object sender, EventArgs e)
		{
			if (stopWatch.IsRunning)
			{
				TimeSpan ts = stopWatch.Elapsed;
				currentTime = String.Format("{0:00}:{1:00}:{2:00}",
				ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
				txt_ido.Text = currentTime;
			}
		}
		private void btn_startstop_Click(object sender, RoutedEventArgs e)
		{
			stopWatch.Start();
			dispatcherTimer.Start();
			btnSzamlalo++;
			if (btnSzamlalo % 2 == 0)
			{
				btn_startstop.Content = "Stop";
				btn_reszidoreset.Content = "Részidő";
			}
			else
			{
				stopWatch.Stop();
				btn_reszidoreset.Content = "Reset";
				btn_startstop.Content = "Start";
			}
		}

		private void btn_reszidoreset_Click(object sender, RoutedEventArgs e)
		{
			if(btnSzamlalo % 2 == 0)
			{
				elapsedtimeitem.Items.Add(currentTime);
			}
			else if (btn_reszidoreset.Content == "Reset")
			{
				txt_ido.Text = "00:00:00";
				stopWatch.Reset();
				elapsedtimeitem.Items.Clear();
			}
			
		}


	}
}
