using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        delegate void dell();
        public static EventWaitHandle EventWaitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
        static void Main()
        {
            dell myDell = SayHello;
            Console.WriteLine("Main поток запущен");
            var myDelegate = new Action(Method);
            
            var asyncResult = myDelegate.BeginInvoke(HandleComplete, myDell);
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("- ");
            }
            myDelegate.EndInvoke(asyncResult);
            Console.ForegroundColor = ConsoleColor.Gray;
            //EventWaitHandle.WaitOne();
            //Console.WriteLine("Main поток завершен после получения сигнала");
            
            Console.WriteLine("Main поток завершен");
        }

        static void Method()
        {
            Thread.CurrentThread.Name = "2";
            Console.WriteLine($"Поток {Thread.CurrentThread.Name} запущен");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(15);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(". ");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            //Console.WriteLine($"Отправлен сигнал");
            //EventWaitHandle.Set();
        }

        static void HandleComplete(IAsyncResult asyncResult)
        {
            dell method = (dell)asyncResult.AsyncState;
            method.Invoke();
            
            Console.WriteLine($"Поток {Thread.CurrentThread.Name} завершен");
        }
        static void SayHello()
        {
            Console.WriteLine($"Hello");
        }
        
    }
}
