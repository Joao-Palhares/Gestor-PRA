using Gestor.Models;
using Gestor.DataAccess.UserDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gestor.DataAccess.CryptoHelpers;

namespace Gestor.Site.Authentication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void blogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string username = tbusername.Text;
                string password = tbpassword.Text;

                User user = UserDAO.GetUser(username, password);
                if (user == null)
                {
                    lbmensagem.Text = "O Username não existe!";
                }
                else if (user.Nr_Attempts != 0)
                {
                    lbmensagem.Text = "Palavra-passe incorreta! Tem mais " + (4 - user.Nr_Attempts) + " tentativas!";
                }
                else if (user.Is_Locked == true)
                {
                    lbmensagem.Text = "Username encontra-se bloqueado! Data de bloqueio: " + user.Locked_Date_Time;
                }
                else
                {
                    Session["id_user"] = user.Id_User;
                    Session["username"] = user.Username;
                    Session["role"] = user.Role;
                    FormsAuthentication.RedirectFromLoginPage("~/Home/Home.aspx", false);
                }

            }
        }


    }
}