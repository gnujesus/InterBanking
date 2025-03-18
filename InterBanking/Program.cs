using InterBanking.Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

/* NOTE: this works, but it's not recommended, since there's no custom section and I'm following ASP.NET Core standard
 * on the appsettings.json
 */
// var connectionString = builder.Configuration.GetSection("ConnectionString").GetValue<string>("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(opts => opts.UseNpgsql(connectionString));

// Add services to the container.

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
