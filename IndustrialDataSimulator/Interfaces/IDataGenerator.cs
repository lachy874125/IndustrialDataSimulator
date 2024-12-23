using ConsoleApp.Models;

namespace ConsoleApp.Interfaces
{
    public interface IDataGenerator : IDisposable
    {
        event EventHandler<SensorReading> NewDataGenerated;
        void StartGenerating();
        void StopGenerating();
    }
}
