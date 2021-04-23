# Character Creator (ITSE 1430)
## Version 2.0

In this lab you will update your Character Creator from the previous lab to be a Windows Forms application.

## Skills Needed

- Windows Forms
   - Forms and layout
   - Controls including TextBox, Button, Label and menus
   - Error Provider

## Story 1 - Set Up Main Window

Create a main window for your new application.

### Description

Copy the existing lab into a new `Lab3` folder and rename the solution.

*Note: You will not need the original console project so you may remove it. However you might want to keep it until you've copied over any code that might be useful in the current lab.* 

1. Open Visual Studio.
1. Create a new project in the copied solution.
    1. Select the `Windows Forms App (.NET)` project template.    
    1. Set the project name to `CharacterCreator.WinHost`.
    1. Create the project.
1. Update to .NET 5.
   1. Right click the project in `Solution Explorer`. Select `Properties` from the menu.
   1. Under the `Application` settings set the `Target Framework` field to `.NET 5.0`.
   1. Close the document tab.
   1. Compile the project. See the note below if you get a build warning `NETSDK1137`*   
1. Add the appropriate file header.

If you get a build warning `NETSDK1137` then you must manually adjust the project file.
Open the project file by clicking it once in `Solution Explorer`.

- Find the line containing `Sdk=` and change the value from `Microsoft.NET.Sdk.WindowsDesktop` to `Microsoft.NET.Sdk`. Note that case is important.
- Find the line containing `<TargetFramework>` and change the value to `net5.0-windows`.
- Rebuild the code.

Add a reference to the business project so you have access to the business code from the previous lab.

For the main window do the following.

- Rename the main window to MainForm.
- Set the following attributes.
    - Title should be `Character Creator`.
    - Default size should be 300 x 450.
    - Minimum size should be 260 x 420.
    - Should open centered on the screen.
- Add a menu for navigating the application. 

### Acceptance Criteria

- Solution opens properly in Visual Studio and loads all projects.
- Project is properly named in repository.
- Code compiles cleanly.
- Main window is properly shown on startup.

## Story 2 - Support Exiting the Program

Implement a command to exit the program.

### Description

Create a new menu item for `File\Exit` with appropriate accelerator keys. The command should be assigned the shortcut key of `Alt+F4`.

When the command is executed close the main window and terminate the application.

### Acceptance Criteria

- Menu option is available to exit program.
- Selecting option closes program.

## Story 3 - Support Help

Implement the command to show help information.

### Descdription

Create a new menu item for `Help\About` with appropriate accelerator keys. The command should be assigned the shortcut key of `F1`.    

When the command is executed show an About form centered in the parent. The form should contain your name, course and name of lab (e.g. Character Creator). The form should provide a button to close it.

### Acceptance Criteria

- Menu option is available to show help.
- Selecting option shows About form.
- Form shows correct data.
- Form can be closed using button.

## Story 4 - Support Adding a New Character 

Allow the user to create a new character. 

### Description

Create a new menu item for `Character\New` with appropriate accelerator keys. The command should be assigned the shortcut key of `Ctrl+N`.

When the command is executed show a form to collect the character information. The form will have the following attributes.

 - The title will be `Create New Character`.
 - The form will be centered on the parent.
 - The form will not be resizable and will appropriately fit the contents.
 - The form will not have an icon, minimize or maximize buttons.
 - Ensure all controls and labels are lined up properly.  

The form will display the fields from the `Character` class defined in the business project. For each field.

- Include an appropriate label.
- Use the appropriate control. For profession/race use a `ComboBox`. 
- The fields should tab in a logical order.

Heroes are not average people so set each attribute to an initial value of `50`.

The combo boxes should not allow freeform text. Only the pre-defined options should be available. 
Refer to the [ComboBox Control](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-4/controls-combobox.adoc) section of the book for information on how to use it.

The form will have a `Save` button that will save the character. 
If there is any validation issues then prevent the form from closing. 

