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
using SWG_Email_tracker.Core.IO;
using SWG_Email_tracker.Core;

using System.IO;

namespace SWG_Email_tracker.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            updateGUIset();


        }
        private void updateGUIset()
        {
            vIP.Text = Core.Settings.IOSettings.ip;
            vPort.Text = Core.Settings.IOSettings.port;
            vUsername.Text = Core.Settings.IOSettings.username;
            vPassword.Text = Core.Settings.IOSettings.password;
            vDIR.Content = Core.Settings.IOSettings.mailLocation;
            Core.Settings.IOSettings.ConString = "datasource=" + Core.Settings.IOSettings.ip + ";port=" + Core.Settings.IOSettings.port + ";username=" + Core.Settings.IOSettings.username + ";password=" + Core.Settings.IOSettings.password;
    }

        private void saveDBBtn(object sender, RoutedEventArgs e)
        {
            Core.Settings.IOSettings.ip = vIP.Text;
            Core.Settings.IOSettings.port = vPort.Text;
            Core.Settings.IOSettings.username = vUsername.Text;
            Core.Settings.IOSettings.password = vPassword.Text;
            saveToPBF(Core.Settings.IOSettings.ip, Core.Settings.IOSettings.port, Core.Settings.IOSettings.username, Core.Settings.IOSettings.password, Core.Settings.IOSettings.mailLocation);
            updateGUIset();

        }

        private void saveMailDirBtn(object sender, RoutedEventArgs e)
        {
            using (var DIR = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = DIR.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(DIR.SelectedPath))
                {
                    Core.Settings.IOSettings.mailLocation = (DIR.SelectedPath);

                }
            }
        }
        private void saveToPBF(string ip, string port, string username, string password, string dir)
        {
            System.IO.File.WriteAllText(@"set.PBF", ip +","+ port + "," + username + "," + password + "," + dir);
        }

        void importButton(object sender, RoutedEventArgs e)
        {
            string ip = vIP.Text;
            string port = vPort.Text;
            string username = vUsername.Text;
            string password = vPassword.Text;
            string mailChk = Core.Settings.IOSettings.mailLocation;

            if ((ip ?? port ?? username ?? password) == "")
            {
                if (mailChk == "")
                {
                    MessageBox.Show("Please make sure all field are filled");
                }
            }
            else
            {
                Core.Settings.IOSettings.ip = vIP.Text;
                Core.Settings.IOSettings.port = vPort.Text;
                Core.Settings.IOSettings.username = vUsername.Text;
                Core.Settings.IOSettings.password = vPassword.Text;
                Import.importMail();
            }
        }
    }
}
