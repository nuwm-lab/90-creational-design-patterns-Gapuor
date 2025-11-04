using System;

namespace LabWork
{
    /// <summary>
    /// Director orchestrates builder steps for common aircraft configurations.
    /// Use <see cref="SetBuilder"/> to provide a concrete builder before calling Construct* methods.
    /// </summary>
    public class AircraftDirector
    {
    private IAircraftBuilder? _builder;

    // Magic strings centralized for easier maintenance
    private const string TurboFanX200 = "TurboFan X200";
    private const string TurboFanZ900 = "TurboFan Z900";
    private const string TurbopropH700 = "Turboprop H700";

        /// <summary>
        /// The builder used by the director. External code should call <see cref="SetBuilder"/> to assign.
        /// </summary>
        public IAircraftBuilder Builder
        {
            get => _builder ?? throw new InvalidOperationException("Builder not set on Director.");
            private set => _builder = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Assigns the builder the director will use. Performs null validation.
        /// </summary>
        /// <param name="builder">A concrete <see cref="IAircraftBuilder"/> to use.</param>
        public void SetBuilder(IAircraftBuilder builder)
        {
            Builder = builder; // setter performs null-check; external callers use this method to set builder
        }

        /// <summary>
        /// Construct a regional passenger aircraft by orchestrating builder steps.
        /// </summary>
        public void ConstructRegionalPassengerPlane()
        {
            EnsureBuilder();
            // a typical regional passenger configuration
            Builder.Reset();
            Builder.SetEngine(new Engine(TurboFanX200, 120));
            Builder.SetWings(new Wings("High-lift", 28.4));
            Builder.SetInterior(new Interior("Comfort", 80));
        }

        /// <summary>
        /// Construct a long-haul passenger aircraft.
        /// </summary>
        public void ConstructLongHaulPassengerPlane()
        {
            EnsureBuilder();
            Builder.Reset();
            Builder.SetEngine(new Engine(TurboFanZ900, 300));
            Builder.SetWings(new Wings("Sweep", 60.0));
            Builder.SetInterior(new Interior("Lux", 250));
        }

        /// <summary>
        /// Construct a heavy cargo aircraft.
        /// </summary>
        public void ConstructHeavyCargoPlane()
        {
            EnsureBuilder();
            Builder.Reset();
            Builder.SetEngine(new Engine(TurbopropH700, 180));
            Builder.SetWings(new Wings("Straight - reinforced", 40.0));
            Builder.SetInterior(new Interior("Utility", 4));
        }

        private void EnsureBuilder()
        {
            if (_builder is null) throw new InvalidOperationException("Builder not set on Director.");
        }
    }
}
