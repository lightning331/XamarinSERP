using System;
using System.Collections.Generic;
using SERPAutoFulfillment.Helpers;
using SERPAutoFulfillment.ViewModels;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;

namespace SERPAutoFulfillment.Views
{
    public partial class VehicleInventoryItemPage : ContentPage
    {
        public VehicleInventoryItemPage()
        {
            InitializeComponent();
            //lvInventory.ItemSelected += (sender, e) => {
            //    ((ListView)sender).SelectedItem = null;
            //};
        }

        //The Helper
        private readonly ListViewAlternatingRowProcessor _listViewProcessor = new ListViewAlternatingRowProcessor();

        private void ViewCell_OnAppearing(object sender, EventArgs e)
        {
            _listViewProcessor.SetBackColor(sender);
        }

        private void TapGestureImage_Tapped(object sender, EventArgs e)
        {
            var vm = BindingContext as VehicleInventoryItemPageViewModel;
            var parent = this.Parent.Parent as TabbedPage;
            _ = vm.VehicleSelect(parent);
        }

    }
}
