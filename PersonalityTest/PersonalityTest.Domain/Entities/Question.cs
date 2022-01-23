using PersonalityTest.Domain.Entities.Enum;
using System;
using System.Collections.Generic;

namespace PersonalityTest.Domain.Entities
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }

        public QuestionType QuestionType { get; set; }

        public ICollection<QuestionOption> QuestionOptions { get; set; }
        public ICollection<QuestionAnswer> Answers { get; set; }
    }
}
