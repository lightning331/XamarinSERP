using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using SERPAutoFulfillment.Business;
using SERPAutoFulfillment.Services;
using SERPAutoFulfillment.Views;
using Xamarin.Forms;



namespace SERPAutoFulfillment.ViewModels
{
    public class MainMyVehiclePageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private IAlertService _alertService;
        //public DelegateCommand<Vehicle> VehicleViewCommand { get; }
        //public DelegateCommand<Vehicle> VehicleSelectCommand { get; }
        public DelegateCommand<Vehicle> ContactDriverCommand { get; }

        public static Vehicle[] DemoVehicles = {
            new Vehicle("truck_demo1.png", "Truck1 2350738 2012 Ford Ford E358"),
            new Vehicle("truck_demo2.png", "Truck2 2350738 2012 Ford Ford E358"),
            new Vehicle("truck_demo3.png", "Truck3 2350738 2012 Ford Ford E358"),
            new Vehicle("truck_demo4.png", "Truck4 2350738 2012 Ford Ford E358"),
            new Vehicle("truck_demo3.png", "Truck5 2350738 2012 Ford Ford E358"),
            new Vehicle("truck_demo1.png", "Truck6 2350738 2012 Ford Ford E358"),
            new Vehicle("truck_demo2.png", "Truck7 2350738 2012 Ford Ford E358"),
            new Vehicle("truck_demo3.png", "Truck9 2350738 2012 Ford Ford E358"),
            new Vehicle("truck_demo4.png", "Truck10 2350738 2012 Ford Ford E358"),
            new Vehicle("truck_demo3.png", "Truck11 2350738 2012 Ford Ford E358"),
            new Vehicle("truck_demo1.png", "Truck12 2350738 2012 Ford Ford E358"),
        };

        public MainMyVehiclePageViewModel(INavigationService navigationService, IAlertService alertService)
        {
            _navigationService = navigationService;
            _alertService = alertService;
            //VehicleViewCommand = new DelegateCommand<Vehicle>(VehicleView);
            //VehicleSelectCommand = new DelegateCommand<Vehicle>(VehicleSelect);
            ContactDriverCommand = new DelegateCommand<Vehicle>(ContactDriver);

        }

        public override void Initialize(INavigationParameters parameters)
        {
            RefreshData();
        }

        public async void RefreshData()
        {
            VehicleList = new ObservableCollection<Vehicle>(DemoVehicles);
        }

        private ObservableCollection<Vehicle> _vehicleList;
        public ObservableCollection<Vehicle> VehicleList
        {
            get => _vehicleList;
            set
            {
                SetProperty(ref _vehicleList, value);
                RaisePropertyChanged(nameof(HasVehicles));
            }
        }

        public bool HasVehicles
        {
            get
            {
                return (VehicleList != null && VehicleList.Count > 0);
            }
        }

        public void VehicleView(Vehicle vehicle, TabbedPage parent)
        {
            _ = _navigationService.NavigateAsync("VehicleInventoryItemPage");

        }

        public async Task<bool> VehicleSelect(Vehicle vehicle, TabbedPage parent)
        {
            bool result = await _alertService.SelectVehicleAlert();
            if (result)
            {
                //go to My order page
                parent.CurrentPage = parent.Children[1];
                parent.CurrentPage.Focus();
            }
            return result;
        }

        private async void ContactDriver(Vehicle vehicle)
        {
            await _alertService.ContactDriverAlert();
        }
        

    }
}

