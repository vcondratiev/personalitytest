namespace PersonalityTest.Domain.Dtos
{
    public class TakenTestDto
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TestResultDto Results { get; set; }
    }
}
