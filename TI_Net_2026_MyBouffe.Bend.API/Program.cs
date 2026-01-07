using Microsoft.EntityFrameworkCore;
using TI_Net_2026_MyBouffe.Bend.API.DependencyInjections;
using TI_Net_2026_MyBouffe.Bend.DAL.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyBouffeContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddOpenAI(builder.Configuration["OpenAI:ApiKey"] ?? throw new Exception("Missing config"));

builder.Services.AddCors(options => options.AddDefaultPolicy(p => p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
