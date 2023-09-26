using System;

namespace POE_PART1_ING
{
    class Ingredient 
    {

        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
    }

    class RecipeStep
    {
        public string Description { get; set; }
    }

    class Recipe
    {
        private Ingredient[] ingredients;
        private RecipeStep[] steps;

        public Recipe()
        {
            //Array list for ingredients
            ingredients = new Ingredient[0];
            steps = new RecipeStep[0];
        }

        public void EnterRecipeDetails()
        {
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            ingredients = new Ingredient[numIngredients];

            //using for/ else statement create a class for numIngredients
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter the name of ingredient {i + 1}: ");
                string name = Console.ReadLine();
                Console.Write($"Enter the quantity of {name}: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write($"Enter the unit of measurement for {name}: ");
                string unit = Console.ReadLine();

                ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
            }
            // Steps needed for the recipe
            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            steps = new RecipeStep[numSteps];
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string description = Console.ReadLine();
                steps[i] = new RecipeStep { Description = description };
            }
        }
        // create a class to display the Recipe
        public void DisplayRecipe()
        {
            Console.WriteLine("\nRecipe Details:");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i].Description}");
            }
        }
        //Class for the  factor (is 2)
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetRecipe()
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity = ingredient.Quantity / 2; 
            }
        }

        public void ClearRecipe()
        {
            ingredients = new Ingredient[0];
            steps = new RecipeStep[0];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                Console.WriteLine("\nRecipe Menu:");
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Recipe");
                Console.WriteLine("5. Clear Recipe");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                // using a switch case to store 
                switch (choice)
                {
                    case 1:
                        recipe.EnterRecipeDetails();
                        break;
                    case 2:
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                        double factor = double.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(factor);
                        break;
                    case 4:
                        recipe.ResetRecipe();
                        break;
                    case 5:
                        recipe.ClearRecipe();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
  