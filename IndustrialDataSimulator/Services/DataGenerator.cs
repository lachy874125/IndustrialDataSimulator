using IndustrialDataSimulator.Interfaces;
using IndustrialDataSimulator.Models;

namespace IndustrialDataSimulator.Services
{
    public class DataGenerator : IDataGenerator, IDisposable
    {
        private readonly Random _random = new Random();
        private Timer? _timer;
        private bool _isRunning;
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
            if (_isRunning) return;

            _isRunning = true;
            _timer = new Timer(GenerateData, null, 0, 1000);    // Generate data every second and call GenerateData on elapse
        }

        private void GenerateData(object? state)
        {
            try
            {
                if (!_isRunning) return;

                var reading = new SensorReading
                {
                    TimeStamp = DateTime.Now,
                    Temperature = 20 + _random.NextDouble() * (80 - 20),    // 20-80°C
                    Pressure = _random.NextDouble() * 100   // 0-100 PSI
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
                StopGenerating();
            }

            _disposed = true;
        }
    }
}