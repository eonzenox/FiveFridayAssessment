using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FiveFridayAssessment.Models;
using FiveFridayAssessment.Services;
using FiveFridayAssessment.Views;
using Xamarin.Forms;

namespace FiveFridayAssessment.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private List<DriverModel> _drivers;
        private ObservableCollection<DriverModel> _filteredDrivers;
        private bool _isSortAscending = true;
        private string _searchText = string.Empty;

        public MainViewModel()
        {
   
            _drivers = new DataService().GetDrivers();
            SortDriversByName();
            FilterDriversByName();
        }

        public List<DriverModel> Drivers => _drivers;

        public ObservableCollection<DriverModel> FilteredDrivers
        {
            get { return _filteredDrivers; }
            set { SetProperty(ref _filteredDrivers, value); }
        }

        public bool IsSortAscending
        {
            get { return _isSortAscending; }
            set
            {
                SetProperty(ref _isSortAscending, value);
                SortDriversByName();
            }
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                SetProperty(ref _searchText, value);
                FilterDriversByName();
            }
        }

        public ICommand ToggleSortCommand => new Command(() => IsSortAscending = !IsSortAscending);

        public ICommand SearchCommand => new Command<string>((query) => SearchText = query);

        public ICommand ViewDetailsCommand => new Command<DriverModel>(async (driver) => await ShowDetails(driver));

        private async Task ShowDetails(DriverModel driver)
        {
       
            await Application.Current.MainPage.Navigation.PushAsync(new DriverDetailsPage(new DriverDetailsViewModel(driver)));
        }

        private void SortDriversByName()
        {
            if (IsSortAscending)
            {
                _drivers = _drivers.OrderBy(driver => $"{driver.Surname} {driver.Forename}").ToList();
            }
            else
            {
                _drivers = _drivers.OrderByDescending(driver => $"{driver.Surname} {driver.Forename}").ToList();
            }
        }

        private void FilterDriversByName()
        {
            if (_drivers == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredDrivers = new ObservableCollection<DriverModel>(_drivers);
            }
            else
            {
                FilteredDrivers = new ObservableCollection<DriverModel>(
                    _drivers.Where(driver => driver.Surname.ToLower().Contains(SearchText.ToLower())
                                            || driver.Forename.ToLower().Contains(SearchText.ToLower())
                                            || driver.VehicleRegistration.ToLower().Contains(SearchText.ToLower())));
            }
        }
    }
}
