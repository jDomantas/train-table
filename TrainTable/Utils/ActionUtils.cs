using System;

namespace TrainTable.Utils
{
    public static class ActionUtils
    {
        public static bool Throws<T>(this Action action) where T : Exception
        {
            try
            {
                action();
                return false;
            }
            catch (T)
            {
                return true;
            }
        }
    }
}
