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

namespace Gestor.DataAccess.Pra.MedidasDA
{
    public class MedidasDAO
    {
        public static int InsertMedidas(Medidas medidas)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertMedidas";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@periodo_inicio", medidas.periodo_inicio);
                    command.Parameters.AddWithValue("@periodo_fim", medidas.periodo_fim);
                    command.Parameters.AddWithValue("@medida", medidas.medida);
                    command.Parameters.AddWithValue("@codemedidas", medidas.codemedidas);
                    command.Parameters.AddWithValue("@id_pra", medidas.id_pra);

                    connection.Open();
                    int returnCode4 = (int)command.ExecuteScalar();

                    return returnCode4;
                }
            }
        }


        public static int UpdateMedidasByID(Medidas medidas)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdateMedidasByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_medidas", medidas.id_medidas);
                    command.Parameters.AddWithValue("@periodo_inicio", medidas.periodo_inicio);
                    command.Parameters.AddWithValue("@periodo_fim", medidas.periodo_fim);
                    command.Parameters.AddWithValue("@medida", medidas.medida);
                    command.Parameters.AddWithValue("@cumprimento", (object)medidas.cumprimento ?? DBNull.Value);
                    command.Parameters.AddWithValue("@data_cumprimento", (object)medidas.data_cumprimento ?? DBNull.Value);
                    command.Parameters.AddWithValue("@dever_incumprimento", (object)medidas.dever_incumprimento ?? DBNull.Value);
                    command.Parameters.AddWithValue("@data_incumprimento", (object)medidas.data_incumprimento ?? DBNull.Value);
                    command.Parameters.AddWithValue("@faltas_desconsideradas", medidas.faltas_desconsideradas);
                    command.Parameters.AddWithValue("@codemedidas", medidas.codemedidas);
                    command.Parameters.AddWithValue("@id_pra", medidas.id_pra);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static Medidas GetPraMedidasByCode(string codemedidas)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetMedidasByCode";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@codemedidas", codemedidas);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Medidas medidas = new Medidas()
                            {
                                id_medidas = Convert.ToInt32(dataReader["id_medidas"]),
                                periodo_inicio = Convert.ToDateTime(dataReader["periodo_inicio"]),
                                periodo_fim= Convert.ToDateTime(dataReader["periodo_fim"]),
                                medida = Convert.ToString(dataReader["medida"]),
                                cumprimento = Convert.ToString(dataReader["cumprimento"]),
                                data_cumprimento = dataReader["data_cumprimento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_cumprimento"]),
                                dever_incumprimento = Convert.ToString(dataReader["dever_incumprimento"]),
                                data_incumprimento = dataReader["data_incumprimento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_incumprimento"]),
                                faltas_desconsideradas = dataReader["faltas_desconsideradas"].ToString(),
                                codemedidas = Convert.ToString(dataReader["codemedidas"]),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"])
                            };
                            return medidas;

                        }
                        return null;
                    }
                }
            }
        }

        public static Medidas GetPraMedidasByPra(int id_pra)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetMedidasByPra";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_pra", id_pra);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Medidas medidas = new Medidas()
                            {
                                id_medidas = Convert.ToInt32(dataReader["id_medidas"]),
                                periodo_inicio = Convert.ToDateTime(dataReader["periodo_inicio"]),
                                periodo_fim = Convert.ToDateTime(dataReader["periodo_fim"]),
                                medida = Convert.ToString(dataReader["medida"]),
                                cumprimento = Convert.ToString(dataReader["cumprimento"]),
                                data_cumprimento = dataReader["data_cumprimento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_cumprimento"]),
                                dever_incumprimento = Convert.ToString(dataReader["dever_incumprimento"]),
                                data_incumprimento = dataReader["data_incumprimento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_incumprimento"]),
                                faltas_desconsideradas = dataReader["faltas_desconsideradas"].ToString(),
                                codemedidas = Convert.ToString(dataReader["codemedidas"]),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"])
                            };
                            return medidas;

                        }
                        return null;
                    }
                }
            }
        }
    }
}