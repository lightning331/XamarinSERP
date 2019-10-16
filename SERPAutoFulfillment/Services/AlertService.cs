using System;
using System.Threading.Tasks;
using Prism.Navigation;
using Xamarin.Forms;

namespace SERPAutoFulfillment.Services
{
    public class AlertService : IAlertService
    {
        private readonly INavigationService _navigationService;
        public AlertService(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public event EventHandler<bool> CallbackEvent;

        public async Task<bool> InfoAlert(int timeToDissapear, string alertText)
        {
            await _navigationService.ClearPopupStackAsync();
            var tcs = new TaskCompletionSource<bool>();

            CallbackEvent = async (s, e) =>
            {
                await _navigationService.ClearPopupStackAsync();
                tcs.TrySetResult(e);
            };

            var navParams = new NavigationParameters();
            navParams.Add("Callback", CallbackEvent);
            navParams.Add("AlertText", alertText);
            await _navigationService.NavigateAsync("InfoAlertPopupPage", navParams);

            return await tcs.Task;

        }

        public async Task<bool> InfoAlert(int timeToDissapear, string alertTitle, string alertText, string confirmText = null, Color? alertColor = null, TextAlignment alignment = TextAlignment.Center)
        {
            await _navigationService.ClearPopupStackAsync();
            var tcs = new TaskCompletionSource<bool>();

            CallbackEvent = async (s, e) =>
            {
                await _navigationService.ClearPopupStackAsync();
                tcs.TrySetResult(e);
            };

            var navParams = new NavigationParameters();
            navParams.Add("Callback", CallbackEvent);
            navParams.Add("AlertTitle", alertTitle);
            navParams.Add("AlertText", alertText);
            navParams.Add("ConfirmText", confirmText);
            navParams.Add("TextAlignment", alignment);
            navParams.Add("AlertColor", alertColor);
            await _navigationService.NavigateAsync("InfoAlertPopupPage", navParams);

            return await tcs.Task;
        }

        public async Task<bool> PasswordResetAlert()
        {
            await _navigationService.ClearPopupStackAsync();
            var tcs = new TaskCompletionSource<bool>();

            CallbackEvent = async (s, e) =>
            {
                await _navigationService.ClearPopupStackAsync();
                tcs.TrySetResult(e);
            };

            var navParams = new NavigationParameters();
            navParams.Add("Callback", CallbackEvent);
            await _navigationService.NavigateAsync("PasswordResetPopupPage", navParams);

            return await tcs.Task;
        }

        public async Task<bool> ContactDriverAlert()
        {
            await _navigationService.ClearPopupStackAsync();
            var tcs = new TaskCompletionSource<bool>();

            CallbackEvent = async (s, e) =>
            {
                await _navigationService.ClearPopupStackAsync();
                tcs.TrySetResult(e);
            };

            var navParams = new NavigationParameters();
            navParams.Add("Callback", CallbackEvent);
            await _navigationService.NavigateAsync("ContactDriverPopupPage", navParams);

            return await tcs.Task;
        }

        public async Task<bool> SelectVehicleAlert()
        {
            await _navigationService.ClearPopupStackAsync();
            var tcs = new TaskCompletionSource<bool>();

            CallbackEvent = async (s, e) =>
            {
                await _navigationService.ClearPopupStackAsync();
                tcs.TrySetResult(e);
            };

            var navParams = new NavigationParameters();
            navParams.Add("Callback", CallbackEvent);
            await _navigationService.NavigateAsync("SelectVehiclePopupPage", navParams);

            return await tcs.Task;
        }

    }
}

