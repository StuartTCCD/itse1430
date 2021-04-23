# Character Creator (ITSE 1430)
## Version 1.0

In this lab you will update the Character Creator to use a database and provide error handling.

## Skills Needed

- C#
   - Exceptions
   - Try-Catch
   - IDisposable
   - IValidatableObject
   - Using statement
- ADO.NET
   - Connections
   - Commands
   - Reading and writing Data

*Note: Remember that business types belong in the business project and should not have any UI.*

## Story 0 - Set Up Database

For this lab you will need the database contained in the lab folder.

### Description

Do the following to set up the database.

1. Copy the zip file from the lab folder in Github to a temporary location on your local machine.
1. Extract the contents of the zip folder to the solution folder of your lab. It should be at the same level as the other projects.
1. In Solution Explorer right click the solution and select `Add \ Existing Project`.
1. Select the project to add it to the solution.

To use the database it is necessary to first deploy it. This only needs to be done once.

1. Right click the database project in Solution Explorer and select `Set as Startup Project`.
1. Debug the solution using `F5` or whatever approach you normally use.
1. The database project should get deployed automatically. Refer to the Output window to confirm.
1. Once the database project is deployed use `Sql Server Object Explorer` to confirm it appears. Note that you may need to refresh the view first.
1. Set the UI project back to the startup project.

## Story 1 - Implement Validation Support in Character Class

Change the existing validation support in the `Character` class to use `IValidatableObject` instead.

### Description

Modify the `Character` class to implement the `IValidatableObject` interface.
The existing validation should be modified/removed in lieu of the new implementation.

Update the remaining code to call the `IValidatableObject` version for validation.

*Note: You may reuse the wrapper type we created in class to help with validation if desired.*

### Acceptance Criteria

- Custom validation logic is removed.
- Character class properly implements `IValidatableObject`.
- All validation rules remain unchanged.
- Remaining code is using `IValidatableObject` implementation.

## Story 2 - Update Business Layer to Raise Errors

Update the existing business library to use exceptions instead of error parameters and return values.

### Description

Update the `ICharacterRoster` interface and all implementations to remove all references to any error parameters or return values.
For each scenario that currently reports an error, replace with throwing an exception instead.
Ensure the proper exception type is being used and that the exception message is clear.

*Note: For cases where this is no existing type use `Exception`.*

For example the original `Add` method had an out parameter called `error` and returned the added movie. 
With this story the `error` parameter is removed and any previous errors will now result in exceptions.
All the existing validation and business rules still apply.

*Note: The code will not compile at this point. This will be resolved after the next story.*

### Acceptance Criteria

- Interface no longer has any error parameters or return values.
- Implementations no longer have any error parameters or return values.
- Code compiles

## Story 3 - Update the UI to Handle Errors

Update the UI to capture and report any errors that occur while calling the business layer.

### Description

In each place the roster is called remove the existing error argument, if any.
Ensure that any exception raised by the business layer is handled and reported to the user.
It is not necessary to do any filtering or conversion of exceptions.

*Note: No business rules have changed so if an error occurs the behavior should remain the same as previous labs.*

### Acceptance Criteria

- Exceptions from the business layer are properly handled and reported.
- References to any error arguments are removed.

## Story 4 - Implement a Roster for a SQL Server Database

Create a new `ICharacterRoster` implementation that uses a SQL Server database.

### Description

Create a new business project called `CharacterCreator.SqlServer` of type `Class Library` to store the implementation.

*Note: Ensure the project is for .NET 5 and C#.*

Add the appropriate references so that the new project can reference the existing business library.
DO NOT replace the existing business project or its code. The new project is in addition to the existing business library.

Create a new roster implementation called `SqlServerCharacterRoster` that implements the `ICharacterRoster` interface. 
For now auto-generate the interface members so the code will compile.

This implementation will require the connection string to use so ensure the constructor accepts the connection string.

*Note: DO NOT hard code any connection strings in this code.*

### Acceptance Criteria

- File header and type documentation are written.
- New project properly created.
- New implementation is appropriately named.
- New implementation has a constructor accepting the connection string to use.
- Project properly references business library project.

## Story 5 - Update UI

Update the UI to use the new roster implementation.

### Description

Replace the existing in-memory roster field with the new SQL Server roster implementation.
If the previous labs have been properly implemented then the only change that should be needed is the `new` expression creating the roster.

*Note: You will need to add a reference to the new project that was created.*

To create the instance a connection string will be needed. 
To get the connection string, assuming you have already deployed the database properly, do the following.

1. Open the `Sql Server Object Explorer` window if it is not yet open.
1. Under the LocalDB's `ProjectsV##` node (e.g. `(localdb)\projectsV13`) expand the databases.
1. If the deployed database does not appear then right click and refresh. If it still does not appear then it was not properly deployed.
1. Select the database and then in the `Properties` window find the `Connection String` property under `General` and select it.

