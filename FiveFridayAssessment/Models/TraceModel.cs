using FiveFridayAssessment.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System;

public class TraceModel
{
    [JsonProperty("date")]
    public string DateString { get; set; }

    [JsonIgnore]
    public DateTime Date => DateTime.ParseExact(DateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

    public List<ActivityModel> Activity { get; set; }
}