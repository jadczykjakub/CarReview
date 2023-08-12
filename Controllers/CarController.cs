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
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IAwardRepository _awardRepository;
        private readonly IMapper _mapper;

        public CarController(ICarRepository carRepository, IOwnerRepository ownerRepository, IAwardRepository awardRepository ,IMapper mapper)
        {
            _carRepository = carRepository;
            _ownerRepository = ownerRepository;
            _awardRepository = awardRepository;
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


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateCar([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] CarDto carCreate)
        {
            if (carCreate == null)
                return BadRequest(ModelState);

            var car = _carRepository.GetCars()
                .Where(c => c.Name.Trim().ToUpper() == carCreate.Name.Trim().ToUpper())
                .FirstOrDefault();

            if (car != null)
            {
                ModelState.AddModelError("", "car already exist");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var carMap = _mapper.Map<Car>(carCreate);

            if (!_carRepository.CreateCar(ownerId, catId, carMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Sucessfully created");

        }

        [HttpPut("{carId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCar( int carId, [FromBody] CarDto updatedCar)
        {
            if (updatedCar == null)
                return BadRequest(ModelState);

            if (carId != updatedCar.CarId)
                return BadRequest(ModelState);

            if (!_carRepository.CarExists(carId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryMap = _mapper.Map<Car>(updatedCar);

            if (!_carRepository.UpdateCar(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{carId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteCategory(int carId)
        {
            if (!_carRepository.CarExists(carId))
            {
                return NotFound();
            }

            var carToDelete = _carRepository.GetCar(carId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_carRepository.DeleteCar(carToDelete))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
            }

            return NoContent();
        }
    }
}
