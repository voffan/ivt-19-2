using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Yaxel.Classes
{
    enum Status
    {
        [Description("Работает")]
        Works,
        [Description("В ремонте")]
        InRepair,
        [Description("Не работает")]
        WritterOff
    }
}
