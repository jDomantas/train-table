using NodaTime;
using System.Linq;
using TrainTable.Contract;
using static TrainTable.Utils.ListUtils;

namespace TrainTable.Evaluators
{
    public class DispersionEvaluator : IEvaluator
    {
        public double Evaluate(ScheduleResponse response)
        {
            var workTimeDispersion =
                response.Drivers
                .Select(d => d.TotalWorkTime.TotalHours)
                .Dispersion();

            var nightTimeDisperion = response.Drivers
                .Select(d => d.TimeInNightShift.TotalHours)
                .Dispersion();

            double totalTime = response.Drivers.Aggregate(Duration.Zero, (a, b) => a + b.TotalWorkTime).TotalHours;
            double totalNightTime = response.Drivers.Aggregate(Duration.Zero, (a, b) => a + b.TimeInNightShift).TotalHours;

            //return workTimeDispersion + nightTimeDisperion;
            double scale = 1;
            if (totalTime != 0)
                scale = totalNightTime / totalTime;

            return workTimeDispersion + nightTimeDisperion / scale;
        }
    }
}
