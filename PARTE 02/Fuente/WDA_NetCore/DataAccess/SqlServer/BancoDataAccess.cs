using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WBE_NetCore.Models;
using WDA_NetCore.DataAccess.Conexion;
using WCom_NetCore;

namespace WDA_NetCore.DataAccess
{
    public class BancoDataAccess
    {
        public BancoRespuesta Registrar(Banco oBe)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            BancoRespuesta objResponse = new BancoRespuesta();

            SqlConnection oConexion = new SqlConnection(ConexionSQLServer.DB_Comercio());
            SqlCommand cmd = new SqlCommand("PA_Banco_INSERTAR", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = oBe.nombre;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = oBe.direccion;
            cmd.Parameters.Add("@fecha_registro", SqlDbType.Date).Value = oBe.fecha_registro;
            try
            {
                oConexion.Open();
                oDTOHeader.CodigoOK_BD = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                oDTOHeader.DescRetorno = ex.Message;
            }
            finally
            {
                if (oConexion.State == ConnectionState.Open) oConexion.Close();
                cmd.Dispose();
                oConexion.Dispose();
            }
            objResponse.DTOHeader = oDTOHeader;
            return objResponse;
        }

        public BancoRespuesta Actualizar(Banco oBe)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            BancoRespuesta objResponse = new BancoRespuesta();
            SqlConnection oConexion = new SqlConnection(ConexionSQLServer.DB_Comercio());
            SqlCommand cmd = new SqlCommand("PA_Banco_ACTUALIZAR", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = oBe.ID;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = oBe.nombre;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = oBe.direccion;
            cmd.Parameters.Add("@fecha_registro", SqlDbType.Date).Value = oBe.fecha_registro;
            try
            {
                oConexion.Open();
                oDTOHeader.CodigoOK_BD = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                oDTOHeader.DescRetorno = ex.Message;
            }
            finally
            {
                if (oConexion.State == ConnectionState.Open) oConexion.Close();
                cmd.Dispose();
                oConexion.Dispose();
            }
            objResponse.DTOHeader = oDTOHeader;
            return objResponse;
        }

        public BancoRespuesta Eliminar(Int32 ID)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            BancoRespuesta objResponse = new BancoRespuesta();
            SqlConnection oConexion = new SqlConnection(ConexionSQLServer.DB_Comercio());
            SqlCommand cmd = new SqlCommand("PA_Banco_ELIMINAR", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            try
            {
                oConexion.Open();
                oDTOHeader.CodigoOK_BD = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                oDTOHeader.DescRetorno = ex.Message;
            }
            finally
            {
                if (oConexion.State == ConnectionState.Open) oConexion.Close();
                cmd.Dispose();
                oConexion.Dispose();
            }
            objResponse.DTOHeader = oDTOHeader;
            return objResponse;
        }

        public BancoRespuesta GetReg(Int32 ID)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            BancoRespuesta objResponse = new BancoRespuesta();
            SqlConnection oConexion = new SqlConnection(ConexionSQLServer.DB_Comercio());
            SqlCommand cmd = new SqlCommand("PA_Banco_GETREG", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            Banco entidad = null;
            try
            {
                oConexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    entidad = new Banco();

                    int iID = reader.GetOrdinal("ID");
                    if (!reader.IsDBNull(iID)) entidad.ID = reader.GetInt32(iID);

                    int inombre = reader.GetOrdinal("nombre");
                    if (!reader.IsDBNull(inombre)) entidad.nombre = reader.GetString(inombre);

                    int idireccion = reader.GetOrdinal("direccion");
                    if (!reader.IsDBNull(idireccion)) entidad.direccion = reader.GetString(idireccion);

                    int ifecha_registro = reader.GetOrdinal("fecha_registro");
                    if (!reader.IsDBNull(ifecha_registro)) entidad.fecha_registro = reader.GetDateTime(ifecha_registro);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                oDTOHeader.DescRetorno = ex.Message;
            }
            finally
            {
                if (oConexion.State == ConnectionState.Open) oConexion.Close();
                cmd.Dispose();
                oConexion.Dispose();
            }

            objResponse.Entidad = entidad;
            objResponse.DTOHeader = oDTOHeader;
            return objResponse;
        }

        public BancoRespuesta ListarAll()
        {
            DTOHeader oDTOHeader = new DTOHeader();
            BancoRespuesta objResponse = new BancoRespuesta();

            SqlConnection oConexion = new SqlConnection(ConexionSQLServer.DB_Comercio());
            SqlCommand cmd = new SqlCommand("PA_Banco_LISTAR_All", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Banco> lista = new List<Banco>();
            try
            {
                oConexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Banco entidad = new Banco();

                    int iID = reader.GetOrdinal("ID");
                    if (!reader.IsDBNull(iID)) entidad.ID = reader.GetInt32(iID);

                    int inombre = reader.GetOrdinal("nombre");
                    if (!reader.IsDBNull(inombre)) entidad.nombre = reader.GetString(inombre);

                    int idireccion = reader.GetOrdinal("direccion");
                    if (!reader.IsDBNull(idireccion)) entidad.direccion = reader.GetString(idireccion);

                    int ifecha_registro = reader.GetOrdinal("fecha_registro");
                    if (!reader.IsDBNull(ifecha_registro)) entidad.fecha_registro = reader.GetDateTime(ifecha_registro);
                    lista.Add(entidad);
                    entidad = null;
                }
                reader.Close();

                oDTOHeader.CodigoOK_BD = Constantes.Exito.Ok;
            }
            catch (Exception ex)
            {
                oDTOHeader.DescRetorno = ex.Message;
            }
            finally
            {
                if (oConexion.State == ConnectionState.Open) oConexion.Close();
                cmd.Dispose();
                oConexion.Dispose();
            }
            objResponse.Lista = lista;
            objResponse.DTOHeader = oDTOHeader;
            return objResponse;
        }

        public BancoRespuesta Listar(Banco oBE)
        {
            DTOHeader oDTOHeader = new DTOHeader();
            BancoRespuesta objResponse = new BancoRespuesta();
            SqlConnection oConexion = new SqlConnection(ConexionSQLServer.DB_Comercio());
            SqlCommand cmd = new SqlCommand("PA_Banco_LISTAR", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Banco> lista = new List<Banco>();
            try
            {
                oConexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Banco entidad = new Banco();

                    int iID = reader.GetOrdinal("ID");
                    if (!reader.IsDBNull(iID)) entidad.ID = reader.GetInt32(iID);

                    int inombre = reader.GetOrdinal("nombre");
                    if (!reader.IsDBNull(inombre)) entidad.nombre = reader.GetString(inombre);

                    int idireccion = reader.GetOrdinal("direccion");
                    if (!reader.IsDBNull(idireccion)) entidad.direccion = reader.GetString(idireccion);

                    int ifecha_registro = reader.GetOrdinal("fecha_registro");
                    if (!reader.IsDBNull(ifecha_registro)) entidad.fecha_registro = reader.GetDateTime(ifecha_registro);
                    lista.Add(entidad);
                    entidad = null;
                }
                reader.Close();
                oDTOHeader.CodigoOK_BD = Constantes.Exito.Ok;
            }
            catch (Exception ex)
            {
                oDTOHeader.DescRetorno = ex.Message;
            }
            finally
            {
                if (oConexion.State == ConnectionState.Open) oConexion.Close();
                cmd.Dispose();
                oConexion.Dispose();
            }
            objResponse.Lista = lista;
            objResponse.DTOHeader = oDTOHeader;
            return objResponse;
        }
    }
}
