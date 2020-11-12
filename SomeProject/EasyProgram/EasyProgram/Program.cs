using System;

namespace EasyProgram
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Cat myCat = new Cat();
            Console.WriteLine(myCat.Voice());
        }
    }
}