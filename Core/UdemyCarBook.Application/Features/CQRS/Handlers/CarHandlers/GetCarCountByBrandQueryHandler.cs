using MediatR;
using System.Collections.Generic;
using System.Linq;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces.CarInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarHandlers
{
    public class GetCarCountByBrandQueryHandler : IRequestHandler<GetCarCountByBrandQuery, List<BrandCarCountQueryResult>>
    {
        private readonly ICarRepository _carRepository;

        public GetCarCountByBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public Task<List<BrandCarCountQueryResult>> Handle(GetCarCountByBrandQuery request, CancellationToken cancellationToken)
        {
            var query = _carRepository.GetCarsListWithBrands()
                                      .GroupBy(c => c.Brand.Name)
                                      .Select(g => new BrandCarCountQueryResult
                                      {
                                          Name = g.Key,
                                          CarCount = g.Count()
                                      })
                                      .ToList();

            return Task.FromResult(query);
        }
    }
}
