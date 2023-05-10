using PruebaTecnicaSETI.DTOs;
using PruebaTecnicaSETI.Models;
using System.Xml;

namespace PruebaTecnicaSETI.Service
{
    public class GenerarXml : IGenerarXml
    {
        public string GenerarXmlG(PetiticionPedidos pedidos)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement envelope = xmlDoc.CreateElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
            xmlDoc.AppendChild(envelope);
            XmlElement header = xmlDoc.CreateElement("soapenv", "Header", "http://schemas.xmlsoap.org/soap/envelope/");
            envelope.AppendChild(header);
            XmlElement body = xmlDoc.CreateElement("soapenv", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            envelope.AppendChild(body);
            XmlElement env = xmlDoc.CreateElement("env", "EnvioPedidoAcme", "http://WSDLs/EnvioPedidos/EnvioPedidosAcme");
            body.AppendChild(env);
            XmlElement envReq = xmlDoc.CreateElement("EnvioPedidoRequest");
            env.AppendChild(envReq);
            XmlElement pedido = xmlDoc.CreateElement("pedido");
            pedido.InnerText = pedidos.enviarPedido.numPedido;
            envReq.AppendChild(pedido);
            XmlElement cantidad = xmlDoc.CreateElement("Cantidad");
            cantidad.InnerText = pedidos.enviarPedido.cantidadPedido;
            envReq.AppendChild(cantidad);
            XmlElement ean = xmlDoc.CreateElement("EAN");
            ean.InnerText = pedidos.enviarPedido.codigoEAN;
            envReq.AppendChild(ean);
            XmlElement producto = xmlDoc.CreateElement("Producto");
            producto.InnerText = pedidos.enviarPedido.nombreProducto;
            envReq.AppendChild(producto);
            XmlElement cedula = xmlDoc.CreateElement("Cedula");
            cedula.InnerText = pedidos.enviarPedido.numDocumento;
            envReq.AppendChild(cedula);
            XmlElement direccion = xmlDoc.CreateElement("Direccion");
            direccion.InnerText = pedidos.enviarPedido.direccion;
            envReq.AppendChild(direccion);

            string xmlString = xmlDoc.OuterXml;

            return xmlString;
        }

        public string GenerarRespuestaXml(PetiticionPedidos pedidos)
        {
            const string mensajeExitoso = "\"Entregado exitosamente al cliente\"";
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement envelope = xmlDoc.CreateElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
            xmlDoc.AppendChild(envelope);
            XmlElement header = xmlDoc.CreateElement("soapenv", "Header", "http://schemas.xmlsoap.org/soap/envelope/");
            envelope.AppendChild(header);
            XmlElement body = xmlDoc.CreateElement("soapenv", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            envelope.AppendChild(body);
            XmlElement envRes = xmlDoc.CreateElement("env", "EnvioPedidoAcmeResponse", "http://WSDLs/EnvioPedidos/EnvioPedidosAcme");
            body.AppendChild(envRes);
            XmlElement envReq = xmlDoc.CreateElement("EnvioPedidoResponse");
            envRes.AppendChild(envReq);
            XmlElement codigo = xmlDoc.CreateElement("Codigo");
            codigo.InnerText = pedidos.enviarPedido.numPedido;
            envReq.AppendChild(codigo);
            XmlElement mensaje = xmlDoc.CreateElement("Mensaje");
            mensaje.InnerText = mensajeExitoso;
            envReq.AppendChild(mensaje);

            return xmlDoc.OuterXml;
        }

        public ResponseJson ObtenerDatosXml(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList nodoCodigo = doc.GetElementsByTagName("Codigo");
            XmlNodeList nodoMensaje = doc.GetElementsByTagName("Mensaje");

            var responseJson = new ResponseJson();

            ObtenerCodigo(nodoCodigo, responseJson);
            ObtenerMensaje(nodoCodigo, responseJson);

            return responseJson;
        }

        private ResponseJson ObtenerCodigo(XmlNodeList nodos, ResponseJson responseJson)
        {
            foreach (XmlNode nodo in nodos)
            {
                responseJson.codigoEnvio = nodo.InnerText;
            }
            return responseJson;
        }

        private ResponseJson ObtenerMensaje(XmlNodeList nodos, ResponseJson responseJson)
        {
            foreach (XmlNode nodo in nodos)
            {
                responseJson.estado = nodo.InnerText;
            }
            return responseJson;
        }
    }
}
