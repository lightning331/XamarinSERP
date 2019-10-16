using System;
using Prism;
using Xamarin.Forms;

namespace SERPAutoFulfillment.Styles
{
    public class AppStyles
    {
        public static Color PrimaryRed = LoadResource<Color>("PrimaryRed");
        public static Color EvenRowBackground = LoadResource<Color>("EvenRowBackground");
        public static Color OddRowBackground = LoadResource<Color>("OddRowBackground");
        public static Color TappedRowBackground = LoadResource<Color>("TappedRowBackground");

        private static T LoadResource<T>(string key)
        {
            if (PrismApplicationBase.Current.Resources.TryGetValue(key, out var value))
            {
                return (T)value;
            }

            return default(T);
        }

    }
}

