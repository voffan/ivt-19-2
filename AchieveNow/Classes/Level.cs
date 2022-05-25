using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AchieveNow.Classes
{
    public enum Level
    {
        Муниципальный = 10,
        Районный = 50,
        Региональный = 100,
        Межрегиональный = 150,
        Всенародный = 200,
        Международный = 250,
        Всемирный = 300
    }
}
