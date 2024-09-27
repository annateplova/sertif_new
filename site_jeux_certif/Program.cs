
using site_jeux_certif.Repository;
using Microsoft.AspNetCore.Connections;
using site_jeux_certif.Business;


namespace site_jeux_certif
{   public class Program

    {public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            // Configuration des services pour les couches

            builder.Services.AddSingleton<interfaceConnexion>(sp =>
                new GenerateurConnection(builder.Configuration.GetConnectionString("DefaultConnection")); 
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
