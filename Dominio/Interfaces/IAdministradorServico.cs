using veiculos_minimal_api.Dominio.DTOs;
using veiculos_minimal_api.Dominio.Entidades;

namespace veiculos_minimal_api.Dominio.Interfaces
{
    public interface IAdministradorServico
    {
        Administrador? Login(LoginDTO loginDTO);
    }
}