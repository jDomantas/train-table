using System.Collections.Generic;
using TrainTable.Contract;

namespace TrainTable.Repositories
{
    public class HardcodedDriverRepository : IRepository<Driver>
    {
        public IEnumerable<Driver> GetAll()
        {
            return new List<Driver>()
            {
                new Driver()
                {
                    Name = "Driver 1",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Electric
                    }
                },
                new Driver()
                {
                    Name = "Driver 2",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Diesel
                    }
                },
                new Driver()
                {
                    Name = "Driver 3",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Diesel,
                        TrainType.Electric
                    }
                },
                new Driver()
                {
                    Name = "Driver 4",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Electric
                    }
                },
                new Driver()
                {
                    Name = "Driver 5",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Electric,
                        TrainType.Diesel
                    }
                },
                new Driver()
                {
                    Name = "Driver 6",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Electric
                    }
                },
                new Driver()
                {
                    Name = "Driver 7",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Electric,
                        TrainType.Diesel
                    }
                },
                new Driver()
                {
                    Name = "Driver 8",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Diesel
                    }
                },
                new Driver()
                {
                    Name = "Driver 9",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Diesel
                    }
                }
            };
        }
    }
}
