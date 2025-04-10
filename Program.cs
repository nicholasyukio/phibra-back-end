using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Entry.Data;

var builder = WebApplication.CreateBuilder(args);

// Pega a variável de ambiente "PORT" ou usa a porta 5000 como padrão
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";

// Configura o Kestrel para escutar na porta especificada
builder.WebHost.UseKestrel(options =>
{
    // Usamos UseUrls para garantir que o Kestrel não tentará usar uma porta já em uso
    var url = $"http://0.0.0.0:{port}";
    builder.WebHost.UseUrls(url);  // Faz a aplicação escutar na porta fornecida pela variável de ambiente
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", corsBuilder =>
    {
        corsBuilder
            .WithOrigins(
                "http://localhost:3000",
                "https://phibra.nicholasyukio.com.br"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
               .ConfigureWarnings(warnings =>
                    warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate(); // Aplica as migrations e cria o schema
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao aplicar migrations: {ex.Message}");
    }
}

app.UseCors("FrontendPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection(); // Somente no desenvolvimento
}

app.UseAuthorization();
app.MapControllers();

Console.WriteLine("Server running!");
app.Run();
