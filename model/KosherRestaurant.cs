using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class KosherRestaurant : Places   
    {
        private string telephone;
        private string typeOfFood;
        private string name;

        public string Telephone { get => telephone; set => telephone = value; }
        public string TypeOfFood { get => typeOfFood; set => typeOfFood = value; }
        public string Name { get => name; set => name = value; }
    }
}
