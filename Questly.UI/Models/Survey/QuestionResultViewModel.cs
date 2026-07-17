using Questly.Domain.Enums;
using Questly.UI.Models.Question;

namespace Questly.UI.Models.Survey
{
    public class QuestionResultViewModel
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; } = string.Empty;

        public QuestionType Type { get; set; }

        public double RatingAverage { get; set; }

        public int ResponseCount { get; set; }

        public List<OptionResultViewModel> Options { get; set; } = new();

        public List<MatrixRowResultViewModel> MatrixRows { get; set; } = new();

    }

    public class MatrixRowResultViewModel
    {
        public int RowId { get; set; }
        public string Text { get; set; } = string.Empty;
        public List<MatrixCellResultViewModel> Results { get; set; } = new();
    }

    public class MatrixCellResultViewModel
    {
        public int OptionId { get; set; }
        public int Count { get; set; }
    }
}
