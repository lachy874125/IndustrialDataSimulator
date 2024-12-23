using ConsoleApp.Models;

namespace SensorAPI.Interfaces
{
    public interface IDataGeneratorService
    {
        SensorReading? GetLatestReading();
    }
}
