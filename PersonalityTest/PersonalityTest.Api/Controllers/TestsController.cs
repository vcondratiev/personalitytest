using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalityTest.Domain.Contracts;
using PersonalityTest.Domain.Dtos;

namespace PersonalityTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ILogger<QuestionsController> _logger;
        private readonly ITestResultsService _testResultsService;

        public TestsController(
            ILogger<QuestionsController> logger,
            ITestResultsService testResultsService)
        {
            _logger = logger;
            _testResultsService = testResultsService;
        }

        [HttpGet]
        public async Task <IActionResult> GetTakeTestsAsync()
        {
            try
            {
                var testResults = await _testResultsService.GetTakenTestsAsync();
                return new OkObjectResult(testResults);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> LoadAsync(string id)
        {
            try
            {
                var testResults = await _testResultsService.LoadTestAsync(id);
                return new OkObjectResult(testResults);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/result")]
        public async Task<IActionResult> GetTestResultAsync(string id)
        {
            try
            {
                var testResults = await _testResultsService.CalculateResultsAsync(id);
                return new OkObjectResult(testResults);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync([FromBody] SaveTestDto dto)
        {
            try
            {
                var identifier = await _testResultsService.SaveTestAsync(dto);
                return new OkObjectResult(new { identifier });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
