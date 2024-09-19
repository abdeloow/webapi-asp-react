namespace QuizzFullStack;

public class TriviaQuestion
{
    public string Text { get; set; }
    public string CorrectAnswer { get; set; }
    public IEnumerable<TriviaAnswer> Answers { get; set; }
}
