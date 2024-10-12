using AirQualityApp.ApiService.Models;
using Microsoft.Data.Sqlite;

namespace AirQualityApp.ApiService.Repository
{
    public class SqliteAirQualityReportsDbContext : IAirQualityReportRepository
    {
        private readonly string _connectionString;

        public SqliteAirQualityReportsDbContext()
        {
            _connectionString = "Data Source=airQualityAppDb.db";
        }
        public async Task AddEntityAsync(AirQualityReport entity)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = await connection.BeginTransactionAsync())
                {
                    var command = connection.CreateCommand();
                    // Assuming entity has properties that can be mapped to table columns
                    // Here you would build the INSERT command dynamically based on the entity type
                    // For simplicity, let's assume T has properties "Id" and "Name"

                    command.CommandText = "INSERT INTO AirQualityReport(TimeStamp) VALUES (@Id, @TimeStamp)";
                    command.Parameters.AddWithValue("@Id", typeof(AirQualityReport).GetProperty("Id")?.GetValue(entity));
                    command.Parameters.AddWithValue("@TimeStamp", typeof(AirQualityReport).GetProperty("TimeStamp")?.GetValue(entity));

                    await command.ExecuteNonQueryAsync();
                    await transaction.CommitAsync();
                }
            }
        }
    }
}

#region Microsoft official docs example of a servie. 
//Source: https://github.com/dotnet/aspire-samples/blob/ab410c06fddf23f1e0369c2c6124df3f5f4909be/samples/AspireShop/AspireShop.BasketService/Repositories/RedisBasketRepository.cs

//using System.Text.Json;
//using StackExchange.Redis;
//using AspireShop.BasketService.Models;

//namespace AspireShop.BasketService.Repositories;

//public class RedisBasketRepository(ILogger<RedisBasketRepository> logger, IConnectionMultiplexer redis) : IBasketRepository
//{
//    private readonly ILogger<RedisBasketRepository> _logger = logger;
//    private readonly IConnectionMultiplexer _redis = redis;
//    private readonly IDatabase _database = redis.GetDatabase();
//    private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
//    {
//        PropertyNameCaseInsensitive = true,
//    };

//    public async Task<bool> DeleteBasketAsync(string id)
//    {
//        return await _database.KeyDeleteAsync(id);
//    }

//    public IEnumerable<string> GetUsers()
//    {
//        var server = GetServer();
//        var data = server.Keys();

//        return data?.Select(k => k.ToString()) ?? Enumerable.Empty<string>();
//    }

//    public async Task<CustomerBasket?> GetBasketAsync(string customerId)
//    {
//        var data = await _database.StringGetAsync(customerId);

//        if (data.IsNullOrEmpty)
//        {
//            return null;
//        }

//        return JsonSerializer.Deserialize<CustomerBasket>(data!, _jsonSerializerOptions);
//    }

//    public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
//    {
//        if (basket.BuyerId == null)
//        {
//            return null;
//        }

//        var created = await _database.StringSetAsync(basket.BuyerId, JsonSerializer.Serialize(basket, _jsonSerializerOptions));

//        if (!created)
//        {
//            _logger.LogInformation("Problem occur persisting the item.");
//            return null;
//        }

//        _logger.LogInformation("Basket item persisted successfully.");

//        return await GetBasketAsync(basket.BuyerId);
//    }

//    private IServer GetServer()
//    {
//        var endpoint = _redis.GetEndPoints();
//        return _redis.GetServer(endpoint.First());
//    }
//}

#endregion