using Monolegal.Application.Interfaces;
using Monolegal.Application.Services;
using Monolegal.Infrastructure.Repositories;
using Monolegal.Infrastructure.Services;
using Monolegal.Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// 🔹 Swagger SIMPLE (sin Models)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection("MongoSettings"));

builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IEmailService, FakeEmailService>();
builder.Services.AddScoped<InvoiceReminderService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
