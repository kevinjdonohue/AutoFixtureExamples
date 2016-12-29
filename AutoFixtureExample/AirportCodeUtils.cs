using System;

namespace AutoFixtureExample
{
    public static class AirportCodeUtils
    {
        public static void EnsureValidAirportCode(string airportCode)
        {
            var isWrongLength = airportCode.Length != 3;
            var isWrongCase = airportCode != airportCode.ToUpperInvariant();

            if (isWrongLength || isWrongCase)
            {
                throw new ApplicationException($"{airportCode} is an invalid airport");
            }
        }
    }
}