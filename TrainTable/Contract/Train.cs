using System.Collections.Generic;

namespace TrainTable.Contract
{
    public class Train
    {
        public string Id;
        public List<DateRange> Runs;
        public TrainType Type;
    }
}
