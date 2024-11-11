using KalkulatorBudzetowy.Data;
using Microsoft.EntityFrameworkCore;
using KalkulatorBudzetowy.Models;

var builder = WebApplication.CreateBuilder(args);

// Dodaj DbContext do kontenera DI
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Serwowanie plików statycznych z folderu wwwroot
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

// Seed bazy danych
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate(); // Upewnij się, że migracje zostały zastosowane
    
    app.MapControllers();

    // Dodanie domyślnych kategorii
    if (!context.Kategorie.Any())
    {
        context.Kategorie.AddRange(
            new Kategoria { Nazwa = "Jedzenie" },
            new Kategoria { Nazwa = "Transport" },
            new Kategoria { Nazwa = "Rozrywka" },
            new Kategoria { Nazwa = "Rachunki" },
            new Kategoria { Nazwa = "Inne" },
            new Kategoria { Nazwa = "Wypłata" },
            new Kategoria { Nazwa = "Premia" }
            
        );
        context.SaveChanges();
    }
}

app.MapControllers();
app.MapFallbackToFile("index.html"); // Ustawienie pliku index.html jako strony startowej

app.Run();
