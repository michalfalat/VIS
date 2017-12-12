using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dopravio.Models
{

    public enum VehicleStatus
    {
        IN_USE = 0,
        FREE = 1,
        IN_REPAIR = 2,
        DISCARDED = 3

    };

    public enum RequestState
    {
        NEW = 1,
        INPROGRESS = 2,
        ACCEPTED = 3,
        DECLINED = 4
    }

    public enum RequestType
    {
        BUY = 1,
        SELL = 2,
        OTHER = 0,
    }

    public enum FailureType
    {
        ACCIDENT = 1,
        VEHICLE_DAMAGE = 2,
        FUEL_PROBLEM = 3,
        OTHER = 0,
    }

}
