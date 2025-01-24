using veiculos_minimal_api.Dominio.Entidades;
using veiculos_minimal_api.Dominio.Servicos;

namespace Test.Domain.Servicos
{
    [TestClass]
    public class VeiculoServicoTest : ServicoBaseTest
    {
        private VeiculoServico _veiculoServico; 
        public VeiculoServicoTest() : base()
        {
            _veiculoServico = new VeiculoServico(_contexto);
        }
        private void TruncarTabelaVeiculos()
        {
            TruncarTabela("Veiculos");
        }      
        private Veiculo CriarNovoVeiculoParaTeste()
        {
            var veiculo = new Veiculo();
            veiculo.Nome = "Uno";
            veiculo.Marca = "Fiat";
            veiculo.Ano = 1995;

            return veiculo;            
        }

        [TestMethod]
        public void TestarApagarVeiculo()
        {
            // Arrange
            TruncarTabelaVeiculos();

            var veiculo = CriarNovoVeiculoParaTeste();
            _veiculoServico.Incluir(veiculo);

            // Act            
            _veiculoServico.Apagar(veiculo);

            // Assert
            Assert.AreEqual(0, _veiculoServico.Todos(1).Count());
        }

        [TestMethod]
        public void TestarAtualizarVeiculo()
        {
            // Arrange
            TruncarTabelaVeiculos();
   
            var veiculo = CriarNovoVeiculoParaTeste();    
            _veiculoServico.Incluir(veiculo);

            // Act
            veiculo.Nome = "Nome Alterado";
            _veiculoServico.Atualizar(veiculo);

            // Assert
            Assert.AreEqual("Nome Alterado", veiculo.Nome);
        }

        [TestMethod]
        public void TestarBuscarPorIdVeiculo()
        {
            // Arrange
            TruncarTabelaVeiculos();
        
            var veiculo = CriarNovoVeiculoParaTeste();    
            _veiculoServico.Incluir(veiculo);

            // Act
            var veiculoDoBanco = _veiculoServico.BuscaPorId(veiculo.Id);

            // Assert
            Assert.AreEqual(1, veiculoDoBanco?.Id);
        }              

        [TestMethod]
        public void TestarIncluirVeiculo()
        {
            // Arrange
            TruncarTabelaVeiculos();          
            var veiculo = CriarNovoVeiculoParaTeste();

            // Act
            _veiculoServico.Incluir(veiculo);

            // Assert
            Assert.AreEqual(1, _veiculoServico.Todos(1).Count());
        }    

        [TestMethod]
        public void TestarTodosVeiculo()
        {
            // Arrange
            TruncarTabelaVeiculos();

            for (int i = 1; i <= 5; i++)
            {
                var adm = CriarNovoVeiculoParaTeste();
                _veiculoServico.Incluir(adm);            
            }

            // Act       
            var listaVeiculos = _veiculoServico.Todos();

            // Assert
            Assert.AreEqual(5, listaVeiculos.Count);
        }            
    }
}