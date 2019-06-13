using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTable.Contract;

namespace TrainTable.Validators
{
    public interface IChecker
    {
        void Check(ScheduleResponse response);
    }
}
