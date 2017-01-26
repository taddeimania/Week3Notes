using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class Review
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public Movie Movie { get; set; }
        public int Rating { get; set; }

        public override string ToString()
        {
            return $"Someone from {Person.City} rated {Movie.Title}/10 {Rating} stars";
        }
    }
}
