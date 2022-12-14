using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SWG_Email_tracker.Core.IO;
using SWG_Email_tracker.MVVM.ViewModel;

namespace SWG_Email_tracker.MVVM.View
{
    /// <summary>
    /// Interaction logic for SaleTrackerView.xaml
    /// </summary>
    public partial class SaleTrackerView : UserControl
    {
        
        public SaleTrackerView()
        {
            InitializeComponent();
            SaleTrackerModel.saleInfo.Clear();

            dgSaleInfo.ItemsSource = SaleTrackerModel.saleInfo;
            
        }

        private void refreshBtn(object sender, RoutedEventArgs e)
        {
            refreshSales();
        }

        private async Task refreshSales()
        {
            await saleTrackerIO.importSaleOrders();
        }

        
    }
}
