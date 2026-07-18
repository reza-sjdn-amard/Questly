namespace Questly.UI.Models.Question
{
    public class UpdateQuestionOptionViewModel
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Text { get; set; } = string.Empty;
    }
}
