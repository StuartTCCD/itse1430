using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary
{
    //  Should not return Movie directly from DB because it is a reference type and user could change data outside database

    /// <summary>Represents a database of movies.</summary>
    //public class ArrayMovieDatabase
    //{
    //    public Movie Add ( Movie movie, out string error )
    //    {
    //        //Validation
    //        //  Check for null and valid movie
    //        if (movie == null)
    //        {
    //            error = "Movie is null";
    //            return null;
    //        };
    //        if (!movie.Validate(out error))
    //            return null;

    //        //Must be unique
    //        var existing = FindByTitle(movie.Title);
    //        if (existing != null)
    //        {
    //            error = "Movie title must be unique";
    //            return null;
    //        };

    //        //Add the movie
    //        _movies[0] = CloneMovie(movie);

    //        return movie;
    //    }

    //    public Movie[] GetAll ()
    //    {
    //        //Can create an empty array
    //        var emptyArray = new Movie[0];

    //        // Enumeration - could use a for if you need the index
    //        // Prefer foreach
    //        var items = new Movie[_movies.Length];
    //        //for (var index = 0; index < items.Length; ++index)
    //        //    items[index] = _movies[index];

    //        //Foreach - preferred for enumeration
    //        //   item is readonly
    //        //   cannot write to array
    //        //   array cannot change during enumeration
    //        int index = 0;
    //        foreach (var item in _movies)
    //            //Clone the movie so the caller can manipulate the movie without breaking our copy
    //            items[index++] = CloneMovie(item);

    //        return items;
    //    }

    //    private Movie CloneMovie ( Movie movie )
    //    {
    //        var target = new Movie();
    //        target.Title = movie.Title;
    //        target.Description = movie.Description;
    //        target.ReleaseYear = movie.ReleaseYear;
    //        target.Rating = movie.Rating;
    //        target.RunLength = movie.RunLength;
    //        target.IsClassic = movie.IsClassic;

    //        return target;
    //    }

    //    private Movie FindByTitle ( string title )
    //    {
    //        return null;
    //    }

    //    // Array declaration
    //    //   Array specification is part of the type
    //    //   Arrays are always open (meaning no row size), multiple dimensions have fixed size columns
    //    //   Arrays are reference types (nullable, they follow reference semantics)
    //    //   Arrays are, for the most part, limited to 2 billion
    //    // Array size
    //    //   Can be any size >= 0
    //    //   Does not have to be a compile time constant
    //    //   No need for some constant size value
    //    //   Size is determinable at runtime (no need for a size parameter in functions)
    //    //   Length returns the # of rows in an array
    //    // Array behavior
    //    //   Bounds checking always happens
    //    //   Zero initialized
    //    //   Can be empty
    //    //   Indexing is zero based 
    //    //   Should never return null array from property 
    //    private Movie[] _movies = new Movie[100];
    //}
}
