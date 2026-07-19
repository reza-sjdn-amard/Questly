using Questly.Domain.Enums;
using Questly.UI.Models.Question;

namespace Questly.UI.Models.Survey
{
    public class TakeSurveyQuestionViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; } = string.Empty;

        public QuestionType Type { get; set; }

        public bool IsRequired { get; set; }

        // For ShortText / LongText
        public string? AnswerText { get; set; }

        // For SingleChoice / Dropdown
        public int? SelectedOptionId { get; set; }

        // For MultipleChoice
        public List<int> SelectedOptionIds { get; set; } = new();

        public List<TakeSurveyOptionViewModel> Options { get; set; } = new();

        public List<MatrixRowViewModel> MatrixRows { get; set; } = new();

        public List<MatrixAnswerViewModel> MatrixAnswers { get; set; } = new();

        public IFormFile? UploadedFile { get; set; }

    }

    public class MatrixAnswerViewModel
    {
        public int MatrixRowId { get; set; }

        public int? SelectedOptionId { get; set; }
    }
}
