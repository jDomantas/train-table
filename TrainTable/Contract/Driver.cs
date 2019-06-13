using NodaTime;
using System.Collections.Generic;
using System.Linq;

namespace TrainTable.Contract
{
    public class Driver
    {
        public string Name;
        public List<Assignment> Assignments;
        public HashSet<TrainType> AllowedTrainTypes;

        public Duration TotalWorkTime => Assignments.Aggregate(Duration.Zero, (a, b) => a + b.Range.Duration);
        public int WorkDays => Assignments.Select(assignment => assignment.Range.Day).Distinct().Count();
        public Duration TimeInNightShift => Assignments.Aggregate(Duration.Zero, (a, b) => a + b.Range.TimeInNightShift);
    }
}