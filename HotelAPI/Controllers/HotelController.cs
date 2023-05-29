
using HotelAPI.Models;
using HotelManagementAPI.Interfaces;
using HotelManagementAPI.Models;
using HotelManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IRepo<int, Hotel> _repo;
        private readonly HotelService _hotelservice;

        public HotelController(IRepo<int, Hotel> repo, HotelService hotelservice)
        {
            _repo = repo;
            _hotelservice = hotelservice;

        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(List<Hotel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Hotel>> FetchAllHotels()
        {
            var hotels = _repo.GetAll();
            if (hotels.Count == 0)
            {
                return NotFound("No Hotels  available");
            }
            return Ok(hotels);

        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Hotel> Get(int key)
        {
            Hotel hotels = _repo.Get(key);
            if (hotels != null)
                return Ok(hotels);
            return NotFound("No hotel available");
        }





        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(List<Hotel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult FetchAllHotelsBasedOnLocation(string location)
        {
            var hotels = _hotelservice.GetHotelsByLocation(location);
            if (hotels.Count == 0)
            {
                return NotFound("No Hotels  available");
            }
            return Ok(hotels);

        }



        [Authorize]

        [HttpGet]
        [ProducesResponseType(typeof(List<Hotel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Hotel>> FetchHotelsWithinAPriceRange(int min, int max)
        {
            var hotels = _hotelservice.GetHotelsByPrice(min, max);
            if (hotels.Count == 0)
            {
                return NotFound("No Hotels  available");
            }
            return Ok(hotels);

        }

        [Authorize]




        




        [Authorize(Roles = "admin")]

        [HttpPost]
        public ActionResult<Hotel> Post(Hotel hotel)
        {
            Hotel prod = _repo.Add(hotel);
            return Created("HotelListing", prod);
        }
        [Authorize(Roles = "admin")]

        [HttpDelete]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Hotel> Delete(int id)
        {
            var hotel = _repo.Delete(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return BadRequest("Unable to delete the hotel");
        }

        [Authorize(Roles = "admin")]

        [HttpPut]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Hotel> Update(Hotel hotel)
        {
            var updatedHotel = _repo.Update(hotel);
            if (updatedHotel == null)
            {
                BadRequest("Unable to update hotel details");
            }
            return Ok(hotel);
        }





    }

}
