namespace AirQualityApp.ApiService.Internal
{
    public interface IAirQualityProcessorService<IAirQualityReportRepository, ICsvReaderService>
    {
        void PrintDataOnScreen();
    }
}
