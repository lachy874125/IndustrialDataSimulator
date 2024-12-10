using IndustrialDataSimulator.Models;

namespace IndustrialDataSimulator.Interfaces
{
    public interface IDataLogger : IDisposable
    {
        Task LogDataAsync(SensorReading sensorReading);
    }
}
