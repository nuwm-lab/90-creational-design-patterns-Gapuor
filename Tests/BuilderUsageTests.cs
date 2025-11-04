using System;
using Xunit;

namespace LabWork.Tests
{
    public class BuilderUsageTests
    {
        [Fact]
        public void DirectBuilderUsage_WithoutDirector_CreatesValidAircraft()
        {
            // Arrange
            var builder = new PassengerPlaneBuilder();
            
            // Act - build aircraft directly without Director
            builder.SetEngine(new Engine("Test Engine", 100));
            builder.SetWings(new Wings("Test Wings", 30.0));
            builder.SetInterior(new Interior("Test Interior", 50));
            
            var aircraft = builder.Build();
            
            // Assert
            Assert.NotNull(aircraft);
            var json = aircraft.ToJson();
            Assert.Contains("Test Engine", json);
            Assert.Contains("Test Wings", json);
            Assert.Contains("Test Interior", json);
        }

        [Fact]
        public void BuildWithoutRequiredParts_ThrowsInvalidOperationException()
        {
            // Arrange
            var builder = new PassengerPlaneBuilder();
            
            // Act/Assert - try to build without setting any parts
            var ex = Assert.Throws<InvalidOperationException>(() => builder.Build());
            Assert.Equal("Aircraft missing engine.", ex.Message);
            
            // Set only engine
            builder.SetEngine(new Engine("Test Engine", 100));
            ex = Assert.Throws<InvalidOperationException>(() => builder.Build());
            Assert.Equal("Aircraft missing wings.", ex.Message);
            
            // Set wings but no interior
            builder.SetWings(new Wings("Test Wings", 30.0));
            ex = Assert.Throws<InvalidOperationException>(() => builder.Build());
            Assert.Equal("Aircraft missing interior.", ex.Message);
        }

        [Fact]
        public void Reset_ClearsAllParts()
        {
            // Arrange
            var builder = new CargoPlaneBuilder();
            builder.SetEngine(new Engine("Test Engine", 100));
            builder.SetWings(new Wings("Test Wings", 30.0));
            builder.SetInterior(new Interior("Test Interior", 4));
            
            // Act
            builder.Reset();
            
            // Assert - should throw because all parts were cleared
            Assert.Throws<InvalidOperationException>(() => builder.Build());
        }
    }
}