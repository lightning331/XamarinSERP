using System;
using System.Net.Mail;
using Prism.Navigation;
using SERPAutoFulfillment.Services;

namespace SERPAutoFulfillment.ViewModels
{
    public class ForgotPasswordPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private IAlertService _alertService;

        public ForgotPasswordPageViewModel(INavigationService navigationService, IAlertService alertService)
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

        private string _emailAddress;
        public string EmailAddress
        {
            get => _emailAddress;
            set => SetProperty(ref _emailAddress, value);
        }

        private string _confirmEmailAddress;
        public string ConfirmEmailAddress
        {
            get => _confirmEmailAddress;
            set => SetProperty(ref _confirmEmailAddress, value);
        }

        public async void OnCancel()
        {
            //var pw = Password;
            await _navigationService.GoBackAsync();
        }

        public async void OnSubmit()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                await _alertService.InfoAlert(2, "Error", "UserName is required!");
                return;
            }
            if (string.IsNullOrEmpty(EmailAddress))
            {
                await _alertService.InfoAlert(2, "Error", "Email address is required!");
                return;
            }
            if (string.IsNullOrEmpty(ConfirmEmailAddress))
            {
                await _alertService.InfoAlert(2, "Error", "Confirm Email address is required!");
                return;
            }
            if (!EmailAddress.Equals(ConfirmEmailAddress))
            {
                await _alertService.InfoAlert(2, "Error", "Incorrect Email address!");
                return;
            }
            if (!IsValidEmail(EmailAddress))
            {
                await _alertService.InfoAlert(2, "Error", "Invalid Email address!");
                return;
            }
            await _alertService.PasswordResetAlert();

            await _navigationService.NavigateAsync("PasswordSentPage");
        }

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }

}

