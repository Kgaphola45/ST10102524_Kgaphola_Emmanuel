// Define the namespace for the project
using ST10102524_Kgaphola_Emmanuel;

namespace ST10102524_Kgaphola_Emmanuel_PROG6221_Part1
{
    // Define the main program class
    class Program
    {
        // Define the entry point of the program
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            // Display a welcome message
            Console.WriteLine("========== Welcome to the Recipe Book ==========!");
            Console.ResetColor();

            // Create a new Recipe object
            Recipe recipe = new Recipe();

            // Start a loop that will continue until the user chooses to exit
            while (true)
            {
                // Display the menu.
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("_______________________________________________");
                Console.WriteLine("Press '1' to enter the details for a single recipe.");
                Console.WriteLine("Press '2' to display the full recipe.");
                Console.WriteLine("Press '3' to scale by a factor of 0.5 (half), 2 (double) or 3 (triple).");
                Console.WriteLine("Press '4' to reset quantities to the original values.");
                Console.WriteLine("Press '5' to clear all the data to enter a new recipe.");
                Console.WriteLine("Press '6' to exit.");
                Console.WriteLine("_______________________________________________");
                Console.ResetColor();

                string input = Console.ReadLine();

                switch (input)
                {

                    case "1":
                        // If the user entered 1, enter the details for a single recipe.
                        recipe.EnterRecipeDetails();
                        break;
                    case "2":
                        // If the user entered 2, it will display the full recipe.
                        recipe.DisplayRecipe();
                        break;
                    case "3":
                        // If the user entered 3, it will scale the recipe by a factor of 0.5, 2, or 3.
                        recipe.ScaleRecipe();
                        break;
                    case "4":
                        // If the user entered 4,it reset the quantities to their original values.
                        recipe.ResetQuantities();
                        break;
                    case "5":
                        // If the user entered 5, it will clear all the data and enter a new recipe.
                        recipe = new Recipe();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nAll data for this recipe have been successfully cleared.\n");
                        Console.ResetColor();
                        break;
                    case "6":
                        return;  // If the user entered 6,  program will exit.
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

            }
        }
    }
}