using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Services.DTOs.Question
{
    public class SkipLogicDto
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; } = string.Empty;

        public List<SkipLogicOptionDto> Options { get; set; } = new();

        public List<QuestionLookupDto> Questions { get; set; } = new();

        public int SurveyId { get; set; }
    }
}
