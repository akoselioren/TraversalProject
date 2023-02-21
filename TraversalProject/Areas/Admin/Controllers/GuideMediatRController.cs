using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TraversalProject.CQRS.Commands.GuideCommands;
using TraversalProject.CQRS.Handlers.DestinationHandlers;
using TraversalProject.CQRS.Queries.DestinationQueries;
using TraversalProject.CQRS.Queries.GuideQueries;

namespace TraversalProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllGuideQuery());
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> GetGuides(int id)
        {
            var values = await _mediator.Send(new GetGuideByIdQuery(id));
            return View(values);
        }
        [HttpGet]
        public IActionResult AddGuides()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGuides(CreateGuideCommand command)
        {
            await _mediator.Send(command);
            return Redirect(Url.Action("GuideMediatR", "Admin") + "/Index");
        }
    }
}
