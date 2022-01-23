using Microsoft.EntityFrameworkCore;
using PersonalityTest.Domain.Contracts;
using PersonalityTest.Domain.Dtos;
using PersonalityTest.Domain.Entities;
using PersonalityTest.Infrastructure.Data;
using PersonalityTest.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalityTest.Infrastructure.Services
{
    public class TestResultsService : ITestResultsService
    {
        private readonly PersonalityDbContext _context;

        public TestResultsService(PersonalityDbContext context)
        {
            _context = context;
        }

        public async Task<TakenTestDto> CalculateResultsAsync(string id)
        {
            var test = await LoadTestAsync(id);
            if (test == null)
            {
                return null;
            }
            return new TakenTestDto
            {
                Description = test.QuestionSet.Description,
                Name = test.QuestionSet.Name,
                Identifier = test.Identificator,
                Results = test.TestResults.Select(r => new TestResultDto
                {
                    Result = r.Result,
                    Identifier = test.Identificator,
                    TestId = r.TestId
                }).FirstOrDefault()
            };

            // Define test outcomes (results)
            // Define question weight
            // Define score calculation algorithm
            // Implement score calcualtion

            // But for this example we will hardcode some stuff :D

            // Introvert = number of questions * 1/2
            // Extrovert = number of questions * 3/4
            // This can be added to the score calculation algorithm
        }

        public async Task<IEnumerable<TakenTestDto>> GetTakenTestsAsync()
        {
            var tests = await _context.Tests
                .Include(t => t.QuestionSet)
                .Include(q => q.TestResults)
                .ToListAsync();

            return tests.Select(t => new TakenTestDto
            {
                Description = t.QuestionSet.Description,
                Name = t.QuestionSet.Name,
                Identifier = t.Identificator,
                Results = t.TestResults.Select(r => new TestResultDto
                {
                    Result = r.Result,
                    Identifier = t.Identificator,
                    TestId = r.TestId
                }).FirstOrDefault()
            }).ToList();
        }

        public async Task<Test> LoadTestAsync(string identificator)
        {
            return await _context.Tests
                .Include(t => t.QuestionSet)
                    .ThenInclude(q => q.Questions)
                .Include(q => q.Answers)
                .Include(q => q.TestResults)
                .FirstOrDefaultAsync(t => t.Identificator == identificator);
        }

        public async Task<string> SaveTestAsync(SaveTestDto dto)
        {
            // Calculate results
            var totalPoints = 0;

            foreach (var answer in dto.Answers)
            {
                totalPoints += Convert.ToInt32(answer.Value);
            }
            var testResultPoints = totalPoints / dto.Answers.Count();
            var testResult = new TestResult
            {
               Result = testResultPoints <= 2 ? "Introvert" : "Extrovert"
            };

            string identificator = TextGeneratorHelper.RandomString(6);
            var test = new Test
            {
                Identificator = identificator,
                QuestionSetId = dto.QuestionSetId,
                CreatedAt = DateTime.UtcNow,
                Answers = dto.Answers.Select(a => new QuestionAnswer
                {
                    QuestionId = a.QuestionId,
                    Value = a.Value
                }).ToList(),
                TestResults = new List<TestResult>() { testResult }
            };

            _context.Tests.Add(test);
            var result = await _context.SaveChangesAsync();
            return result > 0 ? identificator : null;
        }
    }
}
