using System;
using System.IO;
using System.Reflection;

namespace IDZ
{
    static class ReflectionInfo
    {
        public static void GetMethods<T>(T c)
        {
            Type type = c.GetType();
            MethodInfo[] info = type.GetMethods();
            Console.WriteLine($"{new string('-', 20)} Methods in {type.Name} {new string('-', 20)}");
            foreach (var method in info)
            {
                Console.WriteLine(method.Name);
            }
        }
        public static void SetField<T, R>(T c, string Field, R value)
        {
            Type Type = c.GetType();
            FieldInfo field = Type.GetField(Field, BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(c, value);
            Console.WriteLine($"{new string('-', 20)} Set Value in private field: {field.Name} {new string('-', 20)}");
        }
    }
    class Program
    {
        public static void loadPlugins()
        {
            string folder = Directory.GetCurrentDirectory() + "\\dlls\\";
            string[] files = Directory.GetFiles(folder, "*.dll");
            foreach (string file in files)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);
                    foreach (Type type in assembly.GetTypes())
                    {
                        //Type iface = type.GetInterface("Interface.Interface1");
                        Console.Write(type.FullName);

                        //if (null != iface)
                        //{
                        //    Interface.Interface1 obj = (Interface.Interface1)Activator.CreateInstance(type);
                        //    plugins.Add(obj);
                        //}
                    }
                }
                catch (Exception e)
                {
                }
            }

        }
        static void Main()
        {

            //loadPlugins();
            Assembly assembly = null;
            //assembly = Assembly.Load("ProductLibrary");
            assembly = Assembly.Load("ArrayContainer");
            Type[] types = assembly.GetTypes();
          

            Type type = assembly.GetType("IDZ.Container<Product>");
            dynamic instance = Activator.CreateInstance(type);

            //assembly.CreateInstance(Type, null)
            //assembly = Assembly.Load("ArrayContainer");

            //try
            //{
            //    Container<Product> c = new Container<Product>();
            //    Computer p = new Computer();

            //    ReflectionInfo.GetMethods(c);



            //    ReflectionInfo.SetField(c, "count", 10);
            //    Console.WriteLine(c.GetCount);
            //    ReflectionInfo.SetField(c, "count", 2);
            //    Console.WriteLine(c.GetCount);


            //}
            //catch (ProductException ex)
            //{
            //    Console.WriteLine($"Помилка: {ex.Message}");
            //    if (ex.Value != null)
            //    {
            //        Console.WriteLine($"Некоректне значення: {ex.Value}");
            //    }

            //}
        }
    }
}

