// Importing necessary libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Defining namespace for the program
namespace ST10102524_Kgaphola_Emmanuel
{
    
    class Ingredient
    {
        // Declaring public properties for Ingredient object
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        // Private field to store original quantity
        private double originalQuantity;

        // Constructor to initialize Ingredient object with name, quantity, and unit
        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            originalQuantity = quantity;
        }

        // Method to reset the quantity of Ingredient to its original value
        public void ResetQuantity()
        {
            Quantity = originalQuantity;
        }

    }

    // Defining Recipe class
    class Recipe
    {
        // Private fields to store list of ingredients and steps
        private List<Ingredient> ingredients;
        private List<string> steps;

        // Constructor to initialize Recipe object
        public Recipe()
        {
            // Initializing list of ingredients and steps
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        // Method to enter recipe details (ingredients and steps)
        public void EnterRecipeDetails()
        {
            EnterIngredients(); // Call method to enter ingredients
            EnterSteps(); // Call method to enter steps

            // Printing success message in green color
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nRecipe details entered successfully!");
            Console.ResetColor();
        }

        // Private method to enter ingredients
        private void EnterIngredients()
        {
            // Prompt user to enter number of ingredients
            Console.Write("How many ingredients are in your recipe: ");

            // Check if input is an integer
            if (int.TryParse(Console.ReadLine(), out int numIngredients))
            {
                // Loop through number of ingredients entered
                for (int i = 0; i < numIngredients; i++)
                {
                    // Prompt user to enter name, quantity, and unit for each ingredient
                    Console.Write($"Enter the name of ingredient number {i + 1}: ");
                    string name = Console.ReadLine();
                    Console.Write($"Enter the quantity of ingredient number {i + 1}: ");
                    double quantity = double.Parse(Console.ReadLine());
                    Console.Write($"Enter the unit of measurement for ingredient number {i + 1}: ");
                    string unit = Console.ReadLine();

                    // Add new Ingredient object to list of ingredients
                    ingredients.Add(new Ingredient(name, quantity, unit));

                    // Print success message in green color
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nIngredient number {i + 1} added successfully.\n");
                    Console.ResetColor();
                }
            }
            else
            {
                // Print error message in red color if input is not an integer
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid input. Please enter a valid number.\n");
                Console.ResetColor();
            }
        }


        // Private method to enter steps
        private void EnterSteps()
        {
            // This method asks the user for the number of steps in the recipe.
            // If the user enters a valid number, the method adds that number of steps to the `steps` collection.
            // If the user enters an invalid number, the method displays an error message.

            // Get the number of steps from the user.
            Console.Write("How many steps are required for this recipe: ");
            int numSteps;
            if (int.TryParse(Console.ReadLine(), out numSteps))
            {
                // Add the number of steps to the `steps` collection.
                for (int i = 0; i < numSteps; i++)
                {
                    Console.WriteLine($"Enter step number {i + 1}:");
                    string step = Console.ReadLine();
                    steps.Add(step);
                }
            }
            else
            {
                // Display an error message if the user enters an invalid number.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid input. Please enter a valid number.\n");
                Console.ResetColor();
            }
        }

        public void DisplayRecipe()
        {
            // This method displays the full recipe, including the ingredients and steps.

            // Display the header for the recipe.
            Console.WriteLine("\nFull Recipe:\n");

            // Create a string that contains all of the ingredients.
            string ingredientsList = "";
            foreach (Ingredient ingredient in ingredients)
            {
                ingredientsList += $"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}, ";
            }

            // Trim the trailing comma and space from the ingredients list.
            ingredientsList = ingredientsList.TrimEnd(',', ' ');

            // Display the ingredients.
            Console.WriteLine($"For this recipe, you will need {ingredientsList}.\n");

            // Display the steps.
            Console.WriteLine("Steps required to prepare this recipe:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"Step number {i + 1}. {steps[i]}.");
            }
            Console.WriteLine();
        }

        public void ScaleRecipe()
        {
            // This method scales the recipe by a factor.

            // Get the scaling factor from the user.
            Console.Write("Enter the scaling factor (e.g. 0.5 for half, 2 for double, 3 for triple): ");
            double factor = double.Parse(Console.ReadLine());

            // Check if the user wants to confirm the scaling operation.
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Are you sure you want to scale the recipe by a factor of {factor}? (Y/N)");
            Console.ResetColor();
            string confirm = Console.ReadLine();

            // If the user confirms, it will scale the recipe.
            if (confirm.ToLower() == "y")
            {
                foreach (Ingredient ingredient in ingredients)
                {
                    ingredient.Quantity *= factor;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nRecipe scaled successfully to factor of {factor}!");
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        public void ResetQuantities()
        {
            // This method resets the quantities of all ingredients in the recipe to their original values.

            // Check if the user wants to confirm the reset operation.
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Are you sure you want to reset the quantities of all ingredients in the recipe to their original values? (Y/N)");
            Console.ResetColor();
            string confirm = Console.ReadLine();

            // If the user confirms,  the quantities will be reset to original values.
            if (confirm.ToLower() == "y")
            {
                foreach (Ingredient ingredient in ingredients)
                {
                    ingredient.ResetQuantity();
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nQuantity data for this recipe has been reset.");
                Console.ResetColor();
                Console.WriteLine();
            }
        }




    }


}
