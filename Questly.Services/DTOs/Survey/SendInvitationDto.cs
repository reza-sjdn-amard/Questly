using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Services.DTOs.Survey
{
    public class SendInvitationDto
    {
        public int SurveyId { get; set; }

        public string Emails { get; set; } = string.Empty;
    }
}
