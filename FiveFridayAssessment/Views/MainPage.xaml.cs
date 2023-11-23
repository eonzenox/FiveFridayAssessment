using FiveFridayAssessment.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FiveFridayAssessment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
        }
    }
}