The form will return the newly created character. 
Create an instance of the `Character` class to store the character information and provide it back to the main form.

The form will have a `Cancel` button that will cancel the creation. No validation is done and no changes should be made.

### Acceptance Criteria

- When selected the form is shown.
- Attributes default to the appropriate value.
- Saving saves the character.
- Cancel closes the form without validation and without making any changes.

## Story 5 - Display Roster

Display the roster of characters that have been defined in the main window.

### Description

*Note: For this lab there will only be 1 character in the roster.*

Display the roster in the main form. Use a `ListBox` that displays the character's name.
Ensure that the items in the list box are associated with the character data so it can be used in a later story.
Refer to the [ListBox Control](https://github.com/michaeltccd/ITSE1430-docs/blob/master/book/chapter-4/controls-listbox.adoc) section of the book for more information on how to work with it.

The control should resize as the form is resized to allow for a user to see the entire roster, if necessary.

### Acceptance Criteria

- List of characters are shown in the main form.
- If a character is added then it appears in the main form.
- The list resizes as the main form is resized.

## Story 6 - Support Editing a Character

Allow the user to edit an existing character.

### Description

Create a new menu item for `Character\Edit` with appropriate accelerator keys. The command should be assigned the shortcut key of `Ctrl+O`.

When the command is selected get the currently selected character from the roster. If no character is selected then do nothing. 

If a character is selected then show show the character form again with the selected character information already populated. The form will behave the same as when creating a new character with the following exceptions.

- Change the form title to `Edit Character`.
- When the form is loaded the data should be pre-populated based upon the currently selected character's values.
- When saving the character the existing character instance should be updated instead.

The roster should be refreshed after saving to reflect any changes in the name.

### Acceptance Criteria

- Selecting a character in the roster and then excuting the command properly displays the character in the form.
- Saving the character updates the existing character.
- Roster is refreshed after save.
- Cancelling the edit does not change data.

## Story 7 - Support Deleting a Character

Allow the user to delete an existing character.

### Description

Create a new menu item for `Character\Delete` with appropriate accelerator keys. The command should be assigned the shortcut key of `Del`.

When the command is selected get the currently selected character from the roster. If no character is selected then do nothing. 

If a character is selected then display a confirmation message that asks if the user wants to delete the given character. Include the character name in the message.

The roster should be refreshed after saving to reflect any changes in the name.

### Acceptance Criteria

- Selecting a character in the roster and then excuting the command prompts for confirmation with the character's name.
- Confirming the message deletes the character and refreshes the list.
- Cancelling the confirmation does not change anything.

## Story 8 - Support Error Provider

Add the `ErrorProvider` to the add (and edit) forms for characters.

### Description

Update the add (and edit if different) forms to use the `ErrorProvider` to report errors in fields.

- Validate each field following the rules for validation of that field (e.g. required, range, etc)
- If a field has an invalid value then display an error next to it.
- When validating the user should be able to navigate to other controls but an error should be shown next to the invalid fields. 
- When the user attempts to save the changes then ensure all the controls are valid before attempting to save.
- If the user cancels the form then no validation errors should occur.

### Acceptance Criteria

- Entering an invalid value in a field causes the error icon to display when tabbing away.
- User can navigate away from field even if invalid.
- Attempting to save when a field is invalid should display the error icon(s) appropriately.
- Cancel closes the form without validation and without making any changes.

## Hints

### Naming Conventions

- DO NOT worry about the field names for controls you do not programmatically use (e.g. menu items). The defaults are fine.
- USE descriptive field names for controls you will work with in code (e.g. text boxes).
- USE descriptive method names for event handlers (e.g. `OnFileExit` instead of `menuItem1_Clicked`).
- USE nouns for variable and parameter names.
- USE verbs for method names.
- DO ensure your spelling for identifiers.
- DO use camel casing for variables, parameters and fields.
- DO use Pascal casing for types and public members.

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in MyTCC by providing the link to the Github repository.