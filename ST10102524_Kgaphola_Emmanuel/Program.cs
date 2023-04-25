
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

            Console.WriteLine("========== Welcome to the Recipe Book ==========!");
            Console.ResetColor();
           

            Recipe recipe = new Recipe();

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
                        recipe.EnterRecipeDetails();
                        break;
                    case "2":
                        recipe.DisplayRecipe();
                        break;
                    case "3":
                        recipe.ScaleRecipe();
                        break;
                    case "4":
                        recipe.ResetQuantities();
                        break;
                    case "5":
                        recipe = new Recipe();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nAll data for this recipe have been successfully cleared.\n");
                        Console.ResetColor();
                        break;
                    case "6":
                        return; // Exit the program
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }


                }
        }
    }
}
