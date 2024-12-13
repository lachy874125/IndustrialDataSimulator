# Industrial Data Simulator
## Project 1: Console Application
### Overview
This project implements a console application that generates simulated sensor readings of temperature and pressure at regular intervals. The readings are timestamped, printed to the console and logged to a file. The application demonstrates several C# programming concepts and patterns including:
- Dependency injection
- Asynchronous programming
- Event-driven architecture
- Interface segregation and SOLID principles
- Resource management
- File I/O operations

The project can be built and run with Visual Studio.

### Project Structure

- Interfaces:
	- **IDataGenerator.cs**: Interface for generating sensor readings
	- **IDataLogger.cs**: Interface for logging sensor readings
- Services:
	- **DataGenerator.cs**: Implementation of sensor data generation using Timer
	- **FileLogger.cs**: Implementation of file-based logging
- Models:
	- **SensorReading.cs**: Data model for sensor measurements

## Project 2: Web API
This project extends the Industrial Data Simulator (Project 1) by implementing it as a web API using ASP.NET Core.
### Features

- Background service that continuously generates sensor readings
- REST API endpoint that provides access to the latest sensor data
- Integration with Project 1's DataGenerator

### API Endpoints

- GET /sensor/latest - Returns the most recent sensor reading in JSON format

### Project Structure
- Interfaces:
	- **IDataGeneratorService.cs**: Interface defining how to access sensor reading 
- Servies:
	- **DataGeneratorService.cs**: Background service that generates and provides sensor readings