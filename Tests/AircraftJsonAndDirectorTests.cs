using System;
using LabWork;
using Xunit;

namespace Tests
{
    public class AircraftJsonAndDirectorTests
    {
        [Fact]
        public void Aircraft_ToJson_Contains_EngineModel()
        {
            var director = new AircraftDirector();
            var builder = new PassengerPlaneBuilder();
            director.SetBuilder(builder);
            director.ConstructRegionalPassengerPlane();
            var aircraft = builder.Build();

            var json = aircraft.ToJson();
            Assert.Contains("TurboFan X200", json);
            Assert.Contains("Thrust", json);
        }

        [Fact]
        public void Director_Throws_When_Builder_Not_Set()
        {
            var director = new AircraftDirector();
            Assert.Throws<InvalidOperationException>(() => director.ConstructRegionalPassengerPlane());
        }
    }
}
