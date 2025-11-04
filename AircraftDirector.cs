using System;

namespace LabWork
{
    // Director orchestrates builder steps for common configurations
    public class AircraftDirector
    {
        private IAircraftBuilder _builder;

        /// <summary>
        /// The builder used by the director. Use the setter or <see cref="SetBuilder"/> to assign.
        /// </summary>
        public IAircraftBuilder Builder
        {
            get => _builder;
            set => _builder = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Explicitly sets the builder with a clearer API call and performs null validation.
        /// </summary>
        /// <param name="builder">The builder to use.</param>
        public void SetBuilder(IAircraftBuilder builder)
        {
            Builder = builder; // setter performs null-check
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
