using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using veiculos_minimal_api.Infraestrutura.Db;

namespace Test.Domain.Servicos
{
    public abstract class ServicoBaseTest
    {       
        protected readonly DbContexto _contexto;
        public ServicoBaseTest()
        {   
            _contexto = CriarContextoDeTeste();;
        }
        private DbContexto CriarContextoDeTeste()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

            var builder = new ConfigurationBuilder()
                .SetBasePath(path ?? Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);
        }  
        protected void TruncarTabela(string nomeTabela)
        {
            var comandoSQLTruncarTabela = $"TRUNCATE TABLE {nomeTabela}";
            _contexto.Database.ExecuteSqlRaw(comandoSQLTruncarTabela);
        }
    }
}