using Xamarin.Forms;

namespace SERPAutoFulfillment.Views
{
    public partial class MainTabPage : TabbedPage
    {
        public MainTabPage()
        {
            InitializeComponent();
            var pages = Children.GetEnumerator();
            pages.MoveNext(); // Dashboard page
            CurrentPage = pages.Current;

        }
    }
}
