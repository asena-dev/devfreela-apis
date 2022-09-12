using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DevFreelaDbContext>(
     options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevFreelaCs"))
     //options => options.UseInMemoryDatabase("DevFreelaCs")
   );

builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));

builder.Services.AddControllers();

builder.Services.AddMediatR(typeof(CreateProjectCommand));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevFreela.API v1"));
}

//app cors
app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
