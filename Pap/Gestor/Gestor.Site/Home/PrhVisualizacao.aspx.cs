using Gestor.DataAccess.Prh.AvaliacaoDA;
using Gestor.DataAccess.Prh.DescriçãoAtividadesDA;
using Gestor.DataAccess.Prh.PrhDA;
using Gestor.DataAccess.Prh.PrhPrincipalDA;
using Gestor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gestor.Site.Home
{
    public partial class Visualização : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string rawID = Request.QueryString["id_prh"];
                int id_prh = -1;

                if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_prh))
                {
                    Response.Redirect("~/Home/Home.aspx");
                }
                hiddenid_prh.Value = id_prh.ToString();
                Avaliacao avaliacao = AvaliacaoDAO.GetAvaliacaoByPrh(id_prh);
                PrhPagina prhpagina = PrhDAO.GetPrhByID(id_prh);
                if (prhpagina.id_avaliaçoes != null && avaliacao.dt_assinatura!= null)
                {
                    
                    PrhPrincipal prhprincipal = PrhPrincipalDAO.GetPrhPrincipalByPrh(id_prh);
                    DescricaoAtividades descricaoatividades = DescricaoAtividadesDAO.GetDescricaoAtividadesByPrh(id_prh);

                    tbaluno.Text = Convert.ToString(prhprincipal.id_aluno);
                    tbnaluno.Text = Convert.ToString(prhprincipal.numero_aluno);
                    tbanoletivo.Text = prhprincipal.ano_letivo;
                    tbcurso.Text = prhprincipal.curso;
                    tbturma.Text = prhprincipal.turma;
                    tbdisciplina.Text = prhprincipal.disciplina;
                    tbntempos.Text = Convert.ToString(prhprincipal.tempo_letivos_faltas);
                    string mod = prhprincipal.modalidade_adotada;
                    if (mod == "Estudo acompanhado.")
                    {
                        lbmod.Enabled = true; lbmod.Visible = true;
                        cbmodalidadeea.Checked = true;
                        lbesac.Enabled = true; lbesac.Visible = true;
                        cbmodalidadeea.Enabled = false; cbmodalidadeea.Visible = true;
                        lbrtp.Enabled = true; lbrtp.Visible = true;
                        cbmodalidadertp.Enabled = false; cbmodalidadertp.Visible = true;
                        lbrafal.Enabled = true; lbrafal.Visible = true;
                        cbmodalidaderafal.Enabled = false; cbmodalidaderafal.Visible = true;
                        lbrot.Enabled = true; lbrot.Visible = true;
                        cbmodalidaderot.Enabled = false; cbmodalidaderot.Visible = true;
                        lbot.Enabled = true; lbot.Visible = true;
                        cbmodalidadeo.Enabled = false; cbmodalidadeo.Visible = true;
                        tbmodalidadesoutras.Enabled = false; tbmodalidadesoutras.Visible = true;

                    }
                    else if (mod == "Realização de trabalhos práticos.")
                    {
                        lbmod.Enabled = true; lbmod.Visible = true;
                        lbesac.Enabled = true; lbesac.Visible = true;
                        cbmodalidadeea.Enabled = false; cbmodalidadeea.Visible = true;
                        lbrtp.Enabled = true; lbrtp.Visible = true;
                        cbmodalidadertp.Checked = true;
                        cbmodalidadertp.Enabled = false; cbmodalidadertp.Visible = true;
                        lbrafal.Enabled = true; lbrafal.Visible = true;
                        cbmodalidaderafal.Enabled = false; cbmodalidaderafal.Visible = true;
                        lbrot.Enabled = true; lbrot.Visible = true;
                        cbmodalidaderot.Enabled = false; cbmodalidaderot.Visible = true;
                        lbot.Enabled = true; lbot.Visible = true;
                        cbmodalidadeo.Enabled = false; cbmodalidadeo.Visible = true;
                        tbmodalidadesoutras.Enabled = false; tbmodalidadesoutras.Visible = true;
                    }
                    else if (mod == "Recuperação das aulas fora das atividades letivas.")
                    {
                        lbmod.Enabled = true; lbmod.Visible = true;
                        lbesac.Enabled = true; lbesac.Visible = true;
                        cbmodalidadeea.Enabled = false; cbmodalidadeea.Visible = true;
                        lbrtp.Enabled = true; lbrtp.Visible = true;
                        cbmodalidadertp.Enabled = false; cbmodalidadertp.Visible = true;
                        lbrafal.Enabled = true; lbrafal.Visible = true;
                        cbmodalidaderafal.Checked = true;
                        cbmodalidaderafal.Enabled = false; cbmodalidaderafal.Visible = true;
                        lbrot.Enabled = true; lbrot.Visible = true;
                        cbmodalidaderot.Enabled = false; cbmodalidaderot.Visible = true;
                        lbot.Enabled = true; lbot.Visible = true;
                        cbmodalidadeo.Enabled = false; cbmodalidadeo.Visible = true;
                        tbmodalidadesoutras.Enabled = false; tbmodalidadesoutras.Visible = true;
                    }
                    else if (mod == "Relatórios ou outros trabalhos.")
                    {
                        lbmod.Enabled = true; lbmod.Visible = true;
                        lbesac.Enabled = true; lbesac.Visible = true;
                        cbmodalidadeea.Enabled = false; cbmodalidadeea.Visible = true;
                        lbrtp.Enabled = true; lbrtp.Visible = true;
                        cbmodalidadertp.Enabled = false; cbmodalidadertp.Visible = true;
                        lbrafal.Enabled = true; lbrafal.Visible = true;
                        cbmodalidaderafal.Enabled = false; cbmodalidaderafal.Visible = true;
                        lbrot.Enabled = true; lbrot.Visible = true;
                        cbmodalidaderot.Checked = true;
                        cbmodalidaderot.Enabled = false; cbmodalidaderot.Visible = true;
                        lbot.Enabled = true; lbot.Visible = true;
                        cbmodalidadeo.Enabled = false; cbmodalidadeo.Visible = true;
                        tbmodalidadesoutras.Enabled = false; tbmodalidadesoutras.Visible = true;
                    }
                    else if (mod == "Outra(s):")
                    {

                        lbmod.Enabled = true; lbmod.Visible = true;
                        lbesac.Enabled = true; lbesac.Visible = true;
                        cbmodalidadeea.Enabled = false; cbmodalidadeea.Visible = true;
                        lbrtp.Enabled = true; lbrtp.Visible = true;
                        cbmodalidadertp.Enabled = false; cbmodalidadertp.Visible = true;
                        lbrafal.Enabled = true; lbrafal.Visible = true;
                        cbmodalidaderafal.Enabled = false; cbmodalidaderafal.Visible = true;
                        lbrot.Enabled = true; lbrot.Visible = true;
                        cbmodalidaderot.Enabled = false; cbmodalidaderot.Visible = true;
                        lbot.Enabled = true; lbot.Visible = true;
                        cbmodalidadeo.Checked = true;
                        cbmodalidadeo.Enabled = false; cbmodalidadeo.Visible = true;
                        tbmodalidadesoutras.Text = prhprincipal.outra_modalidade;
                        tbmodalidadesoutras.Enabled = false; tbmodalidadesoutras.Visible = true;
                    }
                    tbatividades.Text = descricaoatividades.atividades;
                    tblocal1.Text = descricaoatividades.local;
                    tbinicio.Text = Convert.ToString(descricaoatividades.data_inicio.ToString("yyyy-MM-dd"));
                    tbfim.Text = Convert.ToString(descricaoatividades.data_final.ToString("yyyy-MM-dd"));


                    if (descricaoatividades.cumprimento == "Cumpriu")
                    {
                        cbcumpriu.Enabled = false; cbcumpriu.Visible = true;
                        cbncumpriu.Enabled = false; cbncumpriu.Visible = true;
                        cbcumpriu.Checked = true;

                    }
                    else if (descricaoatividades.cumprimento == "Nao cumpriu")
                    {
                        cbncumpriu.Enabled = false; cbncumpriu.Visible = true;
                        cbcumpriu.Enabled = false; cbcumpriu.Visible = true;
                        cbncumpriu.Checked = true;
                    }
                    tbavaliaçaoatividade.Text = avaliacao.avaliaçao_atividade;
                    tbfaltasdesconsideradas.Text = avaliacao.faltas_desconsideradas;
                    tbdecisaoaluno.Text = avaliacao.nome_aluno;
                    dataassaluno.Text = Convert.ToString(avaliacao.data_assinatura_aluno);
                    tbdecisaoprofessor.Text = avaliacao.nome_professor;
                    dataassprof.Text = Convert.ToString(avaliacao.data_assinatura_professor);
                    tbdecisaodt.Text = avaliacao.dt_assinatura;
                    dataassdt.Text = Convert.ToString(avaliacao.data_assinatura_dt);
                }
                else
                {
                    Response.Write("<script>alert('Algo de errado aconteceu! Pelo que parece este PRH não está realmente completo!');window.location='/Home/Planos.aspx';</script>");
                }
                
            }
        }

        protected void bsair_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Home.aspx");
        }
    }
}