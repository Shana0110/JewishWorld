using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class CritiqueList : List<Critique>
    {
        public CritiqueList() { }
        public CritiqueList(IEnumerable<Critique> list) : base(list) { }
        public CritiqueList(IEnumerable<Base> list) : base(list.Cast<Critique>().ToList()) { }
    }
}
