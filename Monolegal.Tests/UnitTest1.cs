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
    public async Task ProcessAsync_Should_Run_Without_Errors()
    {
        // 1️⃣ Simular repositorio
        var repositoryMock = new Mock<IInvoiceRepository>();
        repositoryMock
            .Setup(r => r.GetByStatusAsync(It.IsAny<string>()))
            .ReturnsAsync(new List<Invoice>());

        // 2️⃣ Simular servicio de email
        var emailMock = new Mock<IEmailService>();

        // 3️⃣ Crear el servicio real
        var service = new InvoiceReminderService(
            repositoryMock.Object,
            emailMock.Object);

        // 4️⃣ Ejecutar el método
        await service.ProcessAsync();

        // 5️⃣ Si llega aquí sin error, el test PASA
        Assert.True(true);
    }
}
