using TrainTable.Contract;

namespace TrainTable.Validators
{
    public interface IChecker
    {
        void Check(ScheduleResponse response);
    }
}
