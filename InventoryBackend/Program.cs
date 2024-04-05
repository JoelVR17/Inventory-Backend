using InventoryBackend.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Allow CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader() 
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

//COMMENTED FOR HOSTING
//if (app.Environment.IsDevelopment())
//{
    
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("NewPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
