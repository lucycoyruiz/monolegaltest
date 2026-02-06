using Monolegal.Application.Interfaces;
using Monolegal.Domain.Entities;

namespace Monolegal.Application.Services
{
    public class InvoiceReminderService
    {
        private readonly IInvoiceRepository _repository;
        private readonly IEmailService _emailService;

        public InvoiceReminderService(
            IInvoiceRepository repository,
            IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public async Task ProcessAsync()
        {
            var primerRecordatorioInvoices =
                await _repository.GetByStatusAsync("primerrecordatorio");

            if (primerRecordatorioInvoices.Any())
            {
                foreach (var invoice in primerRecordatorioInvoices)
                {
                    await _emailService.SendAsync(invoice, "segundorecordatorio");

                    invoice.Status = "segundorecordatorio";

                    await _repository.UpdateAsync(invoice);
                }

                return;
            }

            var segundoRecordatorioInvoices =
                await _repository.GetByStatusAsync("segundorecordatorio");

            if (segundoRecordatorioInvoices.Any())
            {
                foreach (var invoice in segundoRecordatorioInvoices)
                {
                    await _emailService.SendAsync(invoice, "desactivado");

                    invoice.Status = "desactivado";

                    await _repository.UpdateAsync(invoice);
                }
            }
        }
    }
}


//using Monolegal.Application.Interfaces;
//using Monolegal.Domain.Entities;

//namespace Monolegal.Application.Services
//{
//    public class InvoiceReminderService
//    {
//        private readonly IInvoiceRepository _repository;
//        private readonly IEmailService _emailService;

//        public InvoiceReminderService(
//            IInvoiceRepository repository,
//            IEmailService emailService)
//        {
//            _repository = repository;
//            _emailService = emailService;
//        }

//        public async Task ProcessAsync()
//        {
//            await ProcessStatusAsync("primerrecordatorio", "segundorecordatorio");
//            await ProcessStatusAsync("segundorecordatorio", "desactivado");
//        }

//        private async Task ProcessStatusAsync(string current, string next)
//        {
//            var invoices = await _repository.GetByStatusAsync(current);

//            foreach (var invoice in invoices)
//            {
//                await _emailService.SendAsync(invoice, next);
//                invoice.Status = next;
//                await _repository.UpdateAsync(invoice);
//            }
//        }
//    }
//}
