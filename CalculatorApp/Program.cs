// Interactive Calculator Application
using System;

Console.WriteLine("Welcome to the Interactive Calculator!");
Console.WriteLine();

while (true)
{
    ShowMenu();
    
    if (!TryGetUserChoice(out int choice))
        continue;
    
    if (choice == 0)
    {
        Console.WriteLine("Thank you for using the Interactive Calculator. Goodbye!");
        break;
    }
    
    if (!TryGetTwoNumbers(out double num1, out double num2))
        continue;
    
    PerformCalculation(choice, num1, num2);
    
    Console.WriteLine();
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
}

static void ShowMenu()
{
    Console.WriteLine("Please choose an operation:");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");
    Console.WriteLine("5. Modulus");
    Console.WriteLine("0. Exit");
    Console.WriteLine();
}

static bool TryGetUserChoice(out int choice)
{
    Console.Write("Enter your choice: ");
    choice = 0;
    
    try
    {
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Please enter a valid choice.");
            return false;
        }
        
        choice = int.Parse(input);
        
        if (choice < 0 || choice > 5)
        {
            Console.WriteLine("Please enter a number between 0 and 5.");
            return false;
        }
        
        return true;
    }
    catch (FormatException)
    {
        Console.WriteLine("Please enter a valid number.");
        return false;
    }
    catch (OverflowException)
    {
        Console.WriteLine("Number is too large. Please enter a number between 0 and 5.");
        return false;
    }
}

static bool TryGetTwoNumbers(out double num1, out double num2)
{
    num1 = 0;
    num2 = 0;
    
    Console.Write("Enter first number: ");
    if (!TryGetNumber(out num1))
        return false;
    
    Console.Write("Enter second number: ");
    if (!TryGetNumber(out num2))
        return false;
    
    return true;
}

static bool TryGetNumber(out double number)
{
    number = 0;
    
    try
    {
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Please enter a valid number.");
            return false;
        }
        
        number = double.Parse(input);
        return true;
    }
    catch (FormatException)
    {
        Console.WriteLine("Please enter a valid number.");
        return false;
    }
    catch (OverflowException)
    {
        Console.WriteLine("Number is too large or too small.");
        return false;
    }
}

static void PerformCalculation(int operation, double num1, double num2)
{
    try
    {
        switch (operation)
        {
            case 1: // Addition
                {
                    double result = num1 + num2;
                    Console.WriteLine($"Result: {num1} + {num2} = {result}");
                    break;
                }
            case 2: // Subtraction
                {
                    double result = num1 - num2;
                    Console.WriteLine($"Result: {num1} - {num2} = {result}");
                    break;
                }
            case 3: // Multiplication
                {
                    double result = num1 * num2;
                    Console.WriteLine($"Result: {num1} * {num2} = {result}");
                    break;
                }
            case 4: // Division
                {
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                        return;
                    }
                    double result = num1 / num2;
                    Console.WriteLine($"Result: {num1} / {num2} = {result}");
                    break;
                }
            case 5: // Modulus
                {
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error: Modulus by zero is not allowed.");
                        return;
                    }
                    double result = num1 % num2;
                    Console.WriteLine($"Result: {num1} % {num2} = {result}");
                    break;
                }
            default:
                Console.WriteLine("Invalid operation.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred during calculation: {ex.Message}");
    }
}
