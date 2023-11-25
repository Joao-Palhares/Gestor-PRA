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

namespace Gestor.DataAccess.Pra.DMDA
{
    public class DMDAO
    {


        //#############################################################
        //###                Insert DM                              ###
        //#############################################################
        public static int InsertDM(DM dm)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertDM";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@disciplina_modulo", dm.disciplina_modulo);
                    command.Parameters.AddWithValue("@faltas_excesso", dm.faltas_excesso);
                    command.Parameters.AddWithValue("@dmcode", dm.dmcode);
                    command.Parameters.AddWithValue("@id_professor", dm.id_professor);
                    command.Parameters.AddWithValue("@id_pra", dm.id_pra);

                    connection.Open();
                    int returnCode2 = (int)command.ExecuteScalar();

                    return returnCode2;
                }
            }
        }
        public static int InsertDM2(DM2 dm2)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertDM2";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@disciplina_modulo", dm2.disciplina_modulo);
                    command.Parameters.AddWithValue("@faltas_excesso", dm2.faltas_excesso);
                    command.Parameters.AddWithValue("@dmcode", dm2.dmcode);
                    command.Parameters.AddWithValue("@id_professor", dm2.id_professor);
                    command.Parameters.AddWithValue("@id_pra", dm2.id_pra);

                    connection.Open();
                    int returnCode22 = (int)command.ExecuteScalar();

                    return returnCode22;
                }
            }
        }
        public static int InsertDM3(DM3 dm3)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertDM3";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@disciplina_modulo", dm3.disciplina_modulo);
                    command.Parameters.AddWithValue("@faltas_excesso", dm3.faltas_excesso);
                    command.Parameters.AddWithValue("@dmcode", dm3.dmcode);
                    command.Parameters.AddWithValue("@id_professor", dm3.id_professor);
                    command.Parameters.AddWithValue("@id_pra", dm3.id_pra);

                    connection.Open();
                    int returnCode23 = (int)command.ExecuteScalar();

                    return returnCode23;
                }
            }
        }
        public static int InsertDM4(DM4 dm4)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertDM4";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@disciplina_modulo", dm4.disciplina_modulo);
                    command.Parameters.AddWithValue("@faltas_excesso", dm4.faltas_excesso);
                    command.Parameters.AddWithValue("@dmcode", dm4.dmcode);
                    command.Parameters.AddWithValue("@id_professor", dm4.id_professor);
                    command.Parameters.AddWithValue("@id_pra", dm4.id_pra);

                    connection.Open();
                    int returnCode24 = (int)command.ExecuteScalar();

                    return returnCode24;
                }
            }
        }
        public static int InsertDM5(DM5 dm5)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertDM5";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@disciplina_modulo", dm5.disciplina_modulo);
                    command.Parameters.AddWithValue("@faltas_excesso", dm5.faltas_excesso);
                    command.Parameters.AddWithValue("@dmcode", dm5.dmcode);
                    command.Parameters.AddWithValue("@id_professor", dm5.id_professor);
                    command.Parameters.AddWithValue("@id_pra", dm5.id_pra);

                    connection.Open();
                    int returnCode25 = (int)command.ExecuteScalar();

                    return returnCode25;
                }
            }
        }

        //########################################################
        //###  GET DM BY CODE                                  ###
        //########################################################


        public static DM GetDMByCode(string codigo_dm1)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDMByCode";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@dmcode", codigo_dm1);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DM dm = new DM()
                            {
                                id_dm = Convert.ToInt32(dataReader["id_dm"]),
                                disciplina_modulo = Convert.ToInt32(dataReader["disciplina_modulo"]),
                                faltas_excesso = Convert.ToInt32(dataReader["faltas_excesso"]),
                                assinatura_professor_disciplina = dataReader["assinatura_professor_disciplina"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["assinatura_professor_disciplina"]),
                                data_assinatura = dataReader["data_assinatura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura"]),
                                avaliaçao = dataReader["avaliaçao"].ToString(),
                                retido = dataReader["retido"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["retido"]),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"]),
                                dmcode = dataReader["dmcode"].ToString(),
                                id_professor = Convert.ToInt32(dataReader["id_professor"])
                            };
                            return dm;

                        }
                        return null;
                    }
                }
            }
        }



        public static DM2 GetDMByCode2(string codigo_dm1)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDMByCode2";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@dmcode", codigo_dm1);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DM2 dm2 = new DM2()
                            {
                                id_dm = Convert.ToInt32(dataReader["id_dm"]),
                                disciplina_modulo = Convert.ToInt32(dataReader["disciplina_modulo"]),
                                faltas_excesso = Convert.ToInt32(dataReader["faltas_excesso"]),
                                assinatura_professor_disciplina = dataReader["assinatura_professor_disciplina"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["assinatura_professor_disciplina"]),
                                data_assinatura = dataReader["data_assinatura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura"]),
                                avaliaçao = dataReader["avaliaçao"].ToString(),
                                retido = dataReader["retido"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["retido"]),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"]),
                                dmcode = dataReader["dmcode"].ToString(),
                                id_professor = Convert.ToInt32(dataReader["id_professor"])
                            };
                            return dm2;

                        }
                        return null;
                    }
                }
            }
        }



        public static DM3 GetDMByCode3(string codigo_dm1)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDMByCode3";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@dmcode", codigo_dm1);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DM3 dm3 = new DM3()
                            {
                                id_dm = Convert.ToInt32(dataReader["id_dm"]),
                                disciplina_modulo = Convert.ToInt32(dataReader["disciplina_modulo"]),
                                faltas_excesso = Convert.ToInt32(dataReader["faltas_excesso"]),
                                assinatura_professor_disciplina = dataReader["assinatura_professor_disciplina"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["assinatura_professor_disciplina"]),
                                data_assinatura = dataReader["data_assinatura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura"]),
                                avaliaçao = dataReader["avaliaçao"].ToString(),
                                retido = dataReader["retido"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["retido"]),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"]),
                                dmcode = dataReader["dmcode"].ToString(),
                                id_professor = Convert.ToInt32(dataReader["id_professor"])
                            };
                            return dm3;

                        }
                        return null;
                    }
                }
            }
        }



        public static DM4 GetDMByCode4(string codigo_dm1)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDMByCode4";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@dmcode", codigo_dm1);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DM4 dm4 = new DM4()
                            {
                                id_dm = Convert.ToInt32(dataReader["id_dm"]),
                                disciplina_modulo = Convert.ToInt32(dataReader["disciplina_modulo"]),
                                faltas_excesso = Convert.ToInt32(dataReader["faltas_excesso"]),
                                assinatura_professor_disciplina = dataReader["assinatura_professor_disciplina"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["assinatura_professor_disciplina"]),
                                data_assinatura = dataReader["data_assinatura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura"]),
                                avaliaçao = dataReader["avaliaçao"].ToString(),
                                retido = dataReader["retido"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["retido"]),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"]),
                                dmcode = dataReader["dmcode"].ToString(),
                                id_professor = Convert.ToInt32(dataReader["id_professor"])
                            };
                            return dm4;

                        }
                        return null;
                    }
                }
            }
        }



        public static DM5 GetDMByCode5(string codigo_dm1)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDMByCode5";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@dmcode", codigo_dm1);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DM5 dm5 = new DM5()
                            {
                                id_dm = Convert.ToInt32(dataReader["id_dm"]),
                                disciplina_modulo = Convert.ToInt32(dataReader["disciplina_modulo"]),
                                faltas_excesso = Convert.ToInt32(dataReader["faltas_excesso"]),
                                assinatura_professor_disciplina = dataReader["assinatura_professor_disciplina"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["assinatura_professor_disciplina"]),
                                data_assinatura = dataReader["data_assinatura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura"]),
                                avaliaçao = dataReader["avaliaçao"].ToString(),
                                retido = dataReader["retido"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["retido"]),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"]),
                                dmcode = dataReader["dmcode"].ToString(),
                                id_professor = Convert.ToInt32(dataReader["id_professor"])
                            };
                            return dm5;

                        }
                        return null;
                    }
                }
            }
        }

        //###################################################################
        //###                     Update DM                               ###
        //###################################################################


        public static int UpdateDMByID(DM dm)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdateDMByID1";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id_dm", dm.id_dm);
                    command.Parameters.AddWithValue("@disciplina_modulo", dm.disciplina_modulo);
                    command.Parameters.AddWithValue("@faltas_excesso", dm.faltas_excesso);
                    command.Parameters.AddWithValue("@assinatura_professor_disciplina", dm.assinatura_professor_disciplina);
                    command.Parameters.AddWithValue("@data_assinatura", dm.data_assinatura);
                    command.Parameters.AddWithValue("@avaliaçao", dm.avaliaçao);
                    command.Parameters.AddWithValue("@retido", dm.retido);
                    command.Parameters.AddWithValue("@id_pra", dm.id_pra);
                    command.Parameters.AddWithValue("@dmcode", dm.dmcode);
                    command.Parameters.AddWithValue("@id_professor", dm.id_professor);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static int UpdateDMByID2(DM2 dm2)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdateDMByID2";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id_dm", dm2.id_dm);
                    command.Parameters.AddWithValue("@disciplina_modulo", dm2.disciplina_modulo);
                    command.Parameters.AddWithValue("@faltas_excesso", dm2.faltas_excesso);
                    command.Parameters.AddWithValue("@assinatura_professor_disciplina", dm2.assinatura_professor_disciplina);
                    command.Parameters.AddWithValue("@data_assinatura", dm2.data_assinatura);
                    command.Parameters.AddWithValue("@avaliaçao", dm2.avaliaçao);
                    command.Parameters.AddWithValue("@retido", dm2.retido);
                    command.Parameters.AddWithValue("@id_pra", dm2.id_pra);
                    command.Parameters.AddWithValue("@dmcode", dm2.dmcode);
                    command.Parameters.AddWithValue("@id_professor", dm2.id_professor);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static int UpdateDMByID3(DM3 dm3)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdateDMByID3";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id_dm", dm3.id_dm);
                    command.Parameters.AddWithValue("@disciplina_modulo", dm3.disciplina_modulo);
                    command.Parameters.AddWithValue("@faltas_excesso", dm3.faltas_excesso);
                    command.Parameters.AddWithValue("@assinatura_professor_disciplina", dm3.assinatura_professor_disciplina);
                    command.Parameters.AddWithValue("@data_assinatura", dm3.data_assinatura);
                    command.Parameters.AddWithValue("@avaliaçao", dm3.avaliaçao);
                    command.Parameters.AddWithValue("@retido", dm3.retido);
                    command.Parameters.AddWithValue("@id_pra", dm3.id_pra);
                    command.Parameters.AddWithValue("@dmcode", dm3.dmcode);
                    command.Parameters.AddWithValue("@id_professor", dm3.id_professor);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static int UpdateDMByID4(DM4 dm4)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdateDMByID4";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id_dm", dm4.id_dm);
                    command.Parameters.AddWithValue("@disciplina_modulo", dm4.disciplina_modulo);
                    command.Parameters.AddWithValue("@faltas_excesso", dm4.faltas_excesso);
                    command.Parameters.AddWithValue("@assinatura_professor_disciplina", dm4.assinatura_professor_disciplina);
                    command.Parameters.AddWithValue("@data_assinatura", dm4.data_assinatura);
                    command.Parameters.AddWithValue("@avaliaçao", dm4.avaliaçao);
                    command.Parameters.AddWithValue("@retido", dm4.retido);
                    command.Parameters.AddWithValue("@id_pra", dm4.id_pra);
                    command.Parameters.AddWithValue("@dmcode", dm4.dmcode);
                    command.Parameters.AddWithValue("@id_professor", dm4.id_professor);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static int UpdateDMByID5(DM5 dm5)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdateDMByID5";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id_dm", dm5.id_dm);
                    command.Parameters.AddWithValue("@disciplina_modulo", dm5.disciplina_modulo);
                    command.Parameters.AddWithValue("@faltas_excesso", dm5.faltas_excesso);
                    command.Parameters.AddWithValue("@assinatura_professor_disciplina", dm5.assinatura_professor_disciplina);
                    command.Parameters.AddWithValue("@data_assinatura", dm5.data_assinatura);
                    command.Parameters.AddWithValue("@avaliaçao", dm5.avaliaçao);
                    command.Parameters.AddWithValue("@retido", dm5.retido);
                    command.Parameters.AddWithValue("@id_pra", dm5.id_pra);
                    command.Parameters.AddWithValue("@dmcode", dm5.dmcode);
                    command.Parameters.AddWithValue("@id_professor", dm5.id_professor);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static DM GetDMByPra(int id_pra)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDMByPra";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_pra", id_pra);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DM dm = new DM()
                            {
                                id_dm = Convert.ToInt32(dataReader["id_dm"]),
                                disciplina_modulo = Convert.ToInt32(dataReader["disciplina_modulo"]),
                                faltas_excesso = Convert.ToInt32(dataReader["faltas_excesso"]),
                                assinatura_professor_disciplina = dataReader["assinatura_professor_disciplina"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["assinatura_professor_disciplina"]),
                                data_assinatura = dataReader["data_assinatura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura"]),
                                avaliaçao = dataReader["avaliaçao"].ToString(),
                                retido = dataReader["retido"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["retido"]),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"]),
                                dmcode = dataReader["dmcode"].ToString(),
                                id_professor = Convert.ToInt32(dataReader["id_professor"])
                            };
                            return dm;

                        }
                        return null;
                    }
                }
            }
        }

        public static DM GetDMByPra2(int id_pra)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDMByPra";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_pra", id_pra);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DM dm = new DM()
                            {
                                id_dm = Convert.ToInt32(dataReader["id_dm"]),
                                disciplina_modulo = Convert.ToInt32(dataReader["disciplina_modulo"]),
                                faltas_excesso = Convert.ToInt32(dataReader["faltas_excesso"]),
                                assinatura_professor_disciplina = dataReader["assinatura_professor_disciplina"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["assinatura_professor_disciplina"]),
                                data_assinatura = dataReader["data_assinatura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura"]),
                                avaliaçao = dataReader["avaliaçao"].ToString(),
                                retido = dataReader["retido"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["retido"]),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"]),
                                dmcode = dataReader["dmcode"].ToString(),
                                id_professor = Convert.ToInt32(dataReader["id_professor"])
                            };
                            return dm;

                        }
                        return null;
                    }
                }
            }
        }

        public static DM GetDMByPra3(int id_pra)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDMByPra";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_pra", id_pra);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DM dm = new DM()
                            {
                                id_dm = Convert.ToInt32(dataReader["id_dm"]),
                                disciplina_modulo = Convert.ToInt32(dataReader["disciplina_modulo"]),
                                faltas_excesso = Convert.ToInt32(dataReader["faltas_excesso"]),
                                assinatura_professor_disciplina = dataReader["assinatura_professor_disciplina"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["assinatura_professor_disciplina"]),
                                data_assinatura = dataReader["data_assinatura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura"]),
                                avaliaçao = dataReader["avaliaçao"].ToString(),
                                retido = dataReader["retido"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["retido"]),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"]),
                                dmcode = dataReader["dmcode"].ToString(),
                                id_professor = Convert.ToInt32(dataReader["id_professor"])
                            };
                            return dm;

                        }
                        return null;
                    }
                }
            }
        }

        public static DM GetDMByPra4(int id_pra)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDMByPra";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_pra", id_pra);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DM dm = new DM()
                            {
                                id_dm = Convert.ToInt32(dataReader["id_dm"]),
                                disciplina_modulo = Convert.ToInt32(dataReader["disciplina_modulo"]),
                                faltas_excesso = Convert.ToInt32(dataReader["faltas_excesso"]),
                                assinatura_professor_disciplina = dataReader["assinatura_professor_disciplina"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["assinatura_professor_disciplina"]),
                                data_assinatura = dataReader["data_assinatura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura"]),
                                avaliaçao = dataReader["avaliaçao"].ToString(),
                                retido = dataReader["retido"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["retido"]),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"]),
                                dmcode = dataReader["dmcode"].ToString(),
                                id_professor = Convert.ToInt32(dataReader["id_professor"])
                            };
                            return dm;

                        }
                        return null;
                    }
                }
            }
        }

        public static DM GetDMByPra5(int id_pra)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDMByPra";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_pra", id_pra);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DM dm = new DM()
                            {
                                id_dm = Convert.ToInt32(dataReader["id_dm"]),
                                disciplina_modulo = Convert.ToInt32(dataReader["disciplina_modulo"]),
                                faltas_excesso = Convert.ToInt32(dataReader["faltas_excesso"]),
                                assinatura_professor_disciplina = dataReader["assinatura_professor_disciplina"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["assinatura_professor_disciplina"]),
                                data_assinatura = dataReader["data_assinatura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura"]),
                                avaliaçao = dataReader["avaliaçao"].ToString(),
                                retido = dataReader["retido"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["retido"]),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"]),
                                dmcode = dataReader["dmcode"].ToString(),
                                id_professor = Convert.ToInt32(dataReader["id_professor"])
                            };
                            return dm;

                        }
                        return null;
                    }
                }
            }
        }

        public static DM GetDMByID1(int? id_dm)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDMByID1";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_dm", id_dm);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DM dm = new DM()
                            {
                                id_dm = Convert.ToInt32(dataReader["id_dm"]),
                                disciplina_modulo = Convert.ToInt32(dataReader["disciplina_modulo"]),
                                faltas_excesso = Convert.ToInt32(dataReader["faltas_excesso"]),
                                assinatura_professor_disciplina = dataReader["assinatura_professor_disciplina"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["assinatura_professor_disciplina"]),
                                data_assinatura = dataReader["data_assinatura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura"]),
                                avaliaçao = dataReader["avaliaçao"].ToString(),
                                retido = dataReader["retido"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["retido"]),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"]),
                                dmcode = dataReader["dmcode"].ToString(),
                                id_professor = Convert.ToInt32(dataReader["id_professor"])
                            };
                            return dm;

                        }
                        return null;
                    }
                }
            }
        }



        public static DM2 GetDMByID2(int? id_dm)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDMByID2";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_dm", id_dm);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DM2 dm2 = new DM2()
                            {
                                id_dm = Convert.ToInt32(dataReader["id_dm"]),
                                disciplina_modulo = Convert.ToInt32(dataReader["disciplina_modulo"]),
                                faltas_excesso = Convert.ToInt32(dataReader["faltas_excesso"]),
                                assinatura_professor_disciplina = dataReader["assinatura_professor_disciplina"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["assinatura_professor_disciplina"]),
                                data_assinatura = dataReader["data_assinatura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura"]),
                                avaliaçao = dataReader["avaliaçao"].ToString(),
                                retido = dataReader["retido"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["retido"]),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"]),
                                dmcode = dataReader["dmcode"].ToString(),
                                id_professor = Convert.ToInt32(dataReader["id_professor"])
                            };
                            return dm2;

                        }
                        return null;
                    }
                }
            }
        }



        public static DM3 GetDMByID3(int? id_dm)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDMByID3";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_dm", id_dm);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DM3 dm3 = new DM3()
                            {
                                id_dm = Convert.ToInt32(dataReader["id_dm"]),
                                disciplina_modulo = Convert.ToInt32(dataReader["disciplina_modulo"]),
                                faltas_excesso = Convert.ToInt32(dataReader["faltas_excesso"]),
                                assinatura_professor_disciplina = dataReader["assinatura_professor_disciplina"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["assinatura_professor_disciplina"]),
                                data_assinatura = dataReader["data_assinatura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura"]),
                                avaliaçao = dataReader["avaliaçao"].ToString(),
                                retido = dataReader["retido"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["retido"]),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"]),
                                dmcode = dataReader["dmcode"].ToString(),
                                id_professor = Convert.ToInt32(dataReader["id_professor"])
                            };
                            return dm3;

                        }
                        return null;
                    }
                }
            }
        }



        public static DM4 GetDMByID4(int? id_dm)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDMByDM4";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_dm", id_dm);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DM4 dm4 = new DM4()
                            {
                                id_dm = Convert.ToInt32(dataReader["id_dm"]),
                                disciplina_modulo = Convert.ToInt32(dataReader["disciplina_modulo"]),
                                faltas_excesso = Convert.ToInt32(dataReader["faltas_excesso"]),
                                assinatura_professor_disciplina = dataReader["assinatura_professor_disciplina"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["assinatura_professor_disciplina"]),
                                data_assinatura = dataReader["data_assinatura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura"]),
                                avaliaçao = dataReader["avaliaçao"].ToString(),
                                retido = dataReader["retido"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["retido"]),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"]),
                                dmcode = dataReader["dmcode"].ToString(),
                                id_professor = Convert.ToInt32(dataReader["id_professor"])
                            };
                            return dm4;

                        }
                        return null;
                    }
                }
            }
        }



        public static DM5 GetDMByID5(int? id_dm)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetDMByDM5";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_dm", id_dm);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            DM5 dm5 = new DM5()
                            {
                                id_dm = Convert.ToInt32(dataReader["id_dm"]),
                                disciplina_modulo = Convert.ToInt32(dataReader["disciplina_modulo"]),
                                faltas_excesso = Convert.ToInt32(dataReader["faltas_excesso"]),
                                assinatura_professor_disciplina = dataReader["assinatura_professor_disciplina"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["assinatura_professor_disciplina"]),
                                data_assinatura = dataReader["data_assinatura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["data_assinatura"]),
                                avaliaçao = dataReader["avaliaçao"].ToString(),
                                retido = dataReader["retido"] == DBNull.Value ? DBNull.Value.ToString() : Convert.ToString(dataReader["retido"]),
                                id_pra = dataReader["id_pra"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["id_pra"]),
                                dmcode = dataReader["dmcode"].ToString(),
                                id_professor = Convert.ToInt32(dataReader["id_professor"])
                            };
                            return dm5;

                        }
                        return null;
                    }
                }
            }
        }
    }
}