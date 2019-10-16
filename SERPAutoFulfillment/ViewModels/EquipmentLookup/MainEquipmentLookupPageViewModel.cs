using System;
using System.Net.Mail;
using Prism.Navigation;
using SERPAutoFulfillment.Services;

namespace SERPAutoFulfillment.ViewModels
{
    public class MainEquipmentLookupPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private IAlertService _alertService;


        public MainEquipmentLookupPageViewModel(INavigationService navigationService, IAlertService alertService)
        {
            _navigationService = navigationService;
            _alertService = alertService;
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        private bool _hasSearchResult;
        public bool HasSearchResult
        {
            get => _hasSearchResult;
            set => SetProperty(ref _hasSearchResult, value);
        }
    }
}

