using System;

namespace LabWork
{
    // Director orchestrates builder steps for common configurations
    public class AircraftDirector
    {
        private IAircraftBuilder _builder;

        /// <summary>
        /// Set the builder to use by the director.
        /// </summary>
        public IAircraftBuilder Builder
        {
            set => _builder = value ?? throw new ArgumentNullException(nameof(value));
        }

        public void ConstructRegionalPassengerPlane()
        {
            EnsureBuilder();
            // a typical regional passenger configuration
            _builder.Reset();
            _builder.SetEngine(new Engine("TurboFan X200", 120));
            _builder.SetWings(new Wings("High-lift", 28.4));
            _builder.SetInterior(new Interior("Comfort", 80));
        }

        public void ConstructLongHaulPassengerPlane()
        {
            EnsureBuilder();
            _builder.Reset();
            _builder.SetEngine(new Engine("TurboFan Z900", 300));
            _builder.SetWings(new Wings("Sweep", 60.0));
            _builder.SetInterior(new Interior("Lux", 250));
        }

        public void ConstructHeavyCargoPlane()
        {
            EnsureBuilder();
            _builder.Reset();
            _builder.SetEngine(new Engine("Turboprop H700", 180));
            _builder.SetWings(new Wings("Straight - reinforced", 40.0));
            _builder.SetInterior(new Interior("Utility", 4));
        }

        private void EnsureBuilder()
        {
            if (_builder is null) throw new InvalidOperationException("Builder not set on Director.");
        }
    }
}
