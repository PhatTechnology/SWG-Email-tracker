using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWG_Email_tracker.MVVM.ViewModel
{
    internal class SaleTrackerModel
    {

        public static ObservableCollection<SaleDetail> saleInfo = new ObservableCollection<SaleDetail>();
        public class SaleDetail : INotifyPropertyChanged
        {
            private string mPurchaser;
            private string mPrice;
            private string mDate;
            private string mVendor;
            private string mItem;

            public string Purchaser
            {
                get { return mPurchaser; }
                set
                {
                    mPurchaser = value;
                    OnPropertyChanged("ID");
                }
            }

            public string Price
            {
                get { return mPrice; }
                set
                {
                    mPrice = value;
                    OnPropertyChanged("Price");
                }
            }


            public string Date
            {
                get { return mDate; }
                set
                {
                    mDate = value;
                    OnPropertyChanged("Date");
                }
            }

            public string Vendor
            {
                get { return mVendor; }
                set
                {
                    mVendor = value;
                    OnPropertyChanged("Vendor");
                }
            }

            public string Item
            {
                get { return mItem; }
                set
                {
                    mItem = value;
                    OnPropertyChanged("Item");
                }
            }

            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
}
