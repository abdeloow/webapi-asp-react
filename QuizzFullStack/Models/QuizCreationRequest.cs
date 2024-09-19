namespace QuizzFullStack;

public class QuizCreationRequest
{
    public string Title { get; set; }
    public IEnumerable<Question> Questions { get; set; }
}
