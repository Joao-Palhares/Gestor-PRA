using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.Security;
using System.Data;
using Gestor.DataAccess.CryptoHelpers;
using Gestor.Models;

namespace Gestor.DataAccess.DTDA
{
    public class DTDAO
    {
        public static List<DT> GetDTByProfessor(int id_professor)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDTByProfessor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_professor", id_professor);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<DT> listadt = new List<DT>();

                            while (dataReader.Read())
                            {
                                listadt.Add(new DT()
                                {
                                    id_dt = Convert.ToInt32(dataReader["id_dt"]),
                                    id_professor = Convert.ToInt32(dataReader["id_professor"]),
                                    nome = dataReader["nome_dt"].ToString()
                                });
                            }

                            return listadt;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public static DT GetDTByProfessor1(int id_professor)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDTByProfessor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_professor", id_professor);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DT dt = new DT()
                            {
                                id_dt = Convert.ToInt32(dataReader["id_dt"]),
                                id_professor = Convert.ToInt32(dataReader["id_professor"]),
                                nome = dataReader["nome_dt"].ToString()
                            };
                            return dt;

                        }
                        return null;
                    }
                }
            }
        }

        public static int DeleteDTByIDProf(int id_professor)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_DeleteDTByIDProf";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_professor", id_professor);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
        public static int RegisterDT(DT dt)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertDT";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@nome", dt.nome);
                    command.Parameters.AddWithValue("@id_professor", dt.id_professor);

                    connection.Open();
                    int returnCode1 = (int)command.ExecuteScalar();

                    return returnCode1;
                }
            }
        }
    }
}