using IndustrialDataSimulator.Models;

namespace IndustrialDataSimulator.Interfaces
{
    public interface IDataGenerator
    {
        event EventHandler<SensorReading> NewDataGenerated;
        void StartGenerating();
        void StopGenerating();
    }
}
