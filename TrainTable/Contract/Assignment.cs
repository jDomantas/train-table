using System;

namespace TrainTable.Contract
{
    [Serializable]
    public class Assignment
    {
        private static int _nextId = 0;

        public string Id;
        public string TrainId;
        public TrainType TrainType;
        public DateRange Range;

        public static string NextId()
        {
            return (_nextId++).ToString();
        }
    }
}