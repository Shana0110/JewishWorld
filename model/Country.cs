using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Country:Base
    {
        private string countryName;

        public string CountryName { get => countryName; set => countryName = value; }
    }
}
