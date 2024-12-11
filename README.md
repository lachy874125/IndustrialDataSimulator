# Industrial Data Simulator
## Overview
This application generates simulated sensor readings of temperature and pressure at regular intervals. The readings are timestamped, printed to the console and logged to a file. The application demonstrates several C# programming concepts and patterns including:
- Dependency injection
- Asynchronous programming
- Event-driven architecture
- Interface segregation and SOLID principles
- Resource management
- File I/O operations

## Project Structure

- Interfaces:
	- **IDataGenerator.cs**: Interface for generating sensor readings
	- **IDataLogger.cs**: Interface for logging sensor readings
- Services:
	- **DataGenerator.cs**: Implementation of sensor data generation using Timer
	- **FileLogger.cs**: Implementation of file-based logging
- Models:
	- **SensorReading.cs**: Data model for sensor measurements