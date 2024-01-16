using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Critique: Base
    {
        private PopularPlace idPopularPlace;
        private DateTime dateCr;
        private string critiques;

        public PopularPlace IdPopularPlace { get => idPopularPlace; set => idPopularPlace = value; }
        public DateTime DateCr { get => dateCr; set => dateCr = value; }
        public string Critiques { get => critiques; set => critiques = value; }
    }
}
