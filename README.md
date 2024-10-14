# air-quality-tests
Working with air quality datasets from many sources. Tools: Excel, .NET 8, Visual Studio

## Arch Records
### 1. On DB Injection
#### Context
Based on this file for a current sample: [aspire-samples/samples/AspireShop/AspireShop.BasketService/AspireShop.BasketService.csproj at main · dotnet/aspire-samples (github.com)](https://github.com/dotnet/aspire-samples/blob/main/samples/AspireShop/AspireShop.BasketService/AspireShop.BasketService.csproj)

#### Decision
I will inject the DB from the `AirQualityApp.ApiService` project

### 2. Processing Application
#### Context
Based on experience, the main objective of the app will be exposing through an API/web frontend, the consumed/processed dataset

#### Decision
The architecture will be like:


### 3. CSV Reading approach
#### Context
My options are:
1. Manual parsing.
2. JoshClose/CsvHelper NuGet Package.

#### Decision
We are using this NuGet package: [JoshClose/CsvHelper: Library to help reading and writing CSV files (github.com)](https://github.com/JoshClose/CsvHelper)
[CsvHelper Getting started](https://joshclose.github.io/CsvHelper/getting-started/)

## About the dataset
To inform decisions on air quality, I'll