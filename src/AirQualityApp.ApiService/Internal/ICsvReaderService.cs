namespace AirQualityApp.ApiService.Internal
{
    public interface ICsvReaderService<T> where T : class
    {
        /// <summary>
        /// Reads all records from the CSV file and loads them into memory.
        /// </summary>
        /// <param name="filePath">The path of the CSV file to be read.</param>
        /// <returns>A collection of records read from the CSV file.</returns>
        IEnumerable<T> ReadCsvFile(string filePath);

        /// <summary>
        /// Reads records from the CSV file as a stream (lazy loading, processing one record at a time).
        /// </summary>
        /// <param name="filePath">The path of the CSV file to be read.</param>
        /// <returns>An enumerable of records that allows processing one at a time.</returns>
        IEnumerable<T> StreamCsvFile(string filePath);

        /// <summary>
        /// Loads the CSV data into memory.
        /// </summary>
        /// <param name="filePath">The path of the CSV file to be read.</param>
        void LoadCsvData(string filePath);

        /// <summary>
        /// Provides access to the in-memory loaded data.
        /// </summary>
        /// <returns>A collection of in-memory records from the CSV file.</returns>
        IEnumerable<T> GetLoadedData();
    }

}
