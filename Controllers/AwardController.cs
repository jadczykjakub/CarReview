using AutoMapper;
using CarReview.DTO;
using CarReview.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardController : ControllerBase
    {
        private readonly IAwardRepository _awardRepository;
        private readonly IMapper _mapper;

        public AwardController(IAwardRepository awardRepository, IMapper mapper)
        {
            _awardRepository = awardRepository;
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



    }
}
