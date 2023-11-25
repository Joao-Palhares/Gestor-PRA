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

namespace Gestor.DataAccess.DisciplinaDAO
{
    public class DisciplinaDAO
    {
        public static List<Disciplina> GetDisciplinas()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDisciplinas";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Disciplina> listaDisciplinas = new List<Disciplina>();

                            while (dataReader.Read())
                            {
                                listaDisciplinas.Add(new Disciplina()
                                {
                                    id_disciplina = Convert.ToInt32(dataReader["id_disciplina"]),
                                    nome = dataReader["nome"].ToString(),
                                    id_curso = Convert.ToInt32(dataReader["id_curso"])
                                });
                            }

                            return listaDisciplinas;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }


        public static List<Disciplina> GetDisciplinasByProfessor(int id_professor)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDisciplinaByProfessor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_professor", id_professor);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Disciplina> listaDisciplinas = new List<Disciplina>();

                            while (dataReader.Read())
                            {
                                listaDisciplinas.Add(new Disciplina()
                                {
                                    id_disciplina = Convert.ToInt32(dataReader["id_disciplina"]),
                                    nome = dataReader["nome"].ToString(),
                                    id_curso = Convert.ToInt32(dataReader["id_curso"])
                                });
                            }

                            return listaDisciplinas;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public static List<Disciplina> GetDisciplinaByTurma(int id_turma)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDisciplinaByTurma";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_turma", id_turma);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Disciplina> listadisciplinas = new List<Disciplina>();

                            while (dataReader.Read())
                            {
                                listadisciplinas.Add(new Disciplina()
                                {
                                    id_disciplina = Convert.ToInt32(dataReader["id_disciplina"]),
                                    nome = dataReader["nome"].ToString()
                                });
                            }

                            return listadisciplinas;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }


        public static Disciplina GetDisciplinasByNome(string nome)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDisciplinaByNome";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nome", nome);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Disciplina disciplina = new Disciplina()
                            {
                                id_disciplina = Convert.ToInt32(dataReader["id_disciplina"]),
                                nome = dataReader["nome"].ToString(),
                                id_curso = Convert.ToInt32(dataReader["id_curso"])
                            };
                            return disciplina;

                        }
                        return null;
                    }


                }
            }

        }

        public static Disciplina GetDisciplinasByID(int id_disciplina)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDisciplinaByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_disciplina", id_disciplina);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Disciplina disciplina = new Disciplina()
                            {
                                id_disciplina = Convert.ToInt32(dataReader["id_disciplina"]),
                                nome = dataReader["nome"].ToString(),
                                id_curso = Convert.ToInt32(dataReader["id_curso"])
                            };
                            return disciplina;

                        }
                        return null;
                    }


                }
            }

        }
        public static Disciplina GetDisciplinasByModulo(int id_modulo)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDisciplinaByModulo";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_modulo", id_modulo);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Disciplina disciplina = new Disciplina()
                            {
                                id_disciplina = Convert.ToInt32(dataReader["id_disciplina"]),
                                nome = dataReader["nome"].ToString(),
                                id_curso = Convert.ToInt32(dataReader["id_curso"])
                            };
                            return disciplina;

                        }
                        return null;
                    }


                }
            }

        }
    }
}