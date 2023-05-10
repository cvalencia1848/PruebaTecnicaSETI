using PruebaTecnicaSETI.DTOs;
using PruebaTecnicaSETI.Models;

namespace PruebaTecnicaSETI.Service
{
    public interface IGenerarXml
    {
        string GenerarXmlG(PetiticionPedidos pedidos);
        string GenerarRespuestaXml(PetiticionPedidos pedidos);
        ResponseJson ObtenerDatosXml(string xml);

    }
}
