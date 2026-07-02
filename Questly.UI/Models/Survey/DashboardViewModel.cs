namespace Questly.UI.Models.Survey
{
    public class DashboardViewModel
    {
        public int TotalSurveys { get; set; }

        public int PublishedSurveys { get; set; }

        public int DraftSurveys { get; set; }

        public int TotalResponses { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; } = 10;

        public string? Search { get; set; }

        public List<DashboardSurveyItemViewModel> Surveys { get; set; } = new();
    }
}
