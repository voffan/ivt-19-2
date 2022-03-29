using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Yaxel.Classes
{
    enum AttrType
    {
        [Description("Частота")]
        Frequency,
        [Description("Количество ядер")]
        CoreCount,
        [Description("Кэш процессора")]
        CacheSize,
        [Description("Размер кэша")]
        Transistors,
        [Description("Тепловыделение")]
        Heat,
        [Description("Память")]
        MemorySize,
        [Description("Напряжение")]
        Power,
    }

}