using System.Collections.ObjectModel;
using FiveFridayAssessment.Models;

namespace FiveFridayAssessment.ViewModels
{
    public class DriverDetailsViewModel : BaseViewModel
    {
        private string driverName;
        private string vehicleRegistration;
        private ObservableCollection<TraceModel> traces;

        public string DriverName
        {
            get { return driverName; }
            set { SetProperty(ref driverName, value); }
        }

        public string VehicleRegistration
        {
            get { return vehicleRegistration; }
            set { SetProperty(ref vehicleRegistration, value); }
        }

        public ObservableCollection<TraceModel> Traces
        {
            get { return traces; }
            set
            {
                SetProperty(ref traces, value);
                OnPropertyChanged(nameof(Traces)); 
            }
        }

        public DriverDetailsViewModel(DriverModel driver)
        {
         
            DriverName = $"{driver.Forename} {driver.Surname}";
            VehicleRegistration = driver.VehicleRegistration;
            Traces = new ObservableCollection<TraceModel>(driver.Traces);
        }
    }
}
