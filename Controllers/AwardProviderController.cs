using AutoMapper;
using CarReview.DTO;
using CarReview.Interfaces;
using CarReview.Models;
using CarReview.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardProviderController : ControllerBase
    {
        private readonly IAwardProviderRepository _awardProviderRepository;
        private readonly IMapper _mapper;

        public AwardProviderController(IAwardProviderRepository awardProviderRepository, IMapper mapper)
        {
            _awardProviderRepository = awardProviderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AwardProviderDto>))]

        public IActionResult GetAwardProviders()
        {
            var awardProviders = _mapper.Map<List<AwardProviderDto>>(_awardProviderRepository.GetAwardProviders());


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(awardProviders);
        }

        [HttpGet("{awardProviderId}")]
        [ProducesResponseType(200, Type = typeof(AwardProviderDto))]

        public IActionResult GetAwardProvider(int awardProviderId)
        {
            var awardProvider = _mapper.Map<AwardProviderDto>(_awardProviderRepository.GetAwardProvider(awardProviderId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(awardProvider);
        }

        [HttpGet("award/{awardProviderId}")]
        [ProducesResponseType(200, Type = typeof(AwardProviderDto))]

        public IActionResult GetAwardsByAwardProvider(int awardProviderId)
        {
            var awards = _mapper.Map<List<AwardDto>>(_awardProviderRepository.GetAwardByAwardProvider(awardProviderId));
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(awards);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAwardProvider([FromBody] AwardProviderDto awardProviderCreate)
        {
            if (awardProviderCreate == null)
                return BadRequest(ModelState);

            var awardProvider = _awardProviderRepository.GetAwardProviders()
                .Where(c => c.LastName.Trim().ToUpper() == awardProviderCreate.LastName.Trim().ToUpper())
                .FirstOrDefault();

            if (awardProvider != null)
            {
                ModelState.AddModelError("", "Award provider already exist");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var awardProviderMap = _mapper.Map<AwardProvider>(awardProviderCreate);

            if (!_awardProviderRepository.CreateAwardProvider(awardProviderMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Sucessfully created");

        }

        [HttpPut("{awardProviderId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory(int awardProviderId, [FromBody] AwardProviderDto updatedAwardProvider)
        {
            if (updatedAwardProvider == null)
                return BadRequest(ModelState);

            if (awardProviderId != updatedAwardProvider.AwardProviderId)
                return BadRequest(ModelState);

            if (!_awardProviderRepository.AwardProviderExist(awardProviderId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var awardProviderMap = _mapper.Map<AwardProvider>(updatedAwardProvider);

            if (!_awardProviderRepository.UpdateAwardProvider(awardProviderMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{awardProviderId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteCategory(int awardProviderId)
        {
            if (!_awardProviderRepository.AwardProviderExist(awardProviderId))
            {
                return NotFound();
            }

            var categoryToDelete = _awardProviderRepository.GetAwardProvider(awardProviderId);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_awardProviderRepository.DeleteAwardProvider(categoryToDelete))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
            }

            return NoContent();
        }
    }
}
