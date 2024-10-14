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

Possible approaches:
| **Combination** | **Approach** | **Use Case** | **Benefits** |
|--------------------------------------|--------------------------------------------------------------------------------------------------|--------------------------------------------------------------------|---------------------------------------------------------------|
| **Clustering + Decision Trees** | Cluster data, then use decision trees for rule-based prediction within each cluster. | Customer segmentation and targeted prediction.  | Simplifies data, provides interpretable rules for each cluster.|
| **Decision Trees + Association Rules**| Use decision trees to split data, then apply association rules to find co-occurrences in each subset. | Risk factor segmentation and pattern discovery in healthcare. | Understand decision factors, reveal deeper patterns in subsets. |
| **Clustering + Association Rules**  | Cluster data by similarity, then apply association rule mining within each cluster.  | Market basket analysis for different customer groups.  | Targeted patterns based on behavior segments.|
| **Clustering + Decision Trees + Association Rules** | Cluster data, apply decision trees, then find association rules within decision pathways. | Comprehensive analysis of customer behavior and product relationships. | Multi-faceted insights: segmentation, classification, patterns.|
| **Association Rules + Decision Trees**| Use decision trees to find key features, then focus association rule mining on relevant features. | Efficient recommendation system using user preferences.| Reduces complexity, focuses on the most important features.|
