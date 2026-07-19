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
    public class SurveyInvitationService(QuestlyDbContext _context) : ISurveyInvitationService
    {
        public async Task<SendInvitationDto?> GetInvitationAsync(int surveyId)
        {
            var survey = await _context.Surveys
                .FirstOrDefaultAsync(s => s.Id == surveyId);

            if (survey == null)
                return null;

            return new SendInvitationDto
            {
                SurveyId = survey.Id
            };
        }

        public async Task SendInvitationsAsync(SendInvitationDto dto)
        {
            var emails = dto.Emails
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(e => e.Trim())
                .Distinct();

            foreach (var email in emails)
            {
                _context.SurveyInvitations.Add(new SurveyInvitation
                {
                    SurveyId = dto.SurveyId,
                    Email = email
                });

                // TODO:
                // Send email here using IEmailSender
            }

            await _context.SaveChangesAsync();
        }
    }
}
