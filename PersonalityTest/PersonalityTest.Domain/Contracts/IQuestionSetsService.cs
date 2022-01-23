using PersonalityTest.Domain.Dtos;
using PersonalityTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalityTest.Domain.Contracts
{
    public interface IQuestionSetsService
    {
        Task<IEnumerable<QuestionSet>> GetAllAsync();
        Task<QuestionSet> GetByIdAsynC(Guid id);
        Task<Guid> AddAsync(AddQuestionSetDto questionSet);
        Task<bool> UpdateAsync(QuestionSet questionSet);
        Task<bool> DeleteAsync(Guid id);
    }
}
