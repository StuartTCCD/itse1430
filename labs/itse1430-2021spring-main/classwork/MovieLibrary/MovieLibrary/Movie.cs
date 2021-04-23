using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary
{        
    /// <summary>Represents a movie.</summary>
    /// <remarks>
    /// Where you put additional comments that may be useful to someone.
    /// </remarks>
    // Interfaces appear in the same section as the base type
    ///  IValidatableObject - validates an object
    ///  IComparer<T> - compares two objects (e.g. StringComparer)
    ///  IComparable<T> - compares the current type to another type
    ///  ICloneable - clones an object (NEVER USE IT)
    ///  IEqualityComparer<T> - determines equality (DONT IMPLEMENT ON REF TYPES)
    public class Movie : IValidatableObject
    {
        #region Construction

        //CAVEAT: NOT NEEDED HERE - just demo

        /// <summary>Initializes an instance of the <see cref="Movie"/> class.</summary>
        public Movie ()  //Default constructor
        {
            //Initialize the fields that cannot be initialized using the field initializer syntax
            _description = _title;
        }

        /// <summary>Initializes an instance of the <see cref="Movie"/> class.</summary>
        /// <param name="title">The title of the movie.</param>
        /// <remarks>
        /// Allows you to create the instance and set a common property all at once
        /// </remarks>
        public Movie ( string title )
        {
            _title = title;
        }
        #endregion

        #region Properties

        /// <summary>Unique identifier of the movie.</summary>
        public int Id { get; set; }

        // In special case of a getter only property you can reduce entire declaration to a lambda
        //   [access] T id => E
        // WARNING: DO NOT USE =
        public int AgeInYears => (DateTime.Today.Year < ReleaseYear) ? 0 : DateTime.Today.Year - ReleaseYear;
        //public int AgeInYears = (DateTime.Today.Year < ReleaseYear) ? 0 : DateTime.Today.Year - ReleaseYear;
        //{
        //    //Expression body
        //    get => (DateTime.Today.Year < ReleaseYear) ? 0 : DateTime.Today.Year - ReleaseYear;
        //    //get
        //    //{
        //    //    if (DateTime.Now.Year < ReleaseYear)
        //    //        return 0;

        //    //    return DateTime.Today.Year - ReleaseYear;
        //    //}
        //    //set { }
        //}
        //public void SetAgeInYears ( int year ) {}                

        /// <summary>Gets or sets the title.</summary>
        public string Title //()
        {
            // use an expression body
            get => _title ?? "";
            set => _title = value?.Trim() ?? "";

            ////getter - T identifier ()
            //get  // string get_Title ()
            //{
            //    //Return title if not null or empty string otherwise                
            //    return _title ?? "";   //return (_title != null) ? _title : "";
            //}

            ////setter - void identifier ( T value )
            //set   // void set_Title ( string value )
            //{
            //    //_title = (value != null) ? value.Trim() : null;
            //    _title = value?.Trim() ?? "";
            //}
        }        

        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            //get { return (_description != null) ? _description : "";  }
            get => _description ?? "";
            set => _description = value;
        }
        
        /// <summary>Gets or sets the release year.</summary>
        //public int ReleaseYear
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}
        //private int _releaseYear = 1900;
        public int ReleaseYear { get; set; } = MinimumReleaseYear; // = 1900
        //public int ReleaseYear2 = 1900;

        /// <summary>Gets or sets the run length.</summary>
        //public int RunLength  //Full property syntax
        //{
        //    get { return _runLength; }
        //    set { _runLength = value; }
        //}
        //private int _runLength;

        //Auto property syntax - compiler will auto-generate the full property
        public int RunLength { get; set; }        

        /// <summary>Gets or sets the rating.</summary>
        public string Rating
        {
            //get { return (_rating != null) ? _rating : ""; }
            get => _rating ?? "";
            set => _rating = value;
        }

        /// <summary>Gets or sets the classic indicator.</summary>
        public bool IsClassic { get; set; }
        //{
        //    get { return _isClassic; }
        //    set { _isClassic = value; }
        //}
        //private bool _isClassic;d

        // Auto properties can be getter or setter only if needed
        public int Age { get; } // = 10;
        //private readonly int _age;
        #endregion

        #region Fields

        // Allowed to expose a field if const or readonly
        //   const - glorified, named literal; value baked in to usage at compile time (primitive and value will never change)
        //   readonly - const named variable; value referenced at runtime (non primitive, only option)
        public const int MinimumReleaseYear = 1900;
        public readonly DateTime MinimumReleaseDate = new DateTime(1900, 1, 1);

        private string _title = "";
        private string _description = "";
        private string _rating = "";
        #endregion

        #region Methods

        public override string ToString () => Title;
        //{
        //    return Title;
        //}

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            //var obj1 = Validate(...);
            //foreach (var obj in obj1)
            //    ;
            //var obj2 = Validate(...);
            //foreach (var obj in obj2)
            //    ;

            //var errors = new List<ValidationResult>();

            //Title is required
            if (String.IsNullOrEmpty(Title))
                //errors.Add(new ValidationResult("Title is required."));
                yield return new ValidationResult("Title is required.");

            //Release year >= 1900
            if (ReleaseYear < 1900)
                //errors.Add(new ValidationResult("Release year must be >= 1900."));
                yield return new ValidationResult("Release year must be >= 1900.");

            //Run length >= 0
            if (RunLength < 0)
                //errors.Add(new ValidationResult("Run length must be >= 0."));
                yield return new ValidationResult("Run length must be >= 0.");

            //return errors;
        }
        #endregion
    }
}
