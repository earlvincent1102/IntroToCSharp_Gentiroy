/*
===========================================================
Program: Codac Logistics Delivery & Fuel Auditor
Author: [Your Name]
Description:
This program tracks a driver's fuel expenses and delivery
performance over 5 days. It validates input, calculates
efficiency, and generates an audit report.
===========================================================
*/

using System;

class Program
{
    static void Main()
    {
        // -------------------------------
        // TASK 1: Driver Profile
        // -------------------------------

        // String is used for text input (driver name)
        Console.Write("Enter Driver's Full Name: ");
        string driverName = Console.ReadLine();

        // Decimal is used for money to avoid rounding errors
        Console.Write("Enter Weekly Fuel Budget: ");
        decimal weeklyBudget = decimal.Parse(Console.ReadLine());

        // Double is used for distance (may contain decimals)
        double totalDistance = 0;

        // While loop validates distance input
        while (true)
        {
            Console.Write("Enter Total Distance Traveled (1.0 - 5000.0 km): ");
            totalDistance = double.Parse(Console.ReadLine());

            if (totalDistance >= 1.0 && totalDistance <= 5000.0)
            {
                break; // Exit loop if valid
            }
            else
            {
                Console.WriteLine("Error: Distance must be between 1.0 and 5000.0 km.");
            }
        }

        // -------------------------------
        // TASK 2: Fuel Expense Tracking
        // -------------------------------

        // 1D array to store 5 days of fuel expenses
        decimal[] fuelExpenses = new decimal[5];

        decimal totalFuelSpent = 0;

        // For loop for 5 days input
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Enter fuel expense for Day {i + 1}: ");
            fuelExpenses[i] = decimal.Parse(Console.ReadLine());

            // Accumulate total
            totalFuelSpent += fuelExpenses[i];
        }

        // -------------------------------
        // TASK 3: Performance Analysis
        // -------------------------------

        // Average daily expense
        decimal averageExpense = totalFuelSpent / 5;

        // Convert decimal to double for division
        double efficiencyValue = totalDistance / (double)totalFuelSpent;

        string efficiencyRating;

        // If-else for efficiency rating
        if (efficiencyValue > 15)
        {
            efficiencyRating = "High Efficiency";
        }
        else if (efficiencyValue >= 10)
        {
            efficiencyRating = "Standard Efficiency";
        }
        else
        {
            efficiencyRating = "Low Efficiency / Maintenance Required";
        }

        // Boolean for budget status
        bool underBudget = totalFuelSpent <= weeklyBudget;

        // -------------------------------
        // TASK 4: Audit Report
        // -------------------------------

        Console.WriteLine("\n================ AUDIT REPORT ================");
        Console.WriteLine($"Driver Name: {driverName}");
        Console.WriteLine($"Weekly Budget: ₱{weeklyBudget}");
        Console.WriteLine($"Total Distance: {totalDistance} km\n");

        Console.WriteLine("Fuel Expenses:");

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($" Day {i + 1}: ₱{fuelExpenses[i]}");
        }

        Console.WriteLine("\n---------------------------------------------");
        Console.WriteLine($"Total Fuel Spent: ₱{totalFuelSpent}");
        Console.WriteLine($"Average Daily Cost: ₱{averageExpense}");
        Console.WriteLine($"Fuel Efficiency Rating: {efficiencyRating}");
        Console.WriteLine($"Stayed Under Budget: {underBudget}");
        Console.WriteLine("=============================================");
    }
}