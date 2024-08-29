using System.Reflection;
using System.Text.Json.Serialization;
using FeatureFlagsDemo.Database;
using FeatureFlagsDemo.Services;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("AppDb"));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddTransient<IInvoiceService, InvoiceService>();

var app = builder.Build();


// Seed the database.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/invoices", async (IInvoiceService invoiceService) => Results.Ok(await invoiceService.GetInvoices()))
    .WithName("CreateInvoice")
    .WithOpenApi();

app.Run();