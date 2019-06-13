using NodaTime;

namespace TrainTable.Contract
{
    public class DateRange
    {
        public LocalDate Day;
        public LocalTime From;
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