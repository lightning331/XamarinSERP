using System;
using Prism;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace SERPAutoFulfillment.ViewModels
{
    public class ViewModelBase : BindableBase, IDestructible, INavigationAware, IInitialize
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public DateTime DateTimeNow
        {
            get { return DateTime.Now; }
        }

        public virtual void Destroy()
        {
            Console.WriteLine($"Destroying: {this.GetType()}");
        }

        public virtual void ShowMessage(string title, string message, string buttonText)
        {
            PrismApplicationBase.Current.MainPage.DisplayAlert(title, message, buttonText);
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void Initialize(INavigationParameters parameters)
        {
        }
    }
}

