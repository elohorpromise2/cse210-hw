using System;

public class Program
{
    public static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";

// Creativity: Added an Entry Count option so users can see how many journal entries are currently stored.
        while (choice != "6")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Entry Count");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine(prompt);
                Console.Write("> ");
                string entryText = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();

                Entry newEntry = new Entry(date, prompt, entryText);

                theJournal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                theJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();

                theJournal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();

                theJournal.SaveToFile(filename);
            } else if (choice == "5")
            {
                Console.WriteLine($"You have {theJournal.GetEntryCount()} journal entries.");
            }
            else if (choice == "6")
            {
               Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            Console.WriteLine();
        }
    }
}