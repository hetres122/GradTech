using GradTech.DAL.DbAll;
using GradTech.Data;
using GradTech.Service.AdditionalOption.Interfaces;
using GradTech.Service.AdditionalOption.Services;
using GradTech.Service.ReservationService.Interfaces;
using GradTech.Service.ReservationService.Services;
using GradTech.Service.Unit.Interfaces;
using GradTech.Service.Unit.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Authenticator")));

builder.Services.AddDbContext<DalContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GradTech")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IAdditionalOptionService, AdditionalOptionService>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireRole("Admin"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

var app = builder.Build();

app.MapIdentityApi<IdentityUser>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers().RequireAuthorization();
app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");

app.Run();