using IndustrialDataSimulator.Models;

namespace WebAPI.Interfaces
{
    public interface IDataGeneratorService
    {
        SensorReading? GetLatestReading();
    }
}
