namespace QuizzFullStack;

public class Question
{
    public int Id { get; set; }
    public string QuestionText { get; set; }
    public string CorrectAnswer { get; set; }

    // Navigation property: A Question has many Answers
    public List<Answer> Answers { get; set; } = new List<Answer>();

    // Foreign key to the related Quiz
    public int QuizId { get; set; }

    // Navigation property: Reference to the related Quiz
    public Quiz Quiz { get; set; }
}
