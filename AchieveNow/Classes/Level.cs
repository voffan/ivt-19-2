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
        Муниципальный = 300,
        Районный = 250,
        Региональный = 200,
        Межрегиональный = 150,
        Всенародный = 100,
        Международный = 50,
        Всемирный = 10
    }
}
