using System;
using System.Collections.Generic;
using System.IO;
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

namespace SWG_Email_tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadSettings();
        }

        private void loadSettings()
        {
            if(File.Exists("set.PBF"))
            { 
            string line = System.IO.File.ReadAllText("set.PBF");
            string[] getsets = line.Split(',');
            Core.Settings.IOSettings.ip = getsets[0];
            Core.Settings.IOSettings.port = getsets[1];
            Core.Settings.IOSettings.username = getsets[2];
            Core.Settings.IOSettings.password = getsets[3];
            Core.Settings.IOSettings.mailLocation = getsets[4];
            }

        }
    }
}
