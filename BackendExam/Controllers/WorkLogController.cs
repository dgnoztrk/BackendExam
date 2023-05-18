using MediatR;
using Microsoft.AspNetCore.Mvc;
using BackendExam.ApplicationContract.Dto;
using BackendExam.Application.Commands.WorkLogHandler;
using BackendExam.Application.Queries.WorkLogHandler;
using System.Runtime.InteropServices;
using BackendExam.Application.Queries.EmployeeHandler;

namespace BackendExam.Controllers
{
    public class WorkLogController : Controller
    {
        private readonly IMediator _mediator;

        public WorkLogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetWorkLogCommand(null));

            return View(result);
        }

        public async Task<IActionResult> CreateWorkLog()
        {
            ViewBag.Employees = (await _mediator.Send(new GetEmployeCommand(null))).Data;

            return View();
        }

        public IActionResult UpdateWorkLog()
        {
            return View();
        }

        public IActionResult DeleteWorkLog()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkLog(CreateUpdateWorkLogDto model)
        {
            var result = await _mediator.Send(new CreateWorkLogCommand(model));

            ViewBag.Employees = (await _mediator.Send(new GetEmployeCommand(null))).Data;

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWorkLog(int id, CreateUpdateWorkLogDto model)
        {
            var result = await _mediator.Send(new UpdateWorkLogCommand(id, model));

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteWorkLog(int id)
        {
            var result = await _mediator.Send(new DeleteWorkLogCommand(id));

            return View(result);
        }
    }
}
