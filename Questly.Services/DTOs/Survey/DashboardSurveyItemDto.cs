using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Services.DTOs.Survey
{
    public class DashboardSurveyItemDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public bool IsPublished { get; set; }

        public DateTime? ClosedAt { get; set; }

        public int QuestionCount { get; set; }

        public int ResponseCount { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
