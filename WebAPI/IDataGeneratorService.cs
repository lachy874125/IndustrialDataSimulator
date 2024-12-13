using IndustrialDataSimulator.Models;

namespace WebAPI
{
    public interface IDataGeneratorService
    {
        SensorReading? GetLatestReading();
    }
}
