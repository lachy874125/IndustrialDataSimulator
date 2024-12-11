using IndustrialDataSimulator.Interfaces;
using IndustrialDataSimulator.Models;

namespace IndustrialDataSimulator.Services
{
    public class DataGenerator : IDataGenerator, IDisposable
    {
        private const double MIN_TEMPERATURE = 20;
        private const double MAX_TEMPERATURE = 80;
        private const double MIN_PRESSURE = 0;
        private const double MAX_PRESSURE = 100;

        private readonly Random _random = new();
        private Timer? _timer;
        private bool _isRunning = false;
        private bool _disposed;

        public event EventHandler<SensorReading>? NewDataGenerated;

        public void StopGenerating()
        {
            _isRunning = false;
            _timer?.Dispose();
            _timer = null;
        }

        public void StartGenerating()
        {
            ObjectDisposedException.ThrowIf(_disposed, this);

            if (_isRunning) return;

            _isRunning = true;
            _timer = new Timer(GenerateData, null, 0, 1000);    // Generate data every second and call GenerateData on elapse
        }

        private void GenerateData(object? state)
        {
            try
            {
                if (!_isRunning || _disposed) return;

                // Generate random sensor reading
                var reading = new SensorReading
                {
                    TimeStamp = DateTime.Now,
                    Temperature = MIN_TEMPERATURE + _random.NextDouble() * (MAX_TEMPERATURE - MIN_TEMPERATURE),
                    Pressure = MIN_PRESSURE + _random.NextDouble() * (MAX_PRESSURE - MIN_PRESSURE)
                };

                NewDataGenerated?.Invoke(this, reading);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating data: {ex.Message}");
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
                StopGenerating();   // Timer is disposed here
            }

            _disposed = true;
        }

        ~DataGenerator()
        {
            Dispose(false);
        }
    }
}