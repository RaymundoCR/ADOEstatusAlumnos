using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ADOEstatusAlumnos
{
    internal class CRUDEstatus : ICRUD
    {
        public static string _cnnString = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
        public static List<Estatus> _listaStatusAl = new List<Estatus>();
        public static String _query;
        public static SqlCommand _comando;
        public List<Estatus> Consultar()
        {
            _listaStatusAl = new List<Estatus>();
            _query = $"select * from EstatusAlumnos";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                _comando = new SqlCommand(_query, con);
                _comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = _comando.ExecuteReader();
                while (reader.Read())
                {
                    _listaStatusAl.Add(
                    new Estatus()
                    {
                        id = Convert.ToInt32(reader["id"]),
                        Clave = reader["Clave"].ToString(),
                        Nombre = reader["Nombre"].ToString()
                    }
                );
                }
                con.Close();
            }
            return _listaStatusAl;
        }
        static Estatus _objEstatus = new Estatus();
        public Estatus Consultar(int id)
        {
            try
            {
                _listaStatusAl = new List<Estatus>();
                _query = $"select * from EstatusAlumnos where id = {id}";
                using (SqlConnection con = new SqlConnection(_cnnString))
                {
                    _comando = new SqlCommand(_query, con);
                    _comando.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader reader = _comando.ExecuteReader();
                    while (reader.Read())
                    {
                        _objEstatus = new Estatus()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            Clave = reader["Clave"].ToString(),
                            Nombre = reader["Nombre"].ToString()
                        };
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return _objEstatus;

        }

        public int Agregar(Estatus status)
        {
            int idEstatus = 0;
            try
            {
                _query = ($"agregarEstatusAlumno");
                using (SqlConnection con = new SqlConnection(_cnnString))
                {
                    _comando = new SqlCommand(_query, con);
                    _comando.CommandType = CommandType.StoredProcedure;
                    _comando.Parameters.AddWithValue("@Clave", status.Clave);
                    _comando.Parameters.AddWithValue("@Nombre", status.Nombre);
                    con.Open();
                    idEstatus = (Int32)_comando.ExecuteScalar();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return idEstatus;
        }

        public void Actualizar(Estatus status)
        {
            _query = $"update EstatusAlumnos set Clave = '{status.Clave}', Nombre = '{status.Nombre}' where id = {status.id}";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                _comando = new SqlCommand(_query, con);
                _comando.CommandType = CommandType.Text;
                con.Open();
                _comando.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Eliminar(Estatus status)
        {
            _query = $"delete EstatusAlumnos where id = {status.id}";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                _comando = new SqlCommand(_query, con);
                _comando.CommandType = CommandType.Text;
                con.Open();
                _comando.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
