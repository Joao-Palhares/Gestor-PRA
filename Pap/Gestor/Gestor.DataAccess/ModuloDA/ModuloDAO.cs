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

namespace Gestor.DataAccess.ModuloDA
{
    public class ModuloDAO
    {
        public static List<Modulo> GetModulos()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetModulos";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Modulo> listaModulos = new List<Modulo>();

                            while (dataReader.Read())
                            {
                                listaModulos.Add(new Modulo()
                                {
                                    id_modulo = Convert.ToInt32(dataReader["id_disciplina"]),
                                    tempos_letivos = Convert.ToInt32(dataReader["tempos_letivos"]),
                                    id_disciplina = Convert.ToInt32(dataReader["id_disciplina"]),
                                    nome = dataReader["nome"].ToString()
                                });
                            }

                            return listaModulos;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public static List<Modulo> GetModuloWhereDisciplina(int Id_disciplina)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetModuloIDDisciplina";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_disciplina", Id_disciplina);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Modulo> listaModulos = new List<Modulo>();

                            while (dataReader.Read())
                            {
                                listaModulos.Add(new Modulo()
                                {
                                    id_modulo = Convert.ToInt32(dataReader["id_modulo"]),
                                    nome = dataReader["nome"].ToString(),
                                    tempos_letivos = Convert.ToInt32(dataReader["tempos_letivos"]),
                                    id_disciplina = Convert.ToInt32(dataReader["id_disciplina"])
                                });
                            }

                            return listaModulos;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public static Modulo GetModuloByID(int id_modulo)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetModuloByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_modulo", id_modulo);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Modulo modulo = new Modulo()
                            {
                                id_modulo = Convert.ToInt32(dataReader["id_modulo"]),
                                tempos_letivos = Convert.ToInt32(dataReader["tempos_letivos"]),
                                id_disciplina = Convert.ToInt32(dataReader["id_disciplina"]),
                                nome = dataReader["nome"].ToString()

                            };
                            return modulo;

                        }
                        return null;
                    }


                }
            }

        }
    }
}