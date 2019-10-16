using System;

using Xamarin.Forms;

namespace SERPAutoFulfillment.Business
{
    public class InentoryDetails
    {
        public InentoryDetails(string tag, string mfr, string modelName, string modelSerial, string status, string lot="")
        {
            Tag = tag;
            Manufacturer = mfr;
            ModelName = modelName;
            ModelSerial = modelSerial;
            Status = status;
            Lot = lot;
        }
        public string Tag { get; set; }
        public string Manufacturer { get; set; }
        public string ModelName { get; set; }
        public string ModelSerial { get; set; }
        public string Status { get; set; }
        public string Lot { get; set; }
    }
}

