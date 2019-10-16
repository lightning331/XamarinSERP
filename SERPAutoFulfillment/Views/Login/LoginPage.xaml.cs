
using System;
using SERPAutoFulfillment.ViewModels;
using Xamarin.Forms;

namespace SERPAutoFulfillment.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void TapForgotPassword(object sender, EventArgs e)
        {
            var vm = BindingContext as LoginPageViewModel;
            vm.ForgotPassword();
        }

        private void TapLogin(object sender, EventArgs e)
        {
            var vm = BindingContext as LoginPageViewModel;
            vm.Login();
        }
    }
}
