using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalityTest.Domain.Contracts;
using PersonalityTest.Domain.Dtos;
using PersonalityTest.Infrastructure.Data;

namespace PersonalityTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly ILogger<QuestionsController> _logger;
        private readonly IQuestionSetsService _questionSetsService;

        public QuestionsController(
            ILogger<QuestionsController> logger,
            IQuestionSetsService questionSetsService)
        {
            _logger = logger;
            _questionSetsService = questionSetsService;
        }

        /// <summary>
        /// Get all question sets.
        /// </summary>
        /// <returns>List of question sets</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var questionSets = await _questionSetsService.GetAllAsync();
                return new OkObjectResult(questionSets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get question set by id.
        /// </summary>
        /// <param name="id">Question set id.</param>
        /// <returns>Question set details</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var questionSet = await _questionSetsService.GetByIdAsynC(id);
                return new OkObjectResult(questionSet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Create new question set.
        /// </summary>
        /// <param name="dto">Question set with details</param>
        /// <returns>Unique identificator</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddQuestionSetDto dto)
        {
            try
            {
                var questionSet = await _questionSetsService.AddAsync(dto);
                return new OkObjectResult(questionSet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        // TO DO
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] AddQuestionSetDto dto)
        {
            try
            {
                var questionSet = await _questionSetsService.AddAsync(dto);
                return new OkObjectResult(questionSet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete question set.
        /// </summary>
        /// <param name="id">Question set id.</param>
        /// <returns>Boolean</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                bool wasDeleted = await _questionSetsService.DeleteAsync(id);
                return new OkObjectResult(wasDeleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}