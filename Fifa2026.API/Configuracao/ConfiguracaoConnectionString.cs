using Fifa2026.Infra.Contexto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Fifa2026.API.Configuracao
{
    internal static class ConfiguracaoConnectionString
    {
        public static void CarregaConexaoComBancoDeDados(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var connectionString = configuration["ConnectionStrings:GravacaoLocal"];
            var connectionStringAzure = configuration["ConnectionStrings:GravacaoAzure"];
            if (!string.IsNullOrEmpty(connectionStringAzure))
            {
                connectionStringAzure = File.ReadAllText(connectionStringAzure).Replace("\\\\", "\\");
            }
         
            try
            {
                services.AddDbContext<Fifa2026Contexto>(options => options.UseSqlServer(connectionString));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar: {ex.Message}");
            }

        }

    }
}
