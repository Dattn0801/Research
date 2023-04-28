using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Khai báo và gán giá trị cho các kiểu số nguyên
            sbyte a = -128;
            byte b = 255;
            short c = -32768;
            ushort d = 65535;
            int e = -2147483648;
            uint f = 4294967295;
            long g = -9223372036854775808;
            ulong h = 18446744073709551615;
            // In giá trị của các biến kiểu số nguyên
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("c = " + c);
            Console.WriteLine("d = " + d);
            Console.WriteLine("e = " + e);
            Console.WriteLine("f = " + f);
            Console.WriteLine("g = " + g);
            Console.WriteLine("h = " + h);
            // Khai báo và gán giá trị cho các kiểu số thực
            float x = 1.23f;
            double y = 4.56;
            decimal z = 7.89m;
            // In giá trị của các biến kiểu số thực
            Console.WriteLine("x = " + x);
            Console.WriteLine("y = " + y);
            Console.WriteLine("z = " + z);

            // Khai báo và gán giá trị cho kiểu ký tự và chuỗi
            char ch = 'A';
            string str = "Hello, world!";

            // In giá trị của các biến kiểu ký tự và chuỗi
            Console.WriteLine("ch = " + ch);
            Console.WriteLine("str = " + str);

            // Khai báo và gán giá trị cho kiểu boolean
            bool b1 = true;
            bool b2 = false;
            // In giá trị của các biến kiểu boolean
            Console.WriteLine("b1 = " + b1);
            Console.WriteLine("b2 = " + b2);

            // Khai báo và gán giá trị cho kiểu đối tượng
            object obj1 = "Hello, world!";
            object obj2 = 123;

            // In giá trị của các biến kiểu đối tượng
            Console.WriteLine("obj1 = " + obj1);
            Console.WriteLine("obj2 = " + obj2);
            //Mục đích sử dụng kiểu dữ liệu trong C# là để định nghĩa kiểu giá trị mà một biến
            //có thể chứa và loại bỏ các giá trị không hợp lệ. Mỗi kiểu dữ liệu trong C# định
            //nghĩa một loại giá trị cụ thể, ví dụ: số nguyên, số thực, ký tự, chuỗi, boolean, v.v.
            //Việc sử dụng kiểu dữ liệu đúng cách giúp cho chương trình trở nên rõ ràng và dễ hiểu hơn,
            //đồng thời giúp cho các lập trình viên có thể dễ dàng xác định được các giá trị hợp lệ cho
            //từng biến, tránh việc gán nhầm kiểu dữ liệu và phát sinh các lỗi không mong muốn trong
            //chương trình.
            //Ngoài ra, việc sử dụng kiểu dữ liệu trong C# cũng giúp cho việc xử lý toán học
            //và các phép tính trên dữ liệu trở nên dễ dàng và chính xác hơn.
            Console.ReadKey();
        }
    }
}
