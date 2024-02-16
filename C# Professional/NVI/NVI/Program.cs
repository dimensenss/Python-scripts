using System;
using System.Reflection;

namespace NVI
{

    class BaseClass
    {
        public void SomeMethod()
        {
            NewMethod();
            CoreSomeMethod();
        }
        protected virtual void CoreSomeMethod()
        {
            Console.WriteLine($"{this.GetType().FullName}.{MethodBase.GetCurrentMethod().Name}");
        }

        private void NewMethod()
        {
            Console.WriteLine("New Method");
        }
    }
    class MyClass : BaseClass
    {
        protected override void CoreSomeMethod()
        {
            Console.WriteLine($"{this.GetType().FullName}.{MethodBase.GetCurrentMethod().Name}");
        }
    }

    class Program
    {
        static void Main()
        {
            BaseClass obj = new BaseClass();
            obj.SomeMethod();
        }
    }
}
