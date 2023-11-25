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

namespace Gestor.DataAccess.Prh.DescriçãoAtividadesDA
{
    public class DescricaoAtividadesDAO
    {
        public static int InsertDescricaoAtividades(DescricaoAtividades descricaoatividades)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertDescricaoatividades";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@atividades", descricaoatividades.atividades);
                    command.Parameters.AddWithValue("@local", descricaoatividades.local);
                    command.Parameters.AddWithValue("@data_inicio", descricaoatividades.data_inicio);
                    command.Parameters.AddWithValue("@data_final", descricaoatividades.data_final);
                    command.Parameters.AddWithValue("@codigo_descricao", descricaoatividades.codigo_descricao);
                    command.Parameters.AddWithValue("@id_prh", descricaoatividades.id_prh);

                    connection.Open();
                    int returnCode21 = (int)command.ExecuteScalar();

                    return returnCode21;
                }
            }
        }

        public static int InsertDescricaoAtividades2(DescricaoAtividades2 descricaoatividades2)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertDescricaoatividades2";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@atividades", descricaoatividades2.atividades);
                    command.Parameters.AddWithValue("@local", descricaoatividades2.local);
                    command.Parameters.AddWithValue("@data_inicio", descricaoatividades2.data_inicio);
                    command.Parameters.AddWithValue("@data_final", descricaoatividades2.data_final);
                    command.Parameters.AddWithValue("@id_prh", descricaoatividades2.id_prh);

                    connection.Open();
                    int returnCode22 = (int)command.ExecuteScalar();

                    return returnCode22;
                }
            }
        }

        public static int InsertDescricaoAtividades3(DescricaoAtividades3 descricaoatividades3)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertDescricaoatividades3";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@atividades", descricaoatividades3.atividades);
                    command.Parameters.AddWithValue("@local", descricaoatividades3.local);
                    command.Parameters.AddWithValue("@data_inicio", descricaoatividades3.data_inicio);
                    command.Parameters.AddWithValue("@data_final", descricaoatividades3.data_final);
                    command.Parameters.AddWithValue("@id_prh", descricaoatividades3.id_prh);

                    connection.Open();
                    int returnCode23 = (int)command.ExecuteScalar();

                    return returnCode23;
                }
            }
        }

        public static int InsertDescricaoAtividades4(DescricaoAtividades4 descricaoatividades4)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertDescricaoatividades4";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@atividades", descricaoatividades4.atividades);
                    command.Parameters.AddWithValue("@local", descricaoatividades4.local);
                    command.Parameters.AddWithValue("@data_inicio", descricaoatividades4.data_inicio);
                    command.Parameters.AddWithValue("@data_final", descricaoatividades4.data_final);
                    command.Parameters.AddWithValue("@id_prh", descricaoatividades4.id_prh);

                    connection.Open();
                    int returnCode24 = (int)command.ExecuteScalar();

                    return returnCode24;
                }
            }
        }

        public static int InsertDescricaoAtividades5(DescricaoAtividades5 descricaoatividades5)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertDescricaoatividades5";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@atividades", descricaoatividades5.atividades);
                    command.Parameters.AddWithValue("@local", descricaoatividades5.local);
                    command.Parameters.AddWithValue("@data_inicio", descricaoatividades5.data_inicio);
                    command.Parameters.AddWithValue("@data_final", descricaoatividades5.data_final);
                    command.Parameters.AddWithValue("@id_prh", descricaoatividades5.id_prh);

                    connection.Open();
                    int returnCode25 = (int)command.ExecuteScalar();

                    return returnCode25;
                }
            }
        }

        public static int UpdateDescricaoAtividadesByID(DescricaoAtividades descricaoatividades)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdateDescricaoAtividadesByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_descriçao_atividade", descricaoatividades.id_descriçao_atividade);
                    command.Parameters.AddWithValue("@atividades", descricaoatividades.atividades);
                    command.Parameters.AddWithValue("@local", descricaoatividades.local);
                    command.Parameters.AddWithValue("@data_inicio", descricaoatividades.data_inicio);
                    command.Parameters.AddWithValue("@data_final", descricaoatividades.data_final);
                    command.Parameters.AddWithValue("@id_prh", descricaoatividades.id_prh);
                    command.Parameters.AddWithValue("@cumprimento", descricaoatividades.cumprimento);
                    command.Parameters.AddWithValue("@codigo_descricao", descricaoatividades.codigo_descricao);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static DescricaoAtividades GetDescricaoAtividadesByCode(string codigo_descricao)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDescricaoAtividadesByCode";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@codigo_descricao", codigo_descricao);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DescricaoAtividades descricaoatividades = new DescricaoAtividades()
                            {
                                id_descriçao_atividade = Convert.ToInt32(dataReader["id_descriçao_atividade"]),
                                atividades= Convert.ToString(dataReader["atividades"]),
                                local= Convert.ToString(dataReader["local"]),
                                data_inicio = Convert.ToDateTime(dataReader["data_inicio"]),
                                data_final = Convert.ToDateTime(dataReader["data_final"]),
                                id_prh = dataReader["id_prh"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_prh"]),
                                cumprimento= Convert.ToString(dataReader["cumprimento"]),
                                codigo_descricao = Convert.ToString(dataReader["codigo_descricao"])
                            };
                            return descricaoatividades;

                        }
                        return null;
                    }
                }
            }
        }

        public static DescricaoAtividades GetDescricaoAtividadesByPrh(int id_prh)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDescricaoAtividadesByPrh";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_prh", id_prh);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DescricaoAtividades descricaoatividades = new DescricaoAtividades()
                            {
                                id_descriçao_atividade = Convert.ToInt32(dataReader["id_descriçao_atividade"]),
                                atividades = Convert.ToString(dataReader["atividades"]),
                                local = Convert.ToString(dataReader["local"]),
                                data_inicio = Convert.ToDateTime(dataReader["data_inicio"]),
                                data_final = Convert.ToDateTime(dataReader["data_final"]),
                                id_prh = dataReader["id_prh"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_prh"]),
                                cumprimento = Convert.ToString(dataReader["cumprimento"]),
                                codigo_descricao = Convert.ToString(dataReader["codigo_descricao"])
                            };
                            return descricaoatividades;

                        }
                        return null;
                    }
                }
            }
        }
    }
}