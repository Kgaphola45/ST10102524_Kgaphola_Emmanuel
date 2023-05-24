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
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        public void ResetQuantity()
        {
            Quantity = 0;
        }
    }

    // Defining Recipe class
    class Recipe
    {
        public string Name { get; set; }
        private List<Ingredient> ingredients;
        private List<string> steps;

        public Recipe(string name)
        {
            Name = name;
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        public void EnterRecipeDetails()
        {
            Console.WriteLine("Enter the details for the recipe:");
            EnterIngredients();
            EnterSteps();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nRecipe details entered successfully!");
            Console.ResetColor();
        }

        private void EnterIngredients()
        {
            Console.Write("How many ingredients are in your recipe: ");
            if (int.TryParse(Console.ReadLine(), out int numIngredients))
            {
                for (int i = 0; i < numIngredients; i++)
                {
                    Console.Write($"Enter the name of ingredient number {i + 1}: ");
                    string name = Console.ReadLine();

                    Console.Write($"Enter the quantity of ingredient number {i + 1}: ");
                    double quantity = double.Parse(Console.ReadLine());

                    Console.Write($"Enter the unit of measurement for ingredient number {i + 1}: ");
                    string unit = Console.ReadLine();

                    Console.Write($"Enter the number of calories for ingredient number {i + 1}: ");
                    int calories = int.Parse(Console.ReadLine());

                    Console.Write($"Enter the food group for ingredient number {i + 1}: ");
                    string foodGroup = Console.ReadLine();

                    ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nIngredient number {i + 1} added successfully.\n");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid input. Please enter a valid number.\n");
                Console.ResetColor();
            }
        }

        private void EnterSteps()
        {
            Console.Write("How many steps are required for this recipe: ");
            if (int.TryParse(Console.ReadLine(), out int numSteps))
            {
                for (int i = 0; i < numSteps; i++)
                {
                    Console.WriteLine($"Enter step number {i + 1}:");
                    string step = Console.ReadLine();
                    steps.Add(step);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid input. Please enter a valid number.\n");
                Console.ResetColor();
            }
        }

        public void DisplayRecipe()
        {
            Console.WriteLine($"\nRecipe Name: {Name}\n");

            string ingredientsList = "";

            foreach (Ingredient ingredient in ingredients)
            {
                ingredientsList += $"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}, ";
            }

            ingredientsList = ingredientsList.TrimEnd(',', ' ');

            Console.WriteLine($"For this recipe, you will need: {ingredientsList}\n");

            Console.WriteLine("Steps required to prepare this recipe:");

            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"Step number {i + 1}: {steps[i]}");
            }

            Console.WriteLine();
        }

        public void ScaleRecipe()
        {
            Console.Write("Enter the scaling factor (e.g., 0.5 for half, 2 for double, 3 for triple): ");
            double factor = double.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Are you sure you want to scale the recipe by a factor of {factor}? (Y/N)");
            Console.ResetColor();
            string confirm = Console.ReadLine();

            if (confirm.ToLower() == "y")
            {
                foreach (Ingredient ingredient in ingredients)
                {
                    ingredient.Quantity *= factor;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nRecipe scaled successfully to a factor of {factor}!");
                Console.ResetColor();
                Console.WriteLine();
            }
        }

       

     
    }


}
