namespace LabWork
{
    public interface IAircraftBuilder
    {
        void Reset();
        void SetEngine(Engine engine);
        void SetWings(Wings wings);
        void SetInterior(Interior interior);
        Aircraft Build();
    }
}
