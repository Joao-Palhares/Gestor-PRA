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

namespace Gestor.DataAccess.AlunoDA
{
    public class AlunoDAO
    {
        public static List<Aluno> GetAlunosList()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetAlunos";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Aluno> listaAlunos = new List<Aluno>();

                            while (dataReader.Read())
                            {
                                listaAlunos.Add(new Aluno()
                                {
                                    Id_Aluno = Convert.ToInt32(dataReader["id_aluno"]),
                                    n_processo = Convert.ToInt32(dataReader["n_processo"]),
                                    nome = dataReader["nome_aluno"].ToString(),
                                    data_nascimento = Convert.ToDateTime(dataReader["data_nascimento"]),
                                    Id_Curso = Convert.ToInt32(dataReader["id_curso"]),
                                    Id_Turma = Convert.ToInt32(dataReader["id_turma"]),
                                    numero = Convert.ToInt32(dataReader["numero"]),
                                    Id_User = Convert.ToInt32(dataReader["id_user"]),
                                    pra= dataReader["pra"].ToString()
                                });
                            }

                            return listaAlunos;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public static int RegisterAluno(Aluno aluno)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertAluno";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@n_processo", aluno.n_processo);
                    command.Parameters.AddWithValue("@nome", aluno.nome);
                    command.Parameters.AddWithValue("@data_nascimento", aluno.data_nascimento);
                    command.Parameters.AddWithValue("@id_curso", aluno.Id_Curso);
                    command.Parameters.AddWithValue("@id_turma", aluno.Id_Turma);
                    command.Parameters.AddWithValue("@numero", aluno.numero);
                    command.Parameters.AddWithValue("@id_user", aluno.Id_User);
                    command.Parameters.AddWithValue("@pra", aluno.pra);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }
        public static int UpdateAluno(Aluno aluno)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdateAlunoByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_aluno", aluno.Id_Aluno);
                    command.Parameters.AddWithValue("@n_processo", aluno.n_processo);
                    command.Parameters.AddWithValue("@nome", aluno.nome);
                    command.Parameters.AddWithValue("@data_nascimento", aluno.data_nascimento);
                    command.Parameters.AddWithValue("@id_curso", aluno.Id_Curso);
                    command.Parameters.AddWithValue("@id_turma", aluno.Id_Turma);
                    command.Parameters.AddWithValue("@numero", aluno.numero);
                    command.Parameters.AddWithValue("@pra", aluno.pra);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
        public static Aluno GetAlunoByID(int id_aluno)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetAlunoByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_aluno", id_aluno);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Aluno aluno = new Aluno()
                            {
                                Id_Aluno = Convert.ToInt32(dataReader["id_aluno"]),
                                n_processo = Convert.ToInt32(dataReader["n_processo"]),
                                nome = dataReader["nome_aluno"].ToString(),
                                data_nascimento = Convert.ToDateTime(dataReader["data_nascimento"]),
                                Id_Curso = Convert.ToInt32(dataReader["id_curso"]),
                                Id_Turma = Convert.ToInt32(dataReader["id_turma"]),
                                numero = Convert.ToInt32(dataReader["numero"]),
                                Id_User = Convert.ToInt32(dataReader["id_user"]),
                                pra = dataReader["pra"].ToString()
                            };
                            return aluno;

                        }
                        return null;
                    }
                }
            }
        }

        public static Aluno GetAlunoByUserID(int id_user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetAlunoByUserID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_user", id_user);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Aluno aluno = new Aluno()
                            {
                                Id_Aluno = Convert.ToInt32(dataReader["id_aluno"]),
                                n_processo = Convert.ToInt32(dataReader["n_processo"]),
                                nome = dataReader["nome_aluno"].ToString(),
                                data_nascimento = Convert.ToDateTime(dataReader["data_nascimento"]),
                                Id_Curso = Convert.ToInt32(dataReader["id_curso"]),
                                Id_Turma = Convert.ToInt32(dataReader["id_turma"]),
                                numero = Convert.ToInt32(dataReader["numero"]),
                                Id_User = Convert.ToInt32(dataReader["id_user"]),
                                pra = dataReader["pra"].ToString()
                            };
                            return aluno;

                        }
                        return null;
                    }
                }
            }
        }

        public static int DeleteAluno(int id_aluno)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_DeleteAlunoByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_aluno", id_aluno);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static int DeleteAlunoByUser(int id_user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_DeleteAlunoByIDUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_user", id_user);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static Aluno GetAlunoByName(string nome)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetAlunoByName";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nome", nome);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Aluno aluno = new Aluno()
                            {
                                Id_Aluno = Convert.ToInt32(dataReader["id_aluno"]),
                                n_processo = Convert.ToInt32(dataReader["n_processo"]),
                                nome = dataReader["nome_aluno"].ToString(),
                                data_nascimento = Convert.ToDateTime(dataReader["data_nascimento"]),
                                Id_Curso = Convert.ToInt32(dataReader["id_curso"]),
                                Id_Turma = Convert.ToInt32(dataReader["id_turma"]),
                                numero = Convert.ToInt32(dataReader["numero"]),
                                Id_User = Convert.ToInt32(dataReader["id_user"]),
                                pra = dataReader["pra"].ToString()
                            };
                            return aluno;

                        }
                        return null;
                    }
                }
            }
        }
        public static List<Aluno> GetAlunoByTurma(int id_turma)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetAlunoByTurma";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_turma", id_turma);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Aluno> listaAlunos = new List<Aluno>();

                            while (dataReader.Read())
                            {
                                listaAlunos.Add(new Aluno()
                                {
                                    Id_Aluno = Convert.ToInt32(dataReader["id_aluno"]),
                                    n_processo = Convert.ToInt32(dataReader["n_processo"]),
                                    nome = dataReader["nome_aluno"].ToString(),
                                    data_nascimento = Convert.ToDateTime(dataReader["data_nascimento"]),
                                    Id_Curso = Convert.ToInt32(dataReader["id_curso"]),
                                    Id_Turma = Convert.ToInt32(dataReader["id_turma"]),
                                    numero = Convert.ToInt32(dataReader["numero"]),
                                    Id_User = Convert.ToInt32(dataReader["id_user"]),
                                    pra = dataReader["pra"].ToString()
                                });
                            }

                            return listaAlunos;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public static Aluno GetAlunoByNumero(int numero)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetAlunoByNumturma";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@numero", numero);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Aluno aluno = new Aluno()
                            {
                                Id_Aluno = Convert.ToInt32(dataReader["id_aluno"]),
                                n_processo = Convert.ToInt32(dataReader["n_processo"]),
                                nome = dataReader["nome_aluno"].ToString(),
                                data_nascimento = Convert.ToDateTime(dataReader["data_nascimento"]),
                                Id_Curso = Convert.ToInt32(dataReader["id_curso"]),
                                Id_Turma = Convert.ToInt32(dataReader["id_turma"]),
                                numero = Convert.ToInt32(dataReader["numero"]),
                                Id_User = Convert.ToInt32(dataReader["id_user"]),
                                pra = dataReader["pra"].ToString()
                            };
                            return aluno;

                        }
                        return null;
                    }
                }
            }
        }


        public static Aluno GetAlunoByProcesso(int n_processo)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetAlunoByProcesso";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@n_processo", n_processo);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Aluno aluno = new Aluno()
                            {
                                Id_Aluno = Convert.ToInt32(dataReader["id_aluno"]),
                                n_processo = Convert.ToInt32(dataReader["n_processo"]),
                                nome = dataReader["nome_aluno"].ToString(),
                                data_nascimento = Convert.ToDateTime(dataReader["data_nascimento"]),
                                Id_Curso = Convert.ToInt32(dataReader["id_curso"]),
                                Id_Turma = Convert.ToInt32(dataReader["id_turma"]),
                                numero = Convert.ToInt32(dataReader["numero"]),
                                Id_User = Convert.ToInt32(dataReader["id_user"]),
                                pra = dataReader["pra"].ToString()
                            };
                            return aluno;

                        }
                        return null;
                    }
                }
            }
        }
    }
}