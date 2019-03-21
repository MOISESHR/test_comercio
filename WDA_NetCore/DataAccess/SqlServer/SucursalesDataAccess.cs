using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WBE_NetCore.Models;

namespace WDA_NetCore.DataAccess
{
    public class SucursalesDataAccess
    {
        public int Registrar(Sucursales oBe)
        {
            int res = 0;
            SqlConnection oConexion = new SqlConnection(ConexionData.DB_Comercio());
            SqlCommand cmd = new SqlCommand("PA_Sucursales_INSERTAR", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = oBe.ID;
            cmd.Parameters.Add("@banco_id", SqlDbType.Int).Value = oBe.banco_id;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = oBe.nombre;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = oBe.direccion;
            cmd.Parameters.Add("@fecha_registro", SqlDbType.Date).Value = oBe.fecha_registro;
            try
            {
                oConexion.Open();
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (oConexion.State == ConnectionState.Open) oConexion.Close();
                cmd.Dispose();
                oConexion.Dispose();
            }
            return res;
        }

        public int Actualizar(Sucursales oBe)
        {
            int res = 0;
            SqlConnection oConexion = new SqlConnection(ConexionData.DB_Comercio());
            SqlCommand cmd = new SqlCommand("PA_Sucursales_ACTUALIZAR", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = oBe.ID;
            cmd.Parameters.Add("@banco_id", SqlDbType.Int).Value = oBe.banco_id;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = oBe.nombre;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = oBe.direccion;
            cmd.Parameters.Add("@fecha_registro", SqlDbType.Date).Value = oBe.fecha_registro;
            try
            {
                oConexion.Open();
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (oConexion.State == ConnectionState.Open) oConexion.Close();
                cmd.Dispose();
                oConexion.Dispose();
            }
            return res;
        }

        public int Eliminar(Int32 ID)
        {
            int res = 0;
            SqlConnection oConexion = new SqlConnection(ConexionData.DB_Comercio());
            SqlCommand cmd = new SqlCommand("PA_Sucursales_ELIMINAR", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            try
            {
                oConexion.Open();
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (oConexion.State == ConnectionState.Open) oConexion.Close();
                cmd.Dispose();
                oConexion.Dispose();
            }
            return res;
        }

        public Sucursales GetReg(Int32 ID)
        {
            SqlConnection oConexion = new SqlConnection(ConexionData.DB_Comercio());
            SqlCommand cmd = new SqlCommand("PA_Sucursales_GETREG", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            Sucursales entidad = null;
            try
            {
                oConexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    entidad = new Sucursales();

                    int iID = reader.GetOrdinal("ID");
                    if (!reader.IsDBNull(iID)) entidad.ID = reader.GetInt32(iID);

                    int ibanco_id = reader.GetOrdinal("banco_id");
                    if (!reader.IsDBNull(ibanco_id)) entidad.banco_id = reader.GetInt32(ibanco_id);

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

            }
            finally
            {
                if (oConexion.State == ConnectionState.Open) oConexion.Close();
                cmd.Dispose();
                oConexion.Dispose();
            }
            return entidad;
        }

        public List<Sucursales> ListarAll()
        {
            SqlConnection oConexion = new SqlConnection(ConexionData.DB_Comercio());
            SqlCommand cmd = new SqlCommand("PA_Sucursales_LISTAR_All", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Sucursales> lista = new List<Sucursales>();
            try
            {
                oConexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Sucursales entidad = new Sucursales();

                    int iID = reader.GetOrdinal("ID");
                    if (!reader.IsDBNull(iID)) entidad.ID = reader.GetInt32(iID);

                    int ibanco_id = reader.GetOrdinal("banco_id");
                    if (!reader.IsDBNull(ibanco_id)) entidad.banco_id = reader.GetInt32(ibanco_id);

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
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (oConexion.State == ConnectionState.Open) oConexion.Close();
                cmd.Dispose();
                oConexion.Dispose();
            }
            return lista;
        }

        public List<Sucursales> Listar(Sucursales oBE)
        {
            SqlConnection oConexion = new SqlConnection(ConexionData.DB_Comercio());
            SqlCommand cmd = new SqlCommand("PA_Sucursales_LISTAR", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@banco_id", SqlDbType.Int).Value = oBE.banco_id;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = oBE.nombre;
            List<Sucursales> lista = new List<Sucursales>();
            try
            {
                oConexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Sucursales entidad = new Sucursales();

                    int iID = reader.GetOrdinal("ID");
                    if (!reader.IsDBNull(iID)) entidad.ID = reader.GetInt32(iID);

                    int ibanco_id = reader.GetOrdinal("banco_id");
                    if (!reader.IsDBNull(ibanco_id)) entidad.banco_id = reader.GetInt32(ibanco_id);

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
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (oConexion.State == ConnectionState.Open) oConexion.Close();
                cmd.Dispose();
                oConexion.Dispose();
            }
            return lista;
        }
    }
}
