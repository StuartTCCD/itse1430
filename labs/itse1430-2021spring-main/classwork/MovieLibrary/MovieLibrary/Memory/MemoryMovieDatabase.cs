using System;
using System.Collections.Generic;

namespace MovieLibrary.Memory
{    
    //  Should not return Movie directly from DB because it is a reference type and user could change data outside database

    /// <summary>Represents an in-memory movie database.</summary>
    public class MemoryMovieDatabase : MovieDatabase
    {        
        //public Movie Add ( Movie );
        protected override Movie AddCore ( Movie movie )
        {                    
            //Add the movie
            movie.Id = ++_id;
            _movies.Add(CloneMovie(movie));

            return movie;
        }

        //public void Delete ( int id )
        protected override void DeleteCore ( int id )
        {            
            var existing = FindById(id);
            if (existing != null)
                _movies.Remove(existing);
        }

        //public Movie Get ( int id )
        protected override Movie GetCore ( int id )
        {
            var existing = FindById(id);
            if (existing == null)
                return null;

            return CloneMovie(existing);
        }

        // Iterator - returns back data on demand
        //   - they ONLY work with methods that return IEnumerable<T>
        //   - all return statements must be preceded with yield
        // IEnumerable<T> is readonly, use for returning a readonly set of values
        //public Movie[] GetAll ()
        protected override IEnumerable<Movie> GetAllCore ()
        {
            //Counter determines # of items in list
            //var items = new Movie[_movies.Count];

            //Foreach - preferred for enumeration
            //   item is readonly
            //   cannot write to array
            //   array cannot change during enumeration
            //int index = 0;
            foreach (var item in _movies)
                //Clone the movie so the caller can manipulate the movie without breaking our copy
                //items[index++] = CloneMovie(item);
                yield return CloneMovie(item);

            //return items;
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            //Must exist
            //existing = FindById(id);
            //if (existing == null)
              //  throw new Exception("Movie does not exist.");

            //Throw expression
            var existing = FindById(id) ?? throw new Exception("Movie does not exist.");

            //Update the movie
            CopyMovie(existing, movie);
        }

        private Movie CloneMovie ( Movie movie )
        {
            var target = new Movie() {
                Id = movie.Id
            };

            CopyMovie(target, movie);
            return target;
        }

        private void CopyMovie ( Movie target, Movie source )
        {
            //Object initializer syntax - creates an initializes an object as a single expression
            // 1. Remove semicolon from end of new expression
            // 2. Put curly braces after new expression
            // 3. Move closing curly after last property assignment
            // 4. Replace each semicolon on property assignment with a comma
            // 5. Remove the temp variable name and member access on each property
            // Limitations
            //   - Only works with new 
            //   - Can only assign a value to settable properties
            //   - Cannot access the newly created value while inside the initializer
            //var target = new Movie();
            //target.Id = movie.Id;
            target.Title = source.Title;
            target.Description = source.Description;
            target.ReleaseYear = source.ReleaseYear;
            target.Rating = source.Rating;
            target.RunLength = source.RunLength;
            target.IsClassic = source.IsClassic;
            //var target = new Movie() {
            //return new Movie() {
            //    Id = movie.Id,
            //    Title = movie.Title,
            //    Description = movie.Description,
            //    ReleaseYear = movie.ReleaseYear,
            //    Rating = movie.Rating,
            //    RunLength = movie.RunLength,
            //    IsClassic = movie.IsClassic,
            //};
            //return target;
        }

        private Movie FindById ( int id )
        {
            foreach (var item in _movies)
            {
                if (item.Id == id)
                    return item;
            };

            return null;
        }

        // Generic type - a class that uses the same implementation irrelevant of the type        
        //   closed type - can be instantiated because all type parameters are specified
        //   open type - cannot be instantiated because at least one type parameter is missing
        //private Movie[] _movies = new Movie[100];
        // List<T> is a dynamic resizing array of T
        private readonly List<Movie> _movies = new List<Movie>();
        //private readonly System.Collections.ObjectModel.Collection<Movie> _movies = new System.Collections.ObjectModel.Collection<Movie>();

        private int _id;

        // Collection<T> vs List<T>
        //  List<T> - low level implementation of a dynamic array, private facing
        //  Collection<T> - high level impl of a dynamic array, public facing
        //private System.Collections.ObjectModel.Collection<Movie> _test = new System.Collections.ObjectModel.Collection<Movie>();
    }

    //class GenericDynamicArray<T>
    //{
    //    public T Get ( int index );
    //    public void Add ( T item );
    //    public void Remove ( T item );

    //    private T[] _items;
    //}

    //class MovieDynamicArray
    //{
    //    public Movie Get ( int index );
    //    public void Add ( Movie item );
    //    public void Remove ( Movie item );

    //    private Movie[] _items;
    //}

    //class StringDynamicArray
    //{
    //    public string Get ( int index );
    //    public void Add ( string item );
    //    public void Remove ( string item );

    //    private string[] _items;
    //}

    //class Int32DynamicArray
    //{
    //    public int Get ( int index );
    //    public void Add ( int item );
    //    public void Remove ( int item );

    //    private int[] _items;
    //}
}
