using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.BrandQueries;
using UdemyCarBook.Persistence.Context;
using UdemyCarBook.Dto.DashboardDtos;


namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly CarBookContext _context;

        public BrandsController(
            CarBookContext context,
            CreateBrandCommandHandler createBrandCommandHandler,
            GetBrandByIdQueryHandler getBrandByIdQueryHandler,
            GetBrandQueryHandler getBrandQueryHandler,
            UpdateBrandCommandHandler updateBrandCommandHandler,
            RemoveBrandCommandHandler removeBrandCommandHandler)
        {
            _context = context;
            _createBrandCommandHandler = createBrandCommandHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _getBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var value = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _createBrandCommandHandler.Handle(command);
            return Ok("Marka Bilgisi Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("Marka Bilgisi Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handle(command);
            return Ok("Marka Bilgisi Güncellendi");
        }
        [HttpGet("BrandCarCounts")]
        public async Task<IActionResult> BrandCarCounts()
        {
            // _context'i veya repository'i kullanabilirsin
            var query = from c in _context.Cars
                        join b in _context.Brands on c.BrandID equals b.BrandID
                        group c by b.Name into g
                        select new BrandCarCountDto
                        {
                            Name = g.Key,
                            CarCount = g.Count()
                        };

            var list = query.ToList();
            return Ok(list);
        }
        [HttpGet("Top7BrandCarCounts")]
        public IActionResult Top7BrandCarCounts()
        {
            var query = _context.Cars
                .Join(_context.Brands,
                      c => c.BrandID,
                      b => b.BrandID,
                      (c, b) => new { b.Name })
                .GroupBy(x => x.Name)
                .Select(g => new BrandCarCountDto
                {
                    Name = g.Key,
                    CarCount = g.Count()
                })
                .OrderByDescending(x => x.CarCount)
                .Take(7) // sadece en çok 7 markayı al
                .ToList();

            return Ok(query);
        }
    }
}
