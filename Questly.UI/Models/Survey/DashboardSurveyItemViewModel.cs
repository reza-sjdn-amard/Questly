namespace Questly.UI.Models.Survey
{
    public class DashboardSurveyItemViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public bool IsPublished { get; set; }

        public int QuestionCount { get; set; }

        public int ResponseCount { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
