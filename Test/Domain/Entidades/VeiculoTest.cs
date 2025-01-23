using veiculos_minimal_api.Dominio.Entidades;

namespace Test.Domain.Entidades
{
    [TestClass]
    public class VeiculoTest
    {
        [TestMethod]
        public void TestarGetSetPropriedades()
        {
            // Arrange
            var veiculo = new Veiculo();

            // Act
            veiculo.Id = 1;
            veiculo.Nome = "T-Cross";
            veiculo.Marca = "Volkswagen";
            veiculo.Ano = 2024;

            // Assert
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("T-Cross", veiculo.Nome);
            Assert.AreEqual("Volkswagen", veiculo.Marca);
            Assert.AreEqual(2024, veiculo.Ano);
        }
    }
}