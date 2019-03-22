using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WBE_NetCore.Models;
using WCom_NetCore;

namespace WApp_NetCore_v2.Services
{
    public class OrdenPagoService
    {
        public OrdenPagoRespuesta ListarAll()
        {
            DTOHeader oDTOHeader = new DTOHeader();
            OrdenPagoRespuesta objResponse = new OrdenPagoRespuesta();

            List<OrdenPago> objLista = new List<OrdenPago>();
            String url = "http://localhost:35846/api/OrdenPago/ListarAll";

            WebClient webClient = new WebClient();
            webClient.UseDefaultCredentials = true;
            webClient.Credentials = new NetworkCredential("", "");

            webClient.Headers.Add("Content-Type", "application/json");
            webClient.Encoding = System.Text.Encoding.UTF8;

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);

                var data = webClient.DownloadString(url);

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(data);
                var f = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);

                JObject rss = JObject.Parse(f);

                for (int i = 0; i < rss["lista"].Count(); i++)
                {
                    var _entidad = new OrdenPago
                    {
                        ID = (int)rss["lista"][i]["id"],
                        sucursal_id = (int)rss["lista"][i]["sucursal_id"],
                        monto = (decimal)rss["lista"][i]["monto"],
                        moneda = (string)rss["lista"][i]["moneda"],
                        estado = (string)rss["lista"][i]["estado"],
                        fecha_pago = (DateTime)rss["lista"][i]["fecha_pago"]
                    };
                    objLista.Add(_entidad);
                }

