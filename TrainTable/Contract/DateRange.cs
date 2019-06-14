using Newtonsoft.Json;
using NodaTime;
using System;

namespace TrainTable.Contract
{
    [JsonObject(MemberSerialization.OptIn)]
    [Serializable]
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

        public bool Intersects(DateRange other)
        {
            if (other.ExactTo < ExactFrom || other.ExactFrom > ExactTo) return false;
            return true;
        }
    }
}