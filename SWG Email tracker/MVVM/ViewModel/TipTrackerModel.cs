using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWG_Email_tracker.MVVM.ViewModel
{
    internal class TipTrackerModel
    {
        public static ObservableCollection<TipDetail> TipInfo = new ObservableCollection<TipDetail>();

        public class TipDetail : INotifyPropertyChanged
        {
            private string mTipSender;
            private string mTipAmount;
            private string mTipDate;


            public string TipSender
            {
                get { return mTipSender; }
                set
                {
                    mTipSender = value;
                    OnPropertyChanged("TipSender");
                }
            }

            public string TipAmount
            {
                get { return mTipAmount; }
                set
                {
                    mTipAmount = value;
                    OnPropertyChanged("TipAmount");
                }
            }


            public string TipDate
            {
                get { return mTipDate; }
                set
                {
                    mTipDate = value;
                    OnPropertyChanged("TipDate");
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
