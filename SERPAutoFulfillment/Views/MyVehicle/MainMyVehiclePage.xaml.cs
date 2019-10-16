using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SERPAutoFulfillment.Business;
using SERPAutoFulfillment.ViewModels;

namespace SERPAutoFulfillment.Views
{
    public partial class MainMyVehiclePage : ContentPage
    {
        public MainMyVehiclePage()
        {
            InitializeComponent();

        }

        private void TapGestureVehicleSelect_Tapped(object sender, EventArgs e)
        {
            Vehicle  selected = (Vehicle)(e as TappedEventArgs).Parameter;

            var vm = BindingContext as MainMyVehiclePageViewModel;
            var parent = this.Parent.Parent as TabbedPage;
            _ = vm.VehicleSelect(selected, parent);
        }

        private void TapGestureVehicleView_Tapped(object sender, EventArgs e)
        {
            Vehicle selected = (Vehicle)(e as TappedEventArgs).Parameter;

            var vm = BindingContext as MainMyVehiclePageViewModel;
            vm.VehicleView(selected, this.Parent as TabbedPage);
        }

    }
}
