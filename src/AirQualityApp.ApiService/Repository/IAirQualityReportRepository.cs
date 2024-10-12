using AirQualityApp.ApiService.Models;

namespace AirQualityApp.ApiService.Repository
{
    public interface IAirQualityReportRepository
    {
        Task AddEntityAsync(AirQualityReport entity);
    }
}
