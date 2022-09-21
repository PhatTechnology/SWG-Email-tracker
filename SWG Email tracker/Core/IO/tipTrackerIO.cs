using MySql.Data.MySqlClient;
using SWG_Email_tracker.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static SWG_Email_tracker.MVVM.ViewModel.TipTrackerModel;

namespace SWG_Email_tracker.Core.IO
{
    internal class tipTrackerIO
    {
        public static async Task importTips()
        {

            await Task.Factory.StartNew(() =>
            {
                using var con = new MySqlConnection(Settings.IOSettings.ConString);
                con.Open();

                string sql = "SELECT * FROM swgmt.sales";
                using var cmd = new MySqlCommand(sql, con);
                using MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        
                        TipTrackerModel.TipInfo.Add(new TipDetail() { TipSender = rdr.GetString(1), TipAmount = rdr.GetString(2), TipDate = rdr.GetString(3)});
                    });
                }
                if (con != null)
                {
                    con.Close();
                    

                }
            });

        }
    }
}
