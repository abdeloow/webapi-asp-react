using Microsoft.EntityFrameworkCore;

namespace QuizzFullStack;

public class QuizService : IQuizService
{
    private readonly ApplicationDbContext _context;

    public QuizService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Quiz> GetQuizAsync(int id)
    {
        return await _context.Quizzes
            .Include(q => q.Questions)
            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<int> SubmitQuizAsync(int quizId, Dictionary<int, string> answers)
    {
        var quiz = await _context.Quizzes.FindAsync(quizId);
        if (quiz == null)
        {
            throw new ArgumentException("Quiz not found.");
        }

        int score = 0;
        foreach (var answer in answers)
        {
            var question = await _context.Questions.FindAsync(answer.Key);
            if (question != null && question.CorrectAnswer == answer.Value)
            {
                score++;
            }
        }

        var submission = new QuizSubmission
        {
            QuizId = quizId,
            UserId = "CurrentUserId", // Replace with actual user ID
            SubmittedAt = DateTime.UtcNow,
            Score = score,
            Answers = Newtonsoft.Json.JsonConvert.SerializeObject(answers)
        };
        _context.QuizSubmissions.Add(submission);
        await _context.SaveChangesAsync();

        return score;
    }

    public async Task<Quiz> CreateQuizAsync(Quiz quiz)
    {
        _context.Quizzes.Add(quiz);
        await _context.SaveChangesAsync();
        return quiz;
    }

    public async Task UpdateQuizAsync(Quiz quiz)
    {
        _context.Quizzes.Update(quiz);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteQuizAsync(int id)
    {
        var quiz = await _context.Quizzes.FindAsync(id);
        if (quiz != null)
        {
            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Quiz>> GetAllQuizzesAsync()
    {
        return await _context.Quizzes
            .Include(q => q.Questions)
            .ToListAsync();
    }
}
