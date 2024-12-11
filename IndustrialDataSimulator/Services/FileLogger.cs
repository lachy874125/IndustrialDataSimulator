using IndustrialDataSimulator.Interfaces;
using IndustrialDataSimulator.Models;

namespace IndustrialDataSimulator.Services
{
    public class FileLogger : IDataLogger, IDisposable
    {
        private readonly string _filePath;
        private readonly SemaphoreSlim _semaphore = new(1);
        private bool _disposed;

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
            ObjectDisposedException.ThrowIf(_disposed, this);

            try
            {
                await _semaphore.WaitAsync();

                // Semaphore is released regardless of success of try code
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

        // Standard disposal pattern
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _semaphore.Dispose();
            }

            _disposed = true;
        }

        ~FileLogger()
        {
            Dispose(false);
        }
    }
}