using Microsoft.EntityFrameworkCore;
using SimpleBank.Infra;
using SimpleBank.Application;
using SimpleBank.Infra.Context;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// my injections 
builder.Services.AddApplication();
builder.Services.AddInfraStructure();

var connectionString =
    builder.Configuration.GetConnectionString("SQLITE")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");

builder.Services.AddDbContext<SimpleBankDbContext>(options =>
    options.UseSqlite(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
