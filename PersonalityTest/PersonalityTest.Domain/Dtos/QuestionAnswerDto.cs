using System;

namespace PersonalityTest.Domain.Dtos
{
    public class QuestionAnswerDto
    {
        public Guid QuestionId { get; set; }
        public string Value { get; set; }
    }
}
