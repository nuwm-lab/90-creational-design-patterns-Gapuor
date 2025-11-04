using System.Text;

namespace LabWork
{
    // Product class: Aircraft with encapsulated parts
    public class Aircraft
    {
        private Engine _engine;
        private Wings _wings;
        private Interior _interior;

        internal void SetEngine(Engine engine)
        {
            _engine = engine;
        }

        internal void SetWings(Wings wings)
        {
            _wings = wings;
        }

        internal void SetInterior(Interior interior)
        {
            _interior = interior;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Aircraft configuration:");
            sb.AppendLine($" Engine: {_engine}");
            sb.AppendLine($" Wings: {_wings}");
            sb.AppendLine($" Interior: {_interior}");
            return sb.ToString();
        }
    }
}
