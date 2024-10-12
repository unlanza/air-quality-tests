using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace AirQualityApp.ApiService.Internal
{
    public class CsvReaderService<T> : ICsvReaderService<T> where T : class
    {
        private List<T> _loadedData;

        public CsvReaderService()
        {
            _loadedData = new List<T>();
        }

        public IEnumerable<T> ReadCsvFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            }))
            {
                return csv.GetRecords<T>().ToList();
            }
        }

        public IEnumerable<T> StreamCsvFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            }))
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
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            }))
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
