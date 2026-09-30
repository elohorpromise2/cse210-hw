using System;
using System.Collections.Generic;

// Derived class for reflection activity
public class ReflectionActivity : Activity
{
    // Private lists for prompts and questions - Encapsulation
    private List<string> _prompts;
    private List<string> _questions;

    // Constructor - initializes prompts and questions
    public ReflectionActivity() : base("Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        // Initialize prompts - examples from specification
        _prompts = new List<string>();
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        // Initialize questions - examples from specification
        _questions = new List<string>();
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }

    public void Run()
    {
        DisplayStartingMessage();

        // Select random prompt
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];

        // Display prompt to user
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        // Show random questions until time runs out
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            string question = _questions[random.Next(_questions.Count)];
            Console.Write($"> {question} ");
            ShowSpinner(10); // Pause with spinner for 10 seconds
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}