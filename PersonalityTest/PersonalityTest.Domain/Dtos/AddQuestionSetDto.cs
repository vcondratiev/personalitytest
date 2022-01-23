using System.Collections.Generic;

namespace PersonalityTest.Domain.Dtos
{
    public class AddQuestionSetDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public ICollection<AddQuestionDto> Questions { get; set; }
    }
}
