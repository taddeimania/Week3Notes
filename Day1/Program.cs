using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    enum Car
    {
        red,
        blue,
        green
    }

    enum Owner
    {
        peanut,
        joel,
        sarah
    }

    class Program
    {


        static void MakeSpeak(ISpeakable animal)
        {
            animal.Speak();
        }

        static void Main(string[] args)
        {
            var joel = new Human("lol");
            var peanut = new Dog();

            MakeSpeak(peanut);
            MakeSpeak(joel);

            var myDictionary = new Dictionary<string, string>();

            myDictionary.Add("Surface", "Microsoft");
            string myKey = myDictionary.FirstOrDefault(x => x.Value == "Microsoft").Key;
            Console.WriteLine(myDictionary["Surface"]);
            Console.WriteLine(myKey);

            var conversionVals = new Dictionary<string, double>();
            conversionVals.Add("BTC", .0003);
            Console.WriteLine(5 * conversionVals["BTC"]);

            var humanDictionary = new Dictionary<string, Human>();
            humanDictionary.Add("joel", new Human("peanutbutter"));
            humanDictionary.Add("sarah", new Human("sarah"));
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            if (humanDictionary.Keys.Contains(username))
            {
                if (humanDictionary[username].password == password)
                {
                    Console.WriteLine("SUCCESSFUL LOGIN!");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
