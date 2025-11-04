namespace LabWork
{
    public class PassengerPlaneBuilder : IAircraftBuilder
    {
        private Aircraft _aircraft;

        public PassengerPlaneBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            _aircraft = new Aircraft();
        }

        public void SetEngine(Engine engine)
        {
            if (engine is null) throw new System.ArgumentNullException(nameof(engine));
            _aircraft.SetEngine(engine);
        }

        public void SetWings(Wings wings)
        {
            if (wings is null) throw new System.ArgumentNullException(nameof(wings));
            _aircraft.SetWings(wings);
        }

        public void SetInterior(Interior interior)
        {
            if (interior is null) throw new System.ArgumentNullException(nameof(interior));
            _aircraft.SetInterior(interior);
        }

        public Aircraft Build()
        {
            // Validate assembled aircraft before returning
            _aircraft.Validate();
            var result = _aircraft;
            Reset();
            return result;
        }
    }
}
