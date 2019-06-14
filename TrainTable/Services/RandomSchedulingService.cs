﻿using System;
using System.Collections.Generic;
using System.Linq;
using TrainTable.Contract;
using TrainTable.Utils;
using TrainTable.Validators;

namespace TrainTable.Services
{
    public class RandomSchedulingService : ISchedulingService
    {
        private readonly IChecker _checker;

        public RandomSchedulingService(IChecker checker)
        {
            _checker = checker;
        }

        public ScheduleResponse Schedule(List<Train> trains, List<Driver> drivers)
        {
            var trainType = trains.ToDictionary(t => t.Id, t => t.Type);

            var assignments = trains
                .SelectMany(t => t.Runs.Select(r => new Assignment { TrainId = t.Id, Range = r, TrainType=t.Type }))
                .OrderBy(a => a.Range.ExactFrom)
                .ToList();

            drivers = drivers.Select(d => new Driver
            {
                AllowedTrainTypes = d.AllowedTrainTypes,
                Assignments = new List<Assignment>(),
                Name = d.Name
            }).ToList();

            var unassigned = new List<Assignment>();

            var random = new Random(42);

            foreach (var a in assignments)
            {
                var assigned = false;
                drivers.Shuffle(random);
                foreach (var driver in drivers)
                {
                    if (!driver.AllowedTrainTypes.Contains(trainType[a.TrainId]))
                        continue;

                    driver.Assignments.Add(a);
                    if (IsValid(drivers))
                    {
                        assigned = true;
                        break;
                    }
                    else
                    {
                        driver.Assignments.RemoveAt(driver.Assignments.Count - 1);
                    }
                }

                if (!assigned)
                    unassigned.Add(a);
            }

            return new ScheduleResponse
            {
                Drivers = drivers,
                Unassigned = unassigned,
            };
        }

        private bool IsValid(List<Driver> drivers)
        {
            Action check = () => _checker.Check(new ScheduleResponse
            {
                Drivers = drivers,
                Unassigned = new List<Assignment>(),
            });

            return !check.Throws<ValidationException>();
        }
    }
}