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
    /// Interaction logic for clicker.xaml
    /// </summary>
    /// 
    public partial class clicker : Page
    {
        public static int sillys = 0;
        public static int level = 1;
        public static double critchance = 0.05;
        public static string savepath = @"files/save.txt";
        public static Random rng = new Random();

        //Load the Save File
        static void loadsave()
        {
            List<string> savedata = File.ReadAllLines(savepath).ToList();
            foreach (var line in savedata)
            {
                string[] saveline = line.Split(':');
                switch (saveline[0])
                {
                    case "sillys":
                        sillys = Convert.ToInt32(saveline[1]);
                        break;
                    case "level":
                        level = Convert.ToInt32(saveline[1]);
                        break;
                    case "critchance":
                        critchance = Convert.ToDouble(saveline[1]);
                        break;
                    default:
                        Console.WriteLine("Warning: Save line \"{0}\" seems to not match any case!", line);
                        break;
                }
            }
        }
        static void savesave()
        {
            List<string> savedata = new List<string>();
            savedata.Add("sillys:" + sillys);
            savedata.Add("level:" + level);
            savedata.Add("critchance:" + critchance);
            File.WriteAllLines(savepath, savedata);
        }

        private void refresh()
        {
            //Refresh Sillys
            sillyscore.Text = String.Empty;
            sillyscore.Inlines.Add(new Run("Sillys: ") { FontWeight = FontWeights.Bold, FontSize = 17 });
            sillyscore.Inlines.Add(new Run(Convert.ToString(sillys)) { FontSize = 17 });
            //Refresh Upgrade
            sillyupgrade.Text = String.Empty;
            sillyupgrade.Inlines.Add(new Run("Level: ") { FontWeight = FontWeights.Bold, FontSize = 17 });
            sillyupgrade.Inlines.Add(new Run(Convert.ToString(level)) { FontSize = 17 });
        }


        public clicker()
        {
            InitializeComponent();
            loadsave();
            savesave();
            refresh();
            Console.WriteLine("Clicker Loaded!");
        }

        //When Mouse is down on silly
        private void sillymousedown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Button Down");
            sillyimg.Source = null;
            sillyimg.Source = new BitmapImage(new Uri("/files/resources/sillymouthopen.png", UriKind.Relative));
        }

        //When Silly is clicked
        private void silly_Click(object sender, RoutedEventArgs e)
        {
            double crit = rng.Next(1, 100);
            crit = crit / 100;
            if (critchance > crit)
            {
                sillys = sillys + 3 * level;
                Console.WriteLine("Crit with {0}", crit);
            }
            else
            {
                sillys = sillys + 1 * level;
            }
            refresh();
            savesave();
            Console.WriteLine("Point Given");
        }

        //When Mouse is up on silly
        private void sillymouseup(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Button up");
            sillyimg.Source = null;
            sillyimg.Source = new BitmapImage(new Uri("/files/resources/sillymouthclosed.png", UriKind.Relative));
        }

    }
}
