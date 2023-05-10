using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSETI.DTOs;
using PruebaTecnicaSETI.Models;
using PruebaTecnicaSETI.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnicaSETI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IGenerarXml generarXml;

        public JsonController(IMapper mapper, IGenerarXml generarXml)
        {
            this.mapper = mapper;
            this.generarXml = generarXml;
        }

        // POST api/<JsonController>
        [HttpPost("PuntoA")]
        public ResponseJsonDTo PuntoA(PetiticionPedidos pedidos)
        {
            try
            {
                const string mensaje = "Entregado exitosamente al cliente";
                var respuesta = new ResponseJsonDTo();
                respuesta.enviarPedidoRespuesta = new Models.ResponseJson();
                respuesta.enviarPedidoRespuesta.codigoEnvio = pedidos.enviarPedido.numPedido;
                respuesta.enviarPedidoRespuesta.estado = mensaje;

                return respuesta;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        // POST api/<JsonController>
        [HttpPost("PuntoB")]
        public string PuntoB(PetiticionPedidos pedidos)
        {
            try
            {
                return generarXml.GenerarXmlG(pedidos);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        // POST api/<JsonController>
        [HttpPost("PuntoC")]
        public ResponseJson PuntoC(PetiticionPedidos pedidos)
        {
            try
            {
                string xml = generarXml.GenerarRespuestaXml(pedidos);
                return generarXml.ObtenerDatosXml(xml);

            }
            catch (Exception e)
            {

                throw;
            }
        }


    }

}
