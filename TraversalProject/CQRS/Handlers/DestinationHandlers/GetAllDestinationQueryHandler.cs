using DataAccess.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TraversalProject.CQRS.Results.DestinationResults;

namespace TraversalProject.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                Id = x.DestinationID,
                CapaCity = x.Capacity,
                City= x.City,
                DayNight= x.DayNight,
                Price=x.Price
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
