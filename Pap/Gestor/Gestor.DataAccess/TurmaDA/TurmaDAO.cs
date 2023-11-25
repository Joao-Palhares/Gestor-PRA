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

namespace Gestor.DataAccess.TurmaDA
{
    public class TurmaDAO
    {
        public static List<Turma> GetTurmas()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetTurmas";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Turma> listaTurmas = new List<Turma>();

                            while (dataReader.Read())
                            {
                                listaTurmas.Add(new Turma()
                                {
                                    ID_Turma = Convert.ToInt32(dataReader["id_turma"]),
                                    Ano_Escolaridade = Convert.ToInt32(dataReader["ano_escolaridade"]),
                                    ID_Curso = Convert.ToInt32(dataReader["id_curso"]),
                                    Nome_Turma = dataReader["nome_turma"].ToString(),
                                    Diretor_Turma = dataReader["diretor_turma"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["diretor_turma"])
                                });
                            }

                            return listaTurmas;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public static int DeleteTurmaDTByIDProf(int id_professor)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_DeleteTurmaDTByIDProf";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_professor", id_professor);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static int DeleteTurmaByIDProf(int id_professor)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_DeleteTurmaByIDProf";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_professor", id_professor);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static Turma GetTurmaByID(int id_turma)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetTurmaByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_turma", id_turma);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Turma turma = new Turma()
                            {
                                ID_Turma = Convert.ToInt32(dataReader["id_turma"]),
                                Ano_Escolaridade = Convert.ToInt32(dataReader["ano_escolaridade"]),
                                ID_Curso = Convert.ToInt32(dataReader["id_curso"]),
                                Nome_Turma = dataReader["nome_turma"].ToString(),
                                Diretor_Turma = dataReader["diretor_turma"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["diretor_turma"])
                            };
                            return turma;

                        }
                        return null;
                    }
                }
            }
        }

        public static Turma GetTurmaByNomeAno(string nome_turma , int ano_escolaridade)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetTurmaByNomeAno";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nome_turma", nome_turma);
                    command.Parameters.AddWithValue("@ano_escolaridade", ano_escolaridade);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Turma turma = new Turma()
                            {
                                ID_Turma = Convert.ToInt32(dataReader["id_turma"]),
                                Ano_Escolaridade = Convert.ToInt32(dataReader["ano_escolaridade"]),
                                ID_Curso = Convert.ToInt32(dataReader["id_curso"]),
                                Nome_Turma = dataReader["nome_turma"].ToString(),
                                Diretor_Turma = dataReader["diretor_turma"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["diretor_turma"])
                            };
                            return turma;

                        }
                        return null;
                    }
                }
            }
        }
        public static Turma GetTurmaByNome(string nome_turma)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetTurmaByNome";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nome_turma", nome_turma);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Turma turma = new Turma()
                            {
                                ID_Turma = Convert.ToInt32(dataReader["id_turma"]),
                                Ano_Escolaridade = Convert.ToInt32(dataReader["ano_escolaridade"]),
                                ID_Curso = Convert.ToInt32(dataReader["id_curso"]),
                                Nome_Turma = dataReader["nome_turma"].ToString(),
                                Diretor_Turma = dataReader["diretor_turma"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["diretor_turma"])
                            };
                            return turma;

                        }
                        return null;
                    }
                }
            }
        }

        public static List<Turma> GetTurmaWhereCurso(int id_curso)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetTurmaIDCurso";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_curso", id_curso);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Turma> listaTurmas = new List<Turma>();

                            while (dataReader.Read())
                            {
                                listaTurmas.Add(new Turma()
                                {
                                    ID_Turma = Convert.ToInt32(dataReader["id_turma"]),
                                    Ano_Escolaridade = Convert.ToInt32(dataReader["ano_escolaridade"]),
                                    ID_Curso = Convert.ToInt32(dataReader["id_curso"]),
                                    Nome_Turma = dataReader["nome_turma"].ToString(),
                                    Diretor_Turma = dataReader["diretor_turma"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["diretor_turma"])
                                });
                            }

                            return listaTurmas;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public static int RegisterTurma(Turma turma)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertTurma";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_curso", turma.ID_Curso);
                    command.Parameters.AddWithValue("@ano_escolaridade", turma.Ano_Escolaridade);
                    command.Parameters.AddWithValue("@nome_turma", turma.Nome_Turma);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }

        public static int UpdateTurma(Turma turma)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdateTurmaByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_turma", turma.ID_Turma);
                    command.Parameters.AddWithValue("@ano_escolaridade", turma.Ano_Escolaridade);
                    command.Parameters.AddWithValue("@diretor_turma", turma.Diretor_Turma);
                    command.Parameters.AddWithValue("@id_curso", turma.ID_Curso);
                    command.Parameters.AddWithValue("@nome_turma", turma.Nome_Turma);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
        public static List<Turma> GetTurmaByProfessor(int id_professor)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetTurmaByProfessor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_professor", id_professor);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Turma> listaturmas = new List<Turma>();

                            while (dataReader.Read())
                            {
                                listaturmas.Add(new Turma()
                                {
                                    ID_Turma= Convert.ToInt32(dataReader["id_turma"]),
                                    Nome_Turma= dataReader["nome_turma"].ToString()
                                });
                            }

                            return listaturmas;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        //########################################################
        //###           TURMA DT                               ###
        //########################################################
        public static int RegisterTurmaDT(TurmaDT turmadt)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertTurmaDT";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_turma", turmadt.id_turma);
                    command.Parameters.AddWithValue("@id_professor", turmadt.id_professor);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }


        public static TurmaDT GetTurmaByDT(int id_professor)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetTurmaByDT";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_professor", id_professor);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            TurmaDT turmadt = new TurmaDT()
                            {
                                id_turma_dt= Convert.ToInt32(dataReader["id_turma_dt"]),
                                id_turma= Convert.ToInt32(dataReader["id_turma"]),
                                id_professor= Convert.ToInt32(dataReader["id_professor"])
                            };
                            return turmadt;

                        }
                        return null;
                    }
                }
            }
        }
        public static TurmaDT GetTurmaByTurma(int id_turma)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetTurmaByTurma";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_turma", id_turma);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            TurmaDT turmadt = new TurmaDT()
                            {
                                id_turma_dt = Convert.ToInt32(dataReader["id_turma_dt"]),
                                id_turma = Convert.ToInt32(dataReader["id_turma"]),
                                id_professor = Convert.ToInt32(dataReader["id_professor"])
                            };
                            return turmadt;

                        }
                        return null;
                    }
                }
            }
        }

        public static List<Turma> GetTurmasByDiretorturma()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetTurmaByDiretorturma";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Turma> listaTurmas = new List<Turma>();

                            while (dataReader.Read())
                            {
                                listaTurmas.Add(new Turma()
                                {
                                    ID_Turma = Convert.ToInt32(dataReader["id_turma"]),
                                    Nome_Turma = dataReader["nome_turma"].ToString(),
                                    Diretor_Turma = dataReader["diretor_turma"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["diretor_turma"])
                                });
                            }

                            return listaTurmas;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
    }
}