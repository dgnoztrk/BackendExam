using MediatR;
using Microsoft.AspNetCore.Mvc;
using BackendExam.ApplicationContract.Dto;
using BackendExam.Application.Commands.EmployeeHandler;
using BackendExam.Application.Queries.EmployeeHandler;

namespace BackendExam.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _mediator.Send(new GetEmployeCommand(null));
            return View(list);
        }

        public IActionResult CreateEmployee()
        {
            return View();
        }

        public IActionResult UpdateEmployee()
        {
            return View();
        }

        public IActionResult DeleteEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateUpdateEmployeeDto model)
        {
            var result = await _mediator.Send(new CreateEmployeeCommand(model));

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(int id, CreateUpdateEmployeeDto model)
        {
            var result = await _mediator.Send(new UpdateEmployeeCommand(id, model));

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand(id));

            return View(result);
        }
    }
}
