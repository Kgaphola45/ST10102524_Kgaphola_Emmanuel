﻿


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeManagementApp
{
    public partial class MainWindow : Window
    {
        private RecipeManagement recipeManagement;

        public MainWindow()
        {
            InitializeComponent();
            recipeManagement = new RecipeManagement();
            recipeManagement.CurrentRecipe = new Recipe(); // Add this line

        }




        private void ResetAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            recipeManagement.Recipes.Clear(); // Clear the Recipes collection
            lstRecipes.ItemsSource = null;
            lstRecipes.ItemsSource = recipeManagement.GetRecipeList();
        }


        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var ingredientWindow = new IngredientWindow();
            ingredientWindow.Owner = this;
            if (ingredientWindow.ShowDialog() == true)
            {
                var ingredient = ingredientWindow.Ingredient;

                if (recipeManagement.CurrentRecipe == null)
                    recipeManagement.CurrentRecipe = new Recipe();

                if (recipeManagement.CurrentRecipe.Ingredients == null)
                    recipeManagement.CurrentRecipe.Ingredients = new List<Ingredient>();

                recipeManagement.CurrentRecipe.Ingredients.Add(ingredient);
                lstIngredients.ItemsSource = null;
                lstIngredients.ItemsSource = recipeManagement.CurrentRecipe.Ingredients;
            }
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecipeName.Text))
            {
                MessageBox.Show("Please enter a recipe name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var totalCalories = recipeManagement.CalculateTotalCalories(); // Calculate total calories of the current recipe
            if (totalCalories > 300)
            {
                MessageBox.Show("The total calories of this recipe exceed 300.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            var recipe = new Recipe()
            {
                RecipeName = txtRecipeName.Text,
                Ingredients = new List<Ingredient>(recipeManagement.CurrentRecipe.Ingredients)
            };

            recipeManagement.AddRecipe(recipe);
            lstRecipes.ItemsSource = null;
            lstRecipes.ItemsSource = recipeManagement.GetRecipeList();
            ClearForm();
        }

        private void FilterByMaxCalories_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtMaxCalories.Text, out int maxCalories))
            {
                var filteredRecipes = recipeManagement.GetRecipeList().Where(r => recipeManagement.CalculateTotalCalories(r) <= maxCalories).ToList();
                lstRecipes.ItemsSource = filteredRecipes;
            }
            else
            {
                MessageBox.Show("Invalid maximum calories. Please enter a numeric value.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var keyword = txtSearch.Text.ToLower();
            var foodGroup = cmbFoodGroup.SelectedItem as string;
            double maxCalories;
            double.TryParse(txtMaxCalories.Text, out maxCalories);

            var filteredRecipes = recipeManagement.GetRecipeList().Where(r =>
                r.RecipeName.ToLower().Contains(keyword) ||
                r.Ingredients.Any(i => i.Name.ToLower().Contains(keyword))
            ).ToList();

            if (!string.IsNullOrWhiteSpace(foodGroup))
            {
                filteredRecipes = filteredRecipes.Where(r => r.Ingredients.Any(i => i.FoodGroup == foodGroup)).ToList();
            }

            if (maxCalories > 0)
            {
                filteredRecipes = filteredRecipes.Where(r => recipeManagement.CalculateTotalCalories(r) <= maxCalories).ToList();
            }

            lstRecipes.ItemsSource = filteredRecipes;
        }


        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
            lstRecipes.ItemsSource = null;
            lstRecipes.ItemsSource = recipeManagement.GetRecipeList();
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Check if there is a current recipe selected
            if (recipeManagement.CurrentRecipe == null)
            {
                MessageBox.Show("Please select a recipe first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check if there are any ingredients in the current recipe
            if (recipeManagement.CurrentRecipe.Ingredients == null || recipeManagement.CurrentRecipe.Ingredients.Count == 0)
            {
                MessageBox.Show("There are no ingredients to scale.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Retrieve the selected scale factor from the combo box
            ComboBoxItem selectedItem = cmbScaleFactor.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                double scaleFactor = double.Parse(selectedItem.Content.ToString());

                // Scale the quantities of each ingredient in the current recipe
                foreach (var ingredient in recipeManagement.CurrentRecipe.Ingredients)
                {
                    ingredient.Quantity *= scaleFactor;
                }

                // Show a notification to the user
                MessageBox.Show("The recipe has been scaled.", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private void ResetQuantities_Click(object sender, RoutedEventArgs e)
        {
            // Check if there is a current recipe selected
            if (recipeManagement.CurrentRecipe == null)
            {
                MessageBox.Show("Please select a recipe first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check if there are any ingredients in the current recipe
            if (recipeManagement.CurrentRecipe.Ingredients == null || recipeManagement.CurrentRecipe.Ingredients.Count == 0)
            {
                MessageBox.Show("There are no ingredients to reset.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Reset the quantities of each ingredient in the current recipe to their original values
            foreach (var ingredient in recipeManagement.CurrentRecipe.Ingredients)
            {
                var originalIngredient = recipeManagement.GetOriginalRecipe()?.Ingredients.FirstOrDefault(i => i.Name == ingredient.Name);
                if (originalIngredient != null)
                {
                    ingredient.Quantity = originalIngredient.Quantity;
                }
            }

            // Show a notification to the user
            MessageBox.Show("The quantities have been reset.", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
        }





        private void DisplayRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (lstRecipes.SelectedItem != null)
            {
                var recipe = (Recipe)lstRecipes.SelectedItem;
                recipeManagement.CurrentRecipe = recipe; // Set the current recipe to the selected recipe
                var totalCalories = recipeManagement.CalculateTotalCalories();

                var recipeDetails = $"Name: {recipe.RecipeName}\n\n" +
                                     $"Total Calories: {totalCalories}\n\n" +
                                     "Ingredients:\n";

                if (totalCalories > 300)
                {
                    MessageBox.Show("The total calories of this recipe exceed 300.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                foreach (var ingredient in recipe.Ingredients)
                {
                    recipeDetails += $"Name: {ingredient.Name}\n" +
                                     $"Quantity: {ingredient.Quantity}\n" +
                                     $"Unit: {ingredient.Unit}\n" +
                                     $"Calories: {ingredient.Calories}\n" +
                                     $"Food Group: {ingredient.FoodGroup}\n" +
                                     "Steps:\n";

                    foreach (var step in ingredient.Steps)
                    {
                        recipeDetails += $"{step}\n";
                    }

                    recipeDetails += "\n";
                }

                MessageBox.Show(recipeDetails, "Recipe Details", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ClearForm()
        {
            txtRecipeName.Clear();
            recipeManagement.CurrentRecipe.Ingredients.Clear();
            lstIngredients.ItemsSource = null;
        }

        private void lstRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbScaleFactor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }



    public class Recipe : INotifyPropertyChanged
    {
        private string recipeName;
        private List<Ingredient> ingredients;
        private List<Ingredient> originalIngredients; // Add this line

        public string RecipeName
        {
            get { return recipeName; }
            set { recipeName = value; OnPropertyChanged("RecipeName"); }
        }

        public List<Ingredient> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; OnPropertyChanged("Ingredients"); }
        }

        public List<Ingredient> OriginalIngredients
        {
            get { return originalIngredients; }
            set { originalIngredients = value; OnPropertyChanged("OriginalIngredients"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Step
    {
        public string Description { get; set; }
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public List<string> Steps { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }




    }

    public class RecipeManagement
    {
        public ObservableCollection<Recipe> Recipes { get; set; }
        public Recipe CurrentRecipe { get; set; }

        public RecipeManagement()
        {
            Recipes = new ObservableCollection<Recipe>();
            CurrentRecipe = new Recipe();
        }

        public void AddRecipe(Recipe recipe)
        {
            Recipes.Add(recipe);
        }

        public double CalculateTotalCalories(Recipe recipe = null)
        {
            double totalCalories = 0;

            if (recipe == null)
                recipe = CurrentRecipe;

            foreach (var ingredient in recipe.Ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            return totalCalories;
        }




        public ObservableCollection<Recipe> GetRecipeList()
        {
            var sortedRecipes = Recipes.OrderBy(r => r.RecipeName).ToList();
            return new ObservableCollection<Recipe>(sortedRecipes);
        }

        public Recipe GetOriginalRecipe()
        {
            return Recipes.FirstOrDefault(r => r.RecipeName == CurrentRecipe.RecipeName);
        }
    }
}

