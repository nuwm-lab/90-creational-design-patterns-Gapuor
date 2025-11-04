namespace LabWork
{
    /// <summary>
    /// Builder interface for constructing <see cref="Aircraft"/> instances.
    /// </summary>
    public interface IAircraftBuilder
    {
        /// <summary>Reset builder to initial state.</summary>
        void Reset();

        /// <summary>Set engine for the aircraft. Throws <see cref="ArgumentNullException"/> when engine is null.</summary>
        void SetEngine(Engine engine);

        /// <summary>Set wings for the aircraft. Throws <see cref="ArgumentNullException"/> when wings is null.</summary>
        void SetWings(Wings wings);

        /// <summary>Set interior for the aircraft. Throws <see cref="ArgumentNullException"/> when interior is null.</summary>
        void SetInterior(Interior interior);

        /// <summary>Finalize and return the constructed aircraft; may throw InvalidOperationException when parts missing.</summary>
        Aircraft Build();
    }
}
