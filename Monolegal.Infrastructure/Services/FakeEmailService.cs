using Monolegal.Application.Interfaces;
using Monolegal.Domain.Entities;

namespace Monolegal.Infrastructure.Services
{
    public class FakeEmailService : IEmailService
    {
        public Task SendAsync(Invoice invoice, string newStatus)
        {
            Console.WriteLine(
                $"Email enviado factura {invoice.Number} → nuevo estado: {newStatus}"
            );

            return Task.CompletedTask;
        }
    }
}
