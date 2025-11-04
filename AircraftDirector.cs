using System;

namespace LabWork
{
    // Director orchestrates builder steps for common configurations
    public class AircraftDirector
    {
        private IAircraftBuilder _builder = null!;

        // Magic strings centralized for easier maintenance
        private static readonly string TurboFanX200 = "TurboFan X200";
        private static readonly string TurboFanZ900 = "TurboFan Z900";
        private static readonly string TurbopropH700 = "Turboprop H700";

        /// <summary>
        /// The builder used by the director. Use the setter or <see cref="SetBuilder"/> to assign.
        /// </summary>
        public IAircraftBuilder Builder
        {
            get => _builder;
            private set => _builder = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Explicitly sets the builder with a clearer API call and performs null validation.
        /// </summary>
        /// <param name="builder">The builder to use.</param>
        public void SetBuilder(IAircraftBuilder builder)
        {
            Builder = builder; // setter performs null-check; external callers use this method to set builder
        }

        public void ConstructRegionalPassengerPlane()
        {
            EnsureBuilder();
            // a typical regional passenger configuration
            _builder.Reset();
            _builder.SetEngine(new Engine(TurboFanX200, 120));
            _builder.SetWings(new Wings("High-lift", 28.4));
            _builder.SetInterior(new Interior("Comfort", 80));
        }

        public void ConstructLongHaulPassengerPlane()
        {
            EnsureBuilder();
            _builder.Reset();
            _builder.SetEngine(new Engine(TurboFanZ900, 300));
            _builder.SetWings(new Wings("Sweep", 60.0));
            _builder.SetInterior(new Interior("Lux", 250));
        }

        public void ConstructHeavyCargoPlane()
        {
            EnsureBuilder();
            _builder.Reset();
            _builder.SetEngine(new Engine(TurbopropH700, 180));
            _builder.SetWings(new Wings("Straight - reinforced", 40.0));
            _builder.SetInterior(new Interior("Utility", 4));
        }

        private void EnsureBuilder()
        {
            if (_builder is null) throw new InvalidOperationException("Builder not set on Director.");
        }
    }
}
