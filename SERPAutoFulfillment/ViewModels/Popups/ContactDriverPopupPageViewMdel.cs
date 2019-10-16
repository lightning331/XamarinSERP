using System;
using System.ComponentModel;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace SERPAutoFulfillment.ViewModels
{
    class ContactDriverPopupPageViewMdel : ViewModelBase, INotifyPropertyChanged
    {
        public ContactDriverPopupPageViewMdel()
        {
            ExitCommand = new DelegateCommand(Exit);
        }

        public DelegateCommand ExitCommand { get; }
        private EventHandler<bool> Callback;

        private void Exit()
        {
            Callback.Invoke(this, true);
        }

        public override void Initialize(INavigationParameters parameters)
        {
            EventHandler<bool> callback;
            if (parameters.TryGetValue("Callback", out callback))
            {
                Callback = callback;
            }

        }
    }
}

