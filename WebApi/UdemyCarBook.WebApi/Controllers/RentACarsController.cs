using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Features.Mediator.Queries.RentACarQueries;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CarBookContext _context;

        public RentACarsController(CarBookContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRentACarListByLocation(int locationID,bool available)
        {
            GetRentACarQuery getRentACarQuery = new GetRentACarQuery()
            {
                Available = available,
                LocationID = locationID
            };
            var values = await _mediator.Send(getRentACarQuery);
            return Ok(values);
        }
        [HttpGet("Top7Locations")]
        public async Task<IActionResult> Top7Locations()
        {
            // Lokasyon ve araç verilerini çek
            var locations = _context.Locations.ToList();  // Lokasyonlar tablosu
            var rentACars = _context.RentACars
                .Where(x => x.Available) // sadece müsait araçlar
                .ToList();

            var result = locations
                .Select(loc => new {
                    LocationName = loc.Name,
                    CarCount = rentACars.Count(r => r.LocationID == loc.LocationID)
                })
                .OrderByDescending(x => x.CarCount)
                .Take(7)  // sadece top 7 lokasyon
                .ToList();

            return Ok(result);
        }
    }
}
