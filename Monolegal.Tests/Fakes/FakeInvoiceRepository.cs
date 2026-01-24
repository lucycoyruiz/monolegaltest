using Monolegal.Application.Interfaces;
using Monolegal.Domain.Entities;
using System.Collections.Generic;
using System;


namespace Monolegal.Tests.Fakes
{
    public class FakeInvoiceRepository : IInvoiceRepository
    {
        private readonly List<Invoice> _invoices;

        public FakeInvoiceRepository(List<Invoice> invoices)
        {
            _invoices = invoices;
        }

        public List<Invoice> GetExpiredInvoices()
        {
            return _invoices;
        }
    }
}
