using System.ComponentModel.DataAnnotations;

namespace QuizzFullStack;

public class QuizSubmission
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }

    [Required]
    public int QuizId { get; set; }

    [Required]
    public DateTime SubmittedAt { get; set; }

    [Required]
    public int Score { get; set; }

    public string Answers { get; set; } // JSON or serialized answers
    public ApplicationUser User { get; set; }
    public Quiz Quiz { get; set; }
}
