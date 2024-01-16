using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Places : Base
    {
        private City cityCode;
        private string adress;

      
        public string Adress { get => adress; set => adress = value; }
        public City CityCode { get => cityCode; set => cityCode = value; }
    }
}
