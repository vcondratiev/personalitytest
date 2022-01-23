using System;
using System.Collections.Generic;

namespace PersonalityTest.Domain.Dtos
{
    public class SaveTestDto
    {
        public Guid QuestionSetId { get; set; }
        public IEnumerable<QuestionAnswerDto> Answers { get; set; }
    }
}
