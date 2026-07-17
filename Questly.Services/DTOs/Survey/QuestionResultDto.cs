using Questly.Domain.Enums;
using Questly.Services.DTOs.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Services.DTOs.Survey
{
    public class QuestionResultDto
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; } = string.Empty;

        public QuestionType Type { get; set; }

        public double RatingAverage { get; set; }

        public int ResponseCount { get; set; }

        public List<OptionResultDto> Options { get; set; } = new();

        public List<MatrixRowResultDto> MatrixRows { get; set; } = new();

    }

    public class MatrixRowResultDto
    {
        public int RowId { get; set; }
        public string Text { get; set; } = string.Empty;
        public List<MatrixCellResultDto> Results { get; set; } = new();
    }

    public class MatrixCellResultDto
    {
        public int OptionId { get; set; }
        public int Count { get; set; }
    }

}
