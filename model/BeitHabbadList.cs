using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class BeitHabbadList: List<BeitHabbad>
    {
        public BeitHabbadList() { }
        public BeitHabbadList(IEnumerable<BeitHabbad> list) : base(list) { }
        public BeitHabbadList(IEnumerable<Base> list) : base(list.Cast<BeitHabbad>().ToList()) { }
    }
    
}
