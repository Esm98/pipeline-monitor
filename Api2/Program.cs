// Program.cs
using Api2.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register Entity Framework Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add controller support
builder.Services.AddControllers();

// Add Swagger for testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---------- ADD THIS BLOCK (before Build) ----------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});
// ---------------------------------------------------

var app = builder.Build();

// Enable Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ---------- ADD THIS LINE (after HTTPS, before Authorization) ----------
app.UseCors("AllowAll");
// ----------------------------------------------------------------------

app.UseAuthorization();

// Routes
app.MapGet("/", () => "Hello, World");
app.MapControllers();

app.Run();
