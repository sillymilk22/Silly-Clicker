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
using System.IO;

namespace Silly_clicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Main
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new clicker();
        }


 
        private void upgradeclick(object sender, RoutedEventArgs e)
        {
        }

        private void storebtnclick(object sender, RoutedEventArgs e)
        {

            Main.Content = new Shop();


        }

        private void clickerbtnclick(object sender, RoutedEventArgs e)
        {
            Main.Content = new clicker();
        }

        private void settingsbtnclick(object sender, RoutedEventArgs e)
        {
            Main.Content = new settings();
        }
    }
}
