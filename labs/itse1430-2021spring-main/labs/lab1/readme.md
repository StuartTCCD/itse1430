# Budget (ITSE 1430)
## Version 1.2

In this lab you will create a console application to manage a simple budget.

[Skills Needed](#skills-needed)\
[Lab 1 Adjusments](#lab-1-adjustments)\
[Story 1](#story-1)\
[Story 2](#story-2)\
[Story 3](#story-3)\
[Story 4](#story-4)\
[Story 5](#story-5)\
[Story 6](#story-6)\
[Story 7](#story-7)\
[General Guideline](#general-guidelines) \
[Console Help](#console-help)\
[String Help](#string-help)\
[Requirements](#requirements)

## Skills Needed

- C#
  - Control flow statements
  - Functions and parameters
  - Types
  - Variables
- Console read/write
  
## Lab 1 Adjustments

Because this is the first lab some C# guidelines cannot be followed until later in the course.
Some adjustments are necessary for the first lab.

### Variable Scope

Make all variables local to the function they are used in.
If a single value needs to be returned then use the function return value.
If more than two values are needed move the variable declaration of the impacted variables outside all functions and mark each one as `static`.

```csharp
void Foo ()
{
  id = 10;
}

void Bar ()
{
  Console.WriteLine(id);
}

static int id;
```

*NOTE 1: Do not make temporary variables static just to avoid creating multiple variables (e.g. index).*

*NOTE 2: Ensure that any impacted variable is moved out of the function and not copied. Failure to remove the original variable will result in code that compiles but does not execute properly.*

### Function Declarations

Functions need to be marked as `static`. Failure to do so will result in unresolved references when trying to call them.

```csharp
static void Foo ()
{}
```

## Story 1 - Create the Project

Create a new console project to hold your code.

### Description 

For this first lab here are the directions.

*Note: These instructions assume you are using the Git Changes window. For newer Visual Studio versions this should be the default. If you do not see this option then go to `Tools\Options`. Then go to the settings under `Environment\Preview Features`. Finally select the box next to `New Git user experience`.*

1. Start Visual Studio.
1. Connect to your repository by opening the repository in Visual Studio if you have not already done so.
1. Create a new project by using the `Create a new project` option in the `Start Window`.
   1. Under the languages filter select `C#`. Then search for the template `Console App`.
   1. Select `Console App (.NET Core)`. Ensure that the language is shown as `C#`. Click `Next`.
   1. For the project name use `Budget`.
   1. For the solution name use `Lab1`.
   1. Ensure the project location is set to the `Labs` folder of your Github repository that you have previously created in class.
   1. Click `Create` to create the project.
1. Update to .NET 5.
   1. Right click the project in `Solution Explorer`. Select `Properties` from the menu.
   1, Under the `Application` settings set the `Target Framework` field to `.NET 5`.
   1. Close the document tab.
   1. Compile the project.
1. Add the appropriate file header.
   1. Open the `Program.cs` file if it is not yet open.
   1. Add a file header at the top that specifies the class name, semester and your name.
      ```csharp
      /*
       * Budget
       * ITSE 1430
       * Semester 20YY
       * My Name
       */
      ```
1. Commit the lab to Github.
   1. Go to the `Git Changes` window.
   1. Verify there is a `Lab1` folder, and files, under your `Labs` folder.
   1. If there are no files and folders then you did not place your solution in the correct location. 
      1. Use `Solution Explorer` to jump to the correct solution folder (`Lab1`).
      1. Close Visual Studio.
      1. Move the `Lab1` folder to the correct location. DO NOT copy the folder.
      1. Start Visual Studio and verify it is now correct.
      1. Ensure that when you open your `Lab1` solution it is in the new folder and not the old one.
   1. Add a commit message.
   1. Use the `Commit and Push` command to commit the changes locally and push to Github.
   1. If this is your first commit from Visual Studio you will get prompted for your Github credentials.
   1. Go to Github in the browser and verify your files are there. If they are not then your commit did not work correctly. Refer to the class documentation on possible issues pushing to Github.

### Acceptance Criteria

- Solution is properly stored in Github under the `Labs\Lab1` folder.
- Code compiles. 

## Story 2 - Display Program Information

Display basic program information.

### Description

When the program starts display basic program information. 

Remove the existing output code, if any. Display the program title `Budget`, course name (`ITSE 1430`), semester and year and your name.

*NOTE: This is only done at application startup.*

### Acceptance Criteria

- The application compiles cleanly without warnings or errors.
- The application runs.
- Can see the program information on startup.

*NOTE: Remember to commit and push changes to Github.* 

## Story 3 - Get Starting Account 

Prompt the user for the starting account information.

### Description

Prompt the user for the account information.
Do this as soon as the application starts.
The user will not be able to change this later so they will only do this once.

The following information is needed.

| Name | Required? | Description |
| - | - | - |
| Account Name | Yes | An account name that is provided by the user. |
| Account Number | Yes | An account number. See below for more information. |
| Starting Balance | Yes | The starting balance. The balance must be greater than zero. Use `decimal` for the type because this is currency. |

In all cases perform input validation.
If the input is invalid then keep prompting until the user enters the correct information.
Show descriptive error messages such as `Value is required` or `Number must consist of only digits`.

The account number has the following requirements.

- Must consist of only digits (0-9).
- Must be exactly 12 characters long.
- May not start or end with a zero.

Because account numbers are large do not attempt to store them in numeric types or use numeric functions. They will not work properly. Refer to the guidance later in the lab for how to handle account numbers.

*Note: Account information is needed for the entire application so the information needs to be stored outside the function. Refer to the earlier adjustements for lab 1 for more information.*

### Acceptance Criteria

- User is prompted for the starting information.
- Input is validated and errors shown. User is prompted to enter information again.
- Required fields are required.
- Account number is properly validated.
- Balance is greater than zero.

## Story 4 - Display the Main Menu

Display a menu of options to the user.

### Description

The user will need to choose from a list of options in a menu. Set up a simple menu function that displays the available menu options, validates the user input and calls the appropriate function to handle the request.

If the user enters an invalid option then display an error and prompt them again. For now put in a test menu option to verify the behavior is working. Remove it when done.

For user input you should use either letters or numbers to get input (you don't need both). For example a quit command may be mapped to the letter `Q` or the number `0`. You may use whichever is easiest for you but be consistent. 

*Note: When using letters case should not matter.*

Unless otherwise stated after a command is executed the user should return to the main menu so they may choose another option.

The account information should be shown at the top of the menu in all cases. The balance should be formatted as currency.

*Note 1: Create a helper function to display the menu. This may be useful later.*
*Note 2: Consider using an enumeration to identify the options.*
*Note 3: To show prices use the currency format specifier `balance.ToString("C")`.*

### Acceptance Criteria

- Account information is shown above the menu each time it is shown.
- User is shown a menu of options.
- If a user selects a valid menu option then that action is performed.
- If a user selects an incorrect option then they receive an error message and can try again.
- If letters are used for menu options then case does not matter.

## Story 5 - Quit

Allows the user to exit the program.

### Description

Add a menu option to quit the program.
It should always be the last option.

Implement the quit function.
If the user selects the quit option then prompt them for confirmation and then quit.
If the user does not confirm then return to the main menu.

*Note: Consider creating a function to prompt for Yes/No questions and return a boolean result. A simple Y/N is sufficient. Remember case is insensitive.*

### Acceptance Criteria

- Command appears as last option in menu.
- Selecting command prompts user to confirm.
- User is limited to the defined yes/no options.
- Case does not matter on user input.
- Confirming quit terminates program.
- Declining quit returns to menu.

## Story 6 - Allow Money Deposits

Allows the user to deposit money to the account.

### Description

Add an option to the menu to deposit money to the account. To deposit money the user must provide some information first.

| Name | Required? | Description |
| - | - | - |
| Amount | Yes | The amount as a positive number. |
| Description | Yes | The description of the transaction. |
| Category | No | The optional category of the transaction (e.g. `Housing`). |
| Check Number | No | The optional check number read as an integral value. |
| Date | No | The entry date. Defaults to the current date if not specified. The format is `MM/dd/yyyy`. |

*NOTE: Refer to `String Parsing` in the book for information on string parsing.*

For each input, validate the user has met the requirements of the field.
If not then continue prompting for that input until they enter it correctly. 
DO NOT move to the next input until the previous input is valid.

If the amount of `0` is entered then skip prompting for the remaining information and return to the main menu.

After the information has been entered and validated update the balance for the account.

Display a confirmation that the information was added.

*Note 2: Consider adding helper functions to collect standard information such as required strings.*

*Note 3: None of the information, other than current balance, is needed after the data entry. Do not store the values outside the function.*

### Acceptance Criteria

1. Users is prompted for each piece of information.
1. Input validation is performed based upon requirements.
1. Account balance is updated and success message displayed.
1. User returns to the main menu.
1. If user enters 0 for amount then remaining information is skipped and request is cancelled.

## Story 7 - Allow Money Withdrawals

Allows the user to withdraw money from the account.

### Description

The requirements are identical to the previous story including the input collection and validation. The following differences exist.

- Instead of adding to the current balance the amount is subtracted from the balance.
- If the user attempts to subtract more than the current balance then display an error.

*NOTE: The amount input is still positive (> 0) and should be subtracted from the balance.*

### Acceptance Criteria

1. Users is prompted for each piece of information.
1. Input validation is performed based upon requirements.
1. Account balance is updated and success message displayed.
1. User returns to the main menu.
1. If user enters 0 for amount then remaining information is skipped and request is cancelled.

## General Guidelines

### General 

- It is strongly recommended that you complete the stories in order. Some stories rely on the work done in previous stories.
- Commit your changes to Github frequently to ensure you don't lose any work. You do not need to wait for a story to be completed.
- After you implement a story ensure it meets all the acceptance criteria. In some cases a later story may change the behavior of an earlier story.
- After you complete a story you should commit the changes you've made to Github. If something comes up and you are not able to complete the remaining stories you can at least get credit for the work you've done.
- Unless otherwise stated all inputs must be validated to ensure they are of the current type and range as given in the assignment.

### Naming Conventions

- USE descriptive nouns for variable and parameter identifiers (e.g. `payRate`, `name`, `index`).
- USE descriptive verbs for function identifiers (e.g. `GetName`, `ShowProgress`).
- DO NOT use single letters or abbreviations in identifiers (e.g. `x`, `descriptValue`).
- DO ensure spelling for identifiers.
- DO use camel casing for variables, parameters and fields.
- DO use Pascal casing for types and public members.

### Coding Style

- DO put a file header at the top of each file you create. The file header should contain the class, date and your name.
  ```csharp
  /*
   * Your Name
   * ITSE 1430 
   * Lab 1
   */
  ```
- DO use consistent indentation. In general each block indents one time (3 or 4 spaces). Curly braces should be aligned.
  ```csharp
  //NO
  while (someCondition) 
     { 
    Foo();
	     };
		 
  //YES
  while (someCondition)
  {
     Foo();
  };
  ```
- DO use a single blank line between blocks of code (e.g. functions, control flow statements, etc).
  ```csharp
  //NO
  void DoWork ()
  {
  }
  void DoMoreWork()
  {
  }
  
  //YES
  void DoWork ()
  {
  }
  
  void DoWork ()
  {
  }
  ```
- DO consider declaring variables just before or as part of their first usage instead of up front.
  ```csharp
  //NO
  int hours;
  double payRate, totalPay;
  ...
  totalPay = payRate * hours;
  
  //YES
  double totalPay = payRate * hours;
  ```
- DO put comments above code that is not clear.
- DO NOT put comments in code that repeats what the code does.
  ```csharp
  //NO
  //Loop through stuff
  for (...)
  //YES
  for (...)
  ```
### Console Help 

Refer to the `Console` section of the book for information on using the console.

### String Help

Use the [https://docs.microsoft.com/en-us/dotnet/api/system.char.isdigit](Char.IsDigit) function to determine if a character is a digit or not.

```csharp
for (int index = 0; index < stringValue.Length; ++index>)
{
   if (!Char.IsDigit(stringValue, index))
      ; //Not a digit      
}
```

This can be used in a helper function to determine if the entire string is only digits.

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in MyTCC by providing the link to the Github repository.