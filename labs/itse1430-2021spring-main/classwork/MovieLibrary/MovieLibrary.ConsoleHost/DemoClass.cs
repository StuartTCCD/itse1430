using System;

namespace MovieLibrary
{
    // Common Type System (CTS)
    //   All types inherit from some base type (Object)
    //   Object => (alias) object
    //   Shape class - Draw()
    //     Circle class derives from Shape - Draw()
    //     Square class derives from Shape - Draw()
    //     Triangle class derives from Shape - Draw()
    //     ResizableShape derives from Shape - Resize()
    //     MoveableShape derives from Shape - Move()
    //     ResizableAndMovableShape derives ResisableShape, Moverable
    //   Base type provides core functionality
    //   Derived types can extend or add new functionality   
    //  Type compatible (e.g. Type A is/is not compatible with B if 
    //      B variable = instanceof-A
    //      if A derives from B then A is compatible with B
    //      object inst = //anything

    // Naming rules for types
    //   Noun, no abbreviations or acronyms
    //   Pascal cased

    // Accessibility - compile time access given to code (type, member, function, etc) for something
    //   public - usable by anyone
    //   private - only usable by defining type (default for members of a class)
    //   internal - (default for types): only usable in defining assembly
    //   protected - public to type and derived types, private to everyone else

    // class-declaration ::= [modifiers] `class` identifier [base-class] { class-members* }
    // modifiers ::= [access]
    // access ::= `public` | `internal` | `private` | `protected`
    // class-members ::= field | method | property || ctor     
    // field ::= [modifiers] T identifier [ = E ];
    // method ::= [modifiers] (T | `void`) identifier ( [parameters] ) { S* } 
    // property ::= full-property | auto-property
    // full-property ::= [modifiers] T identifier { [getter] [setter] }
    // getter ::= [access] `get` { S* }
    // setter ::= [access] `set` { S* }
    // auto-property ::= [modifiers] T identifier { [[accesss] `get` ;] [[access] `set` ;] } [ = field-initializer ];    
    // ctor ::= [modifiers] identifier ( [parameters] ) { S* }
    class MovieDemoClass : BaseMovieDemo 
    {
        #region Constructors
        
        // Constructors - Create an instance of the type
        //   Bear minimal to create an instance
        //   Method declaration with no return type and name is always the type name
        //   Use a constructor ONLY when field initializers will not work
        //     1. Non-primitive field that requires complex initialization
        //     2. One field relies on the value of another field
        //     3. (Deprecated) Allow creating and setting the most common properties
        //     4. Allow setting of properties that are not writable
        public MovieDemoClass () //Default Constructor (usage: `new Movie()`)
        { }

        public MovieDemoClass ( string title ) //Constructor with one parameter (usage: `new Movie("Title")` )
        { }
        #endregion

        #region Methods

        // Methods - provide functionality to a class (functions)
        //   Methods are verbs representing action
        //   Methods are always Pascal cased        
        public void Foo ()
        {
            //Can use `this` here
            MovieDemoClass currentInstance = this;

            GetFormattedTitle();
        }

        //Override indicates an override of a virtual method
        protected override string GetFormattedTitle ()
        {
            base.GetFormattedTitle();
            return "New Title";
        }

        // Null handling
        //   null coalescing operator ::= E ?? E
        //      Find first non-null value
        //      equivalent to (E1 != null) ? E1 : E2
        //      left associative, can be combined (E1 ?? E2 ?? E3)
        //      can still return null
        //   null condition operator ::= E ?. member
        //      Evaluates expression and if instance is not null, invokes member, or skips if it is
        //      Expression is changed to nullable E, works with all types
        //          int Hours(); instance?.Hours() => type of expression is int || null

        // this keyword is only usable inside a type member
        //   it represents the current instance/object
        //   it is used to distinguish class members from local identifiers        
        //   can be used to get the current instance
        //   should never be needed to clarify a member of the class (this is generally wrong `this.member`)

        #endregion

        // Properties vs Methods
        //
        // Use a property if:        
        //   Must be fast to get or set  
        //   Must be deterministic (known value) - DateTime.Now (wrong, non-deterministic)

