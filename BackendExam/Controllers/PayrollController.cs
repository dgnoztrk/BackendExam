using BackendExam.Application.Queries.PayrollHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackendExam.Controllers
{
    public class PayrollController : Controller
    {
        private readonly IMediator _mediator;

        public PayrollController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetPayrollCommand(null));

            return View(result);
        }

        public async Task<IActionResult> Open(int id)
        {
            var result = await _mediator.Send(new GetPayrollCommand(id));

            return View(result);
        }
    }
}
