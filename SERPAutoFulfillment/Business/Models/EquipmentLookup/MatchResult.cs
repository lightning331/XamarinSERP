using System;

using Xamarin.Forms;

namespace SERPAutoFulfillment.Business
{
    public class MatchResult
    {

        public int Id { get; set; } //0: empty 1: pickup assigned, 2: pickup not assigned, 3: sold facility, 4: sold residence, 5: discarded, 6: inactive, 7: rented, 8: legacy tag, 9: atnr
        public string OrderId { get; set; }
        public string AssignedName { get; set; }

        public Inventory Inventory { get; set; }
        public string DeliveredDate { get; set; }
    }
}

