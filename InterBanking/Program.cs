using InterBanking.Core.Application;
using InterBanking.Infrastructure.Identity.Contexts;
using InterBanking.Infrastructure.Identity.Entities;
using InterBanking.Infrastructure.Persistence;
using InterBanking.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

/* NOTE: this works, but it's not recommended, since there's no custom section and I'm following ASP.NET Core standard
 * on the appsettings.json
 */
// var connectionString = builder.Configuration.GetSection("ConnectionString").GetValue<string>("DefaultConnection");

builder.Services.AddDbContext<IdentityContext>(opts => opts.UseNpgsql(connectionString));
builder.Services.AddDbContext<ApplicationContext>(opts => opts.UseNpgsql(connectionString));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();
    


// Add services to the container.

builder.Services.AddControllers();

// ---  Add Layers  --- 

builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddPersistenceInfrastructureLayer(builder.Configuration);

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
