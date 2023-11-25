using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Gestor.DataAccess.UserDA;
using Gestor.Models;
using Gestor.DataAccess.AlunoDA;
using Gestor.DataAccess.ProfessorDA;
using Gestor.DataAccess.DTDA;
using Gestor.DataAccess.TurmaDA;

namespace Gestor.Site.Administration
{
    public partial class UserManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["role"].ToString().Equals("AD"))
                {
                    RefreshGV();
                }
                else
                {
                    Response.Redirect("~/Home/Home.aspx");
                }
            }
        }
        private void RefreshGV()
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
                    using (SqlDataReader datareader = command.ExecuteReader())
                    {
                        gvusermanagement.DataSource = datareader;
                        gvusermanagement.DataBind();
                    }
                }
            }
        }
        protected void gvusers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                User user = UserDAO.GetUserByID(Convert.ToInt32(e.Row.Cells[0].Text));
                if (user.Role == "A")
                {
                    ((CheckBox)e.Row.FindControl("cbadmin")).Checked = true;
                }

                if (user.Is_Locked == true)
                {
                    ((CheckBox)e.Row.FindControl("cbblock")).Checked = true;
                }
                else
                {
                    ((CheckBox)e.Row.FindControl("cbblock")).Checked = false;
                }
            }
        }

        protected void bsalvar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvusermanagement.Rows.Count; i++)
            {
                User user = UserDAO.GetUserByID(Convert.ToInt32(gvusermanagement.DataKeys[i].Value));
                int id_user = user.Id_User;
                User user12 = UserDAO.GetUserByID(id_user);
                if (user12.Role == "AL" && ((CheckBox)gvusermanagement.Rows[i].FindControl("cbdelete")).Checked)
                {
                    AlunoDAO.DeleteAlunoByUser(id_user);
                    UserDAO.DeleteUser(id_user);
                    continue;
                }
                else if (user12.Role == "PR" && ((CheckBox)gvusermanagement.Rows[i].FindControl("cbdelete")).Checked)
                {
                    ProfessorDAO.DeleteProfessorByUser(id_user);
                    UserDAO.DeleteUser(id_user);
                    continue;
                }
                else if (user12.Role == "DT" && ((CheckBox)gvusermanagement.Rows[i].FindControl("cbdelete")).Checked)
                {
                    Professor professor = ProfessorDAO.GetProfessorByUserID(id_user);
                    TurmaDAO.DeleteTurmaByIDProf(professor.Id_Professor);
                    TurmaDAO.DeleteTurmaDTByIDProf(professor.Id_Professor);
                    DTDAO.DeleteDTByIDProf(professor.Id_Professor);
                    ProfessorDAO.DeleteProfessorByUser(id_user);
                    UserDAO.DeleteUser(id_user);
                    continue;
                }
                else if (user12.Role == "AD" && ((CheckBox)gvusermanagement.Rows[i].FindControl("cbdelete")).Checked)
                {
                    UserDAO.DeleteUser(id_user);
                    continue;

                }


                if (((CheckBox)gvusermanagement.Rows[i].FindControl("cbadmin")).Checked)
                {
                    user.Role = "AD";
                }
                else
                {
                    if(user12.Role == "AL")
                    {
                        Session["role"] = "AL";
                    }
                    else if (user12.Role == "PR")
                    {
                        Session["role"] = "PR";
                    }
                    else if (user12.Role == "DT")
                    {
                        Session["role"] = "DT";
                    }
                    else if (user12.Role == "AD")
                    {
                        Session["role"] = "AD";
                    }

                }

                if (((CheckBox)gvusermanagement.Rows[i].FindControl("cbblock")).Checked)
                {
                    user.Is_Locked = true;
                    user.Nr_Attempts = 0;
                    user.Locked_Date_Time = DateTime.Now;

                }
                else
                {
                    user.Is_Locked = false;
                    user.Locked_Date_Time = null;
                }


                UserDAO.UpdateUser(user);
            }

            Response.Redirect("~/Home/Home.aspx");
        }
    }
}