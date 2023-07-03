# Recipe Management App

This is a Recipe Management App that allows you to create, store, and manage recipes. The app has been updated from a console application to a graphical user interface (GUI) for a more user-friendly experience. With the GUI, you can easily add ingredients, create recipes, filter recipes based on criteria, and perform various operations on recipes.

## brief description (100 to 200 words) of what you changed based on your lecturer’s 
feedback.



- Firstly, I implemented the ability to calculate and display the total calories of all the ingredients in a recipe. This feature allows users to get a quick overview of the nutritional value of their recipes. The `CalculateTotalCalories` method in the `Recipe` class calculates the sum of calories for each ingredient in the recipe, and the `DisplaySingleRecipe` method in the main program displays the total calories for a chosen recipe.

- Secondly, I added a notification feature that alerts the user when the total calories of a recipe exceed 300. This is important for individuals who are conscious of their calorie intake and want to stay within a certain limit. The notification is displayed when the total calories are calculated in the `CalculateTotalCalories` method and the result exceeds 300.




## Features

- Add Ingredients: Click the "Add Ingredient" button to open a window where you can enter the details of a new ingredient. The ingredient will be added to the current recipe.
- Create Recipe: Enter a recipe name in the provided text box and click the "Add Recipe" button to create a new recipe with the entered name and the list of ingredients from the current recipe.
- Filter Recipes by Maximum Calories: Enter a maximum calorie value in the text box and click the "Filter" button to display a list of recipes whose total calories are below or equal to the entered value.
- Search Recipes: Enter a keyword in the search box to search for recipes that contain the keyword in either the recipe name or any of the ingredients' names. You can also select a specific food group and set a maximum calorie value to further refine your search.
- Scale Recipe: Select a scale factor from the provided drop-down menu and click the "Scale Recipe" button to multiply the quantities of ingredients in the current recipe by the selected factor.
- Display Recipe Details: Select a recipe from the list and click the "Display Recipe" button to view detailed information about the recipe, including its name, total calories, ingredients, and steps.
- Reset All Recipes: Click the "Reset All Recipes" button to clear all existing recipes and reset the app to its initial state.

## Instructions

Follow the steps below to compile and run the software:

1. Make sure you have the necessary development environment installed, including the .NET Framework and a compatible IDE like Visual Studio.
2. Clone the repository or download the source code, using Link attached above.
3. Open the solution file (`ST10102524_Kgaphola_Emmanuel.sln`) in Visual Studio.
4. Build the solution to restore dependencies and compile the project.
5. Run the application by pressing `Ctrl+F5` or selecting the "Start" button in Visual Studio.

## Usage

Once the app is running, you can perform the following actions:

- To add ingredients to the current recipe:
  - Click the "Add Ingredient" button to open a new window.
  - Enter the ingredient details (name, quantity, unit, calories, food group, and steps if any).
  - Click "OK" to add the ingredient to the current recipe.

- To create a recipe:
  - Enter a recipe name in the "Recipe Name" text box.
  - Add ingredients to the current recipe using the "Add Ingredient" button as described above.
  - Click the "Add Recipe" button to create the recipe and add it to the list of recipes.

- To filter recipes by maximum calories:
  - Enter a numeric value in the "Maximum Calories" text box.
  - Click the "Filter" button to display the recipes whose total calories are below or equal to the entered value.

- To search for recipes:
  - Enter a keyword in the "Search" text box.
  - Optionally, select a specific food group from the drop-down menu.
  - Optionally, enter a maximum calorie value in the "Maximum Calories" text box.
  - Click the "Search" button to display the recipes that match the search criteria.

- To scale the quantities of ingredients in the current recipe:
  - Select a scale factor from the "Scale Factor" drop-down menu.
  - Click the "Scale Recipe" button to multiply the quantities of ingredients by the selected factor.

- To display recipe details:
  - Select a recipe from the list of recipes.
  - Click the "Display Recipe

" button to view detailed information about the selected recipe.

- To reset the form and list of recipes:
  - Click the "Clear" button to clear the input fields and reset the current recipe.
  - Click the "Reset All Recipes" button to clear all existing recipes and reset the app.

## Notes

- The app calculates the total calories of each recipe based on the sum of calories from all its ingredients.
- If a recipe's total calories exceed 300, a warning message will be displayed.
- The app allows you to customize and personalize the appearance of the GUI, including color schemes, themes, and font sizes.

Enjoy using the Recipe Management App! Feel free to explore and modify the code to suit your needs.
