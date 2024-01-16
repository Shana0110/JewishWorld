using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Rating:Base
    {
        private PopularPlace idPopularPlace;
        private int rate;

        public PopularPlace IdPopularPlace { get => idPopularPlace; set => idPopularPlace = value; }
        public int Rate { get => rate; set => rate = value; }
    }
}
