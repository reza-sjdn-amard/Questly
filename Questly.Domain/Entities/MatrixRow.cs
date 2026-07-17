using Questly.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Domain.Entities
{
    public class MatrixRow : BaseEntity
    {
        public string Text { get; set; } = string.Empty;

        public int DisplayOrder { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; } = null!;
    }
}
