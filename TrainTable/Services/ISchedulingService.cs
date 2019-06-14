using TrainTable.Contract;

namespace TrainTable.Services
{
    public interface ISchedulingService
    {
        ScheduleResponse GenerateSchedule();
        ScheduleResponse GetSchedule();
        ScheduleResponse GenerateAndSaveSchedule();
        void DeleteAssignment(string assignmentId);
        void AddAssignment(AddAssignmentRequest request);
    }
}
