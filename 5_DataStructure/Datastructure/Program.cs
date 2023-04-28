using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructure
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /////////////////////////////////////List/////////////////////////////////
            // Khai báo và khởi tạo List với các giá trị mặc định
            List<int> numbers = new List<int>();

            // Thêm giá trị vào List
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);

            // In giá trị của List
            Console.Write("Add 1,2,3 to list => numbers: ");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // Chèn giá trị vào List tại vị trí chỉ định
            numbers.Insert(1, 4);

            // In giá trị của List sau khi chèn giá trị
            Console.Write("Insert 4 To list ==> numbers: ");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // Xóa giá trị khỏi List tại vị trí chỉ định
            numbers.RemoveAt(2);

            // In giá trị của List sau khi xóa giá trị
            Console.Write("Remove list[2] ==> numbers: ");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // Kiểm tra sự tồn tại của giá trị trong List
            bool containsTwo = numbers.Contains(2);
            Console.WriteLine("containsTwo: " + containsTwo);

            // Lấy giá trị tại vị trí chỉ định trong List
            int valueAtIndexOne = numbers[1];
            Console.WriteLine("valueAtIndexOne: " + valueAtIndexOne);



            // Xóa tất cả giá trị trong List
            numbers.Clear();
            Console.WriteLine("After clear List");
            // In giá trị của List sau khi xóa tất cả giá trị
            Console.Write("numbers: ");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }


            Console.WriteLine("/////////////////////////////////////ARRAY/////////////////////////////////");

            // Khai báo và khởi tạo một mảng số nguyên
            int[] numbers1 = new int[5];

            // Gán giá trị cho các phần tử trong mảng
            numbers1[0] = 1;
            numbers1[1] = 7;
            numbers1[2] = 12;
            numbers1[3] = 45;
            numbers1[4] = 51;
            // In các giá trị trong mảng
            Console.Write("numbers: ");
            foreach (int num in numbers1)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            // Tạo một mảng mới bằng cách sao chép các giá trị từ mảng cũ
            int[] newNumbers = new int[numbers1.Length];
            Array.Copy(numbers1, newNumbers, numbers1.Length);

            // In các giá trị trong mảng mới
            Console.Write("newNumbers: ");
            foreach (int num in newNumbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // Sắp xếp các giá trị trong mảng
            Array.Sort(newNumbers);
            // In các giá trị trong mảng mới sau khi sắp xếp
            Console.Write("newNumbers (sorted): ");
            foreach (int num in newNumbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // Tìm kiếm giá trị trong mảng
            int index = Array.IndexOf(newNumbers, 12);
            Console.WriteLine("index of 3: " + index);
            Console.WriteLine("/////////////////////////////////////SORTED LIST/////////////////////////////////");

            // Khởi tạo một SortedList
            SortedList mySortedList = new SortedList();

            // Thêm các phần tử vào SortedList
            mySortedList.Add("apple", 1);
            mySortedList.Add("banana", 2);
            mySortedList.Add("cherry", 3);
            mySortedList.Add("date", 4);

            // In các phần tử trong SortedList
            foreach (DictionaryEntry entry in mySortedList)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }
            // Tìm kiếm và in giá trị của một khóa trong SortedList
            if (mySortedList.ContainsKey("banana"))
            {
                Console.WriteLine("The value of 'banana' is " + mySortedList["banana"]);
            }
            Console.ReadKey();
        }
    }
}
