
using System;
using System.ComponentModel;
using Prism.Commands;
using Prism.Navigation;


namespace SERPAutoFulfillment.ViewModels
{
    class SelectVehiclePopupPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public SelectVehiclePopupPageViewModel()
        {
            ConfirmCommand = new DelegateCommand(Confirm);
            CancelCommand = new DelegateCommand(Cancel);
        }

        public DelegateCommand ConfirmCommand { get; }
        public DelegateCommand CancelCommand { get; }
        private EventHandler<bool> Callback;

        private void Confirm()
        {
            Callback.Invoke(this, true);
        }
        private void Cancel()
        {
            Callback.Invoke(this, false);
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

