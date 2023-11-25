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

namespace Gestor.DataAccess.CursoDA
{
    public class CursoDAO
    {
        
        public static List<Curso> GetCursos()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetCursos";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Curso> listaCursos = new List<Curso>();

                            while (dataReader.Read())
                            {
                                listaCursos.Add(new Curso()
                                {
                                    Id_Curso = Convert.ToInt32(dataReader["id_curso"]),
                                    Nome = dataReader["nome"].ToString(),
                                    Diretor_Curso = dataReader["diretor_curso"].ToString()
                                });
                            }

                            return listaCursos;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public static Curso GetCursoByID(int id_curso)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetCursoByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_curso", id_curso);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Curso curso = new Curso()
                            {
                                Id_Curso = Convert.ToInt32(dataReader["id_curso"]),
                                Nome = dataReader["Nome"].ToString(),
                                Diretor_Curso = dataReader["diretor_curso"].ToString()
                            };
                            return curso;

                        }
                        return null;
                    }
                }
            }
        }
        public static int RegisterCurso(Curso curso)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertCurso";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@nome", curso.Nome);
                    command.Parameters.AddWithValue("@diretor_curso", curso.Diretor_Curso);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }

        public static Curso GetCursoByNome(string nome)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetCursoByNome";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nome", nome);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Curso curso = new Curso()
                            {
                                Id_Curso = Convert.ToInt32(dataReader["id_curso"]),
                                Nome = dataReader["Nome"].ToString(),
                                Diretor_Curso = dataReader["diretor_curso"].ToString()
                            };
                            return curso;

                        }
                        return null;
                    }
                }
            }
        }

        public static Curso GetCursoByDiretorcurso(string diretor_curso)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetCursoByDiretorcurso";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@diretor_curso", diretor_curso);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Curso curso = new Curso()
                            {
                                Id_Curso = Convert.ToInt32(dataReader["id_curso"]),
                                Nome = dataReader["Nome"].ToString(),
                                Diretor_Curso = dataReader["diretor_curso"].ToString()
                            };
                            return curso;

                        }
                        return null;
                    }
                }
            }
        }
    }
}