using System;
using System.Collections.Generic;
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
using TemplatesExample;

namespace WpfTemplateExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private TemplatesExample.UserControl1 templateExample;

        public MainWindow()
        {
            InitializeComponent();

            this.templateExample = new UserControl1();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            contentControlTemplatesExample.Content = this.templateExample;
        }
    }
}
