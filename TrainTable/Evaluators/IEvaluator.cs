using TrainTable.Contract;

namespace TrainTable.Evaluators
{
    public interface IEvaluator
    {
        double Evaluate(ScheduleResponse response);
    }
}
