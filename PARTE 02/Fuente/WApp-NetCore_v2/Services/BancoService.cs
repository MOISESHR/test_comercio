using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WBE_NetCore.Models;
using WCom_NetCore;

namespace WApp_NetCore_v2.Services
{
    public class BancoService
    {

        public BancoRespuesta ListarAll()
        {
            DTOHeader oDTOHeader = new DTOHeader();
            BancoRespuesta objResponse = new BancoRespuesta();

            List<Banco> objLista = new List<Banco>();
            String url = "http://localhost:35846/api/Banco/ListarAll";

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
                    var _entidad = new Banco
                    {
                        ID = (int)rss["lista"][i]["id"],
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

        public BancoRespuesta Listar(Banco oBE)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            BancoRespuesta objResponse = new BancoRespuesta();

            List<Banco> objLista = new List<Banco>();
            String url = "http://localhost:35846/api/Banco/Listar";

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
                    var _entidad = new Banco
                    {
                        ID = (int)rss["lista"][i]["id"],
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

        public BancoRespuesta GetReg(Int32 ID)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            BancoRespuesta objResponse = new BancoRespuesta();

            List<Banco> objLista = new List<Banco>();
            String url = "http://localhost:35846/api/Banco/GetReg/" + ID.ToString();

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
                Banco _entidad = new Banco();
                if (objeto > 0)
                {
                    _entidad.ID = (int)rss["entidad"]["id"];
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

        public static BancoRespuesta Registrar(Banco oBe)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            BancoRespuesta objResponse = new BancoRespuesta();

            List<Banco> objLista = new List<Banco>();
            String url = "http://localhost:35846/api/Banco/Registrar";
            String param = "ID=" + oBe.ID.ToString() + "&nombre=" + oBe.nombre + "&direccion=" + oBe.direccion + "&fecha_registro=" + oBe.fecha_registro.ToString();

            WebClient webClient = new WebClient();
            webClient.UseDefaultCredentials = true;
            webClient.Credentials = new NetworkCredential("", "");

            webClient.Headers.Add("Content-Type", "application/json");
            //webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            //webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            webClient.Encoding = System.Text.Encoding.UTF8;

            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);

                //var method = "POST"; // If your endpoint expects a GET then do it.
                //var parameters = new NameValueCollection();
                //parameters.Add("ID", oBe.ID.ToString());
                //parameters.Add("nombre", oBe.nombre);
                //parameters.Add("direccion", oBe.direccion);
                //parameters.Add("fecha_registro", oBe.fecha_registro.ToString());

                var data = webClient.UploadString(url, param);
                //var data = webClient.UploadValues(url, method, parameters);
                //// Parse the returned data (if any) if needed.
                //var responseString = UnicodeEncoding.UTF8.GetString(data);

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
            objResponse.Lista = objLista;
            objResponse.DTOHeader = oDTOHeader;
            return objResponse;
        }

        public static BancoRespuesta Actualizar(Banco oBe)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            BancoRespuesta objResponse = new BancoRespuesta();

            List<Banco> objLista = new List<Banco>();
            String url = "http://localhost:35846/api/Banco/Actualizar";

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
            objResponse.Lista = objLista;
            objResponse.DTOHeader = oDTOHeader;
            return objResponse;
        }

        public static BancoRespuesta Eliminar(Int32 ID)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            BancoRespuesta objResponse = new BancoRespuesta();

            List<Banco> objLista = new List<Banco>();
            String url = "http://localhost:35846/api/Banco/Eliminar";

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
                    var _entidad = new Banco
                    {
                        ID = (int)rss["lista"][i]["id"],
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

        public static bool ValidateServerCertificate(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
