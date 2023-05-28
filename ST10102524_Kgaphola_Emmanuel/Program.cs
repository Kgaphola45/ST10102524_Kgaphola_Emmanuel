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
            /* Display a welcome message */
            Console.WriteLine("========== Welcome to the Recipe Book ==========!");
            Console.ResetColor();

            // Create a list to store recipes
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
                        // Option 1: Enter the details for a new recipe
                        Recipe recipe = EnterNewRecipe();
                        recipes.Add(recipe);
                        break;
                    case "2":
                        // Option 2: Display all recipes
                        DisplayAllRecipes(recipes);
                        break;
                    case "3":
                        // Option 3: Choose a recipe to display
                        DisplaySingleRecipe(recipes);
                        break;
                    case "4":
                        // Option 4: Scale a recipe
                        ScaleRecipe(recipes);
                        break;
                    case "5":
                        // Option 5: Reset quantities in a recipe
                        ResetQuantities(recipes);
                        break;
                    case "6":
                        // Option 6: Calculate the total calories in a recipe
                        CalculateTotalCalories(recipes);
                        break;
                    case "7":
                        // Option 7: Clear all data to enter a new recipe
                        recipes.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nAll recipe data has been cleared.\n");
                        Console.ResetColor();
                        break;
                    case "8":
                        // Option 8: Exit the program
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        /* Method to enter details for a new recipe */
        static Recipe EnterNewRecipe()
        {
            Console.Write("Enter the name of the recipe: ");
            string recipeName = Console.ReadLine();
            Recipe recipe = new Recipe(recipeName);
            recipe.EnterRecipeDetails();
            return recipe;
        }

        /* Method to display all recipes */
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
                // Sort the recipes by name
                List<Recipe> sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
                foreach (Recipe recipe in sortedRecipes)
                {
                    Console.WriteLine(recipe.Name);
                }
                Console.WriteLine();
            }
        }

        /* Method to display a single recipe */
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
                Console.WriteLine("Choose a recipe to display:");
                for (int i = 0; i < recipes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {recipes[i].Name}");
                }
                Console.WriteLine();
                Console.Write("Enter the number of the recipe: ");
                if (int.TryParse(Console.ReadLine(), out int recipeNumber))
                {
                    // Check if the recipe number is within the valid range
                    if (recipeNumber >= 1 && recipeNumber <= recipes.Count)
                    {
                        Recipe recipe = recipes[recipeNumber - 1];
                        recipe.DisplayRecipe();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nInvalid recipe number.\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nInvalid input. Please enter a valid number.\n");
                    Console.ResetColor();
                }
            }
        }


        /* Method to scale a recipe */
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
                Console.WriteLine("Choose a recipe to scale:");
                for (int i = 0; i < recipes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {recipes[i].Name}");
                }

                Console.Write("Enter the number of the recipe: ");
                if (int.TryParse(Console.ReadLine(), out int recipeNumber))
                {
                    // Check if the recipe number is within the valid range
                    if (recipeNumber >= 1 && recipeNumber <= recipes.Count)
                    {
                        Recipe recipe = recipes[recipeNumber - 1];
                        recipe.ScaleRecipe();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nInvalid recipe number.\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nInvalid input. Please enter a valid number.\n");
                    Console.ResetColor();
                }
            }
        }

        /* Method to reset quantities in a recipe */
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
                Console.WriteLine("Choose a recipe to reset quantities:");
                for (int i = 0; i < recipes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {recipes[i].Name}");
                }

                Console.Write("Enter the number of the recipe: ");
                if (int.TryParse(Console.ReadLine(), out int recipeNumber))
                {
                    // Check if the recipe number is within the valid range
                    if (recipeNumber >= 1 && recipeNumber <= recipes.Count)
                    {
                        Recipe recipe = recipes[recipeNumber - 1];
                        recipe.ResetQuantities();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nInvalid recipe number.\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nInvalid input. Please enter a valid number.\n");
                    Console.ResetColor();
                }
            }
        }

        /* Method to calculate the total calories in a recipe */
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
                Console.WriteLine("Choose a recipe to calculate total calories:");
                for (int i = 0; i < recipes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {recipes[i].Name}");
                }

                Console.Write("Enter the number of the recipe: ");
                if (int.TryParse(Console.ReadLine(), out int recipeNumber))
                {
                    // Check if the recipe number is within the valid range
                    if (recipeNumber >= 1 && recipeNumber <= recipes.Count)
                    {
                        Recipe recipe = recipes[recipeNumber - 1];

                        // Calculate the total calories in the recipe
                        int totalCalories = recipe.CalculateTotalCalories();

                        Console.WriteLine($"\nTotal calories in {recipe.Name}: {totalCalories} calories");

                        // Notify the user if the total calories exceed 300
                        if (totalCalories > 300)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Warning: The total calories exceed 300!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("The total calories are within the recommended range.");
                        }

                        Console.WriteLine();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nInvalid recipe number.\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nInvalid input. Please enter a valid number.\n");
                    Console.ResetColor();
                }
            }
        }

    }
    // Defining Ingredient class
    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        // Constructor for Ingredient class
        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        // Method to reset the quantity of an ingredient to zero
        public void ResetQuantity()
        {
            Quantity = 0;
        }
    }

    
}
