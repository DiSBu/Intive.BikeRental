using System;

namespace Intive.BikeRental.Utility
{
    public class ExceptionHandler
    {
        public static void Execute(object source, string traceMessage, Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public static T Execute<T>(object source, string traceMessage, Func<T> action)
        {
            T result = default(T);
            try
            {
                result = action.Invoke();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return result;
        }

        private static void HandleException(Exception ex)
        {
            try
            {
                //TODO: Log Exception
                throw ex;
            }
            catch (Exception ex1)
            {
                throw ex1;
            }
        }
    }
}