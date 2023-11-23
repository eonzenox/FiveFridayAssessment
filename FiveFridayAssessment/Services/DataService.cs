using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace FiveFridayAssessment.Services
{
    public class DataService
    {
        public List<Models.DriverModel> GetDrivers()
        {
            try
            {
                string json = LoadJson();
                var driversData = JsonConvert.DeserializeObject<Models.DriversDataModel>(json);

                return driversData?.Data ?? new List<Models.DriverModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON: {ex.Message}");
                return new List<Models.DriverModel>(); // or handle the error appropriately
            }
        }

        private string LoadJson()
        {
            try
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(DataService)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("FiveFridayAssessment.Data.drivers.json");

                if (stream == null)
                {
                    Console.WriteLine("Error: Stream is null");
                    return string.Empty; // or handle the error appropriately
                }

                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    Console.WriteLine($"Loaded JSON: {json}");
                    return json;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON: {ex.Message}");
                return string.Empty; // or handle the error appropriately
            }
        }
    }
}