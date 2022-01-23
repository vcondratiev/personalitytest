using System;

namespace PersonalityTest.Domain.Dtos
{
    public class TestResultDto
    {
        public Guid TestId { get; set; }
        public string Identifier { get; set; }
        public object Result { get; set; } // Can be anything (string, int, class, etc)
    }
}
