/*
 * Budget
 * ITSE 1430
 * Spring 2021
 * Stuart Beeby
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget
{
    class AccountProgram
    {
        static Account _account;
        static void Main ( string[] args )
        {
            bool quit = false;
            bool mainMenu = false;
            char choice;

            Console.Clear();
            choice = DisplayInitialText();
            do
            {
                switch (choice)
                {
                    case 'Y': choice = AddAccount(); break;
                    case 'N': choice = ProgramQuit(); break;
                    case 'Q': mainMenu = true; break;
                }
            } while (!mainMenu);

            do
            {
                choice = DisplayMainMenu();
                switch (choice)
                {
                    case 'D': AccountDeposit(); break;
                    case 'W': AccountWithdraw(); break;
                    case 'Q': ProgramQuit(); break;
                    case 'Y': quit = true; break;
                }
            } while (!quit);
        }

        private static char DisplayInitialText ()
        {
            Console.WriteLine("Budget\nCourse : 1430\nSpring 2021\nAuthor : Stuart Beeby\nWould you like to create a new account? Y/N");
            do
            {
                String input = Console.ReadLine();
                input = input.ToUpper();
                switch (input)
                {
                    case "Y": return 'Y';
                    case "N": return 'N';
                };
                Console.Clear();
                Console.WriteLine("Sorry you've entered something invalid.\nWould you like to create a new account? Y/N");
            } while (true);
        }

        static char AddAccount ()
        {
            Account account = new Account();
            bool valid = true;
            bool working = false;
            char nameTester;
            decimal decimalTester;
            String balanceTester;

            Console.Clear();
            Console.WriteLine("Please enter your new account name: ");
            account.accountName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please enter your new account number: ");

            do
            {
                account.accountNumber = Console.ReadLine();
                for (int i = 0; i < account.accountNumber.Length; i++)
                {
                    nameTester = account.accountNumber[i];
                    if (Char.IsDigit(nameTester))
                    {
                        valid = true;
                    } else
                    {
                        valid = false;
                    }
                }
                if (valid == true)
                {
                    if (account.accountNumber.Length == 9)
                    {
                        valid = true;
                    } else
                    {
                        valid = false;
                    }
                }
                if (valid == true)
                {
                    if (account.accountNumber[0] == '0' || account.accountNumber[8] == '0')
                    {
                        valid = false;
                    } else
                    {
                        valid = true;
                    }
                }
                Console.Clear();
                if (valid == true)
                {
                    working = true;
                }
                else
                {
                    Console.WriteLine("An error has occured!\nAn account number must be 9 digits long.\nAn account number can not start or end with a 0.\nPlease enter your new account number :");
                }
            } while (!working);

            Console.Clear();
            Console.WriteLine("Please enter your starting account balance :");
            working = false;
            do
            {
                balanceTester = Console.ReadLine();
                if (Decimal.TryParse(balanceTester, out decimalTester))
                {
                    working = true;
                    decimalTester = Convert.ToDecimal(balanceTester);
                    account.accountBalance = decimalTester;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("An error has occured!\nPlease enter a valid numerical starting account balance :");
                }
            } while (!working);
            _account = account;
            return 'Q';
        }

        static char DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine($"Welcome {_account.accountName}\nYour current account balance is: {_account.accountBalance}");
            Console.WriteLine("");
            Console.WriteLine("What would you like to do?\nD) eposit\nW) ithdraw\nQ) uit");
            do
            {
                String input = Console.ReadLine();
                input = input.ToUpper();
                switch (input)
                {
                    case "D": return 'D';
                    case "W": return 'W';
                    case "Q": return 'Q';
                }
                Console.Clear();
                Console.WriteLine($"Welcome {_account.accountName}\nYour current account balance is: {_account.accountBalance}");
                Console.WriteLine("");
                Console.WriteLine("An error occured, please select an option below");
                Console.WriteLine("");
                Console.WriteLine("What would you like to do?\nD) eposit\nW) ithdraw\nQ) uit");
            } while (true);
        }

        static void AccountDeposit()
        {
            bool quit = false;
            bool descriptionChecker = false;
            bool extraChecker = false;
            bool validDeposit = false;
            String input;
            decimal validInput;
            char extras;
            Console.Clear();
            Console.WriteLine("How much would you like to deposit?");
            input = Console.ReadLine();
            do
            {
                do
                {
                    if (decimal.TryParse(input, out validInput))
                    {
                        validInput = Convert.ToDecimal(input);
                        validDeposit = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("An error has occured! Please enter a valid number");
                        Console.WriteLine("How much would you like to deposit?");
                        input = Console.ReadLine();
                    }
                    if (input == "0")
                    {
                        quit = true;
                        validDeposit = true;
                    }
                } while (!validDeposit);
                Console.Clear();
                Console.WriteLine("Please enter a description for your desposit");
                String description = Console.ReadLine();
                do
                {
                    if(!String.IsNullOrEmpty(description))
                    {
                        descriptionChecker = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("An error occured, please enter a description for your desposit");
                        description = Console.ReadLine();
                    }
                } while (!descriptionChecker);

                do
                {
                    extraChecker = CategoryAdder();
                    extraChecker = CheckNumber();
                    extraChecker = DateAdder();
                    extraChecker = true;
                } while (!extraChecker);
                quit = true;

            } while (!quit);


            _account.accountBalance = _account.accountBalance + validInput;
            Console.Clear();
            Console.WriteLine("Account balance successfully updated, press any key to continue...");
            Console.ReadLine();
        }

        static void AccountWithdraw()
        {
            bool quit = false;
            bool validWithdraw = false;
            bool descriptionChecker = false;
            bool extraChecker = false;
            bool decimalCheck = false;
            String input;
            decimal validInput;
            char extras;
            Console.Clear();
            Console.WriteLine("How much would you like to withdraw?");
            input = Console.ReadLine();
            do
            {
                do
                {
                    if (decimal.TryParse(input, out validInput))
                    {
                        validInput = Convert.ToDecimal(input);
                        decimalCheck = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("An error has occured! Please enter a valid number");
                        Console.WriteLine("How much would you like to withdraw?");
                        input = Console.ReadLine();
                    }
                    if (validInput > _account.accountBalance && decimalCheck == true)
                    {
                        Console.Clear();
                        Console.WriteLine($"Your Balance is to low to withdraw ${validInput}, please enter a smaller amount.");
                        input = Console.ReadLine();
                    }
                    else
                    {
                        validWithdraw = true;
                    }
                    if (input == "0")
                    {
                        quit = true;
                        validWithdraw = true;
                    }
                } while (!validWithdraw);
                Console.Clear();
                Console.WriteLine("Please enter a description for your withdrawal");
                String description = Console.ReadLine();
                do
                {
                    if (!String.IsNullOrEmpty(description))
                    {
                        descriptionChecker = true;
                    } else
                    {
                        Console.Clear();
                        Console.WriteLine("An error occured, please enter a description for your withdrawal");
                        description = Console.ReadLine();
                    }
                } while (!descriptionChecker);

                do
                {
                    extraChecker = CategoryAdder();
                    extraChecker = CheckNumber();
                    extraChecker = DateAdder();
                    extraChecker = true;
                } while (!extraChecker);

                quit = true;
            } while (!quit);


            _account.accountBalance = _account.accountBalance - validInput;
            Console.Clear();
            Console.WriteLine("Account balance successfully updated, press any key to continue...");
            Console.ReadLine();
        }

        static char ProgramQuit()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to quit? Y/N");
            String input = Console.ReadLine();
            input = input.ToUpper();
            if (input == "Y")
            {
                System.Environment.Exit(0);
                return '0';
            }
            else
            {
                return '0';
            }
        }

        static bool CategoryAdder()
        {
            String input;
            Console.Clear();
            Console.WriteLine("Would you like to enter a category? Y/N");
            input = Console.ReadLine();
            input = input.ToUpper();

            if (input == "Y")
            {
                Console.Clear();
                Console.WriteLine("Please enter a category");
                input = Console.ReadLine();
            }
            if (input == "0")
            {
                return true;
            }
            return false;
        }
        static bool CheckNumber()
        {
            String input;
            char checkTester;
            bool valid = false;
            Console.Clear();
            Console.WriteLine("Would you like to enter a check number? Y/N");
            input = Console.ReadLine();
            input = input.ToUpper();

            if (input == "Y")
            {
                Console.WriteLine("Please enter a check number");
                input = Console.ReadLine();
                do
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        checkTester = input[i];
                        if (Char.IsDigit(checkTester))
                        {
                            valid = true;
                        } else
                        {
                            valid = false;
                        }
                    }
                    if (valid == false)
                    {
                        Console.Clear();
                        Console.WriteLine("An error has occured!\nPlease enter a valid numerical check number");
                    }
                } while (!valid);
            }
            if (input == "0")
            {
                return true;
            }
            return false;
        }

        static bool DateAdder()
        {
            String input;
            bool valid = false;
            DateTime validDate;
            Console.Clear();
            Console.WriteLine("Would you like to add a date? Y/N");
            input = Console.ReadLine();
            input = input.ToUpper();

            if (input == "Y")
            {
                Console.Clear();
                Console.WriteLine("Please enter a date : MM/DD/YYYY");
                input = Console.ReadLine();
                do
                {
                    if(DateTime.TryParse(input, out validDate))
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("An error occured\nPlease enter a valid date : MM/DD/YYYY\nExample : 06/06/2002");
                        input = Console.ReadLine();
                    }
                } while (!valid);
            }
            if (input == "0")
            {
                return true;
            }
            return false;
        }
    }
}
