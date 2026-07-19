using Questly.Services.DTOs.Survey;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Services.Interfaces
{
    public interface ISurveyInvitationService
    {
        Task<SendInvitationDto?> GetInvitationAsync(int surveyId);

        Task SendInvitationsAsync(SendInvitationDto dto);
    }
}
