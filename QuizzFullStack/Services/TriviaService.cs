using Newtonsoft.Json.Linq;

namespace QuizzFullStack;

public class TriviaService : ITriviaService
{
    private readonly HttpClient _httpClient;

    public TriviaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Question>> GetTriviaQuestionsAsync(string category, string difficulty, int count)
    {
        var response = await _httpClient.GetAsync($"https://opentdb.com/api.php?amount={count}&category={category}&difficulty={difficulty}");
        var jsonString = await response.Content.ReadAsStringAsync();
        var json = JObject.Parse(jsonString);

        var questions = new List<Question>();

        foreach (var item in json["results"])
        {
            var question = new Question
            {
                QuestionText = item["question"].ToString(),
                CorrectAnswer = item["correct_answer"].ToString(),
                Answers = new List<Answer>
                    {
                        new Answer { AnswerText = item["correct_answer"].ToString() },
                        new Answer { AnswerText = item["incorrect_answers"][0].ToString() },
                        new Answer { AnswerText = item["incorrect_answers"][1].ToString() },
                        new Answer { AnswerText = item["incorrect_answers"][2].ToString() }
                    }
            };
            questions.Add(question);
        }

        return questions;
    }
}
