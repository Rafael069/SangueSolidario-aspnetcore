
using SangueSolidario.Application.Services.Implementations;
using SangueSolidario.Application.Services.Interfaces;
using SangueSolidario.Infrastructure.Persistence;

namespace SangueSolidario.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Adiciona o SangueSolidarioDbContext como serviço no contêiner de injeção de dependência
            builder.Services.AddSingleton<SangueSolidarioDbContext>();

            builder.Services.AddScoped<IDoadorService, DoadorService>();
            builder.Services.AddScoped<IDoacaoService, DoacaoService>();
            builder.Services.AddScoped<IEnderecoService, EnderecoService>();
            builder.Services.AddScoped<IEstoqueDeSangueService, EstoqueDeSangueService>();


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
        }
    }
}
