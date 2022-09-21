using System;
using System.IO;
using System.Linq;
using System.Windows;
using MySql.Data.MySqlClient;
using SWG_Email_tracker.Core.Settings;

namespace SWG_Email_tracker.Core.IO
{
    internal class Import
    {
        public static void importMail()
        {
            string id;
            string serverName;
            string purchaser;
            string purchasePrice;
            string unixTime;
            string vendorName;
            string saleItem;

            foreach (
                var mailVar in Directory.EnumerateFiles(Core.Settings.IOSettings.mailLocation)
            )
            {
                string[] lines = System.IO.File.ReadAllLines(mailVar);
                id = lines[0];

                string[] SrvcmdChk = lines[1].Split('.');

                serverName = SrvcmdChk[1];

                switch (SrvcmdChk[2])
                {
                    case "auctioner":

                        {
                            if (lines[2] == "Vendor Sale Complete")
                            {
                                purchaser = Between(lines[4].ToString(), " to ", " for ");

                                string[] vValue = lines[4].Split(' ');
                                purchasePrice = vValue[vValue.Count() - 2];
                                vendorName = Between(lines[4].ToString(), "Vendor: ", " has ");
                                saleItem = Between(lines[4].ToString(), " sold ", " to ");
                                unixTime = UnixTimeStampToDateTime(Convert.ToDouble(lines[3].Remove(0, 11))).ToString();
                                Console.WriteLine(unixTime);
                                SQLIO("sale",id, purchaser, purchasePrice, unixTime, vendorName, saleItem);
                            }
                        }
                        break;

                    case "bank":

                        {
                            if (lines[2] == "Bank Transfer Complete...")
                            {
                                if (lines[4].Contains("delivered"))
                                {
                                    purchaser = Between(lines[4].ToString(), " from ", " have ");
                                    string[] vValue = lines[4].Split(' ');
                                    purchasePrice = vValue[0];
                                    unixTime = UnixTimeStampToDateTime(Convert.ToDouble(lines[3].Remove(0, 11))).ToString();
                                    Console.WriteLine(unixTime);
                                    SQLIO("bankTip", id, purchaser, purchasePrice, unixTime, " ", " ");
                                    
                                }
                            }
                        }
                        break;
                }
            }
        }

        static void SQLIO(string qType, string id, string purchaser, string purchasePrice, string unixTime, string vendorName, string saleItem)
        {
            string Query = "";
            switch (qType)
            {
                case "sale":
                    {
                         Query = "insert into swgmt.sales(uid,purchaser,PurchasePrice,PurchaseDate,vendorName,saleItem) values('" + id + "','" + purchaser + "','" + purchasePrice + "','" + unixTime + "','" + vendorName + "','" + saleItem + "');";
                    }
                    break;

                case "bankTip":
                    {
                        Query = "insert into swgmt.banktips(uid,tipSender,tipAmount,tipdate) values('" + id + "','" + purchaser + "','" + purchasePrice + "','" + unixTime + "');";
                    }
                    break;
            }

            try
            {
                MySqlConnection Conn = new MySqlConnection(Core.Settings.IOSettings.ConString);
                MySqlCommand cmd = new MySqlCommand(Query, Conn);
                MySqlDataReader Reader;
                Conn.Open();
                Reader = cmd.ExecuteReader();

                while (Reader.Read()) { }
                Conn.Close();
            }
            catch (Exception ex) {  }
        }

        static string Between(string STR, string FirstString, string LastString)
        {
            string FinalString;
            int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
            int Pos2 = STR.IndexOf(LastString);
            FinalString = STR.Substring(Pos1, Pos2 - Pos1);
            return FinalString;
        }
        static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
