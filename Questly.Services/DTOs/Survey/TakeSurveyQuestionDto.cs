using Questly.Domain.Enums;
using Questly.Services.DTOs.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Services.DTOs.Survey
{
    public class TakeSurveyQuestionDto
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

        public List<TakeSurveyOptionDto> Options { get; set; } = new();

        public List<MatrixRowDto> MatrixRows { get; set; } = new();

        public List<MatrixAnswerDto> MatrixAnswers { get; set; } = new();

    }

    public class MatrixAnswerDto
    {
        public int MatrixRowId { get; set; }

        public int? SelectedOptionId { get; set; }
    }
}
