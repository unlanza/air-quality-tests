
using AirQualityApp.ApiService.Models;

namespace AirQualityApp.ApiService.Internal
{
    public class AirQualityProcessorService<IAirQualityReporRepository, ICsvReaderProcessor> : IAirQualityProcessorService<IAirQualityReporRepository, ICsvReaderService<AirQualityReport>>
    {
        private readonly IAirQualityReporRepository _repository;
        private readonly ICsvReaderService<AirQualityReport> _csvReaderService;

        public AirQualityProcessorService(IAirQualityReporRepository repository, ICsvReaderService<AirQualityReport> csvReaderProcessor)
        {
            _repository = repository;
            _csvReaderService = csvReaderProcessor;

        }
        public void PrintDataOnScreen()
        {
            string filePath = Path.Combine("C:\\Users\\llanza\\Proyectos\\UnLanza\\air-quality-tests\\src\\AirQualityApp.ApiService\\Data\\calidad-aire.csv");
            IEnumerable<AirQualityReport> reports = _csvReaderService.ReadCsvFile(filePath);
            foreach (AirQualityReport report in reports) {
                Console.WriteLine(report);
            }
        }
        public IEnumerable<AirQualityReport> SelectAllData()
        {
            string filePath = Path.Combine("C:\\Users\\llanza\\Proyectos\\UnLanza\\air-quality-tests\\src\\AirQualityApp.ApiService\\Data\\calidad-aire.csv");
            return _csvReaderService.ReadCsvFile(filePath);
        }
    }
}
