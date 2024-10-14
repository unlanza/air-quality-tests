using AirQualityApp.ApiService.Models;

namespace AirQualityApp.Web;

public class AirQualityReportClient(HttpClient httpClient)
{
    public async Task<AirQualityReport[]> GetAirQualityReportsAsync(int maxItems = 100, CancellationToken cancellationToken = default)
    {
        List<AirQualityReport>? airQualityRecords = null;

        await foreach (var airQualityRecord in httpClient.GetFromJsonAsAsyncEnumerable<AirQualityReport>("/", cancellationToken))
        {
            if (airQualityRecords?.Count >= maxItems)
            {
                break;
            }
            if (airQualityRecord is not null)
            {
                airQualityRecords ??= [];
                airQualityRecords.Add(airQualityRecord);
            }
        }

        return airQualityRecords?.ToArray() ?? [];
    }
}

