// HelloName.cs
using System;

namespace CsharpBegin.Reference 
{ 
    class HelloName {

        //static void Main() {
        public void Main() {
            Console.Write("Name?: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name} san.");
        }//Main()

    }//class
}
