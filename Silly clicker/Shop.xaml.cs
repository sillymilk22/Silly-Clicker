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
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class Shop : Page
    {
        public static int sillys = 0;
        public static int level = 1;
        public static string savepath = @"files/save.txt";

        public static int upgradecost = 0;

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
            File.WriteAllLines(savepath, savedata);
        }

        private void refresh()
        {
            upgradecost = level * 2;

            //Refresh Sillys
            sillyscore.Text = String.Empty;
            sillyscore.Inlines.Add(new Run("Sillys: ") { FontWeight = FontWeights.Bold, FontSize = 17 });
            sillyscore.Inlines.Add(new Run(Convert.ToString(sillys)) { FontSize = 17 });
            //Refresh Upgrade
            sillyupgrade.Text = String.Empty;
            sillyupgrade.Inlines.Add(new Run("Level: ") { FontWeight = FontWeights.Bold, FontSize = 17 });
            sillyupgrade.Inlines.Add(new Run(Convert.ToString(level)) { FontSize = 17 });
            upgradebtntext.Text = Convert.ToString("Costs: " + level * 2 + " Sillys");
        }

        public Shop()
        {
            InitializeComponent();
            loadsave();
            refresh();
            
            Console.WriteLine("Store Loaded!");
            //sillyupgrade.Inlines.Add(new Run("Level: ") { FontWeight = FontWeights.Bold, FontSize = 17 });
            //sillyupgrade.Inlines.Add(new Run(Convert.ToString(level)) { FontSize = 17 });
        }

        private void upgrade(object sender, RoutedEventArgs e)
        {
            if (upgradecost < sillys)
            {
                sillys = sillys - upgradecost;
                level++;
                savesave();
                refresh();
            }
        }
    }
}
