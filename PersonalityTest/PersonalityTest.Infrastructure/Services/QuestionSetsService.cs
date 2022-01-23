using Microsoft.EntityFrameworkCore;
using PersonalityTest.Domain.Contracts;
using PersonalityTest.Domain.Dtos;
using PersonalityTest.Domain.Entities;
using PersonalityTest.Domain.Entities.Enum;
using PersonalityTest.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalityTest.Infrastructure.Services
{
    public class QuestionSetsService : IQuestionSetsService
    {
        private readonly PersonalityDbContext _context;

        public QuestionSetsService(PersonalityDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(AddQuestionSetDto dto)
        {
            var questionSet = new QuestionSet
            {
                Description = dto.Description,
                Name = dto.Title,
                Order = dto.Order,
                Questions = dto.Questions.Select(q => new Question
                {
                    Order = q.Order,
                    Title = q.Title,
                    QuestionType = QuestionType.Survey,
                    QuestionOptions = q.QuestionOptions.Select(p => new QuestionOption
                    {
                        Text = p.Text,
                        Value = p.Value
                    }).ToList()
                }).ToList()
            };

            _context.QuestionSets.Add(questionSet);
            var result = await _context.SaveChangesAsync();

            return questionSet.Id;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var question = new QuestionSet { Id = id };
            _context.QuestionSets.Remove(question);
            var result = await _context.SaveChangesAsync();

            return result < 0;
        }

        public async Task<IEnumerable<QuestionSet>> GetAllAsync()
        {
            return await _context.QuestionSets.AsNoTracking().ToListAsync();
        }

        public async Task<QuestionSet> GetByIdAsynC(Guid id)
        {
            return await _context.QuestionSets
                .AsNoTracking()
                .Include(q => q.Questions)
                .ThenInclude(q => q.QuestionOptions)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<bool> UpdateAsync(QuestionSet questionSet)
        {
            var existing = await _context.QuestionSets.FirstOrDefaultAsync(q => q.Id == questionSet.Id);
            if (existing == null)
            {
                return false;
            }

            existing = questionSet;
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
