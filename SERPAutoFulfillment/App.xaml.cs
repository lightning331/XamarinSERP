using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using Prism.Unity;
using SERPAutoFulfillment.Services;
using SERPAutoFulfillment.ViewModels;
using SERPAutoFulfillment.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SERPAutoFulfillment
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
            //PCA = new PublicClientApplication(Constants.ClientID, Constants.Authority);
            //PCA.RedirectUri = $"msal{Constants.ClientID}://auth";
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            base.OnStart();

            var result = await NavigationService.NavigateAsync("LoginPage");

            if (!result.Success)
            {
                SetMainPageFromException(result.Exception);
            }

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Navigation - Main Pages //
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage>();
            containerRegistry.RegisterForNavigation<ForgotPasswordPage>();
            containerRegistry.RegisterForNavigation<PasswordSentPage>();
            containerRegistry.RegisterForNavigation<MainTabPage>();
            containerRegistry.RegisterForNavigation<MainMyVehiclePage>();

            // Navigation - PopupPages//
            containerRegistry.RegisterForNavigation<InfoAlertPopupPage>();
            containerRegistry.RegisterForNavigation<PasswordResetPopupPage>();
            containerRegistry.RegisterForNavigation<ContactDriverPopupPage, ContactDriverPopupPageViewMdel>();
            containerRegistry.RegisterForNavigation<SelectVehiclePopupPage, SelectVehiclePopupPageViewModel>();
            containerRegistry.RegisterForNavigation<VehicleInventoryItemPage, VehicleInventoryItemPageViewModel>();
            containerRegistry.RegisterForNavigation<MainEquipmentLookupPage, MainEquipmentLookupPageViewModel>();

            // Services //
            containerRegistry.RegisterSingleton<IAlertService, AlertService>();

            containerRegistry.RegisterPopupNavigationService();
        }

        private void SetMainPageFromException(Exception ex)
        {
            var layout = new StackLayout
            {
                Padding = new Thickness(40)
            };
            layout.Children.Add(new Label
            {
                Text = ex?.GetType()?.Name ?? "Unknown Error encountered",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            });

            layout.Children.Add(new ScrollView
            {
                Content = new Label
                {
                    Text = $"{ex}",
                    LineBreakMode = LineBreakMode.WordWrap
                }
            });

            MainPage = new ContentPage
            {
                Content = layout
            };
        }

    }
}
