using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Services.DTOs.Survey
{
    public class SurveyTemplateDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Category { get; set; } = string.Empty;

        public bool IsOfficial { get; set; }
    }
}
