using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestProject1
{
    public class Ingredient
    {
        public string Name { get; set; }
        public int Calories { get; set; }
    }

    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }
    }

    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void TestCalculateTotalCalories()
        {
            // Arrange
            Recipe recipe = new Recipe();
            recipe.Name = "Test Recipe";
            recipe.Ingredients = new List<Ingredient>()
            {
                new Ingredient() { Name = "Flour", Calories = 100 },
                new Ingredient() { Name = "Sugar", Calories = 200 },
                new Ingredient() { Name = "Butter", Calories = 300 }
            };

            // Act
            int totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(600, totalCalories);
        }
    }
}