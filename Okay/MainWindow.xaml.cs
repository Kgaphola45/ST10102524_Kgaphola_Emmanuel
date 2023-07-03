


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
            // Initialize the RecipeManagement instance and set the CurrentRecipe to a new instance of Recipe
            InitializeComponent();
    recipeManagement = new RecipeManagement();
    recipeManagement.CurrentRecipe = new Recipe(); // Add this line
   
}



        // Event handler for the "Reset All Recipes" button click
        private void ResetAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            recipeManagement.Recipes.Clear(); // Clear the Recipes collection
            lstRecipes.ItemsSource = null;
            lstRecipes.ItemsSource = recipeManagement.GetRecipeList();
        }

        // Event handler for the "Add Ingredient" button click
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var ingredientWindow = new IngredientWindow();
            ingredientWindow.Owner = this;
            // Open the IngredientWindow and add the new ingredient to the CurrentRecipe if the dialog result is true
            if (ingredientWindow.ShowDialog() == true)
                if (ingredientWindow.ShowDialog() == true)
            {
                var ingredient = ingredientWindow.Ingredient;
                    // Check if the CurrentRecipe is null and create a new Recipe if it is
                    if (recipeManagement.CurrentRecipe == null)
                    recipeManagement.CurrentRecipe = new Recipe(); 

                if (recipeManagement.CurrentRecipe.Ingredients == null)
                    recipeManagement.CurrentRecipe.Ingredients = new List<Ingredient>(); 

                recipeManagement.CurrentRecipe.Ingredients.Add(ingredient);
                lstIngredients.ItemsSource = null;
                lstIngredients.ItemsSource = recipeManagement.CurrentRecipe.Ingredients;
            }
        }
        // Event handler for the "Add Recipe" button click
        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Check if the recipe name is empty or whitespace and display an error message if it is
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
        // Event handler for the "Filter By Max Calories" button click
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
        // Event handler for the "Search" button click
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            // Get the keyword, food group, and maximum calories from the input fields
            var keyword = txtSearch.Text.ToLower();
            var foodGroup = cmbFoodGroup.SelectedItem as string;
            double maxCalories;
            double.TryParse(txtMaxCalories.Text, out maxCalories);
            // Retrieve the filtered recipes based on the search criteria and update the UI
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

        // Event handler for the "Clear" button click
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            // Clear the input form and retrieve the updated recipe list
            ClearForm();
            lstRecipes.ItemsSource = null;
            lstRecipes.ItemsSource = recipeManagement.GetRecipeList();
        }
        // Event handler for the "Scale Recipe" button click

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


        }




        // Event handler for the "Display Recipe" button click
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
                    // Build a string representation of the recipe details
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
    // Class representing an ingredient
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public List<string> Steps { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }

       


    }

    // Class responsible for managing recipes

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

 