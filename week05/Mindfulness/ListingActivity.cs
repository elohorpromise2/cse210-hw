using System;
using System.Collections.Generic;

// Derived class for listing activity
public class ListingActivity : Activity
{
    // Private variables - Encapsulation
    private List<string> _prompts;
    private int _count; // To track number of items listed

    public ListingActivity() : base("Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        // Initialize listing prompts from specification
        _prompts = new List<string>();
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }

    public void Run()
    {
        DisplayStartingMessage();

        // Get random prompt
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];

        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5); // Countdown before starting
        Console.WriteLine();

        // Collect responses until time expires
        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            responses.Add(response);
        }

        // Count and display results
        _count = responses.Count;
        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }
}