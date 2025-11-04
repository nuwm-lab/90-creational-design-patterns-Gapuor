using System;

namespace LabWork
{
    /// <summary>
    /// Concrete builder for passenger aircraft.
    /// </summary>
    public sealed class PassengerPlaneBuilder : IAircraftBuilder
    {
        private Engine? _engine;
        private Wings? _wings;
        private Interior? _interior;

        public void Reset()
        {
            _engine = null;
            _wings = null;
            _interior = null;
        }

        public void SetEngine(Engine engine)
        {
            _engine = engine ?? throw new ArgumentNullException(nameof(engine));
        }

        public void SetWings(Wings wings)
        {
            _wings = wings ?? throw new ArgumentNullException(nameof(wings));
        }

        public void SetInterior(Interior interior)
        {
            _interior = interior ?? throw new ArgumentNullException(nameof(interior));
        }

        public Aircraft Build()
        {
            if (_engine is null) throw new InvalidOperationException("Aircraft missing engine.");
            if (_wings is null) throw new InvalidOperationException("Aircraft missing wings.");
            if (_interior is null) throw new InvalidOperationException("Aircraft missing interior.");

            var result = new Aircraft(_engine, _wings, _interior);
            Reset();
            return result;
        }
    }
}
