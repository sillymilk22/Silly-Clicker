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
    /// Interaction logic for settings.xaml
    /// </summary>
    public partial class settings : Page
    {
        public static string savepath = @"files/save.txt";
        public settings()
        {
            InitializeComponent();

        }

        private void resetbtnclick(object sender, RoutedEventArgs e)
        {
            List<string> savedata = new List<string>();
            savedata.Add("sillys:" + 0);
            savedata.Add("level:" + 1);
            File.WriteAllLines(savepath, savedata);
        }
    }
}
