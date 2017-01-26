using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var db = new MovieReviewContext())
            {
                var query = from c in db.Movies select c;
                Movie movie = new Movie
                {
                    Title = "Days of Thunder",
                    Genre = "Racing",
                    ReleaseDate = DateTime.Now
                };
                db.Movies.Add(movie);
                db.SaveChanges();
            }


            /*
            Person joel = new Person { Age = 33, Occupation = "Programmer", City = "Greenvul" };
            Person michael = new Person { Occupation = "Programmer", City = "Barcelona" };
            Movie littleShop = new Movie
            {
                Title = "Little Shop of Horrors",
                Genre = "Musical",
                ReleaseDate = DateTime.Now
            };

            Review myReview = new Review
            {
                Person = joel,
                Movie = littleShop,
                Rating = 8
            };

            Review michaelReview = new Review
            {
                Person = michael,
                Movie = littleShop,
                Rating = 3
            };


            Console.WriteLine(michaelReview);
            Console.WriteLine(myReview);
            */
        }
    }
}
