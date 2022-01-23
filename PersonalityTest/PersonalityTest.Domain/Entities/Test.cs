using System;
using System.Collections.Generic;

namespace PersonalityTest.Domain.Entities
{
    public class Test
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public string Identificator { get; set; }
        public Guid QuestionSetId { get; set; }
        public QuestionSet QuestionSet { get; set; }

        public ICollection<QuestionAnswer> Answers { get; set; }
        public ICollection<TestResult> TestResults { get; set; }
    }
}
