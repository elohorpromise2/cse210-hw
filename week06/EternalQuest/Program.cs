using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> _goals = new List<Goal>();
    static int _score = 0;

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Eternal Quest!");

        string choice = "";

        while (choice != "7")
        {
            Console.WriteLine();
            Console.WriteLine($"Score: {_score}");
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Select a choice: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoals();
                    break;

                case "3":
                    RecordEvent();
                    break;

                case "4":
                    DisplayScore();
                    break;

                case "5":
                    SaveGoals();
                    break;

                case "6":
                    LoadGoals();
                    break;

                case "7":
                    Console.WriteLine("Thank you for using Eternal Quest!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("Create a New Goal");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("How many points is this goal worth? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            SimpleGoal goal = new SimpleGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (type == "2")
        {
            EternalGoal goal = new EternalGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be completed? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("How many bonus points will you receive when you finish? ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal goal = new ChecklistGoal(
                name,
                description,
                points,
                target,
                bonus);

            _goals.Add(goal);
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.WriteLine("Goal created successfully!");
    }

    static void ListGoals()
    {
        Console.WriteLine();
        Console.WriteLine("Your Goals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    static void RecordEvent()
    {
        Console.WriteLine();
        Console.WriteLine("Which goal did you accomplish?");

        ListGoals();

        if (_goals.Count == 0)
        {
            return;
        }

        Console.Write("Enter the goal number: ");
        int number = int.Parse(Console.ReadLine());

        if (number < 1 || number > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[number - 1];

        bool recorded = goal.RecordEvent();

        if (recorded)
        {
            _score += goal.GetPoints();

            Console.WriteLine(
                $"Congratulations! You earned {goal.GetPoints()} points.");

            if (goal is ChecklistGoal checklistGoal)
            {
                if (checklistGoal.JustCompleted())
                {
                    _score += checklistGoal.GetBonus();

                    Console.WriteLine(
                        $"You completed the checklist goal! " +
                        $"You earned a bonus of {checklistGoal.GetBonus()} points.");
                }
            }
        }
        else
        {
            Console.WriteLine("This goal has already been completed.");
        }
    }

    static void DisplayScore()
    {
        Console.WriteLine();

        string level;

        if (_score < 500)
        {
            level = "Level 1 - Quest Beginner";
        }
        else if (_score < 1000)
        {
            level = "Level 2 - Quest Explorer";
        }
        else if (_score < 2000)
        {
            level = "Level 3 - Quest Champion";
        }
        else
        {
            level = "Level 4 - Eternal Master";
        }

        Console.WriteLine($"Your current score is: {_score} points.");
        Console.WriteLine($"Your current level is: {level}");
    }

    static void SaveGoals()
    {
        string fileName = Path.Combine(
            AppContext.BaseDirectory,
            "goals.txt");

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                if (goal is SimpleGoal simpleGoal)
                {
                    outputFile.WriteLine(
                        $"Simple|{simpleGoal.GetName()}|{simpleGoal.GetDescription()}|{simpleGoal.GetPoints()}|{simpleGoal.IsComplete()}");
                }
                else if (goal is EternalGoal eternalGoal)
                {
                    outputFile.WriteLine(
                        $"Eternal|{eternalGoal.GetName()}|{eternalGoal.GetDescription()}|{eternalGoal.GetPoints()}");
                }
                else if (goal is ChecklistGoal checklistGoal)
                {
                    outputFile.WriteLine(
                        $"Checklist|{checklistGoal.GetName()}|{checklistGoal.GetDescription()}|{checklistGoal.GetPoints()}|{checklistGoal.GetTarget()}|{checklistGoal.GetBonus()}|{checklistGoal.GetAmountCompleted()}");
                }
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    static void LoadGoals()
    {
        string fileName = Path.Combine(
            AppContext.BaseDirectory,
            "goals.txt");

        if (!File.Exists(fileName))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);

        _goals.Clear();

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            if (parts[0] == "Simple")
            {
                SimpleGoal goal = new SimpleGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]));

                if (bool.Parse(parts[4]))
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
            else if (parts[0] == "Eternal")
            {
                EternalGoal goal = new EternalGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]));

                _goals.Add(goal);
            }
            else if (parts[0] == "Checklist")
            {
                ChecklistGoal goal = new ChecklistGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[4]),
                    int.Parse(parts[5]));

                int amountCompleted = int.Parse(parts[6]);

                for (int j = 0; j < amountCompleted; j++)
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }

    /*
     * Creativity addition:
     * I added a Quest Level System that gives the player
     * different titles based on their total score.
     * This goes beyond the basic requirements by making
     * the goal tracker feel more like a personal progress
     * and achievement system.
     */
}