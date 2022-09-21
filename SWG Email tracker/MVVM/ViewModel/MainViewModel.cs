using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWG_Email_tracker.Core;

namespace SWG_Email_tracker.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {


        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand SaleTrackerViewCommand { get; set; }

        public RelayCommand TipTrackerViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }

        public SaleTrackerModel SaleTrackerVM { get; set; }

        public TipTrackerModel TipTrackerVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                onPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            SaleTrackerVM = new SaleTrackerModel();
            TipTrackerVM = new TipTrackerModel();
            CurrentView = HomeVM;



            HomeViewCommand = new RelayCommand(o => 
            {
                CurrentView = HomeVM;
            });

            SaleTrackerViewCommand = new RelayCommand(o =>
            {
                CurrentView = SaleTrackerVM;
            });

            TipTrackerViewCommand = new RelayCommand(o =>
            {
                CurrentView = TipTrackerVM;
            });
        }
    }
}
