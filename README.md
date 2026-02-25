# Industrial Measurement Demo

## Overview

IndustrialMeasurementDemo is a multi-project **.NET 10** solution that simulates and processes industrial measurement data using a structured, layered architecture.

The system emulates a measurement device communicating over TCP, processes incoming raw data, applies calibration and scaling logic, evaluates tolerances, and persists results asynchronously to a SQLite database.

The project resembles a simplified industrial measurement and quality control workflow similar to production environments.

---

## Screenshot

![Industrial Measurement Demo UI](docs/screenshot.png)

## System Architecture

The solution follows separation of concerns and clean layering principles.

### IMD.Core
- Domain models  
- Measurement processing pipeline  
- Raw-to-engineering value scaling  
- Tolerance evaluation logic  
- Repository abstractions  
- Infrastructure-independent business logic  

### IMD.Infrastructure
- Entity Framework Core integration  
- SQLite persistence  
- Repository implementation  
- Indexed timestamp-based storage  

### IMD.DeviceSimulator
- TCP-based device simulator  
- Streams simulated raw measurement values  
- Represents an external industrial measurement device  

### IMD.NativeCalibration
- Native C++ calibration library  
- Integrated via P/Invoke  
- Demonstrates managed/unmanaged interoperability  

### IMD.UI
- WinForms-based user interface  
- Real-time visualization of measurements  
- Asynchronous background database writer  
- Bounded `Channel<T>` for controlled backpressure  
- Non-blocking UI updates  

### IMD.Tests
- Unit tests for:
  - Parsing logic  
  - Scaling calculations  
  - Calibration integration  
  - Tolerance evaluation  

---

## Communication Flow

```
DeviceSimulator (TCP Server)
        ↓
TCP Stream (localhost:9000)
        ↓
IMD.UI (TCP Client)
        ↓
Processing Pipeline (Core)
        ↓
Calibration (Native C++)
        ↓
Tolerance Evaluation
        ↓
Async Database Writer
        ↓
SQLite Storage
```

The UI connects to the simulated device using the default endpoint:

`localhost:9000`

This endpoint represents the communication boundary between the measurement device and the application.

---

## Technologies

- .NET 10  
- WinForms  
- Entity Framework Core  
- SQLite  
- C++ (Native Library)  
- P/Invoke Interop  
- System.Threading.Channels  
- xUnit  

---

## Key Technical Concepts Demonstrated

- TCP-based device communication  
- Deterministic scaling from raw to engineering values  
- Tolerance-based classification (OK / NOK)  
- Managed-to-native interoperability  
- Asynchronous background processing  
- Bounded channels for backpressure control  
- Repository abstraction pattern  
- Unit-tested domain logic  

---

## How to Run

1. Build the solution.  
2. Start **IMD.DeviceSimulator**.  
3. Start **IMD.UI**.  
4. Use the UI to connect to the simulated device (default endpoint: `localhost:9000`).  
5. Observe real-time measurements and background database persistence.  

---

## Design Considerations

The project emphasizes:

- Clear separation between UI, domain, and infrastructure  
- Testable and deterministic business logic  
- Explicit abstraction boundaries  
- Non-blocking UI architecture  
- Controlled asynchronous processing  
- Clean managed/unmanaged integration  

The structure is intentionally organized to resemble a small-scale industrial measurement system.

---

## Author

Safir Kebieh  
Created as a technical demonstration project for a Softwareentwickler position.

---

## License

This project is provided for evaluation purposes only.  
All rights reserved © 2026 Safir Kebieh.