using System;

namespace PersonalityTest.Domain.Entities
{
    public class TestResult
    {
        public Guid Id { get; set; }
        public Guid TestId { get; set; }
        public Test Test { get; set; }
        public string Result { get; set; }
    }
}
