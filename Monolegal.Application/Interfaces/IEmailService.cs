using Monolegal.Domain.Entities;

namespace Monolegal.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(Invoice invoice, string newStatus);
    }
}
