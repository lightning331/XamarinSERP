using System;
using System.ComponentModel;
using Prism.Commands;
using Prism.Navigation;
using SERPAutoFulfillment.Styles;
using Xamarin.Forms;

namespace SERPAutoFulfillment.ViewModels
{
    class InfoAlertPopupPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public InfoAlertPopupPageViewModel()
        {
            ConfirmCommand = new DelegateCommand(Confirm);
        }

        public DelegateCommand ConfirmCommand { get; }
        private EventHandler<bool> Callback;

        private void Confirm()
        {
            Callback.Invoke(this, true);
        }

        private string _alertTitle;
        public string AlertTitle
        {
            get { return _alertTitle; }
            set
            {
                SetProperty(ref _alertTitle, value);
            }
        }

        private string _alertText;
        public string AlertText
        {
            get { return _alertText; }
            set
            {
                SetProperty(ref _alertText, value);
            }
        }

        private TextAlignment _textAlignment;
        public TextAlignment TextAlignment
        {
            get { return _textAlignment; }
            set
            {
                SetProperty(ref _textAlignment, value);
            }
        }

        private string _confirmText = "Close";
        public string ConfirmText
        {
            get { return _confirmText; }
            set
            {
                SetProperty(ref _confirmText, value);
            }
        }

        private Color _alertColor = AppStyles.PrimaryRed;
        public Color AlertColor
        {
            get { return _alertColor; }
            set
            {
                SetProperty(ref _alertColor, value);
            }
        }

        public async override void Initialize(INavigationParameters parameters)
        {
            EventHandler<bool> callback;
            if (parameters.TryGetValue("Callback", out callback))
            {
                Callback = callback;
            }

            if (parameters.TryGetValue("AlertTitle", out string alertTitle))
            {
                if (!string.IsNullOrEmpty(alertTitle))
                {
                    AlertTitle = alertTitle;
                }

            }

            if (parameters.TryGetValue("AlertText", out string alertText))
            {
                if (!string.IsNullOrEmpty(alertText))
                {
                    AlertText = alertText;
                }
            }

            if (parameters.TryGetValue("ConfirmText", out string confirmText))
            {
                if (!string.IsNullOrEmpty(confirmText))
                {
                    ConfirmText = confirmText;
                }
            }

            if (parameters.TryGetValue("AlertColor", out Color alertColor))
            {
                if (!alertColor.Equals(Color.Default))
                {
                    AlertColor = alertColor;
                }
            }

            if (parameters.TryGetValue("TextAlignment", out TextAlignment alignment))
            {
                TextAlignment = alignment;
            }
        }
    }
}

