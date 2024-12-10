namespace IndustrialDataSimulator.Models
{
    public class SensorReading
    {
        public DateTime TimeStamp { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }

        public override string ToString()
        {
            return $"[{TimeStamp:yyyy-MM-dd HH:mm:ss}] Temperature: {Temperature:F2}°C, Pressure: {Pressure:F2} PSI";
        }
    }
}
