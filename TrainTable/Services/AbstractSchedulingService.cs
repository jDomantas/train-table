using TrainTable.Contract;
using TrainTable.Repositories;
using System.Linq;
using System;

namespace TrainTable.Services
{
    public abstract class AbstractSchedulingService : ISchedulingService
    {
        protected readonly IRepository<Driver> driverRepository;
        protected readonly IRepository<Train> trainRepository;
        private ScheduleResponse _schedule;

        public AbstractSchedulingService(IRepository<Driver> driverRepository, IRepository<Train> trainRepostory)
        {
            this.driverRepository = driverRepository;
            trainRepository = trainRepostory;
        }

        public ScheduleResponse GenerateAndSaveSchedule()
        {
            return _schedule = GenerateSchedule();
        }

        public ScheduleResponse GetSchedule()
        {
            if (_schedule == null)
            {
                _schedule = GenerateSchedule();
            }
            return _schedule;
        }

        public void DeleteAssignment(string assignmentId)
        {
            var driver = _schedule
                .Drivers
                .Where(d => d.Assignments.Any(a => a.Id == assignmentId))
                .FirstOrDefault();
            if (driver == null) return;
            driver.Assignments.RemoveAll(a => a.Id == assignmentId);
        }

        public void AddAssignment(AddAssignmentRequest request)
        {
            var driver = _schedule
                .Drivers
                .Where(d => d.Name == request.DriverId)
                .FirstOrDefault();
            if (driver == null)
            {
                throw new Exception("Driver with the specified ID was not found");
            }
            var trainType =
                _schedule.Drivers
                    .SelectMany(d => d.Assignments)
                    .Concat(_schedule.Unassigned)
                    .Where(a => a.TrainId == request.TrainId)
                    .Select(a => (TrainType?)a.TrainType)
                    .FirstOrDefault();

            if (!trainType.HasValue)
            {
                throw new Exception("Train with the specified ID was not found");
            }
                    
            driver.Assignments.Add(new Assignment
            {
                Id = Assignment.NextId(),
                TrainId = request.TrainId,
                TrainType = trainType.Value,
                Range = request.Range
            });
        }

        public abstract ScheduleResponse GenerateSchedule();
    }
}
