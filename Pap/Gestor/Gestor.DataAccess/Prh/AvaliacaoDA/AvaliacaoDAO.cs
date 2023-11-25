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

namespace Gestor.DataAccess.Prh.AvaliacaoDA
{
    public class AvaliacaoDAO
    {
        public static int InsertAvaliacao(Avaliacao avaliacao)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertAvaliacao";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@avaliaçao_atividade", avaliacao.avaliaçao_atividade);
                    command.Parameters.AddWithValue("@faltas_desconsideradas", avaliacao.faltas_desconsideradas);
                    command.Parameters.AddWithValue("@codigo_avaliacao", avaliacao.codigo_avaliacao);
                    command.Parameters.AddWithValue("@id_prh", avaliacao.id_prh);


                    connection.Open();
                    int returnCode3 = (int)command.ExecuteScalar();

                    return returnCode3;
                }
            }
        }

        public static Avaliacao GetPrhAvaliacaoByCode(string codigo_avaliacao)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPrhAvaliacaoByCode";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@codigo_avaliacao", codigo_avaliacao);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Avaliacao avaliacao = new Avaliacao()
                            {
                                id_avaliaçoes= Convert.ToInt32(dataReader["id_avaliaçoes"]),
                                avaliaçao_atividade= dataReader["avaliaçao_atividade"].ToString(),
                                faltas_desconsideradas= dataReader["faltas_desconsideradas"].ToString(),
                                nome_aluno= dataReader["nome_aluno"].ToString(),
                                data_assinatura_aluno = dataReader["data_assinatura_aluno"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura_aluno"]),
                                nome_professor= dataReader["nome_professor"].ToString(),
                                data_assinatura_professor= dataReader["data_assinatura_professor"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura_professor"]),
                                dt_assinatura= dataReader["dt_assinatura"].ToString(),
                                data_assinatura_dt= dataReader["data_assinatura_dt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura_dt"]),
                                id_prh= Convert.ToInt32(dataReader["id_prh"]),
                                codigo_avaliacao = dataReader["codigo_avaliacao"].ToString()
                            };
                            return avaliacao;

                        }
                        return null;
                    }
                }
            }
        }

        public static int UpdatePrhAlunoAvaliacaoByID(Avaliacao avaliacao)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdatePrhAlunoAvaliacaoByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_avaliaçoes", avaliacao.id_avaliaçoes);
                    command.Parameters.AddWithValue("@avaliaçao_atividade", avaliacao.avaliaçao_atividade);
                    command.Parameters.AddWithValue("@faltas_desconsideradas", avaliacao.faltas_desconsideradas);
                    command.Parameters.AddWithValue("@nome_aluno", avaliacao.nome_aluno);
                    command.Parameters.AddWithValue("@data_assinatura_aluno", avaliacao.data_assinatura_aluno);
                    command.Parameters.AddWithValue("@codigo_avaliacao", avaliacao.codigo_avaliacao);
                    command.Parameters.AddWithValue("@id_prh", avaliacao.id_prh);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static int UpdatePrhProfessorAvaliacaoByID(Avaliacao avaliacao)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdatePrhProfessorAvaliacaoByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_avaliaçoes", avaliacao.id_avaliaçoes);
                    command.Parameters.AddWithValue("@avaliaçao_atividade", avaliacao.avaliaçao_atividade);
                    command.Parameters.AddWithValue("@faltas_desconsideradas", avaliacao.faltas_desconsideradas);
                    command.Parameters.AddWithValue("@nome_professor", avaliacao.nome_professor);
                    command.Parameters.AddWithValue("@data_assinatura_professor", avaliacao.data_assinatura_professor);
                    command.Parameters.AddWithValue("@codigo_avaliacao", avaliacao.codigo_avaliacao);
                    command.Parameters.AddWithValue("@id_prh", avaliacao.id_prh);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static int UpdatePrhDTAvaliacaoByID(Avaliacao avaliacao)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdatePrhDTAvaliacaoByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_avaliaçoes", avaliacao.id_avaliaçoes);
                    command.Parameters.AddWithValue("@avaliaçao_atividade", avaliacao.avaliaçao_atividade);
                    command.Parameters.AddWithValue("@faltas_desconsideradas", avaliacao.faltas_desconsideradas);
                    command.Parameters.AddWithValue("@dt_assinatura", avaliacao.dt_assinatura);
                    command.Parameters.AddWithValue("@data_assinatura_dt", avaliacao.data_assinatura_dt);
                    command.Parameters.AddWithValue("@codigo_avaliacao", avaliacao.codigo_avaliacao);
                    command.Parameters.AddWithValue("@id_prh", avaliacao.id_prh);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static Avaliacao GetAvaliacaoByPrh(int id_prh)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetAvaliacaoByPrh";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_prh", id_prh);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Avaliacao avaliacao = new Avaliacao()
                            {
                                id_avaliaçoes = Convert.ToInt32(dataReader["id_avaliaçoes"]),
                                avaliaçao_atividade = dataReader["avaliaçao_atividade"].ToString(),
                                faltas_desconsideradas = dataReader["faltas_desconsideradas"].ToString(),
                                nome_aluno = dataReader["nome_aluno"].ToString(),
                                data_assinatura_aluno = dataReader["data_assinatura_aluno"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura_aluno"]),
                                nome_professor = dataReader["nome_professor"].ToString(),
                                data_assinatura_professor = dataReader["data_assinatura_professor"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura_professor"]),
                                dt_assinatura = dataReader["dt_assinatura"].ToString(),
                                data_assinatura_dt = dataReader["data_assinatura_dt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura_dt"]),
                                id_prh = Convert.ToInt32(dataReader["id_prh"]),
                                codigo_avaliacao = dataReader["codigo_avaliacao"].ToString()
                            };
                            return avaliacao;

                        }
                        return null;
                    }
                }
            }
        }
    }
}