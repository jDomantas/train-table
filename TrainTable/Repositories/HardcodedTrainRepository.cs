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
                new Train() // Random runs
                {
                    Id = "T1",
                    Type = TrainType.Diesel,
                    Runs = ParseAll(
                        "14-1300-1630",
                        "14-1700-2030",
                        "16-1500-1830",
                        "20-0900-1400",
                        "20-1430-1930"
                    )
                },
                new Train() // Random runs
                {
                    Id = "T2",
                    Type = TrainType.Electric,
                    Runs = ParseAll(
                        "14-0900-1000",
                        "14-1100-1400",
                        "14-1500-1730",
                        "14-1800-2130",
                        "15-0830-1000",
                        "15-1300-1830",
                        "15-1900-2330",
                        "16-0100-0500",
                        "16-0600-1200",
                        "17-0100-2300", // this mofo too long
                        "19-0130-0630",
                        "19-1500-1800"
                    )
                },
                new Train() // Random runs
                {
                    Id = "T3",
                    Type = TrainType.Electric,
                    Runs = ParseAll(
                        "19-0200-1030",
                        "19-1100-1530",
                        "19-1600-1800",
                        "19-1900-2330",
                        "21-1500-1600",
                        "21-1700-2200"
                    )
                },
                new Train() // Same time every day
                {
                    Id = "T4",
                    Type = TrainType.Diesel,
                    Runs = ParseAll(
                        "14-1530-2230",
                        "15-1530-2230",
                        "16-1530-2230",
                        "17-1530-2230",
                        "18-1530-2230",
                        "19-1530-2230",
                        "20-1530-2230",
                        "21-1530-2230"
                    )
                },
                new Train() // Has runs only on a single day
                {
                    Id = "T5",
                    Type = TrainType.Diesel,
                    Runs = ParseAll(
                        "22-0100-0400",
                        "22-0500-0900",
                        "22-1000-1500",
                        "22-1600-2000",
                        "22-2100-2330"
                    )
                },
                new Train() // Has only night runs
                {
                    Id = "T6",
                    Type = TrainType.Diesel,
                    Runs = ParseAll(
                        "14-0300-0600",
                        "14-2200-2330",
                        "16-0100-0400",
                        "16-0500-0600",
                        "16-2200-2230",
                        "16-2300-2330",
                        "18-0100-0200",
                        "18-0300-0400",
                        "18-0500-0600",
                        "18-2200-2230",
                        "18-2300-2330"
                    )
                },
                new Train() // Has no night runs
                {
                    Id = "T7",
                    Type = TrainType.Diesel,
                    Runs = ParseAll(
                          "15-0600-0800",
                          "15-0900-1500",
                          "15-1800-2200",
                          "17-0900-1600",
                          "18-0900-1800",
                          "19-0900-1500",
                          "19-1800-2200",
                          "22-10600-1500",
                          "22-1600-2200"
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
