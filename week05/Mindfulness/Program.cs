// EXCEEDING REQUIREMENTS - For 7 points:
// 1. Log file that saves activities to mindfulness_log.txt
// 2. Prevents random prompts from repeating until all are used
// 3. Added input validation

using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Start breathing activity");
            Console.WriteLine(" 2. Start reflecting activity");
            Console.WriteLine(" 3. Start listing activity");
            Console.WriteLine(" 4. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity1 = new BreathingActivity();
                activity1.Run();
            }
            else if (choice == "2")
            {
                ReflectionActivity activity2 = new ReflectionActivity();
                activity2.Run();
            }
            else if (choice == "3")
            {
                ListingActivity activity3 = new ListingActivity();
                activity3.Run();
            }
            else if (choice == "4")
            {
                break;
            }
        }
    }
}