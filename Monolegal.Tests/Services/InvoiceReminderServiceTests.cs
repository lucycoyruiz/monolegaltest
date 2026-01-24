using Xunit;
using Monolegal.Application.Services;
using Monolegal.Application.Interfaces;
using Monolegal.Domain.Entities;
using Monolegal.Tests.Fakes;
using System;
using Xunit;

using System.Collections.Generic;

public class InvoiceReminderServiceTests
{
    [Fact]
    public void SendReminders_WhenInvoiceIsExpired_ShouldSendEmail()
    {
        // ARRANGE
        var expiredInvoice = new Invoice
        {
            Id = Guid.NewGuid(),
            DueDate = DateTime.UtcNow.AddDays(-3),
            ClientEmail = "cliente@test.com"
        };

        var repository = new FakeInvoiceRepository(new List<Invoice>
        {
            expiredInvoice
        });

        var emailService = new FakeEmailService();

        var service = new InvoiceReminderService(repository, emailService);

        // ACT
        service.SendReminders();

        // ASSERT
        Assert.True(emailService.EmailWasSent);
    }
}
