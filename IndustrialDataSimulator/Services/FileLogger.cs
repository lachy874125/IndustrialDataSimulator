using IndustrialDataSimulator.Interfaces;
using IndustrialDataSimulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustrialDataSimulator.Services
{
    public class FileLogger : IDataLogger
    {
        private readonly string _filePath;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

        public FileLogger(string filePath)
        {
            _filePath = filePath;

            // Create dictionary if it doesn't exist
            var directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public async Task LogDataAsync(SensorReading sensorReading)
        {
            try
            {
                await _semaphore.WaitAsync();
                try
                {
                    await File.AppendAllTextAsync(_filePath, sensorReading.ToString() + Environment.NewLine);
                }
                finally
                {
                    _semaphore.Release();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging data: {ex.Message}");
            }
        }

        public void Dispose()
        {
            _semaphore.Dispose();
        }
    }
}