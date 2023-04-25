using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10102524_Kgaphola_Emmanuel
{
    class Ingredient
    {

        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        private double originalQuantity;

        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            originalQuantity = quantity;
        }

        public void ResetQuantity()
        {
            Quantity = originalQuantity;
        }

    }



    class Recipe
    {
        private List<Ingredient> ingredients;
        private List<string> steps;


        public Recipe()
        {
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        public void EnterRecipeDetails()
        {
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

                    ingredients.Add(new Ingredient(name, quantity, unit));

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



    }


}
