using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Questly.Data.Context;
using Questly.Domain.Entities;
using Questly.Services.DTOs.Survey;
using Questly.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Services.Implementations
{
    public class SurveyTemplateService(QuestlyDbContext _context,
                                       IMapper _mapper,
                                       ISurveyService _surveyService) : ISurveyTemplateService
    {
        public async Task<List<SurveyTemplateDto>> GetTemplatesAsync()
        {
            var surveyTemplates = await _context.SurveyTemplates
                .AsNoTracking()
                .OrderBy(t => t.Category)
                .ThenBy(t => t.Title).ToListAsync();

            return _mapper.Map<List<SurveyTemplateDto>>(surveyTemplates);
        }

        public async Task<int> CreateSurveyFromTemplateAsync(int templateId, string userId)
        {
            var template = await _context.SurveyTemplates
                .Include(t => t.Questions.OrderBy(q => q.DisplayOrder))
                    .ThenInclude(q => q.Options.OrderBy(o => o.DisplayOrder))
                .FirstOrDefaultAsync(t => t.Id == templateId);

            if (template == null)
                throw new Exception("Template not found.");

            var survey = _mapper.Map<Survey>(template);
            survey.UserId = userId;
            var surveyDto = _mapper.Map<CreateSurveyDto>(survey);
            return await _surveyService.CreateSurveyAsync(surveyDto);
        }
    }
}
