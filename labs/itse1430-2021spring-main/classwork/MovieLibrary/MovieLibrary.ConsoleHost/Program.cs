/*
 * ITSE 1430
 * Spring 2021
 * Sample Implementation
 */
using System;  //Bring into scope all the types defined in the given namespace

//Renamed to match project name
//namespace MovieLibrary
//{
//    namespace ConsoleHost
//    { }
//}

namespace MovieLibrary.ConsoleHost
{   
    class Program  //MovieLibrary.ConsoleHost.Program
    {
        public Program ()
        { }

        static void Main()  //(string[] args)
        {
            //System.Collections.ArrayList
            //Fully qualified type name: System.Boolean   [namespace].[type]
            // MovieLibrary.ConsoleHost.Boolean (not found)
            // MovieLibrary.Boolean (not found)
            // System.Boolean (found)
            //Boolean done = false;
            bool done = false;
            do
            {
                char option = DisplayMainMenu();

                // Switch statement is equivalent to a series of if-else-if with equality checks
                //   switch-statement ::= switch (E) { case-statement* [default-statement] };
                //   case-statement   ::= case E : S ;
                //   default-statement ::= default : S ;
                //  
                //   case label rules:
                //      - Must be constant values : literals or simple expressions of constant values
                //      - Must be unique
                //      - Can be a string
                //   Fallthrough behavior
                //      - No
                //      - Every case statement must end with either break or return statement
                //      - Allowed if case label has no statement (including semicolon)
                //   Styling rules
                //      - Single statement (excluding break) no block statement needed
                //      - Multiple statements (excluding break) should use block statement to avoid compiler errors
                //switch (10)
                //{
                //    case 10: S1; S2; S3; break;
                //    case 12:
                //    {
                //        int x; x = 10; 
                //        break;
                //    };
                //    case 13: SByte; break;
                //}

                //if (option == 'A')
                //    AddMovie();
                //else if (option == 'V')
                //    ViewMovie();
                //else if (option == 'Q')
                //    done = true;
                //else
                //    DisplayError("Unknown command");
                switch (option)
                {
                    case 'A': AddMovie(); break;
                    case 'V': ViewMovie(); break;
                    case 'Q': done = true; break;

                    default: DisplayError("Unknown command"); break;
                };
               
            } while (!done);
        }

        // modifiers* T identifier ( [parameters] ) { S* }
        // function declaration - function signature that tells the compiler a function exists
        // function signature - T identifier ( parameters )
        // function definition - function declaration + implementation
        private static char DisplayMainMenu ()
        {
            //Display output - equivalent to printf, cout
            //Console.Write();
            Console.WriteLine("Movie Library");  //String literals are enclosed in double quotes
            //Console.WriteLine("-------------");
            Console.WriteLine("".PadLeft(20, '-'));

            Console.WriteLine("A) dd Movie");
            Console.WriteLine("V) iew Movie");
            Console.WriteLine("Q) uit");

            //Console input
            do
            {
                string input = Console.ReadLine();  // string ReadLine ()                        

                //if (input == "A" || input == "a")
                //    return 'A';
                //else if (input == "Q" || input == "q")
                //    return 'Q';
                //else if (input == "V" || input == "v")
                //    return 'V';
                switch (input)
                {
                    case "A":
                    case "a": return 'A';

                    case "Q": 
                    case "q": return 'Q';

                    case "V": 
                    case "v": return 'v';
                };

                DisplayError("Invalid option");
            } while (true);
        }

