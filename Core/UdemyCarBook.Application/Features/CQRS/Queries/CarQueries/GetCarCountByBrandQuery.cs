using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;

namespace UdemyCarBook.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarCountByBrandQuery : IRequest<List<BrandCarCountQueryResult>>
    {
    }
}
