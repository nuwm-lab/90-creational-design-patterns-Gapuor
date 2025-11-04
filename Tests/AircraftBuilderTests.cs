using System;
using LabWork;
using Xunit;

namespace Tests
{
    public class AircraftBuilderTests
    {
        [Fact]
        public void Director_Constructs_RegionalPassengerPlane()
        {
            var director = new AircraftDirector();
            var builder = new PassengerPlaneBuilder();
            director.SetBuilder(builder);
            director.ConstructRegionalPassengerPlane();
            var aircraft = builder.Build();
            Assert.NotNull(aircraft);
            var s = aircraft.ToString();
            Assert.Contains("TurboFan X200", s);
        }

        [Fact]
        public void Builder_Throws_On_Null_Engine()
        {
            var builder = new PassengerPlaneBuilder();
            Assert.Throws<ArgumentNullException>(() => builder.SetEngine(null!));
        }

        [Fact]
        public void Build_Throws_When_Missing_Parts()
        {
            var builder = new PassengerPlaneBuilder();
            // do not set any parts
            Assert.Throws<InvalidOperationException>(() => builder.Build());
        }
    }
}
