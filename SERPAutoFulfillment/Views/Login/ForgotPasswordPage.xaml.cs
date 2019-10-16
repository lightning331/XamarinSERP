
using System;
using SERPAutoFulfillment.ViewModels;
using Xamarin.Forms;

namespace SERPAutoFulfillment.Views
{
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        private void TapCancel(object sender, EventArgs e)
        {
            var vm = BindingContext as ForgotPasswordPageViewModel;
            vm.OnCancel();
        }

        private void TapSubmit(object sender, EventArgs e)
        {
            var vm = BindingContext as ForgotPasswordPageViewModel;
            vm.OnSubmit();
        }
    }
}
