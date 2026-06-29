namespace Questly.UI.Models.Survey
{
    public class DashboardViewModel
    {
        public int TotalSurveys { get; set; }

        public int PublishedSurveys { get; set; }

        public int DraftSurveys { get; set; }

        public int TotalResponses { get; set; }

        public List<DashboardSurveyItemViewModel> Surveys { get; set; } = new();
    }
}
