using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using SensorAPI.Interfaces;

namespace SensorAPI.Services
{
    public class DataGeneratorService : BackgroundService, IDataGeneratorService
    {
        private readonly IDataGenerator _dataGenerator;
        private SensorReading? _latestReading;
        private readonly object _lock = new();

        public DataGeneratorService(IDataGenerator dataGenerator)
        {
            _dataGenerator = dataGenerator;
        }

        public SensorReading? GetLatestReading()
        {
            lock (_lock)
            {
                return _latestReading;
            }
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _dataGenerator.NewDataGenerated += (sender, reading) =>
            {
                lock (_lock)
                {
                    _latestReading = reading;
                }
            };
            _dataGenerator.StartGenerating();

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _dataGenerator.StopGenerating();
            return base.StopAsync(cancellationToken);
        }
    }
}