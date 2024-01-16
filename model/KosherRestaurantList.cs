using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class KosherRestaurantList: List<KosherRestaurant>
    {
        public KosherRestaurantList() { }
        public KosherRestaurantList(IEnumerable<KosherRestaurant> list) : base(list) { }
        public KosherRestaurantList(IEnumerable<Base> list) : base(list.Cast<KosherRestaurant>().ToList()) { }
    }
    
}
