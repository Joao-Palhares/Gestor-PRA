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

namespace Gestor.DataAccess.UserDA
{
    public class UserDAO
    {
        public static int RegisterUserAluno(User user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertUserAluno";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@username", user.Username);
                    command.Parameters.AddWithValue("@password", PasswordEncryptSHA256.GenerateSHA256String(user.Password));
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@role", user.Role);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }

        public static int RegisterUserProfessor(User user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertUserProfessor";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@username", user.Username);
                    command.Parameters.AddWithValue("@password", PasswordEncryptSHA256.GenerateSHA256String(user.Password));
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@role", user.Role);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }

        public static int RegisterUserEncEdu(User user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertUserEncEdu";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@username", user.Username);
                    command.Parameters.AddWithValue("@password", PasswordEncryptSHA256.GenerateSHA256String(user.Password));
                    command.Parameters.AddWithValue("@email", user.Email);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }
        public static int RegisterAdmin(User user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertUserAdmin";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@username", user.Username);
                    command.Parameters.AddWithValue("@password", PasswordEncryptSHA256.GenerateSHA256String(user.Password));
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@role", user.Role);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }



        public static int UpdateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdateUserByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_user", user.Id_User);
                    command.Parameters.AddWithValue("@username", user.Username);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@email", user.Email);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
        public static User GetUserByID(int id_user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetUserByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_user", id_user);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            User user = new User()
                            {
                                Id_User = Convert.ToInt32(dataReader["id_user"]),
                                Username = dataReader["username"].ToString(),
                                Password = dataReader["password"].ToString(),
                                Email = dataReader["email"].ToString(),
                                Role = dataReader["role"].ToString(),
                                Is_Locked = dataReader["is_locked"] == DBNull.Value ? false : Convert.ToBoolean(dataReader["is_locked"]),
                                Nr_Attempts = dataReader["nr_attempts"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["nr_attempts"]),
                                Locked_Date_Time = dataReader["locked_date_time"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["locked_date_time"])
                            };
                            return user;

                        }
                        return null;
                    }
                }
            }
        }
        public static int DeleteUser(int id_user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_DeleteUserByID";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_user", id_user);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
        public static User GetUser(string username, string password)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_AuthenticateUser";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", PasswordEncryptSHA256.GenerateSHA256String(password));

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            User user = new User()
                            {
                                Id_User = Convert.ToInt32(dataReader["id_user"]),
                                Username = dataReader["username"].ToString(),
                                Password = dataReader["password"].ToString(),
                                Role = dataReader["role"].ToString(),
                                Is_Locked = dataReader["is_locked"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(dataReader["is_locked"]),
                                Locked_Date_Time = dataReader["locked_date_time"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["locked_date_time"]),
                                Nr_Attempts = dataReader["nr_attempts"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["nr_attempts"])
                            };
                            return user;
                        }
                        return null;
                    }
                }
            }
        }
        public static User GetUserByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetUserByEmail";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", email);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            User user = new User()
                            {
                                Id_User = Convert.ToInt32(dataReader["id_user"]),
                                Username = dataReader["username"].ToString(),
                                Password = dataReader["password"].ToString(),
                                Email = dataReader["email"].ToString(),
                                Role = dataReader["role"].ToString(),
                                Is_Locked = dataReader["is_locked"] == DBNull.Value ? false : Convert.ToBoolean(dataReader["is_locked"]),
                                Nr_Attempts = dataReader["nr_attempts"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["nr_attempts"]),
                                Locked_Date_Time = dataReader["locked_date_time"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["locked_date_time"])
                            };
                            return user;

                        }
                        return null;
                    }
                }
            }
        }
        public static User GetUsers()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetUsers";
                    command.CommandType = CommandType.StoredProcedure;


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            User user = new User()
                            {
                                Id_User = Convert.ToInt32(dataReader["id_user"]),
                                Username = dataReader["username"].ToString(),
                                Password = dataReader["password"].ToString(),
                                Email = dataReader["email"].ToString(),
                                Role = dataReader["role"].ToString(),
                                Is_Locked = dataReader["is_locked"] == DBNull.Value ? false : Convert.ToBoolean(dataReader["is_locked"]),
                                Nr_Attempts = dataReader["nr_attempts"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["nr_attempts"]),
                                Locked_Date_Time = dataReader["locked_date_time"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["locked_date_time"])
                            };
                            return user;

                        }
                        return null;
                    }
                }
            }
        }

        public static User GetUserByusername(string username)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetUserByUsername";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@username", username);


                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            User user = new User()
                            {
                                Id_User = Convert.ToInt32(dataReader["id_user"]),
                                Username = dataReader["username"].ToString(),
                                Password = dataReader["password"].ToString(),
                                Email = dataReader["email"].ToString(),
                                Role = dataReader["role"].ToString(),
                                Is_Locked = dataReader["is_locked"] == DBNull.Value ? false : Convert.ToBoolean(dataReader["is_locked"]),
                                Nr_Attempts = dataReader["nr_attempts"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["nr_attempts"]),
                                Locked_Date_Time = dataReader["locked_date_time"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["locked_date_time"])
                            };
                            return user;

                        }
                        return null;
                    }
                }
            }
        }
    }
}