using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            // Get the number of students
            Console.WriteLine("Enter the number of students in the class:");
            string input = Console.ReadLine();
            int numberOfStudents;

            // Check if the input is a valid integer
            if (int.TryParse(input, out numberOfStudents) && numberOfStudents > 0)
            {
                // Initialize total to store the sum of grades
                double total = 0;

                // Collect grades from the user
                for (int i = 1; i <= numberOfStudents; i++)
                {
                    Console.WriteLine($"Enter the grade for student {i}:");
                    string gradeInput = Console.ReadLine();
                    double grade;

                    // Check if the grade is a valid number and between 0 and 100
                    if (double.TryParse(gradeInput, out grade) && grade >= 0 && grade <= 100)
                    {
                        total += grade; // Add grade to total
                    }
                    else
                    {
                        Console.WriteLine("Invalid grade. Please enter a number between 0 and 100.");
                        i--; // Retry the same student's grade
                    }
                }

                // Calculate the average grade
                double averageGrade = total / numberOfStudents;

                // Determine the letter grade using a switch statement
                string letterGrade = GetLetterGrade(averageGrade);

                // Print the average and letter grade
                Console.WriteLine($"Average grade: {averageGrade:F2}");
                Console.WriteLine($"Letter grade: {letterGrade}");
            }
            else
            {
                Console.WriteLine("Please enter a valid positive number for the number of students.");
            }

            // Ask if the user wants to process another class
            Console.WriteLine("Do you want to calculate grades for another class? (yes/no):");
            string response = Console.ReadLine().ToLower();
            if (response != "yes")
            {
                break; // Exit the loop if user doesn't want to continue
            }
        }
    }

    static string GetLetterGrade(double averageGrade)
    {
        int gradeCategory;

        if (averageGrade >= 90)
        {
            gradeCategory = 1;
        }
        else if (averageGrade >= 80)
        {
            gradeCategory = 2;
        }
        else if (averageGrade >= 70)
        {
            gradeCategory = 3;
        }
        else if (averageGrade >= 60)
        {
            gradeCategory = 4;
        }
        else
        {
            gradeCategory = 5;
        }

        // Use a switch statement to convert the grade category to a letter grade
        switch (gradeCategory)
        {
            case 1: return "A";
            case 2: return "B";
            case 3: return "C";
            case 4: return "D";
            case 5: return "F";
            default: return "Unknown"; // This should not happen
        }
    }
}
