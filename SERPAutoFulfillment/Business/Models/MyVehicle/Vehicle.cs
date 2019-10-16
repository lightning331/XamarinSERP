using System;

using Xamarin.Forms;

namespace SERPAutoFulfillment.Business
{
    public class Vehicle
    {
        public Vehicle(string v1, string v2)
        {
            this.TruckImage = v1;
            this.TruckName = v2;
        }

        public string TruckImage { get; set; }
        public string TruckName { get; set; }
        public string ProfileInfo { get; set; }

    }
}