        // Get movie from user
        static void AddMovie ()
        {
            //// Object creation
            ////   1. Allocates memory to store class fields
            ////   2. All fields are initialized to default or field initializer
            ////   3. Calls constructor
            ////   Only 1 constructor will ever be called

            //// new T();
            //// Movie* movie = new Movie();
            //Movie movie;
            //movie = new Movie("Default Title");
            //movie = new Movie();
            
            ////Member access operator 
            ////   member-access  ::= E . Member            

            //// title, release year, run length (min), description, rating
            //Console.Write("Enter a title: ");
            //movie.Title = Console.ReadLine();   // movie.set_Title(Console.ReadLine());

            //Console.Write("Enter an optional description: ");
            //movie.Description = Console.ReadLine();

            //Console.Write("Enter a release year: ");
            //movie.ReleaseYear = ReadInt32(Movie.MinimumReleaseYear);

            //Console.Write("Enter the run length in minutes: ");
            //movie.RunLength = ReadInt32(-1);
            ////Console.WriteLine(movie.RunLength);
            ////for (var index = 0; index < 1000; ++index)
            ////{
            ////    Console.WriteLine(movie.RunLength);
            ////};            

            //Console.Write("Enter the rating: ");
            //movie.Rating = Console.ReadLine();

            //Console.Write("Is a Classic (Y/N)? ");
            //movie.IsClassic = ReadBoolean();

            //var validator = new ObjectValidator(movie);

            ////Validate movie
            //if (!movie.Validate(out var message))
            //{
            //    DisplayError($"Invalid movie: {message}");
            //    return;
            //};

            ////Hiding the field movie
            ////this.movie = movie;
            //_movie = movie;

            //var movie2 = new Movie();
            //movie2.Title = "Jaws 2";
            //movie2.ReleaseYear = 1930;

            ////movie2.IsBlackAndWhite();
            ////movie.IsBlackAndWhite();
            ////movie.DoComplex(1970, true);

            //// Readable but not writable
            //var age = movie.AgeInYears;
            ////movie.AgeInYears = 10;

            //ViewMovie();
        }
        
        static void ViewMovie ()
        {
            //_movie.get_Title()
            Console.WriteLine($"{_movie.Title} ({_movie.ReleaseYear})");
            if (_movie.RunLength > 0)
                Console.WriteLine($"Running Time: {_movie.RunLength} minutes");
            if (!String.IsNullOrEmpty(_movie.Rating))
                Console.WriteLine($"MPAA Rating: {_movie.Rating}");

            Console.WriteLine($"Classic? {(_movie.IsClassic ? 'Y' : 'N')}");

            if (!String.IsNullOrEmpty(_movie.Description))
                Console.WriteLine(_movie.Description);                                                
        }

        // Reads a boolean value from the console.
        static bool ReadBoolean ()
        {
            do
            {
                //ConsoleKeyInfo key = Console.ReadKey();
                string input = Console.ReadLine();

                // input == "Y" || "y" -: Not correct
                // Comparison 1
                //if (input == "Y" || input == "y")
                //    return true;
                //else if (input == "N" || input == "n")
                //    return false;

                //Should use switch but will play around with comparison
                // Not really recommended...
                // Comparison 2
                //if (input.ToUpper() == "Y")
                //    return true;
                //else if (input.ToLower() == "n")
                //    return false;

                // Comparison 3
                if (String.Compare(input, "Y", true) == 0)
                    return true;
                else if (String.Compare(input, "N", true) == 0)
                    return false;

                DisplayError("Please enter either Y or N");
            } while (true);
        }

        // Reads an integer value from the console.
        static int ReadInt32 ( )
        {
            return ReadInt32(Int32.MinValue);
        }

        static int ReadInt32 ( int minimumValue )
        {            
            // WHILE statement
            //  while (Eb) S;   
            //    S executes 0 or more times (pretest)
            // DO WHILE statement
            //  do S while (Eb) ;
            //    S executes at least once (posttest)
            // break statement
            //    only valid in loop constructs
            //    immediately exits the current loop
            // continue statement
            //    only valid in loop constructs
            //    immediately exits the current iteration and checks the loop again

            do
            {
                // Type inferencing - compiler infers type based upon assignment

                //Keep prompting until valid value
                // ? value = 43.5 + 56;
                //string input = Console.ReadLine();
                var input = Console.ReadLine();

                //Fix so it doesn't crash if not integer, use TryParse instead
                //Convert string to int
                //int value = Int32.Parse(input);  //atoi - prefer TryParse

                // IF statement
                // if (Eb) S;
                // if (Eb) 
                //    St 
                // else 
                //    Sf;
                // if (Eb) 
                //    St 
                // else if (Eb)
                //    Stt;
                // else 
                //    Sf;
                //int result;
                //if (Int32.TryParse(input, out result))                
                if (Int32.TryParse(input, out var result))  //Inline variable declaration
                {
                    //Make sure it is at least minValue
                    if (result >= minimumValue)
                        return result;
                    else
                        DisplayError("Value must be at least " + minimumValue);
                } else
                    DisplayError("Value must be numeric");
            } while (true);
        }

