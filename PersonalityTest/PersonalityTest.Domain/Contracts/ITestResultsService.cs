using PersonalityTest.Domain.Dtos;
using PersonalityTest.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalityTest.Domain.Contracts
{
    public interface ITestResultsService
    {
        Task<string> SaveTestAsync(SaveTestDto test);
        Task<Test> LoadTestAsync(string identificator);
        Task<TakenTestDto> CalculateResultsAsync(string id);
        Task<IEnumerable<TakenTestDto>> GetTakenTestsAsync();
    }
}
