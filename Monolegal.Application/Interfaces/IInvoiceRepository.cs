using Monolegal.Domain.Entities;

namespace Monolegal.Application.Interfaces

{
    public interface IInvoiceRepository
    {



        Task<List<Invoice>> GetByStatusAsync(string status);
        Task UpdateAsync(Invoice invoice);
    
    }
}
