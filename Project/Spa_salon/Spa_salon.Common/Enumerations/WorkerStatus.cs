using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Enumerations
{
    public enum WorkerStatus
    {
        [Description("Працівник")]
        Worker,
        [Description("Адміністратор")]
        Administrator,
        [Description("Власник")]
        Owner
    }
}
