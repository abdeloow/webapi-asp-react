namespace QuizzFullStack;

public interface IQuizService
{
    Task<Quiz> GetQuizAsync(int id);
    Task<int> SubmitQuizAsync(int quizId, Dictionary<int, string> answers);
    Task<Quiz> CreateQuizAsync(Quiz quiz);
    Task UpdateQuizAsync(Quiz quiz);
    Task DeleteQuizAsync(int id);
    Task<IEnumerable<Quiz>> GetAllQuizzesAsync();
}
