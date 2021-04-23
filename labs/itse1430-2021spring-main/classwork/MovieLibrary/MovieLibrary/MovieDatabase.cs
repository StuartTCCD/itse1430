using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary
{    
    /// <summary>Represents a base implementation of movie database.</summary>
    public abstract class MovieDatabase : IMovieDatabase
    {
        //public void NotVisibleInInterface () { }

        // Exceptions - error objects
        //   when an error case occurs we throw/raise an exception
        //   throw ::= throw E;
        //   when a throw occurs current function stops executing and error is immediately returned
        //
        //   Exception is a base type - use when no other exception works
        //     ArgumentException - when an argument is invalid and no other exception is better
        //         ArgumentNullException - when an argument is null and you do not support it
        //         ArgumentOutOfRangException - when an argument is out of range
        //     ValidationException - validation errors from IValidableObject
        //     InvalidOperationException - currently not valid but may be later
        //     NotSupportedException - not currently supported things
        //     NotImplementedException - not currently implemented
        //     SystemException - NEVER THROW
        //        NullReferenceException - thrown when you use a null instance
        //        OutOfMemoryException - *no more memory, always fatal
        //        StackOverflowException - *no more stack space, always fatal
        //     ApplicationException - NEVER USE THIS

        public Movie Add ( Movie movie )
        {            
            //Validation
            if (movie == null)            
                throw new ArgumentNullException(nameof(movie));
            
            //{
            //    error = "Movie is null";
            //    return null;
            //};

            //Validate using IValidatableObject
            //var context = new ValidationContext(movie);
            //var errors = new List<ValidationResult>();
            //if (!Validator.TryValidateObject(movie, context, errors))
            //{
            //    error = errors[0].ErrorMessage;
            //    //if (!movie.Validate(out error))
            //    return null;
            //};
            ObjectValidator.Validate(movie);
            //var errors = new ObjectValidator().TryValidate(movie);
            //if (errors.Count > 0)
            //{
            //    error = errors[0].ErrorMessage;
            //    return null;
            //};

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
            {
                throw new InvalidOperationException("Movie title must be unique.");
                //error = "Movie title must be unique";
                //return null;
            };

            //Add the movie
            return AddCore(movie);
        }

        /// <summary>Adds the movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The new movie.</returns>
        protected abstract Movie AddCore ( Movie movie );

        public void Delete ( int id )
        {
            //Validation
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

            //Delete
            DeleteCore(id);
        }

        protected abstract void DeleteCore ( int id );

        public Movie Get ( int id )
        {
            //Validation
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

            //Get
            return GetCore(id);
        }

        protected abstract Movie GetCore ( int id );

        public IEnumerable<Movie> GetAll ()
        {
            //Will never return null
            return GetAllCore() ?? Enumerable.Empty<Movie>();
        }

        protected abstract IEnumerable<Movie> GetAllCore ();

        public void Update ( int id, Movie movie )
        {
            //Validation
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

            if (movie == null)
                throw new ArgumentNullException(nameof(movie));
            
            ObjectValidator.Validate(movie);

            //Must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null && existing.Id != id)
                 throw new InvalidOperationException("Movie title must be unique.");

            //Hiding exception details
            //   Wrap it - create a new exception to hide the original
            //   Rethrow - let original exception continue on
            try
            {
                UpdateCore(id, movie);
            } catch (ArgumentException e)
            {
                //throw e; //NEVER DO THIS
                throw;
            } catch (InvalidOperationException e)
            {
                throw;
            } catch (Exception e)
            {
                //Wrapping existing exception in a new one
                throw new Exception("Update failed", e);
            };
        }

        protected abstract void UpdateCore ( int id, Movie movie );
            
        protected virtual Movie FindByTitle ( string title )
        {
            //TODO: Convert to Enumerable - FirstOrDefault
            foreach (var item in GetAllCore())
            {
                //Match movie by title, case insensitive
                if (String.Compare(item.Title, title, true) == 0)
                    return item;
            };

            return null;
        }
    }
}
