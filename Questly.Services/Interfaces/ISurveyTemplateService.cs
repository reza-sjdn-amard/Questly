using Questly.Services.DTOs.Survey;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Services.Interfaces
{
    public interface ISurveyTemplateService
    {
        Task<List<SurveyTemplateDto>> GetTemplatesAsync();

        Task<int> CreateSurveyFromTemplateAsync(int templateId, string userId);
    }
}
