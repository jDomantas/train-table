using NodaTime;
using System.Linq;
using TrainTable.Contract;
using static TrainTable.Utils.ListUtils;

namespace TrainTable.Evaluators
{
    public class StandardDeviationEvaluator : IEvaluator
    {
        public double Evaluate(ScheduleResponse response)
        {
            double totalTime = response.Drivers.Aggregate(Duration.Zero, (a, b) => a + b.TotalWorkTime).TotalHours;
            double totalNightTime = response.Drivers.Aggregate(Duration.Zero, (a, b) => a + b.TimeInNightShift).TotalHours;

            double scale = 1;
            if (totalTime != 0)
                scale = totalNightTime / totalTime;

            var workTimeDeviation =
                response.Drivers
                .Select(d => d.TotalWorkTime.TotalHours)
                .StandardDeviation();

            var nightTimeDeviation = response.Drivers
                .Select(d => d.TimeInNightShift.TotalHours)
                .Select(t => t / scale)
                .StandardDeviation();

            return workTimeDeviation + nightTimeDeviation;
        }
    }
}
