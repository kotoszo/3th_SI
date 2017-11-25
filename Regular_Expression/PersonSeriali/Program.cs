using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSeriali
{
    class Program
    {
        static void Main(string[] args)
        {
            Person béla = new Person("Béla", new DateTime(1988,07,15), 0);
            Console.WriteLine("------------");
            Console.WriteLine(béla);
            Console.WriteLine("------------");
            béla.Serialize();
            Person mari = new Person("Mari", new DateTime(1989, 11, 22), 1);
            Console.WriteLine("----Deserialized----");
            Person.Deserialize(béla.Name);
            Console.WriteLine("------------");
            mari.Serialize();
            Console.WriteLine("----Deserialized----");
            Person.Deserialize(béla.Name);
            Console.WriteLine("------------");

            Console.ReadKey();
        }
    }
}
