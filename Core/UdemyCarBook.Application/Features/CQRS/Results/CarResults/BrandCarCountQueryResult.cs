using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Results.CarResults
{
    public class BrandCarCountQueryResult
    {
        public string Name { get; set; }
        public int CarCount { get; set; }
    }
}