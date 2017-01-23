using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Dog : ISpeakable
    {
        public void Speak()
        {
            Bark();
        }

        private void Bark()
        {
            Console.WriteLine("Ruff!");
        }
    }
}
