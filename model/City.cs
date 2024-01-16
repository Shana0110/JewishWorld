using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class City:Base
    {
        private string cityName;
        private Country countryCode;

       
        public string CityName { get => cityName; set => cityName = value; }
        public Country CountryCode { get => countryCode; set => countryCode = value; }
    }
}
