using System;

namespace LabWork
{
    /// <summary>
    /// Concrete builder for cargo/utility aircraft.
    /// </summary>
    public sealed class CargoPlaneBuilder : IAircraftBuilder
    {
    private Aircraft _aircraft = new Aircraft();

        public CargoPlaneBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            _aircraft = new Aircraft();
        }

        public void SetEngine(Engine engine)
        {
            if (engine is null) throw new ArgumentNullException(nameof(engine));
            _aircraft.SetEngine(engine);
        }

        public void SetWings(Wings wings)
        {
            if (wings is null) throw new ArgumentNullException(nameof(wings));
            _aircraft.SetWings(wings);
        }

        public void SetInterior(Interior interior)
        {
            if (interior is null) throw new ArgumentNullException(nameof(interior));
            // Cargo planes may have a utilitarian interior; still store it
            _aircraft.SetInterior(interior);
        }

        public Aircraft Build()
        {
            _aircraft.Validate();
            var result = _aircraft;
            Reset();
            return result;
        }
    }
}
