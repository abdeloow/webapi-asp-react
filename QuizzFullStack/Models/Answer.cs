namespace QuizzFullStack;

public class Answer
{
    public int Id { get; set; }
    public string AnswerText { get; set; }

    // Foreign key to the related Question
    public int QuestionId { get; set; }

    // Navigation property: Reference to the related Question
    public Question Question { get; set; }
}
