using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();

        job1._jobTitle = "CEO";
        job1._company = "Fashion Castle";
        job1._startYear = 2019;
        job1._endYear = 2024;

        Job job2 = new Job();

        job2._jobTitle = "CEO";
        job2._company = "Drops and Clouds";
        job2._startYear = 2026;
        job2._endYear = 2030;

        Resume myResume = new Resume();

        myResume._name = "Promise Elohor";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}