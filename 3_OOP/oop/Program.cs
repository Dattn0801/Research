using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    public interface IAnimal
    {
        void MakeSound();
        void SayKilo();
    }

    public class Animal : IAnimal
    {
        protected string Name { get; set; }
        protected int Age { get; set; }

        //private error
        protected double Kilo { get; set; }

        //default constructor
        public Animal() { }

        //Constructor with params
        public Animal(string name, int age, double kilo)
        {
            Name = name;
            Age = age;
            Kilo = kilo;
        }
        //vitural
        public virtual void SayKilo()
        {
            Console.WriteLine("Animal has kilo: " + Kilo);
        }

        //vitural
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal has name: {0},age: {1} makes a sound.", Name, Age);
        }
    }
    public class Dog : Animal
    {
        // base : su dung params calss cha
        public Dog(string name, int age, double kilo) : base(name, age, kilo)
        {
        }
        public override void SayKilo()
        {
            Console.WriteLine("dog has kilo: " + Kilo);
        }
        public override void MakeSound()
        {
            Console.WriteLine("Dog has name: {0},age: {1} makes a sound.", Name, Age);
        }
    }
    public class Cat : Animal
    {
        public Cat(string name, int age, double kilo) : base(name, age, kilo)
        {
        }
        public override void SayKilo()
        {
            Console.WriteLine("cat has kilo: " + Kilo);


        }
        public override void MakeSound()
        {
            Console.WriteLine("Cat has name: {0},age: {1} makes a sound.", Name, Age);

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // con vat ko truyen params
            Animal a1 = new Animal();
            a1.MakeSound();

            // con vat
            Animal a = new Animal("Con vat", 8, 2.2);
            a.MakeSound();


            //cho
            Animal dog = new Dog("Phu Quoc", 3, 22.3);
            dog.MakeSound();


            //meo
            Animal cat = new Cat("Kitty", 1, 1.2);
            cat.MakeSound();


            //so ki
            Dog dog2 = new Dog("Kiki", 11, 7.8);
            dog2.SayKilo();
            Console.ReadKey();
        }
    }
}
