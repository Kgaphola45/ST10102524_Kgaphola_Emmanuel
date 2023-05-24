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

              List<Recipe> recipes = new List<Recipe>();

            // Start a loop that will continue until the user chooses to exit
            while (true)
            {
                // Display the menu.
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("_______________________________________________");
                Console.WriteLine("Press '1' to enter the details for a new recipe.");
                Console.WriteLine("Press '2' to display all recipes.");
                Console.WriteLine("Press '3' to choose a recipe to display.");
                Console.WriteLine("Press '4' to scale a recipe.");
                Console.WriteLine("Press '5' to reset quantities in a recipe.");
                Console.WriteLine("Press '6' to calculate the total calories in a recipe.");
                Console.WriteLine("Press '7' to clear all data to enter a new recipe.");
                Console.WriteLine("Press '8' to exit.");
                Console.WriteLine("_______________________________________________");
                Console.ResetColor();
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Recipe recipe = EnterNewRecipe();
                        recipes.Add(recipe);
                        break;
                    case "2":
                        DisplayAllRecipes(recipes);
                        break;
                    case "3":
                        DisplaySingleRecipe(recipes);
                        break;
                    case "4":
                        ScaleRecipe(recipes);
                        break;
                    case "5":
                        ResetQuantities(recipes);
                        break;
                    case "6":
                        CalculateTotalCalories(recipes);
                        break;
                    case "7":
                        recipes.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nAll recipe data has been cleared.\n");
                        Console.ResetColor();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        static Recipe EnterNewRecipe()
        {
            Console.Write("Enter the name of the recipe: ");
            string recipeName = Console.ReadLine();
            Recipe recipe = new Recipe(recipeName);
            recipe.EnterRecipeDetails();
            return recipe;
        }

        static void DisplayAllRecipes(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNo recipes found.\n");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("\nList of Recipes:");
                List<Recipe> sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
                foreach (Recipe recipe in sortedRecipes)
                {
                    Console.WriteLine(recipe.Name);
                }
                Console.WriteLine();
            }
        }

        static void DisplaySingleRecipe(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNo recipes found.\n");
                Console.ResetColor();
            }
            else
            {
                Console.Write("Enter the name of the recipe: ");
                string recipeName = Console.ReadLine();

                Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

                if (recipe == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nRecipe not found.\n");
                    Console.ResetColor();
                }
                else
                {
                    recipe.DisplayRecipe();
                }
            }
        }

        static void ScaleRecipe(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNo recipes found.\n");
                Console.ResetColor();
            }
            else
            {
                Console.Write("Enter the name of the recipe: ");
                string recipeName = Console.ReadLine();

                Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

                if (recipe == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nRecipe not found.\n");
                    Console.ResetColor();
                }
                else
                {
                    recipe.ScaleRecipe();
                }
            }
        }

        static void ResetQuantities(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNo recipes found.\n");
                Console.ResetColor();
            }
            else
            {
                Console.Write("Enter the name of the recipe: ");
                string recipeName = Console.ReadLine();

                Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

                if (recipe == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nRecipe not found.\n");
                    Console.ResetColor();
                }
                else
                {
                    recipe.ResetQuantities();
                }
            }
        }

        static void CalculateTotalCalories(List<Recipe> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNo recipes found.\n");
                Console.ResetColor();
            }
            else
            {
                Console.Write("Enter the name of the recipe: ");
                string recipeName = Console.ReadLine();

                Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

                if (recipe == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nRecipe not found.\n");
                    Console.ResetColor();
                }
                else
                {
                    int totalCalories = recipe.CalculateTotalCalories();

                    Console.WriteLine($"\nTotal calories in the recipe '{recipe.Name}': {totalCalories} calories\n");

                    if (totalCalories > 300)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The total calories of this recipe exceed 300.");
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}
