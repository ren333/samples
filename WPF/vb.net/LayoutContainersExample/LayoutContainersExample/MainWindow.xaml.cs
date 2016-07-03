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

namespace LayoutContainersExample
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

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Window1 win1 = new Window1();
			win1.Show();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			DoubleSplitWindow win = new DoubleSplitWindow();
			win.Show();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			CanvasWindow win = new CanvasWindow();
			win.Show();
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			InkCanvasWindow win = new InkCanvasWindow();
			win.Show();
		}
	}
}
