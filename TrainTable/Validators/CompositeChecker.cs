using System.Collections.Generic;
using TrainTable.Contract;

namespace TrainTable.Validators
{
    public class CompositeChecker : IChecker
    {
        private IEnumerable<IChecker> _checkers;

        public CompositeChecker(IEnumerable<IChecker> checkers)
        {
            _checkers = checkers;
        }

        public void Check(ScheduleResponse response)
        {
            foreach(var checker in _checkers)
            {
                checker.Check(response);
            }
        }
    }
}
