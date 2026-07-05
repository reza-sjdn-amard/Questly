namespace Questly.UI.Models.Survey
{
    public class SurveyTemplateViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Category { get; set; } = string.Empty;

        public bool IsOfficial { get; set; }
    }
}
