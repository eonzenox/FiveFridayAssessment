using System;
using System.Collections.Generic;
using System.Text;

namespace FiveFridayAssessment.Models
{
    public class DriverModel
    {
        public int DriverID { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public string VehicleRegistration { get; set; }
        public List<TraceModel> Traces { get; set; }
    }
}
