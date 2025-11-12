# Pipeline Monitor

A full-stack telemetry demo built with ASP.NET Core 8, SQL Server Express, and React (Vite).  
It simulates a real monitoring platform like those used at American Innovations: collecting, storing, and visualizing pipeline sensor data in real time.

---

## Features

- **.NET 8 Web API**
  - REST endpoints for creating, retrieving, and aggregating sensor readings.
  - Entity Framework Core + SQL Server for persistent storage.
  - Auto-generated Swagger documentation for testing.

- **React Frontend**
  - Fetches data from the API and displays it in a live table.
  - Auto-refreshes every 5 seconds.
  - Includes a simple chart using Recharts for trend visualization.

- **Database**
  - SQL Server Express 2022 (`EVANPC\SQLEXPRESS01`).
  - Automatically created through EF Core migrations.
  - Stores readings with `Id`, `SensorId`, `Value`, and `Timestamp`.

---

## Tech Stack

| Layer | Technology |
|-------|-------------|
| Backend | ASP.NET Core 8 |
| Language | C# |
| ORM | Entity Framework Core 8 |
| Database | SQL Server Express 2022 |
| Frontend | React (Vite) |
| Charting | Recharts |
| Package Manager | npm |
| Version Control | Git + GitHub |

---

## Run Locally

### Backend (API)
```bash
cd Api2
dotnet build
dotnet run
```

Runs on http://localhost:5132
Swagger UI → http://localhost:5132/swagger

### Frontend (Dashboard)
cd ../frontend
npm install
npm run dev


#### API Examples
POST /api/SensorReadings
Add a new reading:
{
  "sensorId": "PipeA1",
  "value": 7.25
}
GET /api/SensorReadings

Returns all stored readings.

GET /api/SensorReadings/{id}

Returns a single reading by ID.

GET /api/SensorReadings/stats

Aggregated statistics per sensor:
[
  { "sensorId": "PipeA1", "min": 5.3, "max": 8.1, "avg": 6.7 }
]

#### Frontend Preview
| Feature      | Description                                  |
| ------------ | -------------------------------------------- |
| Table View   | Displays all sensor readings in real time.   |
| Auto-Refresh | Refreshes every 5 seconds.                   |
| Chart        | Plots sensor values over time with Recharts. |


##### Project Structure
PipelineMonitor/
│
├── Api2/                     # ASP.NET Core API
│   ├── Controllers/
│   │   └── SensorReadingsController.cs
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── Models/
│   │   └── SensorReading.cs
│   └── Program.cs
│
└── frontend/                 # React dashboard (Vite)
    ├── src/
    │   ├── App.jsx
    │   └── index.css
    ├── package.json
    └── vite.config.js


Requirements

.NET 8 SDK

SQL Server Express 2022

Node.js 18+

npm

License

MIT License — free for personal and educational use.