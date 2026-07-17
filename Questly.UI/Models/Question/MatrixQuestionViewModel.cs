using Questly.UI.Models.Survey;

namespace Questly.UI.Models.Question
{
    public class MatrixQuestionViewModel
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; } = string.Empty;

        public List<MatrixRowViewModel> Rows { get; set; } = new();

        public List<GetQuestionOptionViewModel> Options { get; set; } = new();

        public int SurveyId { get; set; }

    }
}
