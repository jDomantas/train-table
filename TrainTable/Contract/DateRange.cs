using Newtonsoft.Json;
using NodaTime;

namespace TrainTable.Contract
{
    [JsonObject(MemberSerialization.OptIn)]
    public class DateRange
    {
        [JsonProperty]
        public LocalDate Day;
        [JsonProperty]
        public LocalTime From;
        [JsonProperty]
        public LocalTime To;

        public LocalDateTime ExactFrom => Day + From;
        public LocalDateTime ExactTo => Day + To;
        public Duration Duration => (ExactTo - ExactFrom).ToDuration();
        public bool IsNightShift => From < new LocalTime(6, 0) || To > new LocalTime(22, 0);
        public Duration TimeInNightShift =>
            (From < new LocalTime(6, 0) ? (new LocalTime(6, 0) - From).ToDuration() : Duration.Zero) +
            (To > new LocalTime(22, 0) ? (To - new LocalTime(22, 0)).ToDuration() : Duration.Zero);
    }
}