using Microsoft.EntityFrameworkCore;
using Entry.Data;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", corsBuilder =>
    {
        if (environment.IsDevelopment())
        {
            corsBuilder
                .WithOrigins("http://localhost:3000") // seu front local
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
        else
        {
            corsBuilder
                .WithOrigins("https://phibra.nicholasyukio.com.br") // seu domínio de produção
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    });
});

if (environment.IsDevelopment())
{
    // Development (SQLite)
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
}
else
{
    // Production (PostgreSQL)
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("FrontendPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();