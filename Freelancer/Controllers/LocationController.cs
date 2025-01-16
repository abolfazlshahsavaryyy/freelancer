using Freelancer.Models;
using Freelancer.Repository.Interface;
using Freelancer.StaticData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Freelancer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepo _locationRepo;
        
        
        public LocationController(ILocationRepo locationRepo)
        {
            _locationRepo = locationRepo;
        }
        
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var locations= await _locationRepo.GetAll();
            return Ok(locations);
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromQuery]string location)
        {
            var locations=(await _locationRepo.GetAll()).Select(x=>x.LocationName.ToLower());
            if(locations.Contains(location.ToLower()))
            {
                return Ok($"location is exists: {location}");
            }
            var result = await _locationRepo.Create(new Location
            {
                LocationName = location.ToLower(),

            });
            if (result.IsSucess == true)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
            
        }
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromQuery]string currentLocation, [FromQuery]string newLocation)
        {
            var locations=await _locationRepo.GetAll();
            var locationsString=locations.Select(s=>s.LocationName.ToLower());
            if (locationsString.Contains(currentLocation.ToLower()))
            {
                Location findLocation=locations.Where(l=>l.LocationName.ToLower()==currentLocation.ToLower()).FirstOrDefault();
                var result=await _locationRepo.Update(findLocation,newLocation);
                return Ok(result.Message);
                
            }
            else
            {
                return NotFound("Location not find");
            }
        }
        [HttpGet]
        [Route("GetByLocation")]
        public async Task<IActionResult> GetByName([FromQuery]string locationName)
        {
            var location=await _locationRepo.GetByName(locationName);
            if(location == null)
            {
                return NotFound("can't find the location");
            }
            return Ok(location);
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromQuery]string locationName)
        {
            if (String.IsNullOrEmpty(locationName))
            {
                return BadRequest("string can't be empty or null");
            }
            var location=await _locationRepo.GetByName(locationName);
            if(location == null)
            {
                return NotFound("location not found");
            }
            var result=await _locationRepo.Delete(location);
            if(result.IsSucess==true)
            {
                return Ok("location deleted : " + locationName);
            }
            else
            {
                return StatusCode(500, "database error");
            }
        }
    }
}
