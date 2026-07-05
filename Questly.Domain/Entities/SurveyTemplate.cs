using Questly.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Domain.Entities
{
    public class SurveyTemplate : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Category { get; set; } = string.Empty;

        public bool IsOfficial { get; set; }

        public ICollection<SurveyTemplateQuestion> Questions { get; set; }
            = new List<SurveyTemplateQuestion>();
    }
}
