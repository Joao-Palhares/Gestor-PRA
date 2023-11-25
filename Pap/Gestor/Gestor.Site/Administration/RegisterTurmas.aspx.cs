using Gestor.Models;
using Gestor.DataAccess.ProfessorDA;
using Gestor.DataAccess.CursoDA;
using Gestor.DataAccess.TurmaDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Security.Authentication.ExtendedProtection;

namespace Gestor.Site.Administration
{
    public partial class RegisterTurmas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session["role"].ToString().Equals("AD"))
            {
                Response.Redirect("~/Home/Home.aspx");
            }
            else
            {
                List<Curso> listacursos = CursoDAO.GetCursos();
                ddlcursos.DataSource = listacursos;
                ddlcursos.DataValueField = "id_curso";
                ddlcursos.DataTextField = "nome";
                ddlcursos.DataBind();
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
                    string nomet = tbnometurma.Text;
                    int anole = Convert.ToInt32(tbanoescolaridade.Text);
                    Turma turma1 = TurmaDAO.GetTurmaByNomeAno(nomet, anole);
                    Turma turma2 = TurmaDAO.GetTurmaByNome(nomet);


                    if (turma1 != null)
                    {
                        lbmensagem.Text = "Já existe uma turma com este nome neste ano letivo!";
                    }
                    else if (turma2 != null)
                    {
                        lbmensagem.Text = "Já existe uma turma com este nome!";
                    }
                    else if (anole < 10 || anole > 12)
                    {
                        lbmensagem.Text = "Introduza um ano letivo valido, ou seja entre 10 e 12!";
                    }
                    else
                    {
                        Turma turma = new Turma()
                        {
                            ID_Curso = Convert.ToInt32(ddlcursos.SelectedValue),
                            Ano_Escolaridade = Convert.ToInt32(tbanoescolaridade.Text),
                            Nome_Turma = tbnometurma.Text
                        };
                        int returnCode = TurmaDAO.RegisterTurma(turma);
                        if (returnCode == -1 && returnCode == -1)
                        {
                            lbmensagem.ForeColor = System.Drawing.Color.Green;
                            lbmensagem.Text = "Registo falhado! <br />Contacte o administrador ou tente novamente...";
                        }
                        else
                        {
                            lbmensagem.ForeColor = System.Drawing.Color.Green;
                            lbmensagem.Text = "Registo efetuado com sucesso!";

                            ddlcursos.Enabled = false;
                            tbanoescolaridade.Enabled = false;
                            tbnometurma.Enabled = false;

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
            tbanoescolaridade.Text = "";
            tbnometurma.Text = "";
            ddlcursos.Text = "";
        }
    }
}