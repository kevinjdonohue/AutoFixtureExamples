using System;
using System.Collections.Generic;

namespace AutoFixtureExample
{
    public class FlightDetails
    {
        private string _arrivalAirportCode;
        private string _departureAirportCode;

        public TimeSpan FlightDuration { get; set; }
        public string AirlineName { get; set; }
        public List<string> MealOptions { get; set; }

        public FlightDetails()
        {
            MealOptions = new List<string>();
        }

        public string DepartureAirportCode
        {
            get { return _departureAirportCode; }
            set
            {
                AirportCodeUtils.EnsureValidAirportCode(value);
                _departureAirportCode = value;
            }
        }

        public string ArrivalAirportCode
        {
            get { return _arrivalAirportCode; }
            set
            {
                AirportCodeUtils.EnsureValidAirportCode(value);
                _arrivalAirportCode = value;
            }
        }


    }
}