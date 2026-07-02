using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Services.DTOs.Survey
{
    public class DashboardDto
    {
        public int TotalSurveys { get; set; }

        public int PublishedSurveys { get; set; }

        public int DraftSurveys { get; set; }

        public int TotalResponses { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; } = 10;

        public List<DashboardSurveyItemDto> Surveys { get; set; } = new();
    }
}
