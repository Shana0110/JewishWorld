using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class PopularPlacesList: List<PopularPlace>
    {
        public PopularPlacesList() { }
        public PopularPlacesList(IEnumerable<PopularPlace> list) : base(list) { }
        public PopularPlacesList(IEnumerable<Base> list) : base(list.Cast<PopularPlace>().ToList()) { }
    }
  
}
