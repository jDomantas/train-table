using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using TrainTable.Contract;

namespace TrainTable.Repositories
{
    public class HardcodedTrainRepository : IRepository<Train>
    {
        public IEnumerable<Train> GetAll()
        {
            return new List<Train>()
            {
                new Train()
                {
                    Id = "D911 Turmantas - Vilnius", // Same time every day
                    Type = TrainType.Diesel,
                    Runs = ParseAll(
                        "3-0430-0633",
                        "4-0430-0633",
                        "5-0430-0633"
                    )
                },
                new Train()
                {
                    Id = "M659 Kena - Vilnius",
                    Type = TrainType.Electric,
                    Runs = ParseAll(
                        "3-1405-1441",
                        "4-1405-1441",
                        "5-1405-1441"
                    )
                },
                new Train()
                {
                    Id = "M967 Vilnius - Oro uostas",
                    Type = TrainType.Electric,
                    Runs = ParseAll(
                        "3-1240-1247",
                        "4-1240-1247"
                    )
                },
                new Train()
                {
                    Id = "D646 Marcinkonys - Vilnius",
                    Type = TrainType.Diesel,
                    Runs = ParseAll(
                        "3-0809-1005",
                        "4-1955-2127",
                        "5-1739-1908"
                    )
                },
                new Train() // Has runs only on a single day
                {
                    Id = "D692 Kybartai - Kaunas",
                    Type = TrainType.Diesel,
                    Runs = ParseAll(
                        "4-1002-1129"
                    )
                },
                new Train() // Has only night runs
                {
                    Id = "M657 Kena - Vilnius",
                    Type = TrainType.Diesel,
                    Runs = ParseAll(
                        "3-0524-0600"
                    )
                },
                new Train() // Has no night runs
                {
                    Id = "G22T Šiauliai - Vilnius",
                    Type = TrainType.Diesel,
                    Runs = ParseAll(
                          "3-0800-1043",
                          "4-0800-1043",
                          "5-0800-1043"
                    )
                }
            };
        }

        private List<DateRange> ParseAll(params string[] ss)
        {
            return ss.Select(Parse).ToList();
        }

        // Accepted format: dd-HHmm-HHmm
        private DateRange Parse(string s)
        {
            var parts = s.Split("-");
            var day = new LocalDate(2019, 06, int.Parse(parts[0]));
            var from = new LocalTime(
                int.Parse(parts[1].Substring(0, 2)),
                int.Parse(parts[1].Substring(2, 2))
            );
            var to = new LocalTime(
                int.Parse(parts[2].Substring(0, 2)),
                int.Parse(parts[2].Substring(2, 2))
            );
            return new DateRange()
            {
                Day = day,
                From = from,
                To = to
            };
        }
    }
}
