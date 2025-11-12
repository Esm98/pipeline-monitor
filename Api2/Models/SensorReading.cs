// Models/SensorReading.cs
using System;

namespace Api2.Models
{
    // Represents a single sensor reading record.
    public class SensorReading
    {
        // Primary key, auto-incremented.
        public int Id { get; set; }

        // Unique identifier for the physical sensor (example: "SensorA01").
        // Initialized to empty string to satisfy non-nullable requirement.
        public string SensorId { get; set; } = string.Empty;

        // The actual numeric reading value.
        public double Value { get; set; }

        // Timestamp of when the reading was taken.
        public DateTime Timestamp { get; set; }
    }
}
