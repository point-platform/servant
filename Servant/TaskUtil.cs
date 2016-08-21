using System.Threading.Tasks;

namespace Servant
{
    internal static class TaskUtil
    {
        public static Task<object> Downcast<T>(Task<T> task)
        {
            var tcs = new TaskCompletionSource<object>();

            task.ContinueWith(
                t =>
                {
                    if (t.IsFaulted)
                        tcs.TrySetException(t.Exception.InnerExceptions);
                    else if (t.IsCanceled)
                        tcs.TrySetCanceled();
                    else
                        tcs.TrySetResult(t.Result);
                },
                TaskContinuationOptions.ExecuteSynchronously);

            return tcs.Task;
        }

        public static Task<T> Upcast<T>(Task<object> task)
        {
            var tcs = new TaskCompletionSource<T>();

            task.ContinueWith(
                t =>
                {
                    if (t.IsFaulted)
                        tcs.TrySetException(t.Exception.InnerExceptions);
                    else if (t.IsCanceled)
                        tcs.TrySetCanceled();
                    else
                        tcs.TrySetResult((T)t.Result);
                },
                TaskContinuationOptions.ExecuteSynchronously);

            return tcs.Task;
        }
    }
}