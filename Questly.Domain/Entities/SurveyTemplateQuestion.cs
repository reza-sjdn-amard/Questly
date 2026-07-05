using Questly.Domain.Common;
using Questly.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Domain.Entities
{
    public class SurveyTemplateQuestion : BaseEntity
    {
        public string Text { get; set; } = string.Empty;

        public QuestionType Type { get; set; }

        public bool IsRequired { get; set; }

        public int DisplayOrder { get; set; }

        public int SurveyTemplateId { get; set; }

        public SurveyTemplate SurveyTemplate { get; set; } = null!;

        public ICollection<SurveyTemplateOption> Options { get; set; }
            = new List<SurveyTemplateOption>();
    }
}
