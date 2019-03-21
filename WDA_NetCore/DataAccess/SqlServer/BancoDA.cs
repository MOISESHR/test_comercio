using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WBE_NetCore.Models;

namespace WDA_NetCore.DataAccess
{
    public class BancoDA
    {
        //string connectionString = "Server=DESKTOP-9QOH40S\\SQL2014;Database=DB_MHR_Comercio;User ID=sa;Password=moises.dev";
        string connectionString = ConexionData.DB_Comercio();

        //To View all Bancos details
        public List<Banco> GetAllBancos()
        {
            try
            {
                List<Banco> lstBanco = new List<Banco>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("PA_Banco_LISTAR_All", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Banco _Banco = new Banco();

                        _Banco.ID = Convert.ToInt32(rdr["ID"]);
                        _Banco.nombre = rdr["nombre"].ToString();
                        _Banco.direccion = rdr["direccion"].ToString();
                        _Banco.fecha_registro = Convert.ToDateTime(rdr["fecha_registro"]);

                        lstBanco.Add(_Banco);
                    }
                    con.Close();
                }
                return lstBanco;
            }
            catch
            {
                throw;
            }
        }

        //To Add new Banco record 
        public int AddBanco(Banco _Banco)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("PA_Banco_INSERTAR", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombre", _Banco.nombre);
                    cmd.Parameters.AddWithValue("@direccion", _Banco.direccion);
                    cmd.Parameters.AddWithValue("@fecha_registro", _Banco.fecha_registro);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar Banco
        public int UpdateBanco(Banco _Banco)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("PA_Banco_ACTUALIZAR", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", _Banco.ID);
                    cmd.Parameters.AddWithValue("@nombre", _Banco.nombre);
                    cmd.Parameters.AddWithValue("@direccion", _Banco.direccion);
                    cmd.Parameters.AddWithValue("@fecha_registro", _Banco.fecha_registro);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular Banco
        public Banco GetBancoData(int id)
        {
            try
            {
                Banco _Banco = new Banco();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM tblBanco WHERE BancoID= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        _Banco.ID = Convert.ToInt32(rdr["ID"]);
                        _Banco.nombre = rdr["nombre"].ToString();
                        _Banco.direccion = rdr["direccion"].ToString();
                        _Banco.fecha_registro = Convert.ToDateTime(rdr["fecha_registro"]);
                    }
                }
                return _Banco;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record on a particular Banco
        public int DeleteBanco(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("PA_Banco_ELIMINAR", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
