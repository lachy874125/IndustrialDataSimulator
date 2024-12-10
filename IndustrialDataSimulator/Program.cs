using IndustrialDataSimulator.Interfaces;
using IndustrialDataSimulator.Services;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main(string[] args)
    {
        // Set up dependency injection
        var services = new ServiceCollection()
            .AddSingleton<IDataGenerator, DataGenerator>()
            .AddSingleton<IDataLogger, FileLogger>(sp =>
                new FileLogger(Path.Combine("Logs", "sensor_readings.log")))
            .BuildServiceProvider();

        // Get services
        var dataGenerator = services.GetRequiredService<IDataGenerator>();
        var dataLogger = services.GetRequiredService<IDataLogger>();

        // Subscribe to new data events
        dataGenerator.NewDataGenerated += async (sender, reading) =>
        {
            // Display in console
            Console.WriteLine(reading.ToString());

            // Log to file
            await dataLogger.LogDataAsync(reading);
        };

        try
        {
            Console.WriteLine("Industrial Data Simulator Starting...");
            Console.WriteLine("Press any key to stop");

            // Start generating data
            dataGenerator.StartGenerating();

            // Wait for user input
            Console.ReadKey();

            // Cleanup
            if (dataGenerator is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}