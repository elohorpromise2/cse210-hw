public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        // Can't use _studentName directly - it's private in base
        // So we use the getter we created
        string studentName = GetStudentName();
        return $"{_title} by {studentName}";
    }
}