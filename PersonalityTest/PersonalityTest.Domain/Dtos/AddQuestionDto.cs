using System.Collections.Generic;

namespace PersonalityTest.Domain.Dtos
{
    public class AddQuestionDto
    {
        public string Title { get; set; }
        public int Order { get; set; }

        public IEnumerable<AddQuestionOptionDto> QuestionOptions { get; set; }
    }
}
