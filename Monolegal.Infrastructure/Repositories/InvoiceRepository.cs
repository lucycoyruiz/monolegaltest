using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Monolegal.Application.Interfaces;
using Monolegal.Domain.Entities;
using Monolegal.Infrastructure.Settings;


namespace Monolegal.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IMongoCollection<Invoice> _invoices;

        public InvoiceRepository(IOptions<MongoSettings> options)
        {
            var settings = options.Value;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _invoices = database.GetCollection<Invoice>("invoices");
        }

        public async Task<List<Invoice>> GetByStatusAsync(string status)
        {
            return await _invoices
                .Find(i => i.Status == status)
                .ToListAsync();
        }

        public async Task UpdateAsync(Invoice invoice)
        {
            await _invoices.ReplaceOneAsync(
                i => i.Id == invoice.Id,
                invoice
            );
        }
    }
}
