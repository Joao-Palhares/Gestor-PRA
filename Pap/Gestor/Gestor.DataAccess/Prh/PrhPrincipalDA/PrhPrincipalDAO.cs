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

namespace Gestor.DataAccess.Prh.PrhPrincipalDA
{
    public class PrhPrincipalDAO
    {
        public static int InsertPrhPrincipal(PrhPrincipal prhprincipal)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertPrhPrincipal";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ano_letivo", prhprincipal.ano_letivo);
                    command.Parameters.AddWithValue("@turma", prhprincipal.turma);
                    command.Parameters.AddWithValue("@numero_aluno", prhprincipal.numero_aluno);
                    command.Parameters.AddWithValue("@id_aluno", prhprincipal.id_aluno);
                    command.Parameters.AddWithValue("@curso", prhprincipal.curso);
                    command.Parameters.AddWithValue("@disciplina", prhprincipal.disciplina);
                    command.Parameters.AddWithValue("@tempo_letivos_faltas", prhprincipal.tempo_letivos_faltas);
                    command.Parameters.AddWithValue("@codigo_prhprincipal", prhprincipal.codigo_prhprincipal);
                    connection.Open();
                    int returnCode1 = (int)command.ExecuteScalar();

                    return returnCode1;
                }
            }
        }

        public static int UpdatePrhPrincipalByID(PrhPrincipal prhprincipal)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdatePrhPrincipalByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_principal", prhprincipal.id_principal);
                    command.Parameters.AddWithValue("@ano_letivo", prhprincipal.ano_letivo);
                    command.Parameters.AddWithValue("@turma", prhprincipal.turma);
                    command.Parameters.AddWithValue("@numero_aluno", prhprincipal.numero_aluno);
                    command.Parameters.AddWithValue("@id_aluno", prhprincipal.id_aluno);
                    command.Parameters.AddWithValue("@curso", prhprincipal.curso);
                    command.Parameters.AddWithValue("@disciplina", prhprincipal.disciplina);
                    command.Parameters.AddWithValue("@tempo_letivos_faltas", prhprincipal.tempo_letivos_faltas);
                    command.Parameters.AddWithValue("@modalidade_adotada", prhprincipal.modalidade_adotada);
                    command.Parameters.AddWithValue("@outra_modalidade", prhprincipal.outra_modalidade);
                    command.Parameters.AddWithValue("@codigo_prhprincipal", prhprincipal.codigo_prhprincipal);
                    command.Parameters.AddWithValue("@id_prh", prhprincipal.id_prh);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static PrhPrincipal GetPrhPrincipalByCode(string codigo_prhprincipal)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPrhPrincipalByCode";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@codigo_prhprincipal", codigo_prhprincipal);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            PrhPrincipal prhprincipal = new PrhPrincipal()
                            {
                                id_principal= Convert.ToInt32(dataReader["id_principal"]),
                                ano_letivo= Convert.ToString(dataReader["ano_letivo"]),
                                turma= Convert.ToString(dataReader["turma"]),
                                numero_aluno= Convert.ToInt32(dataReader["numero_aluno"]),
                                id_aluno= Convert.ToInt32(dataReader["id_aluno"]),
                                curso= dataReader["curso"].ToString(),
                                disciplina= dataReader["disciplina"].ToString(),
                                tempo_letivos_faltas= Convert.ToInt32(dataReader["tempo_letivos_faltas"]),
                                modalidade_adotada= Convert.ToString(dataReader["modalidade_adotada"]),
                                outra_modalidade= Convert.ToString(dataReader["outra_modalidade"]),
                                codigo_prhprincipal= Convert.ToString(dataReader["codigo_prhprincipal"]),
                                id_prh= dataReader["id_prh"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_prh"])

                            };
                            return prhprincipal;

                        }
                        return null;
                    }
                }
            }
        }

        public static PrhPrincipal GetPrhPrincipalByPrh(int id_prh)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPrhPrincipalByPrh";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_prh", id_prh);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            PrhPrincipal prhprincipal = new PrhPrincipal()
                            {
                                id_principal = Convert.ToInt32(dataReader["id_principal"]),
                                ano_letivo = Convert.ToString(dataReader["ano_letivo"]),
                                turma = Convert.ToString(dataReader["turma"]),
                                numero_aluno = Convert.ToInt32(dataReader["numero_aluno"]),
                                id_aluno = Convert.ToInt32(dataReader["id_aluno"]),
                                curso = dataReader["curso"].ToString(),
                                disciplina = dataReader["disciplina"].ToString(),
                                tempo_letivos_faltas = Convert.ToInt32(dataReader["tempo_letivos_faltas"]),
                                modalidade_adotada = Convert.ToString(dataReader["modalidade_adotada"]),
                                outra_modalidade = Convert.ToString(dataReader["outra_modalidade"]),
                                codigo_prhprincipal = Convert.ToString(dataReader["codigo_prhprincipal"]),
                                id_prh = dataReader["id_prh"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_prh"])

                            };
                            return prhprincipal;

                        }
                        return null;
                    }
                }
            }
        }
    }
}