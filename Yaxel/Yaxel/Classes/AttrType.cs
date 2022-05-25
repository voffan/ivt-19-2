using System.ComponentModel;

namespace Yaxel.Classes
{
    enum AttrType
    {
        [Description("Частота")]
        Frequency,
        [Description("Количество ядер")]
        CoreCount,
        [Description("Размер кэша")]
        CacheSize,
        [Description("Количество транзисторов")]
        Transistors,
        [Description("Тепловыделение")]
        TDP,
        [Description("Память")]
        MemorySize,
        [Description("Напряжение")]
        Power,
        [Description("Тип памяти")]
        MemoryType,
        [Description("Скорость вращения")]
        SpinRate
    }

}