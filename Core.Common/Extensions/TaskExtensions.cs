using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public static class TaskResolver
    {
        public static void Resolving<T>(this Task<T> task,Action<T> successHandler,Action<Exception>exceptionHandler)
        {
            task.ContinueWith(t => t.Exception.Handle((ex) =>
            {

                exceptionHandler(ex);
                return true;
            }),TaskContinuationOptions.OnlyOnFaulted);
            


            if (!task.IsFaulted)
            {
                T result = task.Result;
                successHandler(result);
            }
        }
    }
}
