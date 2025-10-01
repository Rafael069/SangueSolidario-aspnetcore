
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SangueSolidario.Application.Commands.Doadores.CreateDoador;
using SangueSolidario.Application.Validators;
using SangueSolidario.Infrastructure.Persistence;

namespace SangueSolidario.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Configurando para poder gerar Migration
            var connectionString = builder.Configuration.GetConnectionString("SangueSolidarioCs");
            builder.Services.AddDbContext<SangueSolidarioDbContext>(options => options.UseSqlServer(connectionString));


            builder.Services.AddHttpClient();


            // Add services to the container.

            builder.Services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<NewDoadorInputModelValidator>())

            .AddJsonOptions(options =>
             {
                 //options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                 options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;

             });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // Registrando o MediatR para o assembly onde estão os Commands e Handlers de Doadores.
            // Usamos CreateDoadorCommand apenas como referência para localizar o assembly.
            builder.Services.AddMediatR(typeof(CreateDoadorCommand));




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
        }
    }
}
