using Microsoft.AspNetCore.Mvc;

namespace QuizzFullStack;
[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;

    public QuizController(IQuizService quizService)
    {
        _quizService = quizService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuiz([FromBody] QuizCreationRequest request)
    {
        if (request == null)
        {
            return BadRequest("Quiz creation request cannot be null.");
        }

        // Convert IEnumerable<Question> to List<Question>
        var quiz = new Quiz
        {
            Title = request.Title,
            Questions = request.Questions.ToList() // Ensure conversion to List<Question>
        };

        var createdQuiz = await _quizService.CreateQuizAsync(quiz);
        return CreatedAtAction(nameof(GetQuiz), new { id = createdQuiz.Id }, createdQuiz);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuiz(int id)
    {
        var quiz = await _quizService.GetQuizAsync(id);

        if (quiz == null)
        {
            return NotFound();
        }

        return Ok(quiz);
    }
}
