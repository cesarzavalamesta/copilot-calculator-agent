// Interactive Calculator Application
// Provides basic mathematical operations with a menu-driven interface

Console.WriteLine("Welcome to the Interactive Calculator!");
Console.WriteLine();

bool continueCalculating = true;

while (continueCalculating)
{
    // Display menu options
    Console.WriteLine("Please choose an operation:");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");
    Console.WriteLine("5. Modulus");
    Console.WriteLine("0. Exit");
    Console.WriteLine();
    Console.Write("Enter your choice: ");

    try
    {
        // Get user's menu choice
        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid input. Please enter a number between 0 and 5.");
            Console.WriteLine();
            continue;
        }

        // Handle exit option
        if (choice == 0)
        {
            Console.WriteLine("Thank you for using the Interactive Calculator. Goodbye!");
            continueCalculating = false;
            continue;
        }

        // Validate menu choice range
        if (choice < 1 || choice > 5)
        {
            Console.WriteLine("Invalid choice. Please select a number between 0 and 5.");
            Console.WriteLine();
            continue;
        }

        // Get first number
        Console.Write("Enter first number: ");
        if (!double.TryParse(Console.ReadLine(), out double firstNumber))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.WriteLine();
            continue;
        }

        // Get second number
        Console.Write("Enter second number: ");
        if (!double.TryParse(Console.ReadLine(), out double secondNumber))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.WriteLine();
            continue;
        }

        // Perform calculation based on choice
        double result;
        string operationSymbol;

        switch (choice)
        {
            case 1: // Addition
                result = firstNumber + secondNumber;
                operationSymbol = "+";
                break;
            case 2: // Subtraction
                result = firstNumber - secondNumber;
                operationSymbol = "-";
                break;
            case 3: // Multiplication
                result = firstNumber * secondNumber;
                operationSymbol = "*";
                break;
            case 4: // Division
                if (secondNumber == 0)
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                    Console.WriteLine();
                    continue;
                }
                result = firstNumber / secondNumber;
                operationSymbol = "/";
                break;
            case 5: // Modulus
                if (secondNumber == 0)
                {
                    Console.WriteLine("Error: Modulus by zero is not allowed.");
                    Console.WriteLine();
                    continue;
                }
                result = firstNumber % secondNumber;
                operationSymbol = "%";
                break;
            default:
                Console.WriteLine("Invalid operation.");
                Console.WriteLine();
                continue;
        }

        // Display result
        Console.WriteLine($"Result: {firstNumber} {operationSymbol} {secondNumber} = {result}");
        Console.WriteLine();
        Console.WriteLine("[Return to main menu...]");
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        Console.WriteLine("Please try again.");
        Console.WriteLine();
    }
}
