using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class SynagogueList : List<Synagogue>
    {
        public SynagogueList() { }
        public SynagogueList(IEnumerable<Synagogue> list) : base(list) { }
        public SynagogueList(IEnumerable<Base> list) : base(list.Cast<Synagogue>().ToList()) { }
    }
  
 
}
