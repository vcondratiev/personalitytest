using System;

namespace PersonalityTest.Domain.Entities
{
    public class QuestionAnswer
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public string Value { get; set; }

        public Guid TestId { get; set; }
        public Test Test { get; set; }
    }
}