        private static void DisplayError ( string message )
        {
            Console.WriteLine(message);
        }

        static Movie _movie;

        #region Demo Code

        void DemoString ()
        {
            //Conversion to string  E.ToString();
            // Console.WriteLine(10);  => Console.WriteLine(10.ToString());
            int hours = 10;
            string hourString = hours.ToString();    // "10"
            hourString = 10.ToString();    // "10"

            //String literals  ""
            // escape sequence - \? inside a string literal, have special meaning to the compiler, generally produce a single character
            //   \n - newline (you will rarely use this)
            //   \t - horizontal tab
            //   \\ - slash (e.g. "C:\\Temp\\test.txt")
            //   \" - double quote  (e.g. "Hello \"Bob\"")
            //   \' - single quote in character 
            //   \x## - hex code equivalent
            string stringLiteral = "Hello" + "World";
            stringLiteral = "Hello\nWorld";

            //Verbatim syntax - escape sequence ignored
            string filePath = "C:\\Temp\\test.txt";
            string filePath2 = @"C:\Temp\test.txt";

            //Empty string
            // null and empty string are not the same
            string emptyString = "";
            string defaultString = null;
            bool areEqual = emptyString == defaultString;   //false
            string emptyString2 = String.Empty;   // "" == String.Empty

            //Checking for empty, use String.IsNullOrEmpty
            bool isEmpty = emptyString == "";
            bool isEmpty2 = emptyString == String.Empty || emptyString == null; //IF empty or null
            bool isEmptyPreferred = String.IsNullOrEmpty(emptyString);   //Handles both

            // String concatenation
            //   +
            //   String.Concat
            //   String.Join
            string first = "Hello", second = "World";

            // start with 3 strings, (first + " "), (first + " " + second)
            string concatOp = first + " " + second;
            string concatFunction = String.Concat(first, " ", second);
            string joinFunction = String.Join(' ', first, second);

            // Strings are immutable!!!!
            //   10 + 2 = 12
            string immutableString = "Hello";
            immutableString += " ";    // two strings: "Hello", "Hello "
            immutableString += "World";  // three strings "Hello", "Hello ", "Hello World"

            // String formatting            
            //     The result of 4 + 5 = 9
            int x = 4, y = 5;
            //int result = x + y;

            //  1) String concatenation - ugly and lot to type
            string format1 = "The result of " + x + " + " + y + " = " + (x + y);

            //  2) String Format - more readable than string concat
            //        - runtime overhead
            //        - missing arguments then crashes
            //     Format specifiers follow the ordinal
            string format2 = String.Format("The result of {0:00} + {1:N2} = {2}", x, y, (x + y));

            // Many message-like functions have overloads that have a string and arguments and call String.Format automatically
            Console.WriteLine(format2);
            Console.WriteLine("The result of {0} + {1} = {2}", x, y, (x + y));

            // 3) String interpolation - let the compiler do it
            //      Only works with string literals
            //      Still has the runtime overhead
            string format3 = $"The result of {x:00} + {y:N2} = {x + y}";

            string formattedValue = x.ToString("00");

            decimal price = 8500;
            string priceString = price.ToString("C");  // $8,500.00

            // Common string functions
            //    String.<function>
            //    <string>.<function>
            int len = priceString.Length;  // Length, in chars, of the string

            // Casing
            var name = "Bob";
            string upperName = name.ToUpper();  //Upper cases string
            string lowerName = name.ToLower();  //Lower cases string

            // Comparison
            //  1)  "a" == "A" //false
            //   int to boolean functions ::=
            //       < 0 means a < b
            //       == 0 means a == b
            //       > 0 means a > b
            //  2) string.CompareTo(string) => int, case sensitive
            var areEqualStrings1 = name.CompareTo("bob") == 0;

            // 3) String.Compare(str, str) => int
            //    String.Compare(str, str, bool ) => int 
            var areEqualStrings2 = String.Compare(name, "bob", true) == 0;  // Case insensitive
            var areEqualStrings3 = String.Compare(name, "bob", StringComparison.CurrentCultureIgnoreCase) == 0;  // Case insensitive

            // Padding / Trimming
            //   <string>.Trim() => string with all whitespace removed from front and back
            //   <string>.TrimStart() / TrimEnd() => only from front and back
            //   <string.PadLeft(width) / PadRight(width) => adds spaces until given width
            string trimmedString = name.Trim();
            string trimmedPath = @"C:\Temp\test\folder1\".Trim('\\', ' ', '\t');

            string paddedString = name.PadLeft(10);

            // Manipulate strings
            string world = "Hello World".Substring(6);
            string wor = "Hello World".Substring(6, 3);
            int index = "Hello World".IndexOf(' ');

            // Matching
            bool startsWithSlash = @"\Temp\test.txt".StartsWith('\\');   
            bool endsWithSlash = @"\Temp\test.txt".EndsWith('\\');            
        }

