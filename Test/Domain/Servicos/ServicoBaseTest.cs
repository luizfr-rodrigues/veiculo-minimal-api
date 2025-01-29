using Microsoft.EntityFrameworkCore;
using Test.Infraestrutura.Db;
using veiculos_minimal_api.Infraestrutura.Db;

namespace Test.Domain.Servicos
{
    public abstract class ServicoBaseTest
    {       
        protected readonly DbContexto _contexto;
        public ServicoBaseTest()
        {   
            _contexto = DbContextoTestFactory.CriarDbContexto();
        }
        protected void TruncarTabela(string nomeTabela)
        {
            var comandoSQLTruncarTabela = $"TRUNCATE TABLE {nomeTabela}";
            _contexto.Database.ExecuteSqlRaw(comandoSQLTruncarTabela);
        }
    }
}