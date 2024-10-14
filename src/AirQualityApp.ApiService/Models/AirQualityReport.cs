using System.Globalization;
using CsvHelper.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AirQualityApp.ApiService.Models
{
    public class AirQualityReport
    {
        // Define properties for the record
        public DateTime Timestamp { get; set; } // Combines FECHA and HORA
        public double? CO_CENTENARIO { get; set; }
        public double? NO2_CENTENARIO { get; set; }
        public double? PM10_CENTENARIO { get; set; }
        public double? CO_CORDOBA { get; set; }
        public double? NO2_CORDOBA { get; set; }
        public double? PM10_CORDOBA { get; set; }
        public double? CO_LA_BOCA { get; set; }
        public double? NO2_LA_BOCA { get; set; }
        public double? PM10_LA_BOCA { get; set; }
        public double? CO_PALERMO { get; set; }
        public double? NO2_PALERMO { get; set; }
        public double? PM10_PALERMO { get; set; }
    }

    public class AirQualityReportMap : ClassMap<AirQualityReport>
    {
        public AirQualityReportMap()
        {
            Map(m => m.Timestamp)
                .Convert(row =>
                    GetDateTimeFromString(
                        row.Row.GetField("FECHA").Split(":")[0],
                        row.Row.GetField("HORA").Split(":")[0]
                    )
                );

            Map(m => m.CO_CENTENARIO)
                .Convert(row => GetValueOrDefault(row.Row.GetField("CO_CENTENARIO")));
            Map(m => m.NO2_CENTENARIO)
                .Convert(row => GetValueOrDefault(row.Row.GetField("NO2_CENTENARIO")));
            Map(m => m.PM10_CENTENARIO)
                .Convert(row => GetValueOrDefault(row.Row.GetField("PM10_CENTENARIO")));
            Map(m => m.CO_CORDOBA)
                .Convert(row => GetValueOrDefault(row.Row.GetField("CO_CORDOBA")));
            Map(m => m.NO2_CORDOBA)
                .Convert(row => GetValueOrDefault(row.Row.GetField("NO2_CORDOBA")));
            Map(m => m.PM10_CORDOBA)
                .Convert(row => GetValueOrDefault(row.Row.GetField("PM10_CORDOBA")));
            Map(m => m.CO_LA_BOCA)
                .Convert(row => GetValueOrDefault(row.Row.GetField("CO_LA_BOCA")));
            Map(m => m.NO2_LA_BOCA)
                .Convert(row => GetValueOrDefault(row.Row.GetField("NO2_LA_BOCA")));
            Map(m => m.PM10_LA_BOCA)
                .Convert(row => GetValueOrDefault(row.Row.GetField("PM10_LA_BOCA")));
            Map(m => m.CO_PALERMO)
                .Convert(row => GetValueOrDefault(row.Row.GetField("CO_PALERMO")));
            Map(m => m.NO2_PALERMO)
                .Convert(row => GetValueOrDefault(row.Row.GetField("NO2_PALERMO")));
            Map(m => m.PM10_PALERMO)
                .Convert(row => GetValueOrDefault(row.Row.GetField("PM10_PALERMO")));
        }
        private DateTime GetDateTimeFromString(string date, string hour)
        {
            DateTime resultDate = new DateTime(2010, 1, 1);
            int hourInt = int.Parse(hour);
            if (!string.IsNullOrEmpty(date))
            {
                if (hourInt < 10)
                {
                    hour = "0" + hour;
                }
                else if (hourInt == 24 || hourInt == 0)
                {
                    hour = "00";
                }
                else if (hourInt > 24)
                {
                    hour = "00";
                }
                try
                {
                    resultDate = DateTime.ParseExact(
                        $"{date}:{hour}",
                        "ddMMMyyyy:HH",
                        CultureInfo.InvariantCulture
                    );
                }
                catch
                {
                    throw;
                }
            }
            return resultDate;
        }

        private double? GetValueOrDefault(string value)
        {
            // Initialize a double variable to store the parsed result.
            double result;

            // Check if the input value is null, empty, or equals "s/d" which indicates missing data.
            if (
                string.IsNullOrEmpty(value)
                || value.Equals("s/d", StringComparison.OrdinalIgnoreCase)
            )
            {
                // Return null if the value is invalid or represents missing data.
                return null;
            }

            // Try to parse the input value as a double.
            if (double.TryParse(value, out result))
            {
                // If parsing is successful, return the parsed value.
                return result;
            }
            else
            {
                // If parsing fails (e.g., value contains invalid characters), return null.
                return null;
            }
        }
    }
}
