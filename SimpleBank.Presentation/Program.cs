using Microsoft.EntityFrameworkCore;
using SimpleBank.Infra;
using SimpleBank.Application;
using SimpleBank.Infra.Context;
using SimpleBank.Presentation.Filters;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//filtrando excpetions
builder.Services.AddMvc(builder => builder.Filters.Add<ExceptionFilter>());

// my injections 
builder.Services.AddApplication();
builder.Services.AddInfraStructure(builder.Configuration);

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
