using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WApp_NetCore_v2.Models
{
    public class BancoDA
    {
        //string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=myTestDB;Data Source=ANKIT-HP\\SQLEXPRESS";
        string connectionString = "Server=CHPROV177-027\\SQL2014EX;Database=DB_Comercio;User ID=sa;Password=moises.dev";

        //To View all Bancos details
        public IEnumerable<Banco> GetAllBancos()
        {
            try
            {
                List<Banco> lstBanco = new List<Banco>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllBancos", con);
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
                    SqlCommand cmd = new SqlCommand("spAddBanco", con);
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
                    SqlCommand cmd = new SqlCommand("spUpdateBanco", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", _Banco.ID);
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
                    SqlCommand cmd = new SqlCommand("spDeleteBanco", con);
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
