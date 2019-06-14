using TrainTable.Contract;
using TrainTable.Repositories;
using System.Linq;
using System;
using TrainTable.Utils;
using TrainTable.Validators;

namespace TrainTable.Services
{
    public abstract class AbstractSchedulingService : ISchedulingService
    {
        protected readonly IRepository<Driver> driverRepository;
        protected readonly IRepository<Train> trainRepository;
        protected readonly IChecker checker;
        private ScheduleResponse _schedule;

        public AbstractSchedulingService(IRepository<Driver> driverRepository, IRepository<Train> trainRepository, IChecker checker)
        {
            this.driverRepository = driverRepository;
            this.trainRepository = trainRepository;
            this.checker = checker;
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
            var driver = GetSchedule()
                .Drivers
                .Where(d => d.Assignments.Any(a => a.Id == assignmentId))
                .FirstOrDefault();
            if (driver == null) return;
            var assignment = driver.Assignments.Where(a => a.Id == assignmentId).FirstOrDefault();
            if (assignment == null) return;
            driver.Assignments.Remove(assignment);
            _schedule.Unassigned.Add(assignment);
        }

        public void MoveAssignment(string assignmentId, string driverId)
        {
            var driver = GetSchedule()
                .Drivers
                .Where(d => d.Name == driverId)
                .FirstOrDefault();
            if (driver == null)
            {
                throw new Exception("Driver with the specified ID was not found");
            }
            var assignments =
                _schedule
                    .Drivers
                    .SelectMany(d => d.Assignments)
                    .Select(a => (a, true))
                    .Concat(_schedule.Unassigned.Select(a => (a, false)))
                    .Where(t => t.Item1.Id == assignmentId);

            if (assignments.Count() == 0)
            {
                throw new Exception("Assignment with specified ID was not found");
            }

            var assignmentTuple = assignments.First();
            var assignment = assignmentTuple.Item1;
            var isAssigned = assignmentTuple.Item2;

            var originalSchedule = _schedule.DeepClone();
            
            if (isAssigned)
            {
                _schedule.Drivers.ForEach(d => d.Assignments.Remove(assignment));
            }
            else
            {
                _schedule.Unassigned.Remove(assignment);
            }
            driver.Assignments.Add(assignment);


            try
            {
                checker.Check(_schedule);
            }
            catch (ValidationException e)
            {
                _schedule = originalSchedule;
                throw e;
            }
        }

        public abstract ScheduleResponse GenerateSchedule();
    }
}
