using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Services.DTOs.Question
{
    public class SkipLogicOptionDto
    {
        public int OptionId { get; set; }

        public string OptionText { get; set; } = string.Empty;

        public int? NextQuestionId { get; set; }
    }
}
