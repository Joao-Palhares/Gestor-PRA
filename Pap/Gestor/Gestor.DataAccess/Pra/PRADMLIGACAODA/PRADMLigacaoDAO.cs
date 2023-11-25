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

namespace Gestor.DataAccess.Pra.PRADMLIGACAODA
{
    public class PRADMLigacaoDAO
    {
        public static int InsertPRADMLigacao(PraDMLigacao pradmligacao)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertPraDMLigacao";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_dm", pradmligacao.id_dm);
                    command.Parameters.AddWithValue("@id_pra", pradmligacao.id_pra);

                    connection.Open();
                    int returnCodePraDMlig = (int)command.ExecuteScalar();

                    return returnCodePraDMlig;
                }
            }
        }

        public static int InsertPRADMLigacao2(PraDMLigacao2 pradmligacao2)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertPraDMLigacao";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_dm", pradmligacao2.id_dm);
                    command.Parameters.AddWithValue("@id_pra", pradmligacao2.id_pra);

                    connection.Open();
                    int returnCodePraDMlig2 = (int)command.ExecuteScalar();

                    return returnCodePraDMlig2;
                }
            }
        }


        public static int InsertPRADMLigacao3(PraDMLigacao3 pradmligacao3)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertPraDMLigacao";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_dm", pradmligacao3.id_dm);
                    command.Parameters.AddWithValue("@id_pra", pradmligacao3.id_pra);

                    connection.Open();
                    int returnCodePraDMlig3 = (int)command.ExecuteScalar();

                    return returnCodePraDMlig3;
                }
            }
        }


        public static int InsertPRADMLigacao4(PraDMLigacao4 pradmligacao4)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertPraDMLigacao";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_dm", pradmligacao4.id_dm);
                    command.Parameters.AddWithValue("@id_pra", pradmligacao4.id_pra);

                    connection.Open();
                    int returnCodePraDMlig4 = (int)command.ExecuteScalar();

                    return returnCodePraDMlig4;
                }
            }
        }


        public static int InsertPRADMLigacao5(PraDMLigacao5 pradmligacao5)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertPraDMLigacao";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_dm", pradmligacao5.id_dm);
                    command.Parameters.AddWithValue("@id_pra", pradmligacao5.id_pra);

                    connection.Open();
                    int returnCodePraDMlig5 = (int)command.ExecuteScalar();

                    return returnCodePraDMlig5;
                }
            }
        }
    }
}