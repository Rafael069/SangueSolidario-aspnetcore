
using Microsoft.EntityFrameworkCore;
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
            //builder.Services.AddSingleton<SangueSolidarioDbContext>();

            //Configurando para poder gerar Migration
            var connectionString = builder.Configuration.GetConnectionString("SangueSolidarioCs");
            builder.Services.AddDbContext<SangueSolidarioDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IDoadorService, DoadorService>();
            builder.Services.AddScoped<IDoacaoService, DoacaoService>();
            builder.Services.AddScoped<IEnderecoService, EnderecoService>();
            builder.Services.AddScoped<IEstoqueDeSangueService, EstoqueDeSangueService>();


            // Configura o HttpClient para o EnderecoService, que implementa IViaCepService
            builder.Services.AddHttpClient<IEnderecoService, EnderecoService>(client =>
            {
                client.BaseAddress = new Uri("https://viacep.com.br/ws/"); // Base URL para a API ViaCep
                client.Timeout = TimeSpan.FromSeconds(30);  // Tempo máximo de espera para a resposta
            });


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
