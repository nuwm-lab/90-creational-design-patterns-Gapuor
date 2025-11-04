using System;
using System.Globalization;

namespace LabWork
{
    /// <summary>
    /// Represents an aircraft engine (model and thrust in kN).
    /// Immutable once constructed.
    /// </summary>
    public sealed class Engine
    {
        public string Model { get; }
        public int Thrust { get; }

        public Engine(string model, int thrust)
        {
            if (string.IsNullOrWhiteSpace(model)) throw new ArgumentException("Engine model must be a non-empty string.", nameof(model));
            if (thrust <= 0) throw new ArgumentOutOfRangeException(nameof(thrust), "Thrust must be positive.");

            Model = model;
            Thrust = thrust;
        }

        public override string ToString() => $"{Model} ({Thrust} kN)";
    }

    /// <summary>
    /// Represents aircraft wings with a descriptive type and span in meters.
    /// </summary>
    public sealed class Wings
    {
        public string WingType { get; }
        public double Span { get; }

        public Wings(string wingType, double span)
        {
            if (string.IsNullOrWhiteSpace(wingType)) throw new ArgumentException("Wings type must be a non-empty string.", nameof(wingType));
            if (span <= 0) throw new ArgumentOutOfRangeException(nameof(span), "Span must be positive.");

            WingType = wingType;
            Span = span;
        }

        public override string ToString() => $"{WingType}, span {Span.ToString("F1", CultureInfo.InvariantCulture)} m";
    }

    /// <summary>
    /// Represents the interior configuration (style and passenger/crew seats).
    /// </summary>
    public sealed class Interior
    {
        public string Style { get; }
        public int Seats { get; }

        public Interior(string style, int seats)
        {
            if (string.IsNullOrWhiteSpace(style)) throw new ArgumentException("Interior style must be a non-empty string.", nameof(style));
            if (seats <= 0) throw new ArgumentOutOfRangeException(nameof(seats), "Seats must be positive.");

            Style = style;
            Seats = seats;
        }

        public override string ToString() => $"{Style}, {Seats} seats";
    }
}
