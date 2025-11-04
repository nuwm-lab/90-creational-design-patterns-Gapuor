namespace LabWork
{
    public class Engine
    {
        public string Model { get; }
        public int Thrust { get; }

        public Engine(string model, int thrust)
        {
            Model = model;
            Thrust = thrust;
        }

        public override string ToString()
        {
            return $"{Model} ({Thrust} kN)";
        }
    }

    public class Wings
    {
        public string Type { get; }
        public double Span { get; }

        public Wings(string type, double span)
        {
            Type = type;
            Span = span;
        }

        public override string ToString()
        {
            return $"{Type}, span {Span} m";
        }
    }

    public class Interior
    {
        public string Style { get; }
        public int Seats { get; }

        public Interior(string style, int seats)
        {
            Style = style;
            Seats = seats;
        }

        public override string ToString()
        {
            return $"{Style}, {Seats} seats";
        }
    }
}
