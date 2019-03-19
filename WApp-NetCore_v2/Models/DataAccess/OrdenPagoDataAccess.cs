using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WApp_NetCore_v2.Models.DataAccess
{
    public class OrdenPagoDataAccess
    {
        public int Registrar(OrdenPago oBe)
        {
            int res = 0;
            SqlConnection oConexion = new SqlConnection(ConexionData.DB_Comercio());
            SqlCommand cmd = new SqlCommand("PA_OrdenPago_INSERTAR", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = oBe.ID;
            cmd.Parameters.Add("@sucursal_id", SqlDbType.Int).Value = oBe.sucursal_id;
            cmd.Parameters.Add("@monto", SqlDbType.Decimal, 18).Value = oBe.monto;
            cmd.Parameters.Add("@moneda", SqlDbType.VarChar, 10).Value = oBe.moneda;
            cmd.Parameters.Add("@estado", SqlDbType.VarChar, 20).Value = oBe.estado;
            cmd.Parameters.Add("@fecha_pago", SqlDbType.DateTime).Value = oBe.fecha_pago;
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

        public int Actualizar(OrdenPago oBe)
        {
            int res = 0;
            SqlConnection oConexion = new SqlConnection(ConexionData.DB_Comercio());
            SqlCommand cmd = new SqlCommand("PA_OrdenPago_ACTUALIZAR", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = oBe.ID;
            cmd.Parameters.Add("@sucursal_id", SqlDbType.Int).Value = oBe.sucursal_id;
            cmd.Parameters.Add("@monto", SqlDbType.Decimal, 18).Value = oBe.monto;
            cmd.Parameters.Add("@moneda", SqlDbType.VarChar, 10).Value = oBe.moneda;
            cmd.Parameters.Add("@estado", SqlDbType.VarChar, 20).Value = oBe.estado;
            cmd.Parameters.Add("@fecha_pago", SqlDbType.DateTime).Value = oBe.fecha_pago;
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
            SqlCommand cmd = new SqlCommand("PA_OrdenPago_ELIMINAR", oConexion);
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

        public OrdenPago GetReg(Int32 ID)
        {
            SqlConnection oConexion = new SqlConnection(ConexionData.DB_Comercio());
            SqlCommand cmd = new SqlCommand("PA_OrdenPago_GETREG", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            OrdenPago entidad = null;
            try
            {
                oConexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    entidad = new OrdenPago();

                    int iID = reader.GetOrdinal("ID");
                    if (!reader.IsDBNull(iID)) entidad.ID = reader.GetInt32(iID);

                    int isucursal_id = reader.GetOrdinal("sucursal_id");
                    if (!reader.IsDBNull(isucursal_id)) entidad.sucursal_id = reader.GetInt32(isucursal_id);

                    int imonto = reader.GetOrdinal("monto");
                    if (!reader.IsDBNull(imonto)) entidad.monto = reader.GetDecimal(imonto);

                    int imoneda = reader.GetOrdinal("moneda");
                    if (!reader.IsDBNull(imoneda)) entidad.moneda = reader.GetString(imoneda);

                    int iestado = reader.GetOrdinal("estado");
                    if (!reader.IsDBNull(iestado)) entidad.estado = reader.GetString(iestado);

                    int ifecha_pago = reader.GetOrdinal("fecha_pago");
                    if (!reader.IsDBNull(ifecha_pago)) entidad.fecha_pago = reader.GetDateTime(ifecha_pago);
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

        public List<OrdenPago> ListarAll()
        {
            SqlConnection oConexion = new SqlConnection(ConexionData.DB_Comercio());
            SqlCommand cmd = new SqlCommand("PA_OrdenPago_LISTAR_All", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            List<OrdenPago> lista = new List<OrdenPago>();
            try
            {
                oConexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrdenPago entidad = new OrdenPago();

                    int iID = reader.GetOrdinal("ID");
                    if (!reader.IsDBNull(iID)) entidad.ID = reader.GetInt32(iID);

                    int isucursal_id = reader.GetOrdinal("sucursal_id");
                    if (!reader.IsDBNull(isucursal_id)) entidad.sucursal_id = reader.GetInt32(isucursal_id);

                    int imonto = reader.GetOrdinal("monto");
                    if (!reader.IsDBNull(imonto)) entidad.monto = reader.GetDecimal(imonto);

                    int imoneda = reader.GetOrdinal("moneda");
                    if (!reader.IsDBNull(imoneda)) entidad.moneda = reader.GetString(imoneda);

                    int iestado = reader.GetOrdinal("estado");
                    if (!reader.IsDBNull(iestado)) entidad.estado = reader.GetString(iestado);

                    int ifecha_pago = reader.GetOrdinal("fecha_pago");
                    if (!reader.IsDBNull(ifecha_pago)) entidad.fecha_pago = reader.GetDateTime(ifecha_pago);
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

        public List<OrdenPago> Listar(OrdenPago oBE)
        {
            SqlConnection oConexion = new SqlConnection(ConexionData.DB_Comercio());
            SqlCommand cmd = new SqlCommand("PA_OrdenPago_LISTAR", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            List<OrdenPago> lista = new List<OrdenPago>();
            try
            {
                oConexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrdenPago entidad = new OrdenPago();

                    int iID = reader.GetOrdinal("ID");
                    if (!reader.IsDBNull(iID)) entidad.ID = reader.GetInt32(iID);

                    int isucursal_id = reader.GetOrdinal("sucursal_id");
                    if (!reader.IsDBNull(isucursal_id)) entidad.sucursal_id = reader.GetInt32(isucursal_id);

                    int imonto = reader.GetOrdinal("monto");
                    if (!reader.IsDBNull(imonto)) entidad.monto = reader.GetDecimal(imonto);

                    int imoneda = reader.GetOrdinal("moneda");
                    if (!reader.IsDBNull(imoneda)) entidad.moneda = reader.GetString(imoneda);

                    int iestado = reader.GetOrdinal("estado");
                    if (!reader.IsDBNull(iestado)) entidad.estado = reader.GetString(iestado);

                    int ifecha_pago = reader.GetOrdinal("fecha_pago");
                    if (!reader.IsDBNull(ifecha_pago)) entidad.fecha_pago = reader.GetDateTime(ifecha_pago);
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
