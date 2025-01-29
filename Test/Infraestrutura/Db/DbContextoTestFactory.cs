using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using veiculos_minimal_api.Infraestrutura.Db;

namespace Test.Infraestrutura.Db
{
    public static class DbContextoTestFactory
    {
        public static DbContexto CriarDbContexto()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var stringConexaoConfig = configuration.GetConnectionString("MySql");
            if(string.IsNullOrEmpty(stringConexaoConfig))
            {
                stringConexaoConfig = "Server=__DB_HOST__;Database=__DB_NAME__;Uid=__DB_USER__;Pwd=__DB_PASSWORD__;";
            }

            var stringConexao = stringConexaoConfig
                .Replace( "__DB_HOST__", Environment.GetEnvironmentVariable("DB_HOST_VEICULO_API") ?? "localhost" )
                .Replace( "__DB_NAME__", Environment.GetEnvironmentVariable("DB_NAME_VEICULO_API_TEST") ?? "minimal_apitest" )  
                .Replace( "__DB_USER__", Environment.GetEnvironmentVariable("DB_USER_VEICULO_API") )
                .Replace( "__DB_PASSWORD__", Environment.GetEnvironmentVariable("DB_PASSWORD_VEICULO_API") );                

            var optionsBuilder = new DbContextOptionsBuilder<DbContexto>();
            optionsBuilder.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));

            return new DbContexto(optionsBuilder.Options);
        }
    }
}