using System;

namespace PersonalityTest.Domain.Entities
{
    public class QuestionOption
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }

        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
