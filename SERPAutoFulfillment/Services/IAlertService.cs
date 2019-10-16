using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SERPAutoFulfillment.Services
{
    public interface IAlertService
    {
        Task<bool> InfoAlert(int timeToDissapear, string alertText);

        Task<bool> InfoAlert(int timeToDissapear, string alertTitle, string alertText, string confirmText = null, Color? alertColor = null, TextAlignment alignment = TextAlignment.Center);

        Task<bool> PasswordResetAlert();

        Task<bool> ContactDriverAlert();

        Task<bool> SelectVehicleAlert();
    }
}

