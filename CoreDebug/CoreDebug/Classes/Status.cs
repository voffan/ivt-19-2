using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDebug.Classes
{
    public enum Status
    {
       InExpo,
       InStorage,
       InRecovery
    }
}