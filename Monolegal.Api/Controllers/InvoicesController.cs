using Microsoft.AspNetCore.Mvc;
using Monolegal.Application.Services;

namespace Monolegal.Api.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoiceReminderService _service;

        public InvoicesController(InvoiceReminderService service)
        {
            _service = service;
        }

        [HttpPost("process-reminders")]
        public async Task<IActionResult> ProcessReminders()
        {
            await _service.ProcessAsync();
            return Ok("Proceso de recordatorios ejecutado correctamente");
        }
    }
}
