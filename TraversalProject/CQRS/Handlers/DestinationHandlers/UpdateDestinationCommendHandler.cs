using DataAccess.Concrete;
using TraversalProject.CQRS.Commands.DestinationCommands;

namespace TraversalProject.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommendHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommendHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.DestinationID);
            values.City = command.City;
            values.DayNight= command.DayNight;
            values.Price = command.Price;
            _context.SaveChanges();
        }
    }
}
