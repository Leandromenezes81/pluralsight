using AutoFixture;
using System;
using Xunit;

namespace DemoCode.Tests
{
    public class CustomizeFixtureDemos
    {
        [Fact]
        public void Error()
        {
            // arrange
            var fixture = new Fixture();

            // Especifying the return format
            fixture.Inject("LHR");

            var flight = fixture.Create<FlightDetails>();

            // etc.
        }

        [Fact]
        public void SettingValueForCustomType()
        {
            // arrange
            var fixture = new Fixture();

            // This method assigns the same values to the two fixture references created. 
            fixture.Inject(new FlightDetails
            {
                DepartureAirportCode = "PER",
                ArrivalAirportCode = "LHR",
                FlightDuration = TimeSpan.FromHours(10),
                AirlineName = "Awesome Aero"
            });


            var flight1 = fixture.Create<FlightDetails>();
            var flight2 = fixture.Create<FlightDetails>();

            // etc.
        }

        [Fact]
        public void CustomCreationFunction()
        {
            // arrange
            var fixture = new Fixture();

            // This method assigns different values to the two fixture references created.
            fixture.Register(() => DateTime.Now.Ticks.ToString());

            var string1 = fixture.Create<string>();
            var string2 = fixture.Create<string>();

            // etc.
        }

        [Fact]
        public void FreezingValues()
        {
            var fixture = new Fixture();

            //var id = fixture.Create<int>();
            //fixture.Inject(id);

            //var customerName = fixture.Create<string>();
            //fixture.Inject(customerName);

            var id = fixture.Freeze<int>();
            var customerName = fixture.Freeze<string>();

            var sut = fixture.Create<Order>();

            Assert.Equal(id + "-" + customerName, sut.ToString());
        }

        // This method buid a 'FlygtDetails' object without especifics properties,
        // like 'ArrivalAirportCode' and 'DepartureAirportCode'.
        [Fact]
        public void OmitSettingSpecificProperties()
        {
            // arrange
            var fixture = new Fixture();

            var flight = fixture.Build<FlightDetails>()
                                .Without(x => x.ArrivalAirportCode)
                                .Without(x => x.DepartureAirportCode)
                                .Create();

            // etc.
        }

        // This method buid a 'FlygtDetails' object without all properties (null).
        [Fact]
        public void OmitSettingAllProperties()
        {
            var fixture = new Fixture();

            var flight = fixture.Build<FlightDetails>()
                                .OmitAutoProperties()
                                .Create();
        }

        // This method buid a 'FlygtDetails' object setting especifics properties
        [Fact]
        public void CustomizedBuilding()
        {
            var fixture = new Fixture();

            var flight = fixture.Build<FlightDetails>()
                                .With(x => x.ArrivalAirportCode, "LAX")
                                .With(x => x.DepartureAirportCode, "LHR")
                                .Create();
        }

        [Fact]
        public void CustomizedBuildingWithActions()
        {
            var fixture = new Fixture();

            var flight = fixture.Build<FlightDetails>()
                .With(x => x.DepartureAirportCode, "LHR")
                .With(x => x.ArrivalAirportCode, "LAX")
                .Without(x => x.MealOptions)
                .Do(x => x.MealOptions.Add("Chicken"))
                .Do(x => x.MealOptions.Add("Fish"))
                .Create();
        }

        // This method specifies how 'FlightDetails' instances will be created.
        [Fact]
        public void CustomizedBuildingForAllTypesInFixture()
        {
            var fixture = new Fixture();

            fixture.Customize<FlightDetails>(fd =>
                fd.With(x => x.DepartureAirportCode, "LHR")
                  .With(x => x.ArrivalAirportCode, "LAX")
                  .With(x => x.AirlineName, "Fly Fly Premium Air")
                  .Without(x => x.MealOptions)
                  .Do(x => x.MealOptions.Add("Chicken"))
                  .Do(x => x.MealOptions.Add("Fish"))); // notice no .Create() is required here)

            var flight1 = fixture.Create<FlightDetails>();
            var flight2 = fixture.Create<FlightDetails>();
        }
    }
}