        void DemoExpressions ()
        {
            //Arithmetic (op1 op op2)
            // op1 and op2 must be exact same type
            // If they are not then type coercion (compiler type casting - always safe)
            //     double + int = double + double = double
            int result = 4 + 5;
            result = 5 - 45;
            result = 8 * 5;
            result = 8 / 5;  // Int division: 1
            result = 8 % 5;  // result: 3  isEven ::= number % 2 == 0

            result = 4 + 6 * 5;  //4 + (6 * 5) = 34

            //Logical (bool op bool => bool)
            //   Not same = x && Y || z  (x && Y) || z not X && (Y || Z)
            bool logicalResult = true && true;  //Logical AND  
            logicalResult = true || true;       //Logical OR
            logicalResult = !true;              //Logical !

            // Relational (op1 rop op2 => bool)
            bool relationalResult = 10 > 20;
            relationalResult = 10 < 20;
            relationalResult = 10 >= 20;
            relationalResult = 10 <= 20;
            relationalResult = 10 != 20;   //Not equal
            relationalResult = 10 == 20;   //Equality

            // Conditional
            //    E ? Et : Ef
            //  if (E)
            //     Et
            //  else
            //     Ef
            //  Et and Ef must be the exact same type


            // Misc
            // assignment  lvalue = E
            //   right associative : evals the right side first and then the left
            logicalResult = relationalResult = false;

            // Prefix and postfix increment and decrements
            result = 5;
            int postfixinc = result++; // result += 1; original value of result
            int prefixinc = ++result;  // result += 1; result
            int postfixdec = result--;
            int prefixdec = --result;

            //Function calls
            //  Parameter ::= variable inside function definition used to store temporary value
            //  Argument ::= expression used to assign a value to a parameter 
            //  Kinds of parameters ::= Foo(x)  
            //    Input (pass by value) - copies the argument value into the parameter's memory location, two separate copies
            //         Foo(12);
            //    Input/Output (pass by reference) - temporarily share the same memory location for two different variables
            //         Foo(ref arg);
            //    Output - Function caller provides space but the function provides the value
            //         Foo(out arg);
            result = ReadInt32();
            result = Int32.Parse("123");

            // Primitive types in .NET map to framework types (type aliasing)
            // int -> Int32
            // double -> Double
            // short -> Int16
            // bool -> Boolean
            // char -> Char
            int int1 = 10;
            Int32 int2 = 20;
            int1 = int2;

            //result = int.Parse("123");  //Int32.Parse("123");            
        }

        // Input parameter - T name
        // Input/Output parameter - ref T name
        // Output parameter - out T name
        void Foo ( int inputParameter, ref double ioParameter, out bool result )
        {
            result = false;
        }