        // Use a method if:
        //   Functionality that does not set or return data (e.g. Draw)
        //   Implementation requires slow resources such as network, file system, etc
        //   Non-deterministic calls
        //   Has a side effect (e.g. x++, ++x): exception - caching


        #region Properties

        // Properties - expose data using methods (simple field syntax to call a complex method)
        //   Syntax starts out as a field but curly braces (no parens) like a method
        //  Use cases:
        //    1) Expose a backing field
        //    2) Calculated property - does not store data, just calculates it
        //  Golden rules:
        //    1) String and array properties never return null

        public string Name //Full property
        { 
            get { return _name ?? ""; }
            set { _name = value?.Trim(); }
        }

        public int ReleaseYear { get; set; } //Auto property

        //Demo of mixed accessibility
        //  1. Can only be applied to either the getter or setter, not both
        //  2. Access modifier must be more restrictive than property        
        public int Id { get; private set; }
        #endregion

        #region Fields

        //Fields - variables that store data
        // fields should always start with underscore and be camel cased
        // fields are initialized early in the process to 0, can be changed to another value
        // fields are initialized in an undefined order
        // fields cannot be initialized to another field's value
        // fields should always be preceded by an underscore
        // NEVER expose a field publicly
        private string _name;

        // Problems with fields
        //   1) Can be read or written at will
        //   2) Calculated and must be updated whenever variant values are changed
        //   3) Can never change type from int
        //   4) What happens if it is negative
        //   5) Cannot initialize to another field        

        // Allowed to expose a field if const or readonly
        //   const - glorified, named literal; value baked in to usage at compile time (primitive and value will never change)
        //   readonly - const named variable; value referenced at runtime (non primitive, only option)
        public const int MaximumNameLength = 40;
        public readonly TimeSpan MinimumAge = TimeSpan.FromDays(13 * 365);
        #endregion

        #region Demo code

        void DemoTypeDifferences ()
        {
            // Different kinds of types - reference type or value type
            //   All types are one or the other, never both
            //   Memory - Value types are stored on the stack, ref types are stored on the heap (memory)
            //   Nullability - value types cannot be null, ref types default to null
            //   Assignment - value types ALWAYS copy the value, ref types copy the reference 
            //   Equality - value types are equal if values they contain are equal (value semantics), 
            //              ref types are equal iff they reference the same object in memory (reference semantics)
            //              Can be customized to a degree 
            //   Inheritance - value types cannot be derived from, ref types can 
            //   Default ctor - value types always have one, ref types give you complete control over ctor
            //   Immutability (guideline) - value types should be immutable, ref types don't care
            // How do you know which kind?
            //   Value types - all primitives (except string) are value types; structs
            //   Reference types - class

            DateTime dt;
            int valueType = 123;
            //valueType = null;      Cannot assign null to value type
            int valueType2 = valueType;  // Pass by value, always copy the value
            valueType2 = 123;
            var areEqualValues = valueType == valueType2;   //True

            Movie referenceType = new Movie();
            referenceType = null;   // Allowed because ref types can be null
            
            Movie referenceType2 = referenceType;    // Copy the reference to the new variable, both refer to the same instance in memory
            referenceType2.Title = "Jaws";
            Console.WriteLine(referenceType.Title);  //Jaws
            var areEqualRefs = referenceType2 == referenceType; //True
        }

        /// <summary>Determines if movie is black and white.</summary>
        /// <returns>Returns true if movie is black and white.</returns>
        public bool IsBlackAndWhite ( /* Movie this */ )
        {
            var isOld = ReleaseYear < 1940;
            //var isOld = this.releaseYear < 1940;

            //Only case where `this` makes sense
            //var title = "";
            //title = this.title;

            var note = "";
            note = Name;

            return isOld;
        }

        /// <summary>Do something complex.</summary>
        /// <param name="age">The age of the movie when restored.</param>
        /// <param name="enable">Determines if movie has been restored.</param>
        private void DoComplex ( int age, bool enable )
        { }
        #endregion
    }
    
    class BaseMovieDemo //: Object
    {
        public void Foo ()
        {
            //Type compatibility
            BaseMovieDemo demo = new MovieDemoClass();  // B derives A
            object instance = demo;

            //demo.Foo();                
            //instance.ToString();
        }
        
        protected virtual string GetFormattedTitle ()
        {
            return "";
        }
    }
}
