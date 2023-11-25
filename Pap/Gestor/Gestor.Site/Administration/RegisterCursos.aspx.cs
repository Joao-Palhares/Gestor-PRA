using Gestor.Models;
using Gestor.DataAccess.ProfessorDA;
using Gestor.DataAccess.CursoDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace Gestor.Site.Administration
{
    public partial class RegisterCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!Session["role"].ToString().Equals("AD"))
                {
                    Response.Redirect("~/Home/Home.aspx");
                }
                else
                {
                    List<Professor> listaprofessores = ProfessorDAO.GetProfessores();

                    ddlprofessores.DataSource = listaprofessores;
                    ddlprofessores.DataValueField = "nome";
                    ddlprofessores.DataTextField = "nome";
                    ddlprofessores.DataBind();
                }


            }
        }


        protected void bregistar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                if (!Session["role"].ToString().Equals("AD"))
                {
                    Response.Redirect("~/Home/Home.aspx");
                }
                else
                {
                    string nomecurso = tbnomecurso.Text;
                    string dc = ddlprofessores.SelectedValue;

                    Curso curso1 = CursoDAO.GetCursoByNome(nomecurso);
                    Curso curso2 = CursoDAO.GetCursoByDiretorcurso(dc);
                    if (curso1 != null)
                    {
                        lbmensagem.Text = "Já existe um curso com este nome, verifique se está a introduzir corretamente!";
                    }
                    else if (curso2 != null)
                    {
                        lbmensagem.Text = "Este professor já está registado como diretor de outro curso!";
                    }
                    else
                    {
                        Curso curso = new Curso()
                        {
                            Nome = tbnomecurso.Text,
                            Diretor_Curso = ddlprofessores.SelectedValue
                        };
                        int returnCode = CursoDAO.RegisterCurso(curso);
                        if (returnCode == -1 && returnCode == -1)
                        {
                            lbmensagem.ForeColor = System.Drawing.Color.Green;
                            lbmensagem.Text = "Registo falhado! <br />Contacte o administrador ou tente novamente...";
                        }
                        else
                        {
                            lbmensagem.ForeColor = System.Drawing.Color.Green;
                            lbmensagem.Text = "Registo efetuado com sucesso!";

                            tbnomecurso.Enabled = false;
                            ddlprofessores.Enabled = false;

                            bregistar.Visible = false;
                            bcancelar.Visible = false;
                        }
                        Response.Write("<script>alert('Registo efetuado com sucesso com sucesso!');window.location='/Home/Home.aspx';</script>");
                    }
                }

            }
        }

        protected void bcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Home.aspx");
        }
    }
}