*Note: If the `Properties` window contains only a few properties then there is a refresh issue, expand the database node to trigger a refresh.*

Once the connection string has been copied paste it into a string literal that is passed as a parameter to the constructor.

*Note: Normally this information should not be hard coded into an application. A better place is the application's configuration file but that requires more effort than is needed for this lab.*

### Acceptance Criteria

- Field is properly initialized to the new SQL Server roster implementation.
- Connection string is properly loaded.
- Code compiles cleanly.

## Story 6 - Implement Get All Support

Implement support for getting all characters from the roster implementation.

### Description

Implement the method for getting all the characters by calling the appropriate stored procedure.

*Note: After typing in the first SQL type such as `SqlConnection` quick action and select the `Install System.Data.SqlClient \ Find and Install` option to add the appropriate reference.*

Stored Procedure: `GetAllCharacters`
Parameters: None
Returns: A set of:
  - Id (int, not null)
  - Name (string, not null)
  - Description (string, nullable)
  - Profession (string, not null)
  - Race (string, not null)
  - Attribute1 to Attribute5 (int, not null)
  
*Note: Don't forget to set `ConnectionType` to `StoredProcedure` otherwise the command will fail.*
 
Now that the roster is persisted it is possible that characters will be available from a previous run.
Update the UI to load the initial set of data when the form is loaded using the `OnLoad` method.

*Note: If the open request fails then there is a problem with the connection string or the database is not properly deployed.*

### Acceptance Criteria

- When initially loading the main window the roster is loaded with any existing data from the database.
- Can read a character with and without a description.

## Story 7 - Implement Add Support

Implement support for adding a character to the roster implementation.

### Description

Implement the method for adding a character by calling the appropriate stored procedure.

*Note: All the business rules and validation still apply to this method. The database should not report any errors.*

Stored Procedure: `AddCharacter`
Parameters: 
  - @name (string, not null)
  - @description (string, nullable)
  - @profession (string, not null)
  - @race (string, not null)
  - @attribute1 to @attribute5 (int, not null, must be between 1 and 100)
Returns: Decimal representing the ID of the new character.  
  
*Note: To convert a decimal to an int use the `Convert.ToInt32` function.*

Refer to the section `Additional Stored Procedures` for additional stored procedures that may be needed.

### Acceptance Criteria

- Character is properly validated including null, validation and unique name.
- Method returns uniquely identified character.
- UI properly adds character to roster.
- Validation errors cause a message to be shown and the user is returned to the edit form.
- User cannot add a duplicate character.

## Story 8 - Implement Edit Support

Implement support for editing a character to the roster implementation.

### Description

Implement the method for editing a character by calling the appropriate stored procedure.

*Note: All the business rules and validation still apply to this method. The database should not report any errors.*

Stored Procedure: `UpdateCharacter`
Parameters: 
  - @id (int, not null)
  - @name (string, not null)
  - @description (string, nullable)
  - @profession (string, not null)
  - @race (string, not null)
  - @attribute1 to @attribute5 (int, not null, must be between 1 and 100)
Returns: None
  
Refer to the section `Additional Stored Procedures` for additional stored procedures that may be needed.

### Acceptance Criteria

- Can select and edit all characters in roster.
- ID of the updated character is not changed (e.g. updating character with ID 5 does not change its ID).
- UI properly updates to show changed character.
- Validation errors cause a message to be shown and the user is returned to the edit form.
- User cannot add a duplicate character.

## Story 9 - Implement Delete Support

Implement support for deleting a character to the roster implementation.

### Description

Implement the method for deleting a character by calling the appropriate stored procedure.

Stored Procedure: `DeleteCharacter`
Parameters: 
  - @id (int, not null)
Returns: None

Refer to the section `Additional Stored Procedures` for additional stored procedures that may be needed.

### Acceptance Criteria

- Can select and delete a character from the roster.
- UI properly updates to remove deleted character.
- Validation errors cause a message to be shown.

## Additional Stored Procedures

The following additional stored procedures are available if needed.

### FindCharacterByName

Finds characters by their, case insensitive, name.

Parameters: 
  - `@name` (string, not null)
Returns: A set of:
  - Id (int, not null)
  - Name (string, not null)
  - Description (string, nullable)
  - Profession (string, not null)
  - Race (string, not null)
  - Attribute1 to Attribute5 (int, not null)
  
### GetCharacter

Gets a character by its ID.

Parameters: 
  - `@id` (int, not null)
Returns:
  - Id (int, not null)
  - Name (string, not null)
  - Description (string, nullable)
  - Profession (string, not null)
  - Race (string, not null)
  - Attribute1 to Attribute5 (int, not null)

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in MyTCC by providing the link to the Github repository.
