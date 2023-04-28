using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Private_Internal
{
    class MyClass
    {
        private int x;
        void DoSomething()
        {
            // phương thức này chỉ được gọi từ bên trong lớp MyClass
            Console.WriteLine("DoST");
        }

        public int x2;
        public void DoSomething2()
        {
            // phương thức này có thể được gọi từ bất kỳ đâu trong chương trình
            Console.WriteLine("DoST2");
        }

        internal int x3;
        internal void DoSomething3()
        {
            // phương thức này chỉ có thể được gọi từ bên trong assembly hiện tại. Tức project khác trỏ qua ko gọi đc
            Console.WriteLine("DoST3");
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass class1 = new MyClass();
            //class1.DoSomething();  private method ko goi dc

            class1.DoSomething2();
            class1.DoSomething3();
            Console.ReadKey();
        }
    }
}
