using System;
using System.Reflection;
using Ploeh.AutoFixture.Kernel;

namespace AutoFixtureExampleTests.SpecimenBuilders
{
    public class AirportCodeSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            PropertyInfo propertyInfo = request as PropertyInfo;

            if (propertyInfo == null)
            {
                return new NoSpecimen(request);
            }

            bool isAirportPropertyCode = propertyInfo.Name.Contains("AirportCode") 
                                         && propertyInfo.PropertyType == typeof(string);

            if (isAirportPropertyCode)
            {
                return RandomAirportCode();
            }

            return new NoSpecimen(request);
        }

        private string RandomAirportCode()
        {
            if (DateTime.Now.Ticks % 2 == 0)
            {
                return "AAA";
            }

            return "BBB";
        }
    }
}