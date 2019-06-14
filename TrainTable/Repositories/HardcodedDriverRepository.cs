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
                    Name = "Edgaras U. - 6148",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Electric
                    }
                },
                new Driver()
                {
                    Name = "Tomas J. - 6215",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Diesel
                    }
                },
                new Driver()
                {
                    Name = "Nida S - 6149",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Diesel,
                        TrainType.Electric
                    }
                },
                new Driver()
                {
                    Name = "Gintarė M. - 6176",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Electric
                    }
                },
                new Driver()
                {
                    Name = "Jolanta D. - 6205",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Electric,
                        TrainType.Diesel
                    }
                },
                new Driver()
                {
                    Name = "Rima V. - 6159",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Electric
                    }
                },
                new Driver()
                {
                    Name = "Vasiliy K. - 8704",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Electric,
                        TrainType.Diesel
                    }
                },
                new Driver()
                {
                    Name = "Simas T. - 6219",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Electric,
                        TrainType.Diesel
                    }
                },
                new Driver()
                {
                    Name = "Marius M. - 6162",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Diesel
                    }
                },
                new Driver()
                {
                    Name = "Toma M. - 8771",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Diesel
                    }
                },
                new Driver()
                {
                    Name = "Edgars D. - 6179",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Electric,
                        TrainType.Diesel
                    }
                },
                new Driver()
                {
                    Name = "Thommas M. - 6163",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Diesel
                    }
                },
                new Driver()
                {
                    Name = "Viktorija Č. - 6203",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Diesel
                    }
                },
                new Driver()
                {
                    Name = "Nijolė A. - 6193",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Diesel
                    }
                },
                new Driver()
                {
                    Name = "Thommas M. - 6213",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Diesel
                    }
                },
                new Driver()
                {
                    Name = "Agnė V. - 6164",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Electric
                    }
                },
                new Driver()
                {
                    Name = "Gregorijus A. - 6181",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Electric
                    }
                },
                new Driver()
                {
                    Name = "Linas V. - 6174",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Diesel
                    }
                },
                new Driver()
                {
                    Name = "Karolis D. - 6178",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Electric
                    }
                },
                new Driver()
                {
                    Name = "Mantas M. - 2369",
                    AllowedTrainTypes = new HashSet<TrainType>()
                    {
                        TrainType.Diesel
                    }
                }
            };
        }
    }
}