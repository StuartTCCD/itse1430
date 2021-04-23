using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieLibrary.IO
{    
    /// <summary>Represents an in-memory movie database.</summary>
    public class FileMovieDatabase : Memory.MemoryMovieDatabase
    {
        // Expression body - using a lambda when a ctor, property or method has a single statement/expression
        //   expression-body ::=  => E/S

        public FileMovieDatabase ( string filename ) => _filename = filename;
        //{
        //    _filename = filename;
        //}

        protected override Movie AddCore ( Movie movie )
        {
            //Find highest ID in use
            var movies = GetAllCore();
            var id = GetHighestId(movies);

            movie.Id = ++id;

            //Union the results - Enumerable.Union ( IEnumerable<T> source1, IEnumerable<T> source2 ) -> IEnumerable<T>
            movies = movies.Union(new[] { movie });
            //var items = new List<Movie>(movies);
            //items.Add(movie);
            SaveMovies(movies);
            return movie;
        }

        protected override void DeleteCore ( int id )
        {
            //TODO: Remove item correctly
            var movies = GetAllCore().ToList();

            var movie = FindById(movies, id);
            if (movie != null)
                movies.Remove(movie);

            SaveMovies(movies);
        }

        protected override Movie GetCore ( int id )
        {
            //var movies = GetAllCore();
            //return FindById(movies, id);

            //Streaming IO
            //   OpenRead/OpenWrite/Open -> Stream
            //   OpenText -> StreamReader
            // StreamReader - reads a stream of text
            // StreamWriter - writes a stream of text
            // Use a reader/writer to work with streams to make it easier
            //    BinaryReader/BinaryWriter

            //try-finally ::= allows cleanup of code before try block completes successful or otherwise
            //    try-finally-statement ::= try-block [catch-block] finally { S* }

            #region Try-finally demo
            //StreamReader reader = null;
            //try
            //{
            //    //FileStream stream = File.OpenRead(_filename);
            //    reader = File.OpenText(_filename);  // new StreamReader(File.OpenRead())
            //                                        //do
            //                                        //{
            //                                        //    var line = reader.ReadLine();
            //                                        //    if (line != null)
            //                                        //    {
            //                                        //    };
            //                                        //} while (true);

            //    while (!reader.EndOfStream)
            //    {
            //        var line = reader.ReadLine();
            //        var movie = LoadMovie(line);
            //        if (movie?.Id == id)
            //            return movie;
            //    };

            //    //reader.Close();
            ////} catch
            ////{
            ////    //reader.Close();
            ////    throw;
            //} finally
            //{
            //    //Guaranteed to be called
            //    //Reader can be null so handle that case
            //    reader?.Close();
            //};
            #endregion


            // Preferred approach over try-finally
            //   using-statement ::= using (E) S;
            //       E must be IDisposable
            //   IDisposable - interface used to identify resources that must be explicitly cleaned up
            //       Dispose() - cleans up instance
            //   ALWAYS wrap IDisposable objects in a using if you own the object
            using (var reader = File.OpenText(_filename))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var movie = LoadMovie(line);
                    if (movie?.Id == id)
                        return movie;
                };
            };            

            // Object lifetime
            //   Must explicitly clean up any memory allocated if deterministic clean up needed
            //   Owner of instance must clean up
            //     If returning value from method, caller becomes owner and must clean up
            //     If passing as a parameter to another object then it generally becomes owner and will clean
            //      => RAII ::= resource acquisition is initialization
            //reader.Close();
            // It is not maintainable
            // Not exception safe

            return null;
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            var movies = LoadMovies();

            return movies;

            //return base.GetAllCore();
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            var movies = GetAllCore().ToArray();

            var existing = FindById(movies, id);
            if (existing == null)
                throw new Exception("Movie not found");

            existing.Title = movie.Title;
            existing.Rating = movie.Rating;
            existing.ReleaseYear = movie.ReleaseYear;
            existing.RunLength = movie.RunLength;
            existing.IsClassic = movie.IsClassic;
            existing.Description = movie.Description;

            SaveMovies(movies);            
        }

        private Movie FindById ( IEnumerable<Movie> items, int id )
        {
            //Enumerable.FirstOrDefault();
            //  FirstOrDefault - finds the first matching item in IEnumerable<T> or returns the default value if not found
            //  LastOrDefault - finds the last matching item, doesn't work in all cases outside of memory
            //  First/Last - find the first/last matching item or throw exception otherwise
            //  SingleOrDefault/Single - Finds the only matching item or throws an exception
            //  Any - returns true if there are any items in the IEnumerable that meet the condition (equal to .Where().Count() > 0)

            //Enumerable.FirstOrDefault(Func<T, bool>)
            return items.FirstOrDefault(x => x.Id == id);
            //foreach (var item in items)
            //    if (item.Id == id)
            //        return item;

            //return null;
        }

        private int GetHighestId ( IEnumerable<Movie> items )
        {
            // Enumerable.  (aggregates break if items is empty)
            //    Max() - gets the max value
            //    Min() - gets the min value
            //    Sum() - sums the values
            //    Count() - gets total items
            //         IEnumerable<T> forward only iterations
            //         List<T>.Count
            //         T.Length            
            //return items.Max();
            //var id = 0;
            //foreach (var item in items)
            //{
            //    //id = Math.Max(id, item.Id);
            //    if (item.Id > id)
            //        id = item.Id;
            //};

            //return id;

            return items.Any() ? items.Max(x => x.Id) : 0;
        }

        //  SELECT columns FROM table [WHERE condition] [ORDER BY columns]
        //  Enumerable
        //     .Select() takes IEnumerable<T> and returns IEnumerable<S>
        //     .Where() - returns IEnumerable<T> containing all items that match a condition
        //     .OrderBy() returns IEnumerable<T> ordered by certain values                
        //  Any method that returns IEnumerable<T> is assumed to use deferred execution
        //     The results of IEnumerable<T> are returned on demand, as needed

        // Event - a notification to external users that something has happened
        //   Calls an event handler (method) when the event is raised
        // Delegate - a method that is treated as data (function object, functor) and the data
        //   Function is treated as data just like other values
        //   Movie foo ( string ) => LoadMovie
        //delegate Movie StringToMovieDelegate ( string line );
        //   Common delegates
        //      Action<T> - void action ( T )
        //      Action<T1...T6> - void action ( T1, ... T6 )
        //      Func<T> - T func ();
        //      Func<T1...T6, T> - T func ( T1, ... T6 )
        // Lambda expression  (equivalent to a function T ? ( parameters )
        //    lambda-statement  ::= parameters => { S* }   you must explicitly return any values needed
        //    lambda-expression ::= parameters => expression
        //    parameters ::= ()   -> no parameters  () => true   => bool foo ( ) { return true; }
        //                   id   -> 1 prameter     x => true    => bool foo ( T x ) { return true; }
        //                                          if you don't care about parameter use _  for example  _ => true 
        //                   (id1, id2) -> multiple parameters      (x,y) => x + y   equivalent to int foo ( int x, int y ) { return x + y; }
        //    In rare cases where compiler cannot infer parameter types then add parameter type
        //    Limitations
        //        All values are captured into parameters and lambda body first execution (closure)
        //        Out and ref parameters are not supported

        // LINQ (using System.Linq)
        //  Language Integrated Natural Query
        //  Applied to IEnumerable<T>

        //Buffered IO
        private IEnumerable<Movie> LoadMovies ()
        {
            //Demo
            //To assign to a delegate use function name, without parenthesis
            Action<IEnumerable<Movie>> action = SaveMovies;

            if (File.Exists(_filename))
            {
                //ReadAllBytes - returns a byte[]
                //ReadAllLines - returns a string[]
                //ReadAllText - returns all lines as a single string

                //int id = 1;

                // LINQ version
                //    linq-syntax ::= from id in S
                //                    where E
                //                    orderby P, P, ...
                //                    select E                
                // S is IEnumerable<T>, id is of type T
                // If you have an IEnumerable then to get to IEnumerable<T> use OfType<T>

                var movies = from line in File.ReadAllLines(_filename)
                             let movie = LoadMovie(line)
                             where movie != null
                             orderby movie.Title, movie.ReleaseYear descending
                             select movie;
                return movies;

                // Best version
                //return File.ReadAllLines(_filename)
                //           .Select(LoadMovie)
                //           .OrderBy(x => x.Title).ThenByDescending(x => x.ReleaseYear)
                //           //.Where(IsNotNull);
                //           .Where(x => x != null);  //Lambda expression ::= bool func ( Movie )

                // Enumerable version
                //string[] lines = File.ReadAllLines(_filename); 
                //IEnumerable<Movie> movies = lines.Select(LoadMovie);
                //movies = movies.Where(IsNotNull);

                //return movies;

                //Original version 
                //foreach (var line in lines)
                //{
                //    var movie = LoadMovie(line);
                //    if (movie != null)
                //        yield return movie;
                //};
            };

            return Enumerable.Empty<Movie>();
        }

        //// Required by where to filter out null movies
        //private bool IsNotNull ( Movie movie )
        //{
        //    return movie != null;
        //}

        private Movie LoadMovie ( string line )
        {
            //Id, Title, Rating, ReleaseYear, RunLength, IsClassic, Description
            var tokens = line.Split(',');  //string[]
            if (tokens.Length != 7)
                return null;

            //TODO: Should validate here...
            // Not handling strings with commas in them
            // Will handle quotes and leading/trailing spaces
            var movie = new Movie() {
                Id = Int32.Parse(tokens[0].Trim()),
                Title = tokens[1].Trim().Trim('"'),
                Rating = tokens[2].Trim().Trim('"'),
                ReleaseYear = Int32.Parse(tokens[3].Trim()),
                RunLength = Int32.Parse(tokens[4].Trim()),
                IsClassic = Int32.Parse(tokens[5].Trim()) != 0,
                Description = tokens[6].Trim().Trim('"')
            };

            return movie;
        }

        private void SaveMovies ( IEnumerable<Movie> items )
        {
            //throw new IOException("Something went wrong");

            // Original version
            //var lines = new List<string>();
            //foreach (var item in items)
            //    lines.Add(SaveMovie(item));

            // Enumerable version
            var lines = items.Select(SaveMovie);

            //Buffered write
            //  WriteAllBytes - writes a byte array
            //  WriteAllLines - writes a string array
            //  WriteAllText - writes a string
            File.WriteAllLines(_filename, lines);
        }

        private string SaveMovie ( Movie movie )
        {
            // Collection initializer - arrays, List<T>, Collection<T>, T.Add
            //    Initialize a collection with elements as part of the creation
            //Id, Title, Rating, ReleaseYear, RunLength, IsClassic, Description
            var fields = new [] { //new string[] {
                                movie.Id.ToString(),
                                QuoteString(movie.Title),
                                QuoteString(movie.Rating),
                                movie.ReleaseYear.ToString(),
                                movie.RunLength.ToString(),
                                (movie.IsClassic ? "1" : "0"),
                                QuoteString(movie.Description),
                        };

            return String.Join(',', fields);
        }

        private string QuoteString ( string value )
        {
            if (String.IsNullOrEmpty(value))
                return "\"\"";

            var hasStartingQuote = value.StartsWith('"');
            var hasEndingQuote = value.EndsWith('"');

            //If no starting quote but might have ending quote then wrap it
            if (!hasStartingQuote)
                return "\"" + value + (hasEndingQuote ? "" : "\"");
            else if (!hasEndingQuote)  //Has starting quote but no ending quote
                return value + "\"";

            return value;   //Has starting and ending quote
        }

        // CSV - comma separate variable
        //   Each line represents a "record"
        //   A record consists of fields separate by commas
        //   Field names are implied
        // IO
        //   Buffered - read the entire contents into memory
        //   Streamed - read set of bytes at a time
        private readonly string _filename;
    }
}
