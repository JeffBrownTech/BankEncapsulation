using System.Diagnostics;
using System.Net;

namespace BankEncapsulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            var myAccount = new BankAccount();

            bool exit = false;
            Console.WriteLine("Welcome to Your Bank Account! Enter a number to take an action.");

            do
            {
                string response = OptionPrompt();
                ProcessAction(response, myAccount, ref exit);
            } while (!exit);
        }

        public static string OptionPrompt()
        {
            string? input;

            do
            {
                Console.WriteLine("\n1. Get Balance");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Exit");

                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input action cannot be empty, please try again.");
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input.Trim();
        }

        public static void ProcessAction(string action, BankAccount account, ref bool exit)
        {
            switch (action)
            {
                case "1":
                    Console.WriteLine($"\nCurrent Balance: ${account.GetBalance()}");
                    break;
                case "2":
                    account.Deposit(GetTransactionAmount());
                    break;
                case "3":
                    Console.WriteLine("Thank you for banking with us. Goodbye!");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }

        public static double GetTransactionAmount()
        {
            bool validInput = false;
            double transactionAmount = 0;

            do
            {
                Console.WriteLine("\nEnter transaction amount (enter 0 to exit without action):");
                validInput = Double.TryParse(Console.ReadLine(), out transactionAmount);

                if (!validInput)
                {
                    Console.WriteLine("Not a valid number, please try again.");
                }
                else if (transactionAmount < 0)
                {
                    Console.WriteLine("Deposit amount must be greater than 0.");
                    // Reset validInput to continue looping
                    validInput = false;
                }
            } while (!validInput);

            return transactionAmount;
        }
    }
}
