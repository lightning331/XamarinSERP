using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using SERPAutoFulfillment.Business;
using SERPAutoFulfillment.Services;
using Xamarin.Forms;

namespace SERPAutoFulfillment.ViewModels
{
    public class VehicleInventoryItemPageViewModel : ViewModelBase
    {
        public static Inventory[] DemoInventories = {
            new Inventory("inventory.png", "Broda 48 Pedal Chair 18", 1, 7, 3, 2, false, new InentoryDetails("001234567890", "Responsive Respiratory Inventory", "Christmas Tree Connector", "7891247", "Readt to Rent")),
            new Inventory("inventory.png", "Broda 48 Pedal Chair 18", 2, 3, 3, 2, false, new InentoryDetails("001234567890", "Responsive Respiratory Inventory", "Christmas Tree Connector", "7891247", "Readt to Rent")),
            new Inventory("inventory.png", "Broda 48 Pedal Chair 18", 3, 2, 3, 4, false, new InentoryDetails("001234567890", "Responsive Respiratory Inventory", "Christmas Tree Connector", "7891247", "Readt to Rent")),
            new Inventory("inventory.png", "Broda 48 Pedal Chair 18", 1, 3, 3, 1, false, new InentoryDetails("001234567890", "Responsive Respiratory Inventory", "Christmas Tree Connector", "7891247", "Readt to Rent")),
            new Inventory("inventory.png", "Broda 48 Pedal Chair 18", 2, 7, 3, 3, false, new InentoryDetails("001234567890", "Responsive Respiratory Inventory", "Christmas Tree Connector", "7891247", "Readt to Rent")),
            new Inventory("inventory.png", "Broda 48 Pedal Chair 18", 3, 7, 3, 2, false, new InentoryDetails("001234567890", "Responsive Respiratory Inventory", "Christmas Tree Connector", "7891247", "Readt to Rent")),
            new Inventory("inventory.png", "Broda 48 Pedal Chair 18", 4, 4, 3, 4, false, new InentoryDetails("001234567890", "Responsive Respiratory Inventory", "Christmas Tree Connector", "7891247", "Readt to Rent")),
            new Inventory("inventory.png", "Broda 48 Pedal Chair 18", 5, 5, 3, 4, false, new InentoryDetails("001234567890", "Responsive Respiratory Inventory", "Christmas Tree Connector", "7891247", "Readt to Rent")),
            new Inventory("inventory.png", "Broda 48 Pedal Chair 18", 3, 6, 3, 6, false, new InentoryDetails("001234567890", "Responsive Respiratory Inventory", "Christmas Tree Connector", "7891247", "Readt to Rent")),
            new Inventory("inventory.png", "Broda 48 Pedal Chair 18", 4, 7, 3, 3, false, new InentoryDetails("001234567890", "Responsive Respiratory Inventory", "Christmas Tree Connector", "7891247", "Readt to Rent")),
            new Inventory("inventory.png", "Broda 48 Pedal Chair 18", 2, 7, 3, 4, false, new InentoryDetails("001234567890", "Responsive Respiratory Inventory", "Christmas Tree Connector", "7891247", "Readt to Rent")),
        };

        private INavigationService _navigationService;
        private IAlertService _alertService;
        public DelegateCommand<Inventory> InventorySelectedCommand { get; }

        public VehicleInventoryItemPageViewModel(INavigationService navigationService, IAlertService alertService)
        {
            _navigationService = navigationService;
            _alertService = alertService;
            InventorySelectedCommand = new DelegateCommand<Inventory>(InventorySelected);
        }

        public override void Initialize(INavigationParameters parameters)
        {
            RefreshData();
        }

        public async void RefreshData()
        {
            InventoryList = new ObservableCollection<Inventory>(DemoInventories);
        }

        private ObservableCollection<Inventory> _inventoryList;
        public ObservableCollection<Inventory> InventoryList
        {
            get => _inventoryList;
            set
            {
                SetProperty(ref _inventoryList, value);
                RaisePropertyChanged(nameof(HasList));
            }
        }

        public bool HasList
        {
            get
            {
                return (InventoryList != null && InventoryList.Count > 0);
            }
        }

        private void InventorySelected(Inventory item)
        {
            item.isDetailVisible = !item.isDetailVisible;
            //RaisePropertyChanged(nameof(InventoryList));
            UpDateInventory(item);
        }

        private void UpDateInventory(Inventory product)
        {

            var Index = InventoryList.IndexOf(product);
            InventoryList.Remove(product);
            InventoryList.Insert(Index, product);

        }

        public async Task<bool> VehicleSelect(TabbedPage parent)
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

    }
}

