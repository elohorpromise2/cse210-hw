using System;

// Derived class from Activity - Inheritance Hierarchy principle
// This class handles breathing activity specifically
public class BreathingActivity : Activity
{
    // Constructor calls base class constructor with name and description
    public BreathingActivity() : base("Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    // Run method for breathing activity - specific functionality
    public void Run()
    {
        // Use inherited method for starting message
        DisplayStartingMessage();

        // Calculate end time based on duration from base class
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        // Continue breathing in and out until duration is reached
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            ShowCountDown(4); // Pause 4 seconds with countdown
            Console.WriteLine();
            Console.Write("Now breathe out... ");
            ShowCountDown(6); // Pause 6 seconds with countdown
            Console.WriteLine();
            Console.WriteLine();
        }

        // Use inherited method for ending message
        DisplayEndingMessage();
    }
}