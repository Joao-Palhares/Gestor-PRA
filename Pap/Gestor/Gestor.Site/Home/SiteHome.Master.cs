using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gestor.Site.Home
{
    public partial class SiteHome : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString().Equals("AD")) //Admin stuff
            {
                navLinkPlanos.Attributes["style"] = "display:none";          //Edição de prh
                navLinkinserirprh.Attributes["style"] = "display:none";      //Criar prh
                navLinkregisteraluno.Attributes["style"] = "display:none";   //Registo de Alunos
                navLinkinserirpra.Attributes["style"] = "display:none";      //Criar pra
                navLinkPlanosPra.Attributes["style"] = "display:none"; 
                navLinkUsers.Attributes["style"] = "display:inline";
                navLinkregisterprof.Attributes["style"] = "display:inline";
                navLinkregisteradmin.Attributes["style"] = "display:inline";
                navLinkregisterturma.Attributes["style"] = "display:inline";
                navLinkregistercurso.Attributes["style"] = "display:inline";
            }
            else if (Session["role"].ToString().Equals("AL")) //Aluno stuff
            {
                navLinkUsers.Attributes["style"] = "display:none";
                navLinkregisterprof.Attributes["style"] = "display:none";    //Registo de professores
                navLinkregisteradmin.Attributes["style"] = "display:none";   //Registo de Admin
                navLinkregisterturma.Attributes["style"] = "display:none";   //Registo de Turmas
                navLinkregistercurso.Attributes["style"] = "display:none";   //Registo de Cursos
                navLinkinserirpra.Attributes["style"] = "display:none";      //Criar pra
                navLinkinserirprh.Attributes["style"] = "display:none";      //Criar prh
                navLinkregisteraluno.Attributes["style"] = "display:none";   //Registo de Alunos

            }
            else if (Session["role"].ToString().Equals("DT")) //Diretor de turma stuff
            {
                navLinkUsers.Attributes["style"] = "display:none";
                navLinkregisterprof.Attributes["style"] = "display:none";    //Registo de professores
                navLinkregisteradmin.Attributes["style"] = "display:none";   //Registo de Admin
                navLinkregisterturma.Attributes["style"] = "display:none";   //Registo de Turmas
                navLinkregistercurso.Attributes["style"] = "display:none";   //Registo de Cursos
                
            }
            else if (Session["role"].ToString().Equals("PR")) //Professor stuff
            {
                navLinkinserirpra.Attributes["style"] = "display:none";      //Criar pra
                navLinkUsers.Attributes["style"] = "display:none";
                navLinkregisterprof.Attributes["style"] = "display:none";    //Registo de professores
                navLinkregisteradmin.Attributes["style"] = "display:none";   //Registo de Admin
                navLinkregisterturma.Attributes["style"] = "display:none";   //Registo de Turmas
                navLinkregistercurso.Attributes["style"] = "display:none";   //Registo de Cursos
                navLinkinserirpra.Attributes["style"] = "display:none";
                navLinkinserirprh.Attributes["style"] = "display:none";      //Criar prh
                navLinkregisteraluno.Attributes["style"] = "display:none";   //Registo de Alunos

            }

        }
        protected void blogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("~/Authentication/Login.aspx");
        }
    }
}