                oDTOHeader.CodigoOK_WS = Constantes.Exito.Ok;
            }
            catch (Exception ex)
            {
                oDTOHeader.CodigoOK_WS = Constantes.Exito.NoOK;
                oDTOHeader.DescRetorno = ex.Message;
            }
            objResponse.Lista = objLista;
            objResponse.DTOHeader = oDTOHeader;
            return objResponse;
        }

        public OrdenPagoRespuesta Listar(OrdenPago oBE)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            OrdenPagoRespuesta objResponse = new OrdenPagoRespuesta();

            List<OrdenPago> objLista = new List<OrdenPago>();
            String url = "http://localhost:35846/api/OrdenPago/Listar";

            WebClient webClient = new WebClient();
            webClient.UseDefaultCredentials = true;
            webClient.Credentials = new NetworkCredential("", "");

            webClient.Headers.Add("Content-Type", "application/json");
            webClient.Encoding = System.Text.Encoding.UTF8;

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);

                var data = webClient.DownloadString(url);

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(data);
                var f = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);

                JObject rss = JObject.Parse(f);

                for (int i = 0; i < rss["lista"].Count(); i++)
                {
                    var _entidad = new OrdenPago
                    {
                        ID = (int)rss["lista"][i]["id"],
                        sucursal_id = (int)rss["lista"][i]["sucursal_id"],
                        monto = (decimal)rss["lista"][i]["monto"],
                        moneda = (string)rss["lista"][i]["moneda"],
                        estado = (string)rss["lista"][i]["estado"],
                        fecha_pago = (DateTime)rss["lista"][i]["fecha_pago"]
                    };
                    objLista.Add(_entidad);
                }

                oDTOHeader.CodigoOK_WS = Constantes.Exito.Ok;
            }
            catch (Exception ex)
            {
                oDTOHeader.CodigoOK_WS = Constantes.Exito.NoOK;
                oDTOHeader.DescRetorno = ex.Message;
            }
            objResponse.Lista = objLista;
            objResponse.DTOHeader = oDTOHeader;
            return objResponse;
        }

        public OrdenPagoRespuesta GetReg(Int32 ID)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            OrdenPagoRespuesta objResponse = new OrdenPagoRespuesta();

            List<OrdenPago> objLista = new List<OrdenPago>();
            String url = "http://localhost:35846/api/OrdenPago/GetReg/" + ID.ToString();

            WebClient webClient = new WebClient();
            webClient.UseDefaultCredentials = true;
            webClient.Credentials = new NetworkCredential("", "");

            webClient.Headers.Add("Content-Type", "application/json");
            webClient.Encoding = System.Text.Encoding.UTF8;

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);

                var data = webClient.DownloadString(url);

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(data);
                var f = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);

                JObject rss = JObject.Parse(f);

                var objeto = rss["entidad"].Count();
                OrdenPago _entidad = new OrdenPago();
                if (objeto > 0)
                {
                    _entidad.ID = (int)rss["entidad"]["id"];
                    _entidad.sucursal_id = (int)rss["entidad"]["sucursal_id"];
                    _entidad.monto = (decimal)rss["entidad"]["monto"];
                    _entidad.moneda = (string)rss["entidad"]["moneda"];
                    _entidad.estado = (string)rss["entidad"]["estado"];
                    _entidad.fecha_pago = (DateTime)rss["entidad"]["fecha_pago"];
                }
                objResponse.Entidad = _entidad;
                oDTOHeader.CodigoOK_WS = Constantes.Exito.Ok;
            }
            catch (Exception ex)
            {
                oDTOHeader.CodigoOK_WS = Constantes.Exito.NoOK;
                oDTOHeader.DescRetorno = ex.Message;
            }
            objResponse.DTOHeader = oDTOHeader;
            return objResponse;
        }

        public static OrdenPagoRespuesta Registrar(OrdenPago oBe)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            OrdenPagoRespuesta objResponse = new OrdenPagoRespuesta();

            String url = "http://localhost:35846/api/OrdenPago/Registrar";

            WebClient webClient = new WebClient();
            webClient.UseDefaultCredentials = true;
            webClient.Credentials = new NetworkCredential("", "");

            webClient.Headers.Add("Content-Type", "application/json");
            webClient.Encoding = System.Text.Encoding.UTF8;

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);

                var data = webClient.DownloadString(url);

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(data);
                var f = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);

                JObject rss = JObject.Parse(f);

                oDTOHeader.CodigoOK_WS = Constantes.Exito.Ok;
            }
            catch (Exception ex)
            {
                oDTOHeader.CodigoOK_WS = Constantes.Exito.NoOK;
                oDTOHeader.DescRetorno = ex.Message;
            }
            objResponse.DTOHeader = oDTOHeader;
            return objResponse;
        }

        public static OrdenPagoRespuesta Actualizar(OrdenPago oBe)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            OrdenPagoRespuesta objResponse = new OrdenPagoRespuesta();

            String url = "http://localhost:35846/api/OrdenPago/Actualizar";

            WebClient webClient = new WebClient();
            webClient.UseDefaultCredentials = true;
            webClient.Credentials = new NetworkCredential("", "");

            webClient.Headers.Add("Content-Type", "application/json");
            webClient.Encoding = System.Text.Encoding.UTF8;

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);

                var data = webClient.DownloadString(url);

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(data);
                var f = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);

                JObject rss = JObject.Parse(f);

                oDTOHeader.CodigoOK_WS = Constantes.Exito.Ok;
            }
            catch (Exception ex)
            {
                oDTOHeader.CodigoOK_WS = Constantes.Exito.NoOK;
                oDTOHeader.DescRetorno = ex.Message;
            }
            objResponse.DTOHeader = oDTOHeader;
            return objResponse;
        }

        public static OrdenPagoRespuesta Eliminar(Int32 ID)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            OrdenPagoRespuesta objResponse = new OrdenPagoRespuesta();

            String url = "http://localhost:35846/api/OrdenPago/Eliminar/" + ID.ToString();

            WebClient webClient = new WebClient();
            webClient.UseDefaultCredentials = true;
            webClient.Credentials = new NetworkCredential("", "");

            webClient.Headers.Add("Content-Type", "application/json");
            webClient.Encoding = System.Text.Encoding.UTF8;

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);

                var data = webClient.DownloadString(url);

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(data);
                var f = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);

                JObject rss = JObject.Parse(f);

                oDTOHeader.CodigoOK_WS = Constantes.Exito.Ok;
            }
            catch (Exception ex)
            {
                oDTOHeader.CodigoOK_WS = Constantes.Exito.NoOK;
                oDTOHeader.DescRetorno = ex.Message;
            }
            objResponse.DTOHeader = oDTOHeader;
            return objResponse;
        }

        public static bool ValidateServerCertificate(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
