using SWG_Email_tracker.MVVM.ViewModel;
using SWG_Email_tracker.Core.IO;
using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;

namespace SWG_Email_tracker.MVVM.View
{
    /// <summary>
    /// Interaction logic for TipTrackerView.xaml
    /// </summary>
    public partial class TipTrackerView : UserControl
    {
        public TipTrackerView()
        {
            InitializeComponent();

            TipTrackerModel.TipInfo.Clear();

            dgTipInfo.ItemsSource = TipTrackerModel.TipInfo;
        }


        private void refreshBtn(object sender, RoutedEventArgs e)
        {
            refreshSales();
        }

        private async Task refreshSales()
        {
            await tipTrackerIO.importTips();
        }
    }
}
