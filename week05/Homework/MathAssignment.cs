public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    // Call base() to set the name and topic in the parent
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}