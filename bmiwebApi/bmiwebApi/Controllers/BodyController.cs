using AutoMapper;
using bmiwebApi.Dtos;
using bmiwebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bmiwebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyController : ControllerBase
    {
        private readonly IBodyRepository _bodyRepository;
        private readonly IMapper _mapper;

        public BodyController(IBodyRepository bodyRepository, IMapper mapper)
        {
            _bodyRepository = bodyRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBody()
        {
            var body = await _bodyRepository.GetAllBodyAsync();
            var bodyGet = _mapper.Map<List<BodyGetDto>>(body);
            return Ok(bodyGet);
        }
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetBodyById(int id)
        {
            var body = await _bodyRepository.GetBodyByIdAsync(id);
            if (body is null)
            {
                return NotFound();
            }
            var bodyGet = _mapper.Map<BodyGetDto>(body);
            return Ok(bodyGet);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> CrateBody([FromBody] BodyCreateDto body)
        {
            var domainBody = _mapper.Map<Body>(body);
            await _bodyRepository.CreateBodyAsync(domainBody);
            var bodyGet = _mapper.Map<BodyGetDto>(domainBody);
            return CreatedAtAction(nameof(GetBodyById), new { id = domainBody.bodyId }, bodyGet);

        }
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> UpdateBody([FromBody] BodyCreateDto updateBody, int id)
        {
            var toUpdate = _mapper.Map<Body>(updateBody);
            toUpdate.bodyId = id;
            await _bodyRepository.UpdateBodyAsync(toUpdate);
            return NoContent();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteBody(int id)
        {
            var body = await _bodyRepository.DeleteBodyAsync(id);
            if (body is null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