        void DemoTypes ()
        {
            //Primitive types - types known by the compiler

            //integrals - signed
            // sbyte | 1 byte | -128 to 127             (SByte.TryParse/Parse)
            // short | 2 bytes | +-32K                  (Int16.TryParse/Parse)
            // int   | 4 bytes | +-2 billion | default  (Int32.TryParse/Parse)
            // long  | 8 bytes | really large | only for really large values (Int64.TryParse/Parse)
            sbyte sbyteValue = 10;  //int literal
            short shortValue = 10;  //int literal
            int hours = 20;
            long starsInGalaxy = 1_000_000_000;
            long anotherLong = 10L;  //Long literal

            //integrals - unsigned
            // byte   | 1 byte | 0 to 255               (Byte.TryParse/Parse)
            // ushort | 2 bytes | 0 to 64K              (UInt16.TryParse/Parse)
            // uint   | 4 bytes | 0 to 4 billion        (UInt32.TryParse/Parse)
            // ulong  | 8 bytes | really large          (UInt64.TryParse/Parse)
            byte byteCode = 0xAF;
            ushort shortCode = 0x1045;
            uint hourCode = 0x145678;
            ulong longCode = 0b0010_1010_1111;
            ulong ulongCode = 10UL; //ulong literal

            //floating point IEEE
            // float | 4 bytes | +-E38 | 7-9 precision  123.456789
            // double | 8 bytes | +-E308 | 15-17 precision | default
            // decimal | 80 bytes | currency (money) 
            float delta = 4.5F;     //Float literal         (Single.TryParse/Parse)
            double taxRate = 8.75;   //8E-10                (Double.TryParse/Parse)
            decimal payRate = 12.50M;   //Decimal literal   (Decimal.TryParse/Parse)

            //Textual
            // char | 2 bytes | Single character
            // string | * | Text
            char letter = 'A';                  //Char literals are single quoted
            string className = "ITSE 1430";     //String literals are double quoted

            //Miscellaneous
            // bool | 1 bit | true or false
            bool isPassing = true; //false                  (Boolean.TryParse/Parse)
            //int isOK = 1; //Wrong

            //Other (not primitive types)
            // DateTime | Date-time value
            // TimeSpan | Time of day or duration
            // Guid | Unique value
            DateTime today;
            TimeSpan duration;
            Guid uniqueId;
        }

        void DemoVariables ()
        {
            // variable-declaration ::= T id [ = E ] ;
            //   block-style declarations -> put all declarations at top of function, grouped together
            //   inline-style declaration -> declare variables as needed
            string textInput = "";
            //other code...
            //textInput = ""; //should always initialize variables as part of declaration

            // assignment-statement ::= id =  E ;
            //   id - must be an lvalue (left value)
            //   E - any rvalue (right value) provided it is type compatible
            //   operator precedence - order in which operators are evaluated 4 + 5 * 10 = 54
            //   operator associativity - which operand evaluates first (left, right) - right
            //textInput = "Hello";

            //All reads of variables must be definitely assigned
            //  Compiler must be able to verify that all possible code paths to the read ensure that
            //    variable is first written to
            string textInput2 = textInput;

            //MUltiple declarations
            //  variable-declaration ::= T id [ = E ] { , id [ = E ]}* ;
            int x = 10, y = 12;

            //Identifier rules
            // 1. Must start with letter or underscore 
            // 2. Consist of letters or digits or underscores
            // 3. Must be unique in scope
            // 4. Cannot be a keyword 

            //Variable name guidelines
            // nouns, descriptive (e.g. firstName, payRate, hours)
            // generally less than 15 characters long
            // are not single letters (e.g. x, y)
            // no abbreviations or acronyms unless they are well known (good: ok, bad: nbr, num)
            // USE camel casing (capitalize on word boundaries, lowercase first word - e.g. firstName, payRate, hours)

            //Function name guidelines
            // descriptive verbs (e.g. Get..., Display..., Calculate...)
            // Use Pascal casing
            // no abbreviations or acronyms unless they are well known (good: ok, bad: nbr, num)
        }        

        static void DemoTypeChecking ()
        {
            // Type checking - programmer determining type of an expression
            // Type casting - programmer tells compiler type of expression
            // Type coercion - compiler determines type of expression

            double payRate = 7.5;
            int pay;

            // Type checking
            //   1. C-style cast ::= (T)E
            //        Crashes if invalid
            //        Always compiler verified  (int)"Hello";
            pay = (int)payRate;

            //   2. as operator ::=  E as T
            //       Converts an expression to the given type, if valid, or null otherwise
            //       Only works with classes
            object m = null;
            Program p;
            //p = (Program)m;
            p = m as Program;   // At runtime if m is compatible with Program, returns m as a Program else returns null
            if (p != null)
            {
                //Do something with result
            };

            //  3. is operator ::= E is T => bool
            //        type checking, not type casting
            //        works with all types
            if (m is Program)
            {
                p = (Program)m;
            };
            
            //  Preferred approach
            //  4. pattern matching operator ::= E is T id => bool
            //           bool TryParse(out var result)
            if (m is Program prog)
            {
                //prog is Program
            };
        }
        #endregion
    }
}
