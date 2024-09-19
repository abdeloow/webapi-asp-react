namespace QuizzFullStack;

public class Quiz
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public string Difficulty { get; set; }

    // Navigation property: A Quiz has many Questions
    public List<Question> Questions { get; set; } = new List<Question>();
}
