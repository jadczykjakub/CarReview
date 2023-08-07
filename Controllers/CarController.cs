using AutoMapper;
using CarReview.DTO;
using CarReview.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarController(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CarDto>))]
        public IActionResult GetCars()
        {
            var cars = _mapper.Map<List<CarDto>>(_carRepository.GetCars());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cars);
        }

        [HttpGet("{carId}")]
        [ProducesResponseType(200, Type = typeof(CarDto))]
        [ProducesResponseType(400)]
        public IActionResult GetCar(int carId)
        {
            if (!_carRepository.CarExists(carId))
                return NotFound();

            var car = _mapper.Map<CarDto>(_carRepository.GetCar(carId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(car);
        }
    }
}
