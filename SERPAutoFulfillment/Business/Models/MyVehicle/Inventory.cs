using System;

using Xamarin.Forms;

namespace SERPAutoFulfillment.Business
{
    public class Inventory
    {
        public Inventory(string url, string desc, int profiled=0, int loaded=0, int maint=0, int ready=0, bool isdetailsVisible=false, InentoryDetails details = null)
        {
            this.ImageUrl = url;
            this.Description = desc;
            this.Profiled = profiled;
            this.Loaded = loaded;
            this.Maint = maint;
            this.Ready = ready;
            isDetailVisible = isdetailsVisible;
            Details = details;
        }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int Profiled { get; set; }
        public int Loaded { get; set; }
        public int Maint { get; set; }
        public int Ready { get; set; }

        public InentoryDetails Details { get; set; }

        public bool isDetailVisible { get; set; }
    }
}

