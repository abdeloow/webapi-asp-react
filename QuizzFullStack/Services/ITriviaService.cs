namespace QuizzFullStack;

public interface ITriviaService
{
    Task<List<Question>> GetTriviaQuestionsAsync(string category, string difficulty, int count);
}
