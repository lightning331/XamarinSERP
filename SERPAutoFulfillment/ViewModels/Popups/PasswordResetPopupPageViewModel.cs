using System;
using System.ComponentModel;
using Prism.Commands;
using Prism.Navigation;
using SERPAutoFulfillment.Styles;
using Xamarin.Forms;

namespace SERPAutoFulfillment.ViewModels
{
    class PasswordResetPopupPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public PasswordResetPopupPageViewModel()
        {
            ConfirmCommand = new DelegateCommand(Confirm);
        }

        public DelegateCommand ConfirmCommand { get; }
        private EventHandler<bool> Callback;

        private void Confirm()
        {
            Callback.Invoke(this, true);
        }

        public async override void Initialize(INavigationParameters parameters)
        {
            EventHandler<bool> callback;
            if (parameters.TryGetValue("Callback", out callback))
            {
                Callback = callback;
            }

        }
    }
}

