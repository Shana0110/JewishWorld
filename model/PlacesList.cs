using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class PlacesList:List<Places>
    {
        public PlacesList() { }
        public PlacesList(IEnumerable<Places> list) : base(list) { }
        public PlacesList(IEnumerable<Base> list) : base(list.Cast<Places>().ToList()) { }
    }
   
}
