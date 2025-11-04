using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LabWork
{
    /// <summary>
    /// Product class that represents a constructed aircraft.
    /// Parts are encapsulated and can only be set by builders in the same assembly.
    /// </summary>
    public class Aircraft
    {
    private Engine? _engine;
    private Wings? _wings;
    private Interior? _interior;

        internal void SetEngine(Engine engine)
        {
            _engine = engine ?? throw new ArgumentNullException(nameof(engine));
        }

        internal void SetWings(Wings wings)
        {
            _wings = wings ?? throw new ArgumentNullException(nameof(wings));
        }

        internal void SetInterior(Interior interior)
        {
            _interior = interior ?? throw new ArgumentNullException(nameof(interior));
        }

        internal void Validate()
        {
            if (_engine is null)
            {
                throw new InvalidOperationException("Aircraft missing engine.");
            }

            if (_wings is null)
            {
                throw new InvalidOperationException("Aircraft missing wings.");
            }

            if (_interior is null)
            {
                throw new InvalidOperationException("Aircraft missing interior.");
            }
        }

        /// <summary>
        /// Returns a human-readable description of the aircraft.
        /// This method validates the built state and will throw if parts are missing.
        /// </summary>
        public override string ToString()
        {
            // Protect against accidental use of incomplete product
            Validate();

            var sb = new StringBuilder();
            sb.AppendLine("Aircraft configuration:");
            sb.AppendLine($" Engine: {_engine}");
            sb.AppendLine($" Wings: {_wings}");
            sb.AppendLine($" Interior: {_interior}");
            return sb.ToString();
        }

        /// <summary>
        /// Returns a JSON representation of the aircraft (read-only snapshot).
        /// </summary>
        public string ToJson()
        {
            Validate();

            var dto = new
            {
                Engine = new { Model = _engine!.Model, Thrust = _engine!.Thrust },
                Wings = new { Type = _wings!.WingType, Span = _wings!.Span },
                Interior = new { Style = _interior!.Style, Seats = _interior!.Seats }
            };

            return JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
