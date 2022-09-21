using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWG_Email_tracker.MVVM.ViewModel;
using static SWG_Email_tracker.MVVM.ViewModel.SaleTrackerModel;

namespace SWG_Email_tracker.Core.IO
{
    internal class saleTrackerIO
    {

        public static async Task importSaleOrders()
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

                        SaleTrackerModel.saleInfo.Add(new SaleDetail() { Purchaser = rdr.GetString(1), Price = rdr.GetString(2), Date = rdr.GetString(3), Vendor = rdr.GetString(4), Item = rdr.GetString(5), });
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
