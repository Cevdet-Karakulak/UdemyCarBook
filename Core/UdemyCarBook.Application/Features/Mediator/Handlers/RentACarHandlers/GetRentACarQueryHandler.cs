using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.RentACarQueries;
using UdemyCarBook.Application.Features.Mediator.Results.RentACarResults;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(
                x => x.LocationID == request.LocationID && x.Available == true
            );

            var results = values.Select(y => new GetRentACarQueryResult
            {
                CarId = y.CarID,
                Brand = y.Car?.Brand?.Name ?? "Bilinmiyor",
                Model = y.Car?.Model ?? "Bilinmiyor",
                CoverImageUrl = y.Car?.CoverImageUrl ?? "/carbook-master/images/defaultcar.jpg",

                // 💰 Null kontrolü eklenmiş güvenli fiyat işlemi
                Amount = (y.Car?.CarPricings != null && y.Car.CarPricings.Any())
    ? y.Car.CarPricings
        .Where(p => p.PricingID == 2) // 2 = Günlük
        .OrderByDescending(p => p.CarPricingID)
        .Select(p => p.Amount)
        .FirstOrDefault()
    : 0

            }).ToList();

            return results;
        }
    }
}
