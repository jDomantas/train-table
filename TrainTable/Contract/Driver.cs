using System.Collections.Generic;

namespace TrainTable.Contract
{
    public class Driver
    {
        public string Name;
        public List<Assignment> Assignments;
        public HashSet<TrainType> AllowedTrainTypes;
    }
}