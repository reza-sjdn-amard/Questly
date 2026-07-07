using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.UI.Models.Question
{
    public class SkipLogicOptionViewModel
    {
        public int OptionId { get; set; }

        public string OptionText { get; set; } = string.Empty;

        public int? NextQuestionId { get; set; }
    }
}
