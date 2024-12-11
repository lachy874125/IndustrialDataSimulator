using IndustrialDataSimulator.Models;

namespace IndustrialDataSimulator.Interfaces
{
    public interface IDataGenerator : IDisposable
    {
        event EventHandler<SensorReading> NewDataGenerated;
        void StartGenerating();
        void StopGenerating();
    }
}
