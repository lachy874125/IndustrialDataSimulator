using IndustrialDataSimulator.Models;

namespace IndustrialDataSimulator.Interfaces
{
    public interface IDataLogger
    {
        Task LogDataAsync(SensorReading sensorReading);
    }
}
