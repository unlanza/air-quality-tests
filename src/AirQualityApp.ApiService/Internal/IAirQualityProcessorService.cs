using AirQualityApp.ApiService.Models;

namespace AirQualityApp.ApiService.Internal
{
    public interface IAirQualityProcessorService<IAirQualityReportRepository, ICsvReaderService>
    {
        void PrintDataOnScreen();
        IEnumerable<AirQualityReport> SelectAllData();
    }
}
