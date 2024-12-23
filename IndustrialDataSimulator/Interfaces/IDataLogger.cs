using ConsoleApp.Models;

namespace ConsoleApp.Interfaces
{
    public interface IDataLogger
    {
        Task LogDataAsync(SensorReading sensorReading);
    }
}
