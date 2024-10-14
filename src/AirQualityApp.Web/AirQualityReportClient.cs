using AirQualityApp.ApiService.Models;

namespace AirQualityApp.Web;

public class AirQualityReportClient(HttpClient httpClient)
{
    public async Task<AirQualityReport[]> GetAirQualityReportsAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<AirQualityReport>? airQualityRecordss = null;

        await foreach (var airQualityRecords in httpClient.GetFromJsonAsAsyncEnumerable<AirQualityReport>("/", cancellationToken))
        {
            if (airQualityRecordss?.Count >= maxItems)
            {
                break;
            }
            if (airQualityRecords is not null)
            {
                airQualityRecordss ??= [];
                airQualityRecordss.Add(airQualityRecords);
            }
        }

        return airQualityRecordss?.ToArray() ?? [];
    }
}

