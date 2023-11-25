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

namespace Gestor.DataAccess.Pra.NotificacoesDA
{
    public class NotificacoesDAO
    {
        public static int InsertNotificacoes(Notificacoes notificacoes)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertNotificacoes";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@assinatura_enc", notificacoes.assinatura_enc);
                    command.Parameters.AddWithValue("@data_assinatura_enc", notificacoes.data_assinatura_enc);
                    command.Parameters.AddWithValue("@codenotificaçoes", notificacoes.codenotificaçoes);
                    command.Parameters.AddWithValue("@id_pra", notificacoes.id_pra);

                    connection.Open();
                    int returnCode4 = (int)command.ExecuteScalar();

                    return returnCode4;
                }
            }
        }
        public static int UpdateNotificacoesByID(Notificacoes notificacoes)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdateNotificaçoesByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_notificaçoes", notificacoes.id_notificaçoes);
                    command.Parameters.AddWithValue("@assinatura_enc", notificacoes.assinatura_enc);
                    command.Parameters.AddWithValue("@data_assinatura_enc", (object)notificacoes.data_assinatura_enc ?? DBNull.Value);
                    command.Parameters.AddWithValue("@assinatura_dt", (object)notificacoes.assinatura_dt ?? DBNull.Value);
                    command.Parameters.AddWithValue("@data_assinatura_dt", (object)notificacoes.data_assinatura_dt ?? DBNull.Value);
                    command.Parameters.AddWithValue("@assinatura_pt", (object)notificacoes.assinatura_pt ?? DBNull.Value);
                    command.Parameters.AddWithValue("@data_assinatura_pt", (object)notificacoes.data_assinatura_pt ?? DBNull.Value);
                    command.Parameters.AddWithValue("@data_assinatura_cpcj", (object)notificacoes.data_assinatura_cpcj ?? DBNull.Value);
                    command.Parameters.AddWithValue("@codenotificaçoes", notificacoes.codenotificaçoes);
                    command.Parameters.AddWithValue("@id_pra", notificacoes.id_pra);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static Notificacoes GetPraNotificacoesByCode(string codenotificaçoes)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetNotificacoesByCode";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@codenotificaçoes", codenotificaçoes);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Notificacoes notificacoes = new Notificacoes()
                            {
                                id_notificaçoes= Convert.ToInt32(dataReader["id_notificaçoes"]),
                                assinatura_enc= dataReader["assinatura_enc"].ToString(),
                                data_assinatura_enc = Convert.ToDateTime(dataReader["data_assinatura_enc"]),
                                assinatura_dt = dataReader["assinatura_dt"].ToString(),
                                data_assinatura_dt= dataReader["data_assinatura_dt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura_dt"]),
                                assinatura_pt= dataReader["assinatura_pt"].ToString(),
                                data_assinatura_pt= dataReader["data_assinatura_pt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura_pt"]),
                                data_assinatura_cpcj= dataReader["data_assinatura_cpcj"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura_cpcj"]),
                                codenotificaçoes = dataReader["codenotificaçoes"].ToString(),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"])
                            };
                            return notificacoes;

                        }
                        return null;
                    }
                }
            }
        }

        public static Notificacoes GetPraNotificacoesByPra(int id_pra)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetNotificacoesByPra";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_pra", id_pra);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Notificacoes notificacoes = new Notificacoes()
                            {
                                id_notificaçoes = Convert.ToInt32(dataReader["id_notificaçoes"]),
                                assinatura_enc = dataReader["assinatura_enc"].ToString(),
                                data_assinatura_enc = Convert.ToDateTime(dataReader["data_assinatura_enc"]),
                                assinatura_dt = dataReader["assinatura_dt"].ToString(),
                                data_assinatura_dt = dataReader["data_assinatura_dt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura_dt"]),
                                assinatura_pt = dataReader["assinatura_pt"].ToString(),
                                data_assinatura_pt = dataReader["data_assinatura_pt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura_pt"]),
                                data_assinatura_cpcj = dataReader["data_assinatura_cpcj"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura_cpcj"]),
                                codenotificaçoes = dataReader["codenotificaçoes"].ToString(),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"])
                            };
                            return notificacoes;

                        }
                        return null;
                    }
                }
            }
        }
    }
}