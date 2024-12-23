using ConsoleApp.Interfaces;
using ConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {
        // Create service container to implement dependency injection
        using var services = new ServiceCollection()
            .AddSingleton<IDataGenerator, DataGenerator>()
            .AddSingleton<IDataLogger, FileLogger>(sp => new FileLogger(Path.Combine("Logs", "sensor_readings.log")))
            .BuildServiceProvider();

        // Get instances of services (and throw an exception if they aren't registered)
        using var dataGenerator = services.GetRequiredService<IDataGenerator>();
        var dataLogger = services.GetRequiredService<IDataLogger>();
        using var _ = dataLogger as IDisposable;    // Call dataLogger.Dispose() if dataLogger implements IDisposable

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

            // Wait for user input and discard
            Console.ReadKey(true);

            // Stop the generator
            Console.WriteLine("Stopping data generation...");
            dataGenerator.StopGenerating();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}