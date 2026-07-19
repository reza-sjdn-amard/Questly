using Questly.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Domain.Entities
{
    public class SurveyInvitation : BaseEntity
    {
        public int SurveyId { get; set; }

        public string Email { get; set; } = string.Empty;

        public DateTime SentAt { get; set; } = DateTime.Now;

        public bool IsOpened { get; set; }

        public bool IsResponded { get; set; }

        public Survey Survey { get; set; } = null!;
    }
}
