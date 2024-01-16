using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class RatingList : List<Rating>
    {
        public RatingList() { }
        public RatingList(IEnumerable<Rating> list) : base(list) { }
        public RatingList(IEnumerable<Base> list) : base(list.Cast<Rating>().ToList()) { }


    }
   
}
