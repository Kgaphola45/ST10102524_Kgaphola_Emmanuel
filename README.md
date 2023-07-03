# ST10102524_Kgaphola_Emmanuel

# Recipe Console Application

This is a standalone command line application that allows users to enter and manage recipes. It is implemented in C# using Visual Studio and uses classes to store the recipe data.

##Updates(Part 2)

- In part 2, the application allows the user to enter an unlimited number of recipes, and the user can enter a name for each recipe. The software displays a list of all the recipes to the user in alphabetical order by name, and the user can choose which recipe to display from the list.

- For each ingredient, the user can additionally enter the number of calories and the food group that the ingredient belongs to. The software calculates and displays the total calories of all the ingredients in a recipe. The software also notifies the user when the total calories of a recipe exceed 300.

## Features

- Enter the details for a new recipe.
- Display all recipes.
- Choose a recipe to display.
- Scale a recipe by a given factor.
- Reset quantities in a recipe.
- Calculate the total calories in a recipe.

## Getting Started

To run the Recipe Book application, follow these steps:

1. Clone the repository or download the source code, using Link attached above.
2. Open the solution file (`ST10102524_Kgaphola_Emmanuel.sln`) in Visual Studio.
3. Build the solution to restore dependencies and compile the project.
4. Run the application by pressing `Ctrl+F5` or selecting the "Start" button in Visual Studio.

## Usage

Upon running the application, you will be presented with a menu. Use the numeric options to perform various actions:

1. Enter the details for a new recipe.
2. Display all recipes.
3. Choose a recipe to display.
4. Scale a recipe.
5. Reset quantities in a recipe.
6. Calculate the total calories in a recipe.
7. Clear all data to enter a new recipe.
8. Exit the program.

Follow the prompts to enter the required information for each action.

## Testing

Unit tests are included in the project to ensure the correctness of key functionalities. The tests can be found in the "TestProject1" project.

To run the tests:
1. Open the solution file (`ST10102524_Kgaphola_Emmanuel`) in Visual Studio.
2. In the Solution Explorer, right-click on the test class named "UnitTest1.cs" and select "Run".
3. The test runner will start and the test will be executed.
4. The test runner will display the results of the test.


## Implementation

-The application is implemented in C# using Visual Studio. It uses classes to store the recipe data, and the ingredients and steps are stored in arrays. The application uses the Program class to interact with the user via the command line.




