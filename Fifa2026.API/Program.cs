
using Fifa2026.API.Configuracao;
using Fifa2026.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Fifa2026.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.Development.json")
            .Build();


            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.CarregaConexaoComBancoDeDados(configuration);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Executa migração automática ao iniciar
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<Fifa2026Contexto>();
                db.Database.Migrate();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
