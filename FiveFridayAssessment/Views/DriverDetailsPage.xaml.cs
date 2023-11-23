using FiveFridayAssessment.ViewModels;
using Xamarin.Forms;

namespace FiveFridayAssessment.Views
{
    public partial class DriverDetailsPage : ContentPage
    {
        public DriverDetailsPage(DriverDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}