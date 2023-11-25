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


namespace Gestor.DataAccess.Prh.PrhDA
{
    public class PrhDAO
    {
        public static int InsertPrhPagina(PrhPagina prhpagina)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertPrh";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_principal", prhpagina.id_principal);
                    command.Parameters.AddWithValue("@id_professor", prhpagina.id_professor);
                    command.Parameters.AddWithValue("@id_aluno", prhpagina.id_aluno);
                    command.Parameters.AddWithValue("@id_turma", prhpagina.id_turma);
                    command.Parameters.AddWithValue("@codigo_prh", prhpagina.codigo_prh);
                    command.Parameters.AddWithValue("@id_dt", prhpagina.id_dt);
                    command.Parameters.AddWithValue("@estado", prhpagina.estado);
                    command.Parameters.AddWithValue("@progresso", prhpagina.progresso);

                    connection.Open();
                    int returnCode30 = (int)command.ExecuteScalar();

                    return returnCode30;
                }
            }
        }

        public static int UpdatePrhByID(PrhPagina prhpagina)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdatePrhByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_prh", prhpagina.id_prh);
                    command.Parameters.AddWithValue("@id_principal", prhpagina.id_principal);
                    command.Parameters.AddWithValue("@id_descricao_atividade", prhpagina.id_descricao_atividade);
                    command.Parameters.AddWithValue("@id_avaliaçoes", (object)prhpagina.id_avaliaçoes ?? DBNull.Value);
                    command.Parameters.AddWithValue("@codigo_prh", prhpagina.codigo_prh);
                    command.Parameters.AddWithValue("@id_professor", prhpagina.id_professor);
                    command.Parameters.AddWithValue("@id_aluno", prhpagina.id_aluno);
                    command.Parameters.AddWithValue("@id_turma", prhpagina.id_turma);
                    command.Parameters.AddWithValue("@id_dt", prhpagina.id_dt);
                    command.Parameters.AddWithValue("@estado", prhpagina.estado);
                    command.Parameters.AddWithValue("@progresso", (object)prhpagina.progresso ?? DBNull.Value);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
        
        public static PrhPagina GetPrhByCode(string codigo_prh)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPrhByCode";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@codigo_prh", codigo_prh);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            PrhPagina prhpagina = new PrhPagina()
                            {
                                id_prh= Convert.ToInt32(dataReader["id_prh"]),
                                id_principal= Convert.ToInt32(dataReader["id_principal"]),
                                id_descricao_atividade= dataReader["id_descricao_atividade"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_descricao_atividade"]),
                                id_avaliaçoes = dataReader["id_avaliaçoes"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_avaliaçoes"]),
                                codigo_prh= Convert.ToString(dataReader["codigo_prh"]),
                                id_professor= Convert.ToInt32(dataReader["id_professor"]),
                                id_aluno= Convert.ToInt32(dataReader["id_aluno"]),
                                id_dt= Convert.ToInt32(dataReader["id_dt"]),
                                id_turma= Convert.ToInt32(dataReader["id_turma"]),
                                estado= Convert.ToString(dataReader["estado"]),
                                progresso= Convert.ToString(dataReader["progresso"])
                            };
                            return prhpagina;

                        }
                        return null;
                    }
                }
            }
        }

        public static PrhPagina GetPrhByID(int id_prh)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPrhByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_prh", id_prh);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            PrhPagina prhpagina = new PrhPagina()
                            {
                                id_prh = Convert.ToInt32(dataReader["id_prh"]),
                                id_principal = Convert.ToInt32(dataReader["id_principal"]),
                                id_descricao_atividade = dataReader["id_descricao_atividade"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_descricao_atividade"]),
                                id_avaliaçoes = dataReader["id_avaliaçoes"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_avaliaçoes"]),
                                codigo_prh = Convert.ToString(dataReader["codigo_prh"]),
                                id_professor = Convert.ToInt32(dataReader["id_professor"]),
                                id_aluno = Convert.ToInt32(dataReader["id_aluno"]),
                                id_dt = Convert.ToInt32(dataReader["id_dt"]),
                                id_turma = Convert.ToInt32(dataReader["id_turma"]),
                                estado = Convert.ToString(dataReader["estado"]),
                                progresso = Convert.ToString(dataReader["progresso"])

                            };
                            return prhpagina;

                        }
                        return null;
                    }
                }
            }
        }
    }
}