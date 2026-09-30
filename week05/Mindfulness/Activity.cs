using System;
using System.Collections.Generic;
using System.Threading;

// Base class - contains shared attributes and behaviors for all activities
// This demonstrates Abstraction and Inheritance principles
public class Activity
{
    // Private member variables - Encapsulation principle
    // Using _underscoreCamelCase naming convention
    private string _name;
    private string _description;
    private int _duration;

    // Constructor - sets the name and description of activity
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Getter for duration - allows derived classes to access private _duration
    public int GetDuration()
    {
        return _duration;
    }

    // Common starting message for all activities - Inheriting Behaviors
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        // Ask for duration - shared by all activities
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        // Pause with spinner animation
        ShowSpinner(5);
    }

    // Common ending message for all activities
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(5);
    }

    // Shows spinner animation using backspaces - Pausing/Animation requirement
    public void ShowSpinner(int seconds)
    {
        // List of spinner characters
        List<string> animation = new List<string>();
        animation.Add("|");
        animation.Add("/");
        animation.Add("-");
        animation.Add("\\");

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animation[i];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b"); // Erase character with backspace
            i++;
            if (i >= animation.Count)
            {
                i = 0;
            }
        }
        Console.WriteLine();
    }

    // Shows countdown timer animation
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase number with backspace
        }
        Console.WriteLine();
    }
}