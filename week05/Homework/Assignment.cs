public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // We need this getter because _studentName is private
    // and WritingAssignment needs it for GetWritingInformation()
    public string GetStudentName()
    {
        return _studentName;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}