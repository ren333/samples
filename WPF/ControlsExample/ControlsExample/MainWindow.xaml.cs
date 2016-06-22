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
using System.Diagnostics;

namespace ControlsExample
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void run_MouseEnter(object sender, MouseEventArgs e)
		{
			popLink.IsOpen = true;
		}

		private void lnk_Click(object sender, RoutedEventArgs e)
		{
			Hyperlink lnk = sender as Hyperlink;
			Process.Start(lnk.NavigateUri.ToString()); // System.Diagnostics
		}

		private void lstCheckboxes_SelectionChanged(object sender, RoutedEventArgs e)
		{
			if (lstCheckboxes.SelectedItem == null)
				return;

			lblCheckboxOutput.Content = string.Format("You selected: {0}{1}Checked state is: {2}", lstCheckboxes.SelectedIndex, Environment.NewLine, ((CheckBox)lstCheckboxes.SelectedItem).IsChecked);
		}

		// Styles example event handler code
		private void element_mouseEnter(object sender, MouseEventArgs e)
		{
			(sender as TextBlock).Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
		}

		private void element_mouseLeave(object sender, MouseEventArgs e)
		{
			(sender as TextBlock).Background = null;
		}

	    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
	    {
	        var blah = 99;
	    }
	}
}
