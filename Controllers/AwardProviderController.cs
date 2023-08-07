using AutoMapper;
using CarReview.DTO;
using CarReview.Interfaces;
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
    }
}
