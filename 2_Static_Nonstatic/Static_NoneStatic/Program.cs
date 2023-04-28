using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_NoneStatic
{
    public class ExampleClass
    {
        private static int staticValue = 0;
        private int nonStaticValue = 0;

        public ExampleClass(int value)
        {
            nonStaticValue = value;
            staticValue++;
        }

        public static void StaticMethod()
        {
            Console.WriteLine("This is a static method.");
        }

        public void NonStaticMethod()
        {
            Console.WriteLine("This is a non-static method.");
        }

        public void PrintValues()
        {
            Console.WriteLine("Static value: " + staticValue);
            Console.WriteLine("Non-static value: " + nonStaticValue);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ExampleClass.StaticMethod();

            ExampleClass object1 = new ExampleClass(10);
            object1.PrintValues(); // Output: Static value: 1, Non-static value: 10

            ExampleClass object2 = new ExampleClass(20);
            object2.PrintValues(); // Output: Static value: 2, Non-static value: 20

            object1.NonStaticMethod(); // Output: This is a non-static method.
            object2.NonStaticMethod(); // Output: This is a non-static method.
            //ExampleClass.NonStaticMethod(); // Error: cannot call non-static method from static context
            Console.ReadKey();
        }
    }
}
