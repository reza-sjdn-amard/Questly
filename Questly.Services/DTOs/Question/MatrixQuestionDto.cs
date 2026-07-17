using Questly.Domain.Entities;
using Questly.Services.DTOs.Survey;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Services.DTOs.Question
{
    public class MatrixQuestionDto
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; } = string.Empty;

        public List<MatrixRowDto> Rows { get; set; } = new();

        public List<GetQuestionOptionDto> Options { get; set; } = new();

        public int SurveyId { get; set; }
    }
}
