using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Automation.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml.Linq;

namespace RecipeManagementApp
{
    public partial class IngredientWindow : Window
    {
        public Ingredient Ingredient { get; set; }
        private List<Step> steps;


        public IngredientWindow()
        {
            InitializeComponent();
            Ingredient = new Ingredient();
            steps = new List<Step>();
            DataContext = this;
        }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            // Prompt the user to enter a description for the step
            var description = Microsoft.VisualBasic.Interaction.InputBox("Enter a description for the step:", "Add Step");

            if (!string.IsNullOrWhiteSpace(description))
            {
                // Create a new Step object with the entered description
                var step = new Step { Description = description };

                // Add the Step object to the steps list
                steps.Add(step);

                // Update the ListBox
                UpdateStepListBox();
            }
        }

        private void DeleteStep_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var step = button.DataContext as Step;

            if (step != null)
            {
                steps.Remove(step);

           
                UpdateStepListBox();
            }
        }

        private void UpdateStepListBox()
        {
            stepListBox.ItemsSource = null; // Clear the ListBox's ItemsSource
            stepListBox.ItemsSource = steps; // Set the steps list as the new ItemsSource
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtQuantity.Text) && !string.IsNullOrWhiteSpace(txtUnit.Text))
            {
                Ingredient.Name = txtName.Text;
                Ingredient.Quantity = double.Parse(txtQuantity.Text);
                Ingredient.Unit = txtUnit.Text;
                Ingredient.Steps = steps.Select(step => step.Description).ToList();

                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }



    public class StepDescriptionValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string description = (value ?? "").ToString();

            if (string.IsNullOrWhiteSpace(description))
                return new ValidationResult(false, "Step description cannot be empty.");

            if (description.Length > 100)
                return new ValidationResult(false, "Step description cannot exceed 100 characters.");

            return ValidationResult.ValidResult;
        }
    }
}
