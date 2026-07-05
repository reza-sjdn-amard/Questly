using Questly.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Domain.Entities
{
    public class SurveyTemplateOption : BaseEntity
    {
        public string Text { get; set; } = string.Empty;

        public int DisplayOrder { get; set; }

        public int SurveyTemplateQuestionId { get; set; }

        public SurveyTemplateQuestion SurveyTemplateQuestion { get; set; } = null!;
    }
}
