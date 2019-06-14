using System;
using System.Collections.Generic;

namespace TrainTable.Contract
{
    [Serializable]
    public class Train
    {
        public string Id;
        public List<DateRange> Runs;
        public TrainType Type;
    }
}
