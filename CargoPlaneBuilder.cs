namespace LabWork
{
    public class CargoPlaneBuilder : IAircraftBuilder
    {
        private Aircraft _aircraft;

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
            _aircraft.SetEngine(engine);
        }

        public void SetWings(Wings wings)
        {
            _aircraft.SetWings(wings);
        }

        public void SetInterior(Interior interior)
        {
            // Cargo planes may have a utilitarian interior; still store it
            _aircraft.SetInterior(interior);
        }

        public Aircraft Build()
        {
            var result = _aircraft;
            Reset();
            return result;
        }
    }
}
