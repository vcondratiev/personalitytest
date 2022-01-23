using System;
using System.Collections.Generic;

namespace PersonalityTest.Domain.Entities
{
    public class QuestionSet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
