import { useEffect, useState } from "react";

function App() {
  const [readings, setReadings] = useState([]);

  useEffect(() => {
    fetch("http://localhost:5132/api/SensorReadings")
      .then(res => res.json())
      .then(data => setReadings(data))
      .catch(err => console.error(err));
  }, []);

  return (
    <div style={{ padding: 20 }}>
      <h1>Pipeline Monitor</h1>
      <button onClick={() => window.location.reload()}>Refresh</button>
      <table border="1" cellPadding="8" style={{ marginTop: 10 }}>
        <thead>
          <tr>
            <th>ID</th>
            <th>Sensor</th>
            <th>Value</th>
            <th>Timestamp</th>
          </tr>
        </thead>
        <tbody>
          {readings.map(r => (
            <tr key={r.id}>
              <td>{r.id}</td>
              <td>{r.sensorId}</td>
              <td>{r.value}</td>
              <td>{r.timestamp}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default App;
