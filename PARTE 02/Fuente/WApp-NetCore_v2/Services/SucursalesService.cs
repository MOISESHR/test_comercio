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
    public class SucursalesService
    {
        public SucursalesRespuesta ListarAll()
        {
            DTOHeader oDTOHeader = new DTOHeader();
            SucursalesRespuesta objResponse = new SucursalesRespuesta();

            List<Sucursales> objLista = new List<Sucursales>();
            String url = "http://localhost:35846/api/Sucursales/ListarAll";

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
                    var _entidad = new Sucursales
                    {
                        ID = (int)rss["lista"][i]["id"],
                        banco_id = (int)rss["lista"][i]["banco_id"],
                        nombre = (string)rss["lista"][i]["nombre"],
                        direccion = (string)rss["lista"][i]["direccion"],
                        fecha_registro = (DateTime)rss["lista"][i]["fecha_registro"]
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

        public SucursalesRespuesta Listar(Sucursales oBE)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            SucursalesRespuesta objResponse = new SucursalesRespuesta();

            List<Sucursales> objLista = new List<Sucursales>();
            String url = "http://localhost:35846/api/Sucursales/Listar";

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
                    var _entidad = new Sucursales
                    {
                        ID = (int)rss["lista"][i]["id"],
                        banco_id = (int)rss["lista"][i]["banco_id"],
                        nombre = (string)rss["lista"][i]["nombre"],
                        direccion = (string)rss["lista"][i]["direccion"],
                        fecha_registro = (DateTime)rss["lista"][i]["fecha_registro"]
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

        public SucursalesRespuesta GetReg(Int32 ID)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            SucursalesRespuesta objResponse = new SucursalesRespuesta();

            List<Sucursales> objLista = new List<Sucursales>();
            String url = "http://localhost:35846/api/Sucursales/GetReg/" + ID.ToString();

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
                Sucursales _entidad = new Sucursales();
                if (objeto > 0)
                {
                    _entidad.ID = (int)rss["entidad"]["id"];
                    _entidad.banco_id = (int)rss["entidad"]["banco_id"];
                    _entidad.nombre = (string)rss["entidad"]["nombre"];
                    _entidad.direccion = (string)rss["entidad"]["direccion"];
                    _entidad.fecha_registro = (DateTime)rss["entidad"]["fecha_registro"];
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

        public static SucursalesRespuesta Registrar(Sucursales oBe)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            SucursalesRespuesta objResponse = new SucursalesRespuesta();

            String url = "http://localhost:35846/api/Sucursales/Registrar";

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

        public static SucursalesRespuesta Actualizar(Sucursales oBe)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            SucursalesRespuesta objResponse = new SucursalesRespuesta();

            String url = "http://localhost:35846/api/Sucursales/Actualizar";

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

        public static SucursalesRespuesta Eliminar(Int32 ID)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            SucursalesRespuesta objResponse = new SucursalesRespuesta();

            String url = "http://localhost:35846/api/Sucursales/Eliminar/"+ ID.ToString();

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
