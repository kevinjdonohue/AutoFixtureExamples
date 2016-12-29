namespace AutoFixtureExample
{
    public class Airport
    {
        private string _airportCode;

        public string AirportCode
        {
            get { return _airportCode; }
            set
            {
                AirportCodeUtils.EnsureValidAirportCode(value);
                _airportCode = value;
            }
        }

        public string AirlineName { get; set; }
    }
}