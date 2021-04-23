<<<<<<< HEAD
﻿/*
 * Character Creator
 * ITSE 1430
 * Spring 2021
 * Stuart Beeby
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.ConsoleHost
{
    class CharacterCreatorConsoleHost
    {
        static CharacterCreator s_character;
        static void Main(string[] args)
        {
            bool quit = false;
            char choice;
            bool first = false;

            Clear();
            choice = DisplayInitialText();
            do
            {
                switch (choice)
                {
                    case 'Y': CreateCharacter(); break;
                    case 'N': first = QuitHelper(); break;
                }
                if (choice == 'Y')
                {
                    break;
                }
                if (first == true)
                {
                    break;
                }
                Clear();
                choice = DisplayInitialText();
            } while (true);

            /*
             * 1 = create new character
             * 2 = view stats
             * 3 = edit character 
             * 4 = quit
             */
            if (!first)
            {
                choice = MainMenu();
                do
                {

                    switch (choice)
                    {
                        case '1': CreateCharacter(); break;
                        case '2': ViewStats(); break;
                        case '3': EditCharacter(); break;
                        case '4': DeleteCharacter(); break;
                        case '5': quit = QuitHelper(); break;
                    }
                    if (quit)
                    {
                        first = true;
                    }
                    Clear();
                    choice = MainMenu();
                } while (!quit);
            }
        }

        private static char DisplayInitialText()
        {
            Console.WriteLine("Character Creator\nCourse : 1430\nSpring 2021\nAuthor : Stuart Beeby\nWould you like to create a character? Y/N");
            do
            {
                String input = Console.ReadLine();
                if (String.Compare(input, "Y", true) == 0)
                {
                    return 'Y';
                }
                if (String.Compare(input, "N", true) == 0)
                {
                    return 'N';
                }
                Clear();
                Console.WriteLine("Sorry you've entered something invalid.\nWould you like to create a new character? Y/N");
            } while (true);
        }

        static char MainMenu()
        {
            Clear();
            Console.WriteLine($"Welcome {s_character.characterName} what would you like to do?\n");
            Console.WriteLine("1) Create a new character\n2) View your stats\n3) Edit your character\n4) Delete character\n5) Quit");
            do
            {
                String input = Console.ReadLine();
                switch (input)
                {
                    case "1": return '1';
                    case "2": return '2';
                    case "3": return '3';
                    case "4": return '4';
                    case "5": return '5';
                }
                Clear();
                Console.WriteLine("You've entered something invalid\n please select from the options below");
                Console.WriteLine("1) Create a new character\n2) View your stats\n3) Edit your character\n4) Delete Character\n5) Quit");
            } while (true);
        }

        static void CreateCharacter()
        {
            CharacterCreator character = new CharacterCreator();
            String[] attribute = { "Strength", "Intelligence", "Agility", "Consitution", "Charisma" };
            int attributeNumber;
            bool valid = false;
            bool working = false;

            Clear();
            Console.WriteLine("Please enter your character name: ");
            character.characterName = Console.ReadLine();
            Clear();
            Console.WriteLine("Please select a profession.\nChoices:\n1) Fighter\n2) Hunter\n3) Priest\n4) Rogue\n5) Wizard");
            character.characterProfession = ProfessionHelper();
            Clear();
            Console.WriteLine("Please select a race.\nChoices:\n1) Dwarf\n2) Elf\n3) Gnome\n4) Half Elf\n5) Human");
            character.characterRace = RaceHelper();
            Clear();
            Console.WriteLine("Would you like to enter a biography? Y/N");
            character.characterBiography = BiographyHelper();
            for (int i = 0; i < 5; i++)
            {
                Clear();
                Console.WriteLine($"Please enter your {attribute[i]} stat");
                attributeNumber = AttributeHelper();
                character.characterAttributeValue[i] = attributeNumber; ;
            }
            s_character = character;
        }

        static String ProfessionHelper()
        {
            String input;
            input = Console.ReadLine();
            do
            {
                switch (input)
                {
                    case "1": return "Fighter";
                    case "2": return "Hunter";
                    case "3": return "Priest";
                    case "4": return "Rogue";
                    case "5": return "Wizard";
                }
                Clear();
                Console.WriteLine("You've entered something invalid.\nPlease select a profession from the list below\n1) Fighter\n2) Hunter\n3) Priest\n4) Rogue\n5) Wizard");
                input = Console.ReadLine();
            } while (true);

        }

        static String RaceHelper()
        {
            String input = Console.ReadLine();
            do
            {
                switch (input)
                {
                    case "1": return "Dwarf";
                    case "2": return "Elf";
                    case "3": return "Gnome";
                    case "4": return "Half Elf";
                    case "5": return "Human";
                }
                Clear();
                Console.WriteLine("You've entered something invalid.\nPlease select a race from the list below\n1) Dwarf\n2) Elf\n3) Gnome\n4) Half Elf\n5) Human");
                input = Console.ReadLine();
            } while (true);
        }

        static String BiographyHelper()
        {
            bool bioQuitter = false;
            String bio = "";
            String input = Console.ReadLine();
            do
            {
                if (String.Compare(input, "Y", true) == 0)
                {
                    Clear();
                    Console.WriteLine("Please enter your biography below\nWhen you are done, type \"QUIT\"");
                    do
                    {
                        input = Console.ReadLine();
                        if (String.Compare(input, "QUIT", true) == 0)
                        {
                            bioQuitter = true;
                        }
                        bio += input;
                        bio += "\n";
                    } while (!bioQuitter);
                    return bio;
                }
                if (String.Compare(input, "N", true) == 0)
                {
                    return "";
                }
                Clear();
                Console.WriteLine("You've entered something invalid.\nWould you like to enter a biography? Y/N");
                input = Console.ReadLine();
            } while (true);
        }

        static int AttributeHelper()
        {
            int number;
            String input = Console.ReadLine();
            do
            {
                if (Int32.TryParse(input, out number))
                {
                    if (number > 0 && number < 101)
                    {
                        return number;
                    }
                }
                Clear();
                Console.WriteLine("You've entered something invalid\nPlease enter a number between 1-100");
                input = Console.ReadLine();
            } while (true);
        }

        static void ViewStats()
        {
            bool done = false;

            do
            {
                Clear();
                Console.WriteLine($"Name : {s_character.characterName}\n");
                Console.WriteLine($"Profession : {s_character.characterProfession}\n");
                Console.WriteLine($"Race : {s_character.characterRace}\n");
                if (!String.IsNullOrEmpty(s_character.characterBiography))
                {
                    Console.WriteLine($"Biography :\n{s_character.characterBiography}\n");
                }
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{s_character.characterAttributeNames[i]} : {s_character.characterAttributeValue}\n\n");
                }
                Console.WriteLine("Type \"QUIT\" to quit");
                String input = Console.ReadLine();
                if (String.Compare(input, "QUIT", true) == 0)
                {
                    done = true;
                }
            } while (!done);
        }

        static void EditCharacter()
        {
            Clear();
            Console.WriteLine("What would you like to edit?\n1) Name\n2) Profession\n3) Race\n4) Biography\n5) Attributes\n\n6) Back");
            String input = Console.ReadLine();
            switch (input)
            {
                case "1": NameEditor(); break;
                case "2": ProfessionEditor(); break;
                case "3": RaceEditor(); break;
                case "4": BiographyEditor(); break;
                case "5": AttributeEditor(); break;
            }
        }

        static void NameEditor()

        {
            Clear();
            Console.WriteLine("Please enter your new name");
            String input = Console.ReadLine();
            s_character.characterName = input;
        }

        static void ProfessionEditor()
        {
            Clear();
            Console.WriteLine("Please select your new profession\n1) Fighter\n2) Hunter\n3) Priest\n4) Rogue\n5) Wizard");
            String input;
            input = Console.ReadLine();
            do
            {
                switch (input)
                {
                    case "1": s_character.characterProfession = "Fighter"; return;
                    case "2": s_character.characterProfession = "Hunter"; return;
                    case "3": s_character.characterProfession = "Priest"; return;
                    case "4": s_character.characterProfession = "Rogue"; return;
                    case "5": s_character.characterProfession = "Wizard"; return;
                }
                Clear();
                Console.WriteLine("You've entered something invalid.\nPlease select your new profession from the list below\n1) Fighter\n2) Hunter\n3) Priest\n4) Rogue\n5) Wizard");
                input = Console.ReadLine();
            } while (true);
        }

        static void RaceEditor()
        {
            Clear();
            Console.WriteLine("Please select your new race\n1) Dwarf\n2) Elf\n3) Gnome\n4) Half Elf\n5) Human");
            String input = Console.ReadLine();
            do
            {
                switch (input)
                {
                    case "1": s_character.characterRace = "Dwarf"; return;
                    case "2": s_character.characterRace = "Elf"; return;
                    case "3": s_character.characterRace = "Gnome"; return;
                    case "4": s_character.characterRace = "Half Elf"; return;
                    case "5": s_character.characterRace = "Human"; return;
                }
                Clear();
                Console.WriteLine("You've entered something invalid.\nPlease select a race from the list below\n1) Dwarf\n2) Elf\n3) Gnome\n4) Half Elf\n5) Human");
                input = Console.ReadLine();
            } while (true);
        }

        static void BiographyEditor()
        {
            bool bioQuitter = false;
            String bio = "";
            do
            {
                Clear();
                Console.WriteLine("Please enter your new biography below\nWhen you are done, type \"QUIT\"");
                String input = Console.ReadLine();
                do
                {
                    input = Console.ReadLine();
                    if (String.Compare(input, "QUIT", true) == 0)
                    {
                        bioQuitter = true;
                    }
                    bio += input;
                    bio += "\n";
                } while (!bioQuitter);
                s_character.characterBiography = bio;
                return;
            } while (true);
        }
        static bool QuitHelper()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to quit? Y/N");
            String input = Console.ReadLine();
            input = input.ToUpper();
            if (String.Compare(input, "Y", true) == 0)
            {
                return true;
            }
            return false;
        }

        static void DeleteCharacter()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to delete your character? Y/N");
            String input = Console.ReadLine();
            input = input.ToUpper();
            if (String.Compare(input, "Y", true) == 0)
            {
                DeleteHelper();
            }
            return;
        }

        static void DeleteHelper()
        {
            Console.WriteLine("You currently don't have a character, would you like to create a character? Y/N");
            do
            {
                String input = Console.ReadLine();
                if (String.Compare(input, "Y", true) == 0)
                {
                    CreateCharacter();
                }
                if (String.Compare(input, "N", true) == 0)
                {
                    QuitHelper();
                }
                Clear();
                Console.WriteLine("Sorry you've entered something invalid.\nWould you like to create a new character? Y/N");
            } while (true);
        }

        static void AttributeEditor()
        {
            String[] attributeNames = { "Strength", "Intelligence", "Agility", "Constitution", "Charisma" };
            Clear();
            Console.WriteLine("Which attribute would you like to edit?\n1) Strength\n2) Intelligence\n3) Agility\n4)Constitution\n5) Charisma\n\n6) Done");

            int number;
            int editor;
            bool statEditor = false;
            String input = Console.ReadLine();
            do
            {
                statEditor = false;
                if (String.Compare(input, "6", true) == 0)
                {
                    return;
                }
                if (Int32.TryParse(input, out editor))
                {
                    if (editor > 0 && editor < 6)
                    {
                        Clear();
                        Console.WriteLine($"Please enter your new {attributeNames[editor - 1]} value;");
                        input = Console.ReadLine();
                        do
                        {
                            if (Int32.TryParse(input, out number))
                            {
                                if (number > 0 && number < 101)
                                {
                                    s_character.characterAttributeValue[editor - 1] = number;
                                    statEditor = true;
                                }
                            }
                            Clear();
                            Console.WriteLine("You've entered something invalid\nPlease enter a number between 1-100");
                            input = Console.ReadLine();
                        } while (!statEditor);
                    }
                }
                Clear();
                Console.WriteLine("You've entered something invalid\nWhich attribute would you like to edit?\n1) Strength\n2) Intelligence\n3) Agility\n4)Constitution\n5) Charisma");
                input = Console.ReadLine();
            } while (true);
        }

        // Console Clearer
        static void Clear()
        {
            Console.Clear();
        }
    }
}
=======
﻿/*
 * Character Creator
 * ITSE 1430
 * Spring 2021
 * Stuart Beeby
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.ConsoleHost
{
    class CharacterCreatorConsoleHost
    {
        static CharacterCreator _character;
        static void Main(string[] args)
        {
            bool quit = false;
            char choice;
            bool first = false;

            Clear();
            choice = DisplayInitialText();
            do
            {
                switch (choice)
                {
                    case 'Y': CreateCharacter(); break;
                    case 'N': first = QuitHelper(); break;
                }
                if (choice == 'Y')
                {
                    break;
                }
                if (first == true)
                {
                    break;
                }
                Clear();
                choice = DisplayInitialText();
            } while (true);

            /*
             * 1 = create new character
             * 2 = view stats
             * 3 = edit character 
             * 4 = quit
             */
            if (!first)
            {
                choice = MainMenu();
                do
                {

                    switch (choice)
                    {
                        case '1': CreateCharacter(); break;
                        case '2': ViewStats(); break;
                        case '3': EditCharacter(); break;
                        case '4': DeleteCharacter(); break;
                        case '5': quit = QuitHelper(); break;
                    }
                    if (quit)
                    {
                        first = true;
                    }
                    Clear();
                    choice = MainMenu();
                } while (!quit);
            }
        }

        private static char DisplayInitialText()
        {
            Console.WriteLine("Character Creator\nCourse : 1430\nSpring 2021\nAuthor : Stuart Beeby\nWould you like to create a character? Y/N");
            do
            {
                String input = Console.ReadLine();
                if (String.Compare(input, "Y", true) == 0)
                {
                    return 'Y';
                }
                if (String.Compare(input, "N", true) == 0)
                {
                    return 'N';
                }
                Clear();
                Console.WriteLine("Sorry you've entered something invalid.\nWould you like to create a new character? Y/N");
            } while (true);
        }

        static char MainMenu()
        {
            Clear();
            Console.WriteLine($"Welcome {_character.characterName} what would you like to do?\n");
            Console.WriteLine("1) Create a new character\n2) View your stats\n3) Edit your character\n4) Delete character\n5) Quit");
            do
            {
                String input = Console.ReadLine();
                switch (input)
                {
                    case "1": return '1';
                    case "2": return '2';
                    case "3": return '3';
                    case "4": return '4';
                    case "5": return '5';
                }
                Clear();
                Console.WriteLine("You've entered something invalid\n please select from the options below");
                Console.WriteLine("1) Create a new character\n2) View your stats\n3) Edit your character\n4) Delete Character\n5) Quit");
            } while (true);
        }

        static void CreateCharacter()
        {
            CharacterCreator character = new CharacterCreator();
            String[] attribute = { "Strength", "Intelligence", "Agility", "Consitution", "Charisma" };
            int attributeNumber;
            bool valid = false;
            bool working = false;

            Clear();
            Console.WriteLine("Please enter your character name: ");
            character.characterName = Console.ReadLine();
            Clear();
            Console.WriteLine("Please select a profession.\nChoices:\n1) Fighter\n2) Hunter\n3) Priest\n4) Rogue\n5) Wizard");
            character.characterProfession = ProfessionHelper();
            Clear();
            Console.WriteLine("Please select a race.\nChoices:\n1) Dwarf\n2) Elf\n3) Gnome\n4) Half Elf\n5) Human");
            character.characterRace = RaceHelper();
            Clear();
            Console.WriteLine("Would you like to enter a biography? Y/N");
            character.characterBiography = BiographyHelper();
            for (int i = 0; i < 5; i++)
            {
                Clear();
                Console.WriteLine($"Please enter your {attribute[i]} stat");
                attributeNumber = AttributeHelper();
                character.characterAttributeValue[i] = attributeNumber; ;
            }
            _character = character;
        }

        static String ProfessionHelper()
        {
            String input;
            input = Console.ReadLine();
            do
            {
                switch (input)
                {
                    case "1": return "Fighter";
                    case "2": return "Hunter";
                    case "3": return "Priest";
                    case "4": return "Rogue";
                    case "5": return "Wizard";
                }
                Clear();
                Console.WriteLine("You've entered something invalid.\nPlease select a profession from the list below\n1) Fighter\n2) Hunter\n3) Priest\n4) Rogue\n5) Wizard");
                input = Console.ReadLine();
            } while (true);

        }

        static String RaceHelper()
        {
            String input = Console.ReadLine();
            do
            {
                switch (input)
                {
                    case "1": return "Dwarf";
                    case "2": return "Elf";
                    case "3": return "Gnome";
                    case "4": return "Half Elf";
                    case "5": return "Human";
                }
                Clear();
                Console.WriteLine("You've entered something invalid.\nPlease select a race from the list below\n1) Dwarf\n2) Elf\n3) Gnome\n4) Half Elf\n5) Human");
                input = Console.ReadLine();
            } while (true);
        }

        static String BiographyHelper()
        {
            bool bioQuitter = false;
            String bio = "";
            String input = Console.ReadLine();
            do
            {
                if (String.Compare(input, "Y", true) == 0)
                {
                    Clear();
                    Console.WriteLine("Please enter your biography below\nWhen you are done, type \"QUIT\"");
                    do
                    {
                        input = Console.ReadLine();
                        if (String.Compare(input, "QUIT", true) == 0)
                        {
                            bioQuitter = true;
                        }
                        bio += input;
                        bio += "\n";
                    } while (!bioQuitter);
                    return bio;
                }
                if (String.Compare(input, "N", true) == 0)
                {
                    return "";
                }
                Clear();
                Console.WriteLine("You've entered something invalid.\nWould you like to enter a biography? Y/N");
                input = Console.ReadLine();
            } while (true);
        }

        static int AttributeHelper()
        {
            int number;
            String input = Console.ReadLine();
            do
            {
                if (Int32.TryParse(input, out number))
                {
                    if (number > 0 && number < 101)
                    {
                        return number;
                    }
                }
                Clear();
                Console.WriteLine("You've entered something invalid\nPlease enter a number between 1-100");
                input = Console.ReadLine();
            } while (true);
        }

        static void ViewStats()
        {
            bool done = false;

            do
            {
                Clear();
                Console.WriteLine($"Name : {_character.characterName}\n");
                Console.WriteLine($"Profession : {_character.characterProfession}\n");
                Console.WriteLine($"Race : {_character.characterRace}\n");
                if (!String.IsNullOrEmpty(_character.characterBiography))
                {
                    Console.WriteLine($"Biography :\n{_character.characterBiography}\n");
                }
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{_character.characterAttributeNames[i]} : {_character.characterAttributeValue}\n\n");
                }
                Console.WriteLine("Type \"QUIT\" to quit");
                String input = Console.ReadLine();
                if (String.Compare(input, "QUIT", true) == 0)
                {
                    done = true;
                }
            } while (!done);
        }

        static void EditCharacter()
        {
            Clear();
            Console.WriteLine("What would you like to edit?\n1) Name\n2) Profession\n3) Race\n4) Biography\n5) Attributes\n\n6) Back");
            String input = Console.ReadLine();
            switch (input)
            {
                case "1": NameEditor(); break;
                case "2": ProfessionEditor(); break;
                case "3": RaceEditor(); break;
                case "4": BiographyEditor(); break;
                case "5": AttributeEditor(); break;
            }
        }

        static void NameEditor()

        {
            Clear();
            Console.WriteLine("Please enter your new name");
            String input = Console.ReadLine();
            _character.characterName = input;
        }

        static void ProfessionEditor()
        {
            Clear();
            Console.WriteLine("Please select your new profession\n1) Fighter\n2) Hunter\n3) Priest\n4) Rogue\n5) Wizard");
            String input;
            input = Console.ReadLine();
            do
            {
                switch (input)
                {
                    case "1": _character.characterProfession = "Fighter"; return;
                    case "2": _character.characterProfession = "Hunter"; return;
                    case "3": _character.characterProfession = "Priest"; return;
                    case "4": _character.characterProfession = "Rogue"; return;
                    case "5": _character.characterProfession = "Wizard"; return;
                }
                Clear();
                Console.WriteLine("You've entered something invalid.\nPlease select your new profession from the list below\n1) Fighter\n2) Hunter\n3) Priest\n4) Rogue\n5) Wizard");
                input = Console.ReadLine();
            } while (true);
        }

        static void RaceEditor()
        {
            Clear();
            Console.WriteLine("Please select your new race\n1) Dwarf\n2) Elf\n3) Gnome\n4) Half Elf\n5) Human");
            String input = Console.ReadLine();
            do
            {
                switch (input)
                {
                    case "1": _character.characterRace = "Dwarf"; return;
                    case "2": _character.characterRace = "Elf"; return;
                    case "3": _character.characterRace = "Gnome"; return;
                    case "4": _character.characterRace = "Half Elf"; return;
                    case "5": _character.characterRace = "Human"; return;
                }
                Clear();
                Console.WriteLine("You've entered something invalid.\nPlease select a race from the list below\n1) Dwarf\n2) Elf\n3) Gnome\n4) Half Elf\n5) Human");
                input = Console.ReadLine();
            } while (true);
        }

        static void BiographyEditor()
        {
            bool bioQuitter = false;
            String bio = "";
            do
            {
                Clear();
                Console.WriteLine("Please enter your new biography below\nWhen you are done, type \"QUIT\"");
                String input = Console.ReadLine();
                do
                {
                    input = Console.ReadLine();
                    if (String.Compare(input, "QUIT", true) == 0)
                    {
                        bioQuitter = true;
                    }
                    bio += input;
                    bio += "\n";
                } while (!bioQuitter);
                _character.characterBiography = bio;
                return;
            } while (true);
        }
        static bool QuitHelper()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to quit? Y/N");
            String input = Console.ReadLine();
            input = input.ToUpper();
            if (String.Compare(input, "Y", true) == 0)
            {
                return true;
            }
            return false;
        }

        static void DeleteCharacter()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to delete your character? Y/N");
            String input = Console.ReadLine();
            input = input.ToUpper();
            if (String.Compare(input, "Y", true) == 0)
            {
                DeleteHelper();
            }
            return;
        }

        static void DeleteHelper()
        {
            Console.WriteLine("You currently don't have a character, would you like to create a character? Y/N");
            do
            {
                String input = Console.ReadLine();
                if (String.Compare(input, "Y", true) == 0)
                {
                    CreateCharacter();
                }
                if (String.Compare(input, "N", true) == 0)
                {
                    QuitHelper();
                }
                Clear();
                Console.WriteLine("Sorry you've entered something invalid.\nWould you like to create a new character? Y/N");
            } while (true);
        }

        static void AttributeEditor()
        {
            String[] attributeNames = { "Strength", "Intelligence", "Agility", "Constitution", "Charisma" };
            Clear();
            Console.WriteLine("Which attribute would you like to edit?\n1) Strength\n2) Intelligence\n3) Agility\n4)Constitution\n5) Charisma\n\n6) Done");

            int number;
            int editor;
            bool statEditor = false;
            String input = Console.ReadLine();
            do
            {
                statEditor = false;
                if (String.Compare(input, "6", true) == 0)
                {
                    return;
                }
                if (Int32.TryParse(input, out editor))
                {
                    if (editor > 0 && editor < 6)
                    {
                        Clear();
                        Console.WriteLine($"Please enter your new {attributeNames[editor - 1]} value;");
                        input = Console.ReadLine();
                        do
                        {
                            if (Int32.TryParse(input, out number))
                            {
                                if (number > 0 && number < 101)
                                {
                                    _character.characterAttributeValue[editor - 1] = number;
                                    statEditor = true;
                                }
                            }
                            Clear();
                            Console.WriteLine("You've entered something invalid\nPlease enter a number between 1-100");
                            input = Console.ReadLine();
                        } while (!statEditor);
                    }
                }
                Clear();
                Console.WriteLine("You've entered something invalid\nWhich attribute would you like to edit?\n1) Strength\n2) Intelligence\n3) Agility\n4)Constitution\n5) Charisma");
                input = Console.ReadLine();
            } while (true);
        }

        // Console Clearer
        static void Clear()
        {
            Console.Clear();
        }
    }
}
>>>>>>> 5b928dc7477ff2c55affb2464a610bddb0a14bec
