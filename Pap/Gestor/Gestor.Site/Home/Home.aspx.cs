using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gestor.DataAccess.UserDA;
using Gestor.Models;

namespace Gestor.Site.Home
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int iduser = Convert.ToInt32(Session["id_user"]);
            User user=UserDAO.GetUserByID(iduser);
            UserDAO.GetUserByID(iduser);
        }
    }
}