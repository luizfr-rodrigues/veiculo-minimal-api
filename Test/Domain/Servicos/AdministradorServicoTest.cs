using veiculos_minimal_api.Dominio.DTOs;
using veiculos_minimal_api.Dominio.Entidades;
using veiculos_minimal_api.Dominio.Servicos;

namespace Test.Domain.Servicos;

[TestClass]
public class AdministradorServicoTest : ServicoBaseTest
{
    private AdministradorServico _administradorServico; 
    public AdministradorServicoTest() : base()
    {
        _administradorServico = new AdministradorServico(_contexto);
    }
    private void TruncarTabelaAdministradores()
    {
        TruncarTabela("Administradores");
    }    
    private Administrador CriarNovoAdministradorParaTeste()
    {
        var adm = new Administrador();
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        return adm;            
    }     

    [TestMethod]
    public void TestarBuscaPorIdAdministrador()
    {
        // Arrange
        TruncarTabelaAdministradores();

        var adm = CriarNovoAdministradorParaTeste();
        _administradorServico.Incluir(adm);

        // Act       
        var admDoBanco = _administradorServico.BuscaPorId(adm.Id);

        // Assert
        Assert.AreEqual(1, admDoBanco?.Id);
    }

    [TestMethod]
    public void TestarIncluirAdministrador()
    {
        // Arrange
        TruncarTabelaAdministradores();
        var adm = CriarNovoAdministradorParaTeste();

        // Act
        _administradorServico.Incluir(adm);

        // Assert
        Assert.AreEqual(1, _administradorServico.Todos(1).Count());
    }

    [TestMethod]
    public void TestarLoginSucessodministrador()
    {
        // Arrange
        TruncarTabelaAdministradores();

        var adm = CriarNovoAdministradorParaTeste();
        _administradorServico.Incluir(adm);

        // Act  
        var login = new LoginDTO()
        {
            Email = adm.Email,
            Senha = adm.Senha
        };
        var admDoBanco = _administradorServico.Login(login);

        // Assert
        Assert.AreNotEqual(null, admDoBanco);
        Assert.AreEqual(1, admDoBanco?.Id);
    }   

    [TestMethod]
    public void TestarLoginEmailNaoLocalizadoAdministrador()
    {
        // Arrange
        TruncarTabelaAdministradores();

        var adm = CriarNovoAdministradorParaTeste();
        _administradorServico.Incluir(adm);

        // Act  
        var login = new LoginDTO()
        {
            Email = "outro@teste.com",
            Senha = adm.Senha
        };
        var admDoBanco = _administradorServico.Login(login);

        // Assert
        Assert.AreEqual(null, admDoBanco);
    }  

    [TestMethod]
    public void TestarLoginSenhaNaoLocalizadaAdministrador()
    {
        // Arrange
        TruncarTabelaAdministradores();

        var adm = CriarNovoAdministradorParaTeste();
        _administradorServico.Incluir(adm);

        // Act  
        var login = new LoginDTO()
        {
            Email = adm.Email,
            Senha = "XXXXX"
        };
        var admDoBanco = _administradorServico.Login(login);

        // Assert
        Assert.AreEqual(null, admDoBanco);
    }          
}