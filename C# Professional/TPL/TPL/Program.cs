using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
    internal class Program
    {
        static int MyTask(object cancelToken)
        {
            int res = 0;
            var token = (CancellationToken)cancelToken;
            token.ThrowIfCancellationRequested();

            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} started");
            for (int i = 0; i < 10; i++)
            {
                ++res;
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("\nRequest to stop");
                    token.ThrowIfCancellationRequested();
                }

                Console.Write(". ");
                Thread.Sleep(200);
            }
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} ended");
            return res;
        }

        static void ContinuationTask(Task task)
        {
            Console.WriteLine("ContinuationTask");
        }
        static void Main(string[] args)
        {
            var cancelToken = new CancellationTokenSource();
            var task = Task<int>.Factory.StartNew(MyTask, cancelToken.Token, cancelToken.Token);
            task.ContinueWith(continuation => Console.WriteLine("Task stopped"), TaskContinuationOptions.OnlyOnCanceled);
            task.ContinueWith(continuation => Console.WriteLine($"Task res = {task.Result}"), TaskContinuationOptions.OnlyOnRanToCompletion);
            try
            {
                
                Thread.Sleep(1000);
                cancelToken.Cancel();

                task.Wait();
                Console.WriteLine("Main Thread ended");
            }
            catch (AggregateException ex)
            {
                if (task.IsCanceled)
                    Console.WriteLine("\nЗадача task отменена.\n");
            }
            finally
            {
                task.Dispose();
                cancelToken.Dispose();
            }
        }
    }
}
