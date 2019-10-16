using Prism.Mvvm;
using Prism.Navigation;
using System;
using Prism;
using Xamarin.Forms;
using System.ComponentModel;
using SERPAutoFulfillment.Services;

namespace SERPAutoFulfillment.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private IAlertService _alertService;

        public LoginPageViewModel(INavigationService navigationService, IAlertService alertService)
        {
            _navigationService = navigationService;
            _alertService = alertService;
        }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private bool _isPasswordSave;
        public bool IsPasswordSave
        {
            get => _isPasswordSave;
            set => SetProperty(ref _isPasswordSave, value);
        }

        public void ForgotPassword()
        {
            _navigationService.NavigateAsync("ForgotPasswordPage");
        }

        public void Login()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                _alertService.InfoAlert(2, "Error", "UserName is required!");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                _alertService.InfoAlert(2, "Error", "Password is required!");
                return;
            }

            //await _navigationService.ClearPopupStackAsync();

            _navigationService.NavigateAsync("/NavigationPage/MainTabPage");
            //Console.WriteLine($"MainTabPage: {r.Success}  - {r.Exception}");


        }
        private bool _isBusy = true;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                SetProperty(ref _isBusy, value);
            }
        }


    }

}

