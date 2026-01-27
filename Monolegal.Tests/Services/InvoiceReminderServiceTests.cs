using Xunit;
using Moq;
using Monolegal.Application.Services;
using Monolegal.Application.Interfaces;
using Monolegal.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public class InvoiceReminderServiceTests
{
    [Fact]
    public async Task ProcessAsync_WhenInvoiceIsPrimerRecordatorio_ShouldSendEmailAndUpdateStatus()
    {
        // Arrange
        var invoice = new Invoice
        {
            Id = "1",
            Number = "FAC-001",
            Status = "primerrecordatorio"
        };

        var repositoryMock = new Mock<IInvoiceRepository>();
        repositoryMock
            .Setup(r => r.GetByStatusAsync("primerrecordatorio"))
            .ReturnsAsync(new List<Invoice> { invoice });

        repositoryMock
            .Setup(r => r.GetByStatusAsync("segundorecordatorio"))
            .ReturnsAsync(new List<Invoice>());

        var emailMock = new Mock<IEmailService>();

        var service = new InvoiceReminderService(
            repositoryMock.Object,
            emailMock.Object);

        // Act
        await service.ProcessAsync();

        // Assert
        emailMock.Verify(
            e => e.SendAsync(invoice, "segundorecordatorio"),
            Times.Once);

        repositoryMock.Verify(
            r => r.UpdateAsync(It.Is<Invoice>(i => i.Status == "segundorecordatorio")),
            Times.Once);
    }


}
