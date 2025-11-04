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
    public sealed class Aircraft
    {
        private readonly Engine _engine;
        private readonly Wings _wings;
        private readonly Interior _interior;

        /// <summary>
        /// Creates a new Aircraft with all required parts.
        /// Internal to ensure only builders in this assembly can create instances.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when any part is null.</exception>
        internal Aircraft(Engine engine, Wings wings, Interior interior)
        {
            _engine = engine ?? throw new ArgumentNullException(nameof(engine));
            _wings = wings ?? throw new ArgumentNullException(nameof(wings));
            _interior = interior ?? throw new ArgumentNullException(nameof(interior));
        }

        private void Validate()
        {
            // Since constructor validates, this should never happen unless reflection is used
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
