using System;

namespace MovieLibrary
{
    // Utility class
    //  Downsides to instance methods
    //    1. Create an instance
    //    2. Function call performance (this pointer)
    // All members ar either instance or static
    //   Instance members
    //      1. Require an instance
    //      2. Receive this as first parameter
    //   Static members (static method = global function)
    //      1. Do not require instance (compiler error)
    //      2. No this parameter (compiler error)
    //      3. Can only use other static members of the same type
    // Can mark the class static
    //    1. Only contain static members
    //    2. Cannot derive from anything or implement any interfaces
    //    3. Cannot create an instance of the type

    // Extension class - extends an existing type with new methods
    //   Extension methods must:
    //       1. Be static
    //       2. Be in a public/internal static class
    //       3. Have a first parameter preceded by the keyword this
    //   Extension methods extend an existing type with a new method
    //      The extension method appears as an instance member on the type specified as first parameter
    //      They do not provide you any more accessibility to a type then already provided by the public members
    //   Guidelines
    //      1. Do not create an extension method for a type you own
    //      2. Do not extend primitives or object unless there is a very good reason
    //      3. Do not add to high level namespaces unless generally usable
    public static class SeedDatabase
    {
        //private SeedDatabase()
        //{ }

        //Type constructor
        //  1. No access modifier
        //  2. Must be static
        //  3. Can have no parameters
        //static SeedDatabase()
        //{
        //    //Initialize type and its static members
        //}

        ////Instance constructor
        //public SeedDatabase ()
        //{
        //}

        //public static readonly SeedDatabase Instance = new SeedDatabase();

        //public static int MoviesToAdd { get; set; }

        //Make this static by adding keyword static before return type
        public static void Seed ( this IMovieDatabase database )
        {            
            var movie1 = new Movie() {
                Title = "Jaws",
                Description = "The original shark movie",
                Rating = "PG",
                ReleaseYear = 1979,
                RunLength = 123
            };

            //Compiler error - static member
            //this._dummy;
            //_dummy; 

            var movie2 = new Movie() {
                Title = "Jaws 2",
                Rating = "PG-13",
                ReleaseYear = 1981,
                RunLength = 156,
            };

            var movie3 = new Movie() {
                Title = "Dune",
                Rating = "PG",
                ReleaseYear = 1985,
                RunLength = 210
            };

            database.Add(movie1);
            database.Add(movie2);
            database.Add(movie3);
        }

        //private readonly int _dummy = 1;
    }
}
