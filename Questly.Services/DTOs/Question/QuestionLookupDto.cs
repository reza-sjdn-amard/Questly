using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Services.DTOs.Question
{
    public class QuestionLookupDto
    {
        public int Id { get; set; }

        public string Text { get; set; } = string.Empty;
    }
}
