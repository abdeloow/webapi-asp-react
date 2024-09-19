namespace QuizzFullStack;

public class QuizSubmissionRequest
{
    public int QuizId { get; set; }
    public Dictionary<int, string> Answers { get; set; }
}
