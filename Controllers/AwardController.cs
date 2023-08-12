using AutoMapper;
using CarReview.DTO;
using CarReview.Interfaces;
using CarReview.Models;
using CarReview.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardController : ControllerBase
    {
        private readonly IAwardRepository _awardRepository;
        private readonly ICarRepository _carRepository;
        private readonly IAwardProviderRepository _awardProviderRepository;
        private readonly IMapper _mapper;

        public AwardController(
            IAwardRepository awardRepository, 
            ICarRepository carRepository, 
            IAwardProviderRepository awardProviderRepository,
            IMapper mapper
            )
        {
            _awardRepository = awardRepository;
            _carRepository = carRepository;
            _awardProviderRepository = awardProviderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AwardDto>))]

        public IActionResult GetAwards()
        {
            var awards = _mapper.Map<List<AwardDto>>(_awardRepository.GetAwards());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(awards);
        }

        [HttpGet("{awardId}")]
        [ProducesResponseType(200, Type = typeof(AwardDto))]

        public IActionResult GetAward(int awardId)
        {
            var award = _mapper.Map<AwardDto>(_awardRepository.GetAward(awardId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(award);
        }

        [HttpGet("/award-provider/{awardId}")]
        [ProducesResponseType(200, Type = typeof(AwardProviderDto))]

        public IActionResult GetAwardProviderByAward(int awardId)
        {
            var awardProvider = _mapper.Map<AwardProviderDto>(_awardRepository.GetAwardProviderByAward(awardId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(awardProvider);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateAward([FromQuery] int awardProviderId, [FromQuery] int carId, [FromBody] AwardDto awardCreate)
        {
            if (awardCreate == null)
                return BadRequest(ModelState);

            var award = _awardRepository.GetAwards()
                .Where(c => c.Title.Trim().ToUpper() == awardCreate.Title.Trim().ToUpper())
                .FirstOrDefault();

            if (award != null)
            {
                ModelState.AddModelError("", "award already exist");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var awardMap = _mapper.Map<Award>(awardCreate);

            awardMap.Car = _carRepository.GetCar(carId);
            awardMap.AwardProvider = _awardProviderRepository.GetAwardProvider(awardProviderId);

            if (!_awardRepository.CreateAward(awardMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Sucessfully created");
        }

        [HttpPut("{awardId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory(int awardId, [FromBody] AwardDto updatedAward)
        {
            if (updatedAward == null)
                return BadRequest(ModelState);

            if (awardId != updatedAward.AwardId)
                return BadRequest(ModelState);

            if (!_awardRepository.AwardExists(awardId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var awardMap = _mapper.Map<Award>(updatedAward);

            if (!_awardRepository.UpdateAward(awardMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{awardId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteCategory(int awardId)
        {
            if (!_awardRepository.AwardExists(awardId))
            {
                return NotFound();
            }

            var categoryToDelete = _awardRepository.GetAward(awardId);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_awardRepository.DeleteAward(categoryToDelete))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
            }

            return NoContent();
        }

    }
}
