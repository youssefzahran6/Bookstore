// Program.cs
using System.ServiceModel;
using bookstore.Data;
using bookstore.Interface;
using bookstore.Repository;
using bookstore.SOAPService;
using Microsoft.EntityFrameworkCore;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Configure Database Connection
builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories and Services
builder.Services.AddScoped<IBookRepo, BookRepo>();
builder.Services.AddScoped<IBookstoreService, BookstoreService>();

// Configure Swagger/OpenAPI for REST API testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Ensure SOAP Endpoint is configured
app.UseRouting(); // Add UseRouting() to ensure proper routing pipeline
app.UseEndpoints(endpoints =>
{
    // Map SOAP Service endpoint
    _ = endpoints.UseSoapEndpoint<IBookstoreService>("/BookstoreService.svc",
        new SoapEncoderOptions(),
        SoapSerializer.DataContractSerializer);
});

// Configure REST API Controllers
app.MapControllers();

// Apply middleware for HTTPS redirection and authorization
app.UseHttpsRedirection();
app.UseAuthorization();

// Run the application
app.Run();
