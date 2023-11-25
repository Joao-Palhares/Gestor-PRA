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

namespace Gestor.DataAccess.Pra.PraDA
{
    public class PraDAO
    {
        public static int InsertPra(PraPagina prapagina)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertPra";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_principal", prapagina.id_principal);
                    command.Parameters.AddWithValue("@codigo_pra", prapagina.codigo_pra);
                    command.Parameters.AddWithValue("@id_turma", prapagina.id_turma);
                    command.Parameters.AddWithValue("@id_aluno", prapagina.id_aluno);
                    command.Parameters.AddWithValue("@id_dt", prapagina.id_dt);
                    command.Parameters.AddWithValue("@progresso", prapagina.progresso);
                    command.Parameters.AddWithValue("@estado", prapagina.estado);
                    connection.Open();
                        int returnCodepra = (int)command.ExecuteScalar();

                    return returnCodepra;
                }
            }
        }
        public static int UpdatePra(PraPagina prapagina)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdatePraByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_pra", prapagina.id_pra);
                    command.Parameters.AddWithValue("@id_principal", prapagina.id_principal);
                    command.Parameters.AddWithValue("@id_medidas", (object)prapagina.id_medidas ?? DBNull.Value);
                    command.Parameters.AddWithValue("@id_notificaçoes", (object)prapagina.id_notificaçoes ?? DBNull.Value);
                    command.Parameters.AddWithValue("@id_decisao", (object)prapagina.id_decisao ?? DBNull.Value);
                    command.Parameters.AddWithValue("@codigo_pra", prapagina.codigo_pra);
                    command.Parameters.AddWithValue("@id_turma", prapagina.id_turma);
                    command.Parameters.AddWithValue("@id_aluno", prapagina.id_aluno);
                    command.Parameters.AddWithValue("@id_dt", prapagina.id_dt);
                    command.Parameters.AddWithValue("@progresso", prapagina.progresso);
                    command.Parameters.AddWithValue("@estado", prapagina.estado);
                    command.Parameters.AddWithValue("@id_professor1", (object)prapagina.id_professor1 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@id_professor2", (object)prapagina.id_professor2 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@id_professor3", (object)prapagina.id_professor3 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@id_professor4", (object)prapagina.id_professor4 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@id_professor5", (object)prapagina.id_professor5 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ndisciplinas", (object)prapagina.ndisciplinas ?? DBNull.Value);
                    command.Parameters.AddWithValue("@id_dm1", (object)prapagina.id_dm1 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@id_dm2", (object)prapagina.id_dm2 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@id_dm3", (object)prapagina.id_dm3 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@id_dm4", (object)prapagina.id_dm4 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@id_dm5", (object)prapagina.id_dm5 ?? DBNull.Value);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static PraPagina GetPraByID(int id_pra)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPraByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_pra", id_pra);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            PraPagina prapagina = new PraPagina()
                            {
                                id_pra = Convert.ToInt32(dataReader["id_pra"]),
                                id_principal = Convert.ToInt32(dataReader["id_principal"]),
                                id_medidas = dataReader["id_medidas"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_medidas"]),
                                id_notificaçoes = dataReader["id_notificaçoes"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_notificaçoes"]),
                                id_decisao = dataReader["id_decisao"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_decisao"]),
                                codigo_pra = dataReader["codigo_pra"].ToString(),
                                estado = dataReader["estado"].ToString(),
                                progresso = dataReader["progresso"].ToString(),
                                id_aluno = Convert.ToInt32(dataReader["id_aluno"]),
                                id_dt = Convert.ToInt32(dataReader["id_dt"]),
                                id_turma = Convert.ToInt32(dataReader["id_turma"]),
                                id_professor1 = dataReader["id_professor1"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_professor1"]),
                                id_professor2 = dataReader["id_professor2"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_professor2"]),
                                id_professor3 = dataReader["id_professor3"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_professor3"]),
                                id_professor4 = dataReader["id_professor4"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_professor4"]),
                                id_professor5 = dataReader["id_professor5"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_professor5"]),
                                ndisciplinas = dataReader["ndisciplinas"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["ndisciplinas"]),
                                id_dm1 = dataReader["id_dm1"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_dm1"]),
                                id_dm2 = dataReader["id_dm2"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_dm2"]),
                                id_dm3 = dataReader["id_dm3"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_dm3"]),
                                id_dm4 = dataReader["id_dm4"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_dm4"]),
                                id_dm5 = dataReader["id_dm5"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_dm5"])
                            };
                            return prapagina;

                        }
                        return null;
                    }
                }
            }
        }

        public static PraPagina GetPraByCode(string codigo_pra)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPraByCode";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@codigo_pra", codigo_pra);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            PraPagina prapagina = new PraPagina()
                            {
                                id_pra = Convert.ToInt32(dataReader["id_pra"]),
                                id_principal = Convert.ToInt32(dataReader["id_principal"]),
                                id_medidas = dataReader["id_medidas"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_medidas"]),
                                id_notificaçoes = dataReader["id_notificaçoes"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_notificaçoes"]),
                                id_decisao = dataReader["id_decisao"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_decisao"]),
                                codigo_pra = dataReader["codigo_pra"].ToString(),
                                estado = dataReader["estado"].ToString(),
                                progresso = dataReader["progresso"].ToString(),
                                id_aluno = Convert.ToInt32(dataReader["id_aluno"]),
                                id_dt = Convert.ToInt32(dataReader["id_dt"]),
                                id_turma = Convert.ToInt32(dataReader["id_turma"]),
                                id_professor1 = dataReader["id_professor1"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_professor1"]),
                                id_professor2 = dataReader["id_professor2"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_professor2"]),
                                id_professor3 = dataReader["id_professor3"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_professor3"]),
                                id_professor4 = dataReader["id_professor4"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_professor4"]),
                                id_professor5 = dataReader["id_professor5"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_professor5"]),
                                ndisciplinas = dataReader["ndisciplinas"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["ndisciplinas"]),
                                id_dm1 = dataReader["id_dm1"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_dm1"]),
                                id_dm2 = dataReader["id_dm2"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_dm2"]),
                                id_dm3 = dataReader["id_dm3"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_dm3"]),
                                id_dm4 = dataReader["id_dm4"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_dm4"]),
                                id_dm5 = dataReader["id_dm5"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_dm5"])
                            };
                            return prapagina;

                        }
                        return null;
                    }
                }
            }
        }

        public static PraPagina GetPra()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPra";
                    command.CommandType = CommandType.StoredProcedure;


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            PraPagina prapagina = new PraPagina()
                            {
                                id_pra = Convert.ToInt32(dataReader["id_pra"]),
                                id_principal = Convert.ToInt32(dataReader["id_principal"]),
                                id_medidas = dataReader["id_medidas"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_medidas"]),
                                id_notificaçoes = dataReader["id_notificaçoes"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_notificaçoes"]),
                                id_decisao = dataReader["id_decisao"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_decisao"]),
                                codigo_pra = dataReader["codigo_pra"].ToString(),
                                estado = dataReader["estado"].ToString(),
                                progresso = dataReader["progresso"].ToString(),
                                id_aluno = Convert.ToInt32(dataReader["id_aluno"]),
                                id_dt = Convert.ToInt32(dataReader["id_dt"]),
                                id_turma = Convert.ToInt32(dataReader["id_turma"]),
                                id_professor1 = dataReader["id_professor1"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_professor1"]),
                                id_professor2 = dataReader["id_professor2"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_professor2"]),
                                id_professor3 = dataReader["id_professor3"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_professor3"]),
                                id_professor4 = dataReader["id_professor4"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_professor4"]),
                                id_professor5 = dataReader["id_professor5"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_professor5"]),
                                ndisciplinas = dataReader["ndisciplinas"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["ndisciplinas"]),
                                id_dm1 = dataReader["id_dm1"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_dm1"]),
                                id_dm2 = dataReader["id_dm2"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_dm2"]),
                                id_dm3 = dataReader["id_dm3"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_dm3"]),
                                id_dm4 = dataReader["id_dm4"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_dm4"]),
                                id_dm5 = dataReader["id_dm5"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_dm5"])
                            };
                            return prapagina;

                        }
                        return null;
                    }
                }
            }
        }


    }
}