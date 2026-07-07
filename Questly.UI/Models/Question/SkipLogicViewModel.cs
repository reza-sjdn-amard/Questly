using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.UI.Models.Question
{
    public class SkipLogicViewModel
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; } = string.Empty;

        public List<SkipLogicOptionViewModel> Options { get; set; } = new();

        public List<QuestionLookupViewModel> Questions { get; set; } = new();

        public int SurveyId { get; set; }
    }
}
