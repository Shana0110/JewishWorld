using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Synagogue : Places
    {
        private TimeOnly openHour;
        private TimeOnly closeHour;

        public TimeOnly OpenHour { get => openHour; set => openHour = value; }
        public TimeOnly CloseHour { get => closeHour; set => closeHour = value; }
    }
}
