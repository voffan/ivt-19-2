using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Yaxel.Classes
{
    enum ComponentType
    {
        [Description("Процессор")]
        CPU,
        [Description("Материнская память")]
        Motherboard,
        [Description("ОЗУ")]
        RAM,
        [Description("Видеокарта")]
        Video,
        [Description("HDD")]
        HDD,
        [Description("SSD")]
        SSD,
        [Description("Сетевая карта")]
        Net
    }
}
