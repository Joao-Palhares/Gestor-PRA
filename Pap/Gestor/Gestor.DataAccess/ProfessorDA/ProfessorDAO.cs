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
using System.Data.SqlTypes;

namespace Gestor.DataAccess.ProfessorDA
{
    public class ProfessorDAO
    {
        public static int RegisterProfessor(Professor professor)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertProfessor";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@nome", professor.Nome);
                    command.Parameters.AddWithValue("@data_nascimento", professor.data_nascimento);
                    command.Parameters.AddWithValue("@dt", professor.dt);
                    command.Parameters.AddWithValue("@id_user", professor.Id_User);

                    connection.Open();
                    int returnCode1 = (int)command.ExecuteScalar();

                    return returnCode1;
                }
            }
        }
        public static int UpdateProfessor(Professor professor)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdateProfessorByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id_professor", professor.Id_Professor);
                    command.Parameters.AddWithValue("@nome", professor.Nome);
                    command.Parameters.AddWithValue("@data_nascimento", professor.data_nascimento);
                    command.Parameters.AddWithValue("@dt", professor.dt);
                    command.Parameters.AddWithValue("@id_user", professor.Id_User);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
        public static Professor GetProfessorByID(int id_professor)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetProfessorByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_professor", id_professor);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Professor professor = new Professor()
                            {
                                Id_Professor = Convert.ToInt32(dataReader["id_professor"]),
                                Nome = dataReader["nome_professor"].ToString(),
                                data_nascimento = Convert.ToDateTime(dataReader["data_nascimento"]),
                                dt = dataReader["dt"].ToString(),
                                Id_User = Convert.ToInt32(dataReader["id_user"])
                            };
                            return professor;

                        }
                        return null;
                    }
                }
            }
        }
        public static int DeleteProfessor(int id_professor)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_DeleteProfessorByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_professor", id_professor);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
        public static int DeleteProfessorByUser(int id_user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_DeleteProfessorByIDUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_user", id_user);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static List<Professor> GetProfessoresByDiretoria()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetProfessorByDiretoria";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Professor> listaProfessores = new List<Professor>();

                            while (dataReader.Read())
                            {
                                listaProfessores.Add(new Professor()
                                {
                                    Id_Professor = Convert.ToInt32(dataReader["id_professor"]),
                                    Nome = dataReader["nome_professor"].ToString(),
                                    data_nascimento = Convert.ToDateTime(dataReader["data_nascimento"]),
                                    dt = dataReader["dt"].ToString(),
                                    Id_User = Convert.ToInt32(dataReader["id_user"])
                                });
                            }

                            return listaProfessores;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public static List<Professor> GetProfessores()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetProfessores";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Professor> listaprofessores = new List<Professor>();

                            while (dataReader.Read())
                            {
                                listaprofessores.Add(new Professor()
                                {
                                    Id_Professor = Convert.ToInt32(dataReader["id_professor"]),
                                    Nome = dataReader["nome_professor"].ToString(),
                                    data_nascimento = Convert.ToDateTime(dataReader["data_nascimento"]),
                                    dt = dataReader["dt"].ToString(),
                                    Id_User = Convert.ToInt32(dataReader["id_user"])
                                });
                            }

                            return listaprofessores;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public static Professor GetProfessorByUserID(int id_user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetProfessorByUserID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_user", id_user);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Professor professor = new Professor()
                            {
                                Id_Professor = Convert.ToInt32(dataReader["id_professor"]),
                                Nome = dataReader["nome_professor"].ToString(),
                                data_nascimento = Convert.ToDateTime(dataReader["data_nascimento"]),
                                dt = dataReader["dt"].ToString(),
                                Id_User = Convert.ToInt32(dataReader["id_user"])
                            };
                            return professor;

                        }
                        return null;
                    }
                }
            }
        }

        public static List<Professor> GetProfessorByTurma(int id_turma)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetProfessorByTurma";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_turma", id_turma);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Professor> listaprofessores = new List<Professor>();

                            while (dataReader.Read())
                            {
                                listaprofessores.Add(new Professor()
                                {
                                    Id_Professor = Convert.ToInt32(dataReader["id_professor"]),
                                    Nome = dataReader["nome_professor"].ToString()
                                });
                            }

                            return listaprofessores;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public static List<Professor> GetListaProfessoresByID(int id_professor)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetProfessorByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_professor", id_professor);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Professor> listaProfessores = new List<Professor>();

                            while (dataReader.Read())
                            {
                                listaProfessores.Add(new Professor()
                                {
                                    Id_Professor = Convert.ToInt32(dataReader["id_professor"]),
                                    Nome = dataReader["nome_professor"].ToString(),
                                    data_nascimento = Convert.ToDateTime(dataReader["data_nascimento"]),
                                    dt = dataReader["dt"].ToString(),
                                    Id_User = Convert.ToInt32(dataReader["id_user"])
                                });
                            }

                            return listaProfessores;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public static List<Professor> GetListaProfessoresByDisciplina(int id_disciplina)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetProfessorByDisciplina";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_disciplina", id_disciplina);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Professor> listaProfessores = new List<Professor>();

                            while (dataReader.Read())
                            {
                                listaProfessores.Add(new Professor()
                                {
                                    Id_Professor = Convert.ToInt32(dataReader["id_professor"]),
                                    Nome = dataReader["nome_professor"].ToString(),
                                    data_nascimento = Convert.ToDateTime(dataReader["data_nascimento"]),
                                    dt = dataReader["dt"].ToString(),
                                    Id_User = Convert.ToInt32(dataReader["id_user"])
                                });
                            }

                            return listaProfessores;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public static Professor GetProfessorByDisciplinaTurma(int id_disciplina, int id_turma)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetProfessorByDisciplinaTurma";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_disciplina", id_disciplina);
                    command.Parameters.AddWithValue("@id_turma", id_turma);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Professor professor = new Professor()
                            {
                                Id_Professor = Convert.ToInt32(dataReader["id_professor"]),
                                Nome = dataReader["nome_professor"].ToString(),
                                data_nascimento = Convert.ToDateTime(dataReader["data_nascimento"]),
                                dt = dataReader["dt"].ToString(),
                                Id_User = Convert.ToInt32(dataReader["id_user"])
                            };
                            return professor;

                        }
                        return null;
                    }
                }
            }
        }
    }
}