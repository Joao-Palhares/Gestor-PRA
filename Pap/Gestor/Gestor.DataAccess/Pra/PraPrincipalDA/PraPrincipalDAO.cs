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

namespace Gestor.DataAccess.Pra.PraPrincipalDA
{
    public class PraPrincipalDAO
    {
        public static int InsertPrincipal(PraPrincipal praprincipal)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertPrincipal";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@idade", praprincipal.idade);
                    command.Parameters.AddWithValue("@id_aluno", praprincipal.id_aluno);
                    command.Parameters.AddWithValue("@ano_letivo", praprincipal.ano_letivo);
                    command.Parameters.AddWithValue("@turma", praprincipal.turma);
                    command.Parameters.AddWithValue("@numero_aluno", praprincipal.numero_aluno);
                    command.Parameters.AddWithValue("@codepraprincipal", praprincipal.codepraprincipal);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }


        public static int UpdatePraPrincipalByID(PraPrincipal praprincipal)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdatePraPrincipalByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id_principal", praprincipal.id_principal);
                    command.Parameters.AddWithValue("@id_aluno", praprincipal.id_aluno);
                    command.Parameters.AddWithValue("@idade", praprincipal.idade);
                    command.Parameters.AddWithValue("@ano_letivo", praprincipal.ano_letivo);
                    command.Parameters.AddWithValue("@turma", praprincipal.turma);
                    command.Parameters.AddWithValue("@numero_aluno", praprincipal.numero_aluno);
                    command.Parameters.AddWithValue("@codepraprincipal", praprincipal.codepraprincipal);
                    command.Parameters.AddWithValue("@id_pra", praprincipal.id_pra);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static PraPrincipal GetPraPrincipalByCode(string codepraprincipal)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPraPrincipalByCode";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@codepraprincipal", codepraprincipal);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            PraPrincipal praPrincipal = new PraPrincipal()
                            {
                                id_principal = Convert.ToInt32(dataReader["id_principal"]),
                                id_aluno = Convert.ToInt32(dataReader["id_aluno"]),
                                idade = Convert.ToInt32(dataReader["idade"]),
                                ano_letivo = dataReader["ano_letivo"].ToString(),
                                turma = dataReader["turma"].ToString(),
                                numero_aluno = Convert.ToInt32(dataReader["numero_aluno"]),
                                codepraprincipal = dataReader["codepraprincipal"].ToString(),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"])
                            };
                            return praPrincipal;

                        }
                        return null;
                    }
                }
            }
        }

        public static PraPrincipal GetPraPrincipalByPra(int id_pra)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPraPrincipalByPra";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_pra", id_pra);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            PraPrincipal praPrincipal = new PraPrincipal()
                            {
                                id_principal = Convert.ToInt32(dataReader["id_principal"]),
                                id_aluno = Convert.ToInt32(dataReader["id_aluno"]),
                                idade = Convert.ToInt32(dataReader["idade"]),
                                ano_letivo = dataReader["ano_letivo"].ToString(),
                                turma = dataReader["turma"].ToString(),
                                numero_aluno = Convert.ToInt32(dataReader["numero_aluno"]),
                                codepraprincipal = dataReader["codepraprincipal"].ToString(),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"])
                            };
                            return praPrincipal;

                        }
                        return null;
                    }
                }
            }
        }
    }
}