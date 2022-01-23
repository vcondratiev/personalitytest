using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PersonalityTest.Domain.Contracts;
using PersonalityTest.Infrastructure.Data;
using PersonalityTest.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("Cors",
        builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials());
});

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PersonalityDbContext>(opt => opt.UseInMemoryDatabase("PersonalityDb"));

builder.Services.AddScoped<IQuestionSetsService, QuestionSetsService>();
builder.Services.AddScoped<ITestResultsService, TestResultsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("Cors");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
    {
        var logger = scope.ServiceProvider.GetService<ILogger<PersonalityDbContextSeed>>();
        using (var context = scope.ServiceProvider.GetService<PersonalityDbContext>())
        {
            await new PersonalityDbContextSeed().SeedAsync(context, logger);
        }
    }

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
