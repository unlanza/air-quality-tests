using System.Globalization;
using AirQualityApp.ApiService.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace AirQualityApp.ApiService.Internal
{
    public class CsvReaderService<T> : ICsvReaderService<T> where T : class
    {
        private List<T> _loadedData;
        private CsvConfiguration _config;
        public CsvReaderService()
        {
            _loadedData = new List<T>();
            _config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                //NewLine = Environment.NewLine,
                HasHeaderRecord = true
            };
        }

        public IEnumerable<T> ReadCsvFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, _config))
            {
                // Falta hacer esto genérico 
                csv.Context.RegisterClassMap<AirQualityReportMap>(); // Primero lo hardcodeo para probar
                IEnumerable<T> records = csv.GetRecords<T>();
                
                return records.ToList();
            }
        }

        public IEnumerable<T> StreamCsvFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, _config))
            {
                foreach (var record in csv.GetRecords<T>())
                {
                    yield return record;
                }
            }
        }

        public void LoadCsvData(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, _config))
            {
                _loadedData = csv.GetRecords<T>().ToList();
            }
        }

        public IEnumerable<T> GetLoadedData()
        {
            return _loadedData;
        }
    }
}
