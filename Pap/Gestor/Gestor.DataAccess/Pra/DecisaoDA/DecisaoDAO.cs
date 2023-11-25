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

namespace Gestor.DataAccess.Pra.DecisaoDA
{
    public class DecisaoDAO
    {
        public static int InsertDecisao(Decisao decisao)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertDecisao";
                    command.CommandType = CommandType.StoredProcedure;
                    
                    command.Parameters.AddWithValue("@data_conselho", decisao.data_conselho);
                    command.Parameters.AddWithValue("@decisao_code", decisao.decisao_code);

                    connection.Open();
                    int returnCode1 = (int)command.ExecuteScalar();

                    return returnCode1;
                }
            }
        }


        public static int UpdateDecisaoByID(Decisao decisao)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdateDecisaoByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_decisao", decisao.id_decisao);
                    command.Parameters.AddWithValue("@data_eadpf", (object)decisao.data_eadpf ?? SqlDateTime.Null);
                    command.Parameters.AddWithValue("@data_conselho", decisao.data_conselho);
                    command.Parameters.AddWithValue("@consequencia", decisao.consequencia);
                    command.Parameters.AddWithValue("@medidas_c_s", decisao.medidas_c_s);
                    command.Parameters.AddWithValue("@assinatura_diretor", decisao.assinatura_diretor);
                    command.Parameters.AddWithValue("@data_assinatura_diretor", decisao.data_assinatura_diretor);
                    command.Parameters.AddWithValue("@decisao_code", decisao.decisao_code);
                    command.Parameters.AddWithValue("@id_pra", decisao.id_pra);

                    connection.Open();
                    int returnCode1 = (int)command.ExecuteScalar();

                    return returnCode1;
                }
            }
        }


        public static Decisao GetPraDecisaoByCode(string decisao_code)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDecisaoByCode";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@decisao_code", decisao_code);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Decisao decisao = new Decisao()
                            {
                                id_decisao = Convert.ToInt32(dataReader["id_decisao"]),
                                data_conselho = Convert.ToDateTime(dataReader["data_conselho"]),
                                consequencia = dataReader["consequencia"].ToString(),
                                data_eadpf = dataReader["data_eadpf"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_eadpf"]),
                                medidas_c_s = dataReader["medidas_c_s"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["medidas_c_s"]),
                                assinatura_diretor = dataReader["assinatura_diretor"].ToString(),
                                data_assinatura_diretor= Convert.ToDateTime(dataReader["data_assinatura_diretor"]),
                                decisao_code = dataReader["decisao_code"].ToString(),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"])
                                
                                
                            };
                            return decisao;

                        }
                        return null;
                    }
                }
            }
        }

        public static Decisao GetPraDecisaoByPra(int id_pra)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDecisaoByPra";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_pra", id_pra);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Decisao decisao = new Decisao()
                            {
                                id_decisao = Convert.ToInt32(dataReader["id_decisao"]),
                                data_conselho = Convert.ToDateTime(dataReader["data_conselho"]),
                                consequencia = dataReader["consequencia"].ToString(),
                                data_eadpf = dataReader["data_eadpf"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_eadpf"]),
                                medidas_c_s = dataReader["medidas_c_s"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["medidas_c_s"]),
                                assinatura_diretor = dataReader["assinatura_diretor"].ToString(),
                                data_assinatura_diretor = Convert.ToDateTime(dataReader["data_assinatura_diretor"]),
                                decisao_code = dataReader["decisao_code"].ToString(),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"])
                            };
                            return decisao;

                        }
                        return null;
                    }
                }
            }
        }
    }
}