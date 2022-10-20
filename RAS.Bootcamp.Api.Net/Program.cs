using Microsoft.EntityFrameworkCore;
using RAS.Bootcamp.Api.Net;
using RAS.Bootcamp.Api.Net.Datas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EMarketDbContext>(options =>{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

//builder.Services.AddSingleton<IGuidRandom, GuidRandom>();

//builder.Services.AddScoped<IGuidRandom, GuidRandom>();

builder.Services.AddTransient<IGuidRandom, GuidRandom>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
