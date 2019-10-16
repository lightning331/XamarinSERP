using Prism.Commands;
using Prism.Navigation;

namespace SERPAutoFulfillment.ViewModels
{
    public class PasswordSentPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public PasswordSentPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoToLoginCommand = new DelegateCommand(GoToLogin);
        }
        public DelegateCommand GoToLoginCommand { get; }

        private async void GoToLogin()
        {
            await _navigationService.ClearPopupStackAsync();
            await _navigationService.NavigateAsync("LoginPage");
        }

    }
}

