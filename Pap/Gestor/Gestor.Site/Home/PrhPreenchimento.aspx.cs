using Gestor.Models;
using Gestor.DataAccess.UserDA;
using Gestor.DataAccess.AlunoDA;
using Gestor.DataAccess.CursoDA;
using Gestor.DataAccess.TurmaDA;
using Gestor.DataAccess.Prh.PrhPrincipalDA;
using Gestor.DataAccess.Prh.DescriçãoAtividadesDA;
using Gestor.DataAccess.Prh.AvaliacaoDA;
using Gestor.DataAccess.Pra.PraDA;
using Gestor.DataAccess.Pra.DecisaoDA;
using Gestor.DataAccess.Pra.DMDA;
using Gestor.DataAccess.Pra.MedidasDA;
using Gestor.DataAccess.Pra.NotificacoesDA;
using Gestor.DataAccess.Pra.PraPrincipalDA;
using Gestor.DataAccess.Pra.PRADMLIGACAODA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Gestor.DataAccess.DisciplinaDAO;
using Gestor.DataAccess.ModuloDA;
using Gestor.DataAccess.Prh.PrhDA;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using Gestor.DataAccess.ProfessorDA;

namespace Gestor.Site.Home
{
    public partial class PrhPreenchimento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lbmod.Enabled = false; lbmod.Visible = false;
                cbmodalidadeea.Enabled = false; cbmodalidadeea.Visible = false;
                lbesac.Enabled = false; lbesac.Visible = false;
                cbmodalidadertp.Enabled = false; cbmodalidadertp.Visible = false;
                lbrtp.Enabled = false; lbrtp.Visible = false;
                cbmodalidaderafal.Enabled = false; cbmodalidaderafal.Visible = false;
                lbrafal.Enabled = false; lbrafal.Visible = false;
                cbmodalidaderot.Enabled = false; cbmodalidaderot.Visible = false;
                lbrot.Enabled = false; lbrot.Visible = false;
                cbmodalidadeo.Enabled = false; cbmodalidadeo.Visible = false;
                lbot.Enabled = false; lbot.Visible = false;
                tbmodalidadesoutras.Enabled = false; tbmodalidadesoutras.Visible = false;
                lbda.Enabled = false; lbda.Visible = false;
                lbati.Enabled = false; lbati.Visible = false;
                tbatividades.Enabled = false; tbatividades.Visible = false;
                lblocal.Enabled = false; lblocal.Visible = false;
                tblocal1.Enabled = false; tblocal1.Visible = false;
                lbrp.Enabled = false; lbrp.Visible = false;
                lbinicio.Enabled = false; lbinicio.Visible = false;
                lbfim.Enabled = false; lbfim.Visible = false;
                tbinicio.Enabled = false; tbinicio.Visible = false;
                tbfim.Enabled = false; tbfim.Visible = false;
                lbat.Enabled = false; lbat.Visible = false;
                tbavaliaçaoatividade.Enabled = false; tbavaliaçaoatividade.Visible = false;
                lbfd.Enabled = false; lbfd.Visible = false;
                tbfaltasdesconsideradas.Enabled = false; tbfaltasdesconsideradas.Visible = false;
                lbd.Enabled = false; lbd.Visible = false;
                lboa.Enabled = false; lboa.Visible = false;
                lbaal.Enabled = false; lbaal.Visible = false;
                tbdecisaoaluno.Enabled = false; tbdecisaoaluno.Visible = false;
                dataassaluno.Enabled = false; dataassaluno.Visible = false;
                lbop.Enabled = false; lbop.Visible = false;
                lbaal2.Enabled = false; lbaal2.Visible = false;
                tbdecisaoprofessor.Enabled = false; tbdecisaoprofessor.Visible = false;
                dataassprof.Enabled = false; dataassprof.Visible = false;
                lbodt.Enabled = false; lbodt.Visible = false;
                lbaal3.Enabled = false; lbaal3.Visible = false;
                tbdecisaodt.Enabled = false; tbdecisaodt.Visible = false;
                dataassdt.Enabled = false; dataassdt.Visible = false;
                binserir1.Enabled = false; binserir1.Visible = false;
                binserir2.Enabled = false; binserir2.Visible = false;
                binserir3.Enabled = false; binserir3.Visible = false;
                binserir4.Enabled = false; binserir4.Visible = false;
                binserir5.Enabled = false; binserir5.Visible = false;
                binserir6.Enabled = false; binserir6.Visible = false;
                bcancelar1.Enabled = false; bcancelar1.Visible = false;
                bcancelar2.Enabled = false; bcancelar2.Visible = false;
                bcancelar3.Enabled = false; bcancelar3.Visible = false;
                bcancelar4.Enabled = false; bcancelar4.Visible = false;
                bcancelar5.Enabled = false; bcancelar5.Visible = false;
                bcancelar6.Enabled = false; bcancelar6.Visible = false;

                lbcumprimento.Enabled = false; lbcumprimento.Visible = false;
                lbcumpriu.Enabled = false; lbcumpriu.Visible = false;
                lbncumpriu.Enabled = false; lbncumpriu.Visible = false;
                cbcumpriu.Enabled = false; cbcumpriu.Visible = false;
                cbncumpriu.Enabled = false; cbncumpriu.Visible = false;


                string hoje = DateTime.Today.ToString("yyyy-MM-dd");

                /*if (Session["role"].ToString() == "U")
                {
                    Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
                }*/
                string rawID = Request.QueryString["id_prh"];
                int id_prh = -1;

                if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_prh))
                {
                    Response.Redirect("~/Home/Home.aspx");
                }

                int iduser = Convert.ToInt32(Session["id_user"]);
                Professor professor = ProfessorDAO.GetProfessorByUserID(iduser);
                hiddenid_prh.Value = id_prh.ToString();
                PrhPagina prhpagina = PrhDAO.GetPrhByID(id_prh);
                PrhPrincipal prhprincipal = PrhPrincipalDAO.GetPrhPrincipalByPrh(id_prh);
                DescricaoAtividades descricaoatividades = DescricaoAtividadesDAO.GetDescricaoAtividadesByPrh(id_prh);
                Avaliacao avaliacao = AvaliacaoDAO.GetAvaliacaoByPrh(id_prh);
                Aluno aluno = AlunoDAO.GetAlunoByID(prhprincipal.id_aluno);
                tbaluno.Text = aluno.nome;
                tbnaluno.Text = Convert.ToString(aluno.numero);
                tbanoletivo.Text = prhprincipal.ano_letivo;
                tbcurso.Text = prhprincipal.curso;
                tbturma.Text = prhprincipal.turma;
                tbdisciplina.Text = prhprincipal.disciplina;
                tbntempos.Text = Convert.ToString(prhprincipal.tempo_letivos_faltas);
                string mod = prhprincipal.modalidade_adotada;

                if ((string.IsNullOrEmpty(mod)) && (prhpagina.id_professor == professor.Id_Professor) && (Session["role"].ToString().Equals("PR") || Session["role"].ToString().Equals("DT")))
                {
                    lbmod.Enabled = true; lbmod.Visible = true;
                    cbmodalidadeea.Enabled = true; cbmodalidadeea.Visible = true;
                    lbesac.Enabled = true; lbesac.Visible = true;
                    cbmodalidadertp.Enabled = true; cbmodalidadertp.Visible = true;
                    lbrtp.Enabled = true; lbrtp.Visible = true;
                    cbmodalidaderafal.Enabled = true; cbmodalidaderafal.Visible = true;
                    lbrafal.Enabled = true; lbrafal.Visible = true;
                    cbmodalidaderot.Enabled = true; cbmodalidaderot.Visible = true;
                    lbrot.Enabled = true; lbrot.Visible = true;
                    cbmodalidadeo.Enabled = true; cbmodalidadeo.Visible = true;
                    lbot.Enabled = true; lbot.Visible = true;
                    tbmodalidadesoutras.Enabled = true; tbmodalidadesoutras.Visible = true;
                    lbda.Enabled = true; lbda.Visible = true;
                    lbati.Enabled = true; lbati.Visible = true;
                    tbatividades.Enabled = true; tbatividades.Visible = true;
                    lblocal.Enabled = true; lblocal.Visible = true;
                    tblocal1.Enabled = true; tblocal1.Visible = true;
                    lbrp.Enabled = true; lbrp.Visible = true;
                    lbinicio.Enabled = true; lbinicio.Visible = true;
                    lbfim.Enabled = true; lbfim.Visible = true;
                    tbinicio.Enabled = true; tbinicio.Visible = true;
                    tbfim.Enabled = true; tbfim.Visible = true;

                    binserir1.Enabled = true; binserir1.Visible = true;
                    bcancelar1.Enabled = true; bcancelar1.Visible = true;

                }
                else if ((prhpagina.id_descricao_atividade != null) && (string.IsNullOrEmpty(descricaoatividades.cumprimento)) && Session["role"].ToString().Equals("PR"))
                {
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

                    lbda.Enabled = false; lbda.Visible = true;
                    lbati.Enabled = false; lbati.Visible = true;
                    tbatividades.Enabled = false; tbatividades.Visible = true;
                    tbatividades.Text = descricaoatividades.atividades;
                    lblocal.Enabled = false; lblocal.Visible = true;
                    tblocal1.Enabled = false; tblocal1.Visible = true;
                    tblocal1.Text = descricaoatividades.local;
                    lbrp.Enabled = false; lbrp.Visible = true;
                    lbinicio.Enabled = false; lbinicio.Visible = true;
                    lbfim.Enabled = false; lbfim.Visible = true;
                    tbinicio.Enabled = false; tbinicio.Visible = true;
                    tbfim.Enabled = false; tbfim.Visible = true;
                    tbinicio.Text = Convert.ToString(descricaoatividades.data_inicio.ToString("yyyy-MM-dd"));
                    tbfim.Text = Convert.ToString(descricaoatividades.data_final.ToString("yyyy-MM-dd"));
                    lbcumprimento.Enabled = true; lbcumprimento.Visible = true;
                    lbcumpriu.Enabled = true; lbcumpriu.Visible = true;
                    lbncumpriu.Enabled = true; lbncumpriu.Visible = true;
                    cbcumpriu.Enabled = true; cbcumpriu.Visible = true;
                    cbncumpriu.Enabled = true; cbncumpriu.Visible = true;
                    binserir2.Enabled = true; binserir2.Visible = true;
                    bcancelar2.Enabled = true; bcancelar2.Visible = true;
                }
                else if ((prhpagina.id_descricao_atividade != null) && (descricaoatividades.cumprimento != null) && (prhpagina.id_avaliaçoes == null) && Session["role"].ToString().Equals("PR"))
                {
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
                    lbda.Enabled = false; lbda.Visible = true;
                    lbati.Enabled = false; lbati.Visible = true;
                    tbatividades.Enabled = false; tbatividades.Visible = true;
                    tbatividades.Text = descricaoatividades.atividades;
                    lblocal.Enabled = false; lblocal.Visible = true;
                    tblocal1.Enabled = false; tblocal1.Visible = true;
                    tblocal1.Text = descricaoatividades.local;
                    lbrp.Enabled = false; lbrp.Visible = true;
                    lbinicio.Enabled = false; lbinicio.Visible = true;
                    lbfim.Enabled = false; lbfim.Visible = true;
                    tbinicio.Enabled = false; tbinicio.Visible = true;
                    tbinicio.Text = Convert.ToString(descricaoatividades.data_inicio.ToString("yyyy-MM-dd"));
                    tbfim.Enabled = false; tbfim.Visible = true;
                    tbfim.Text = Convert.ToString(descricaoatividades.data_final.ToString("yyyy-MM-dd"));
                    lbcumprimento.Enabled = false; lbcumprimento.Visible = true;
                    lbcumpriu.Enabled = false; lbcumpriu.Visible = true;
                    lbncumpriu.Enabled = false; lbncumpriu.Visible = true;
                    if (descricaoatividades.cumprimento == "Cumpriu")
                    {
                        cbcumpriu.Enabled = false; cbcumpriu.Visible = true;
                        cbncumpriu.Enabled = false; cbncumpriu.Visible = true;
                        cbcumpriu.Checked = true;
                        tbfaltasdesconsideradas.Text = "Faltas desconcideradas";
                    }
                    else if (descricaoatividades.cumprimento == "Nao cumpriu")
                    {
                        cbncumpriu.Enabled = false; cbncumpriu.Visible = true;
                        cbcumpriu.Enabled = false; cbcumpriu.Visible = true;
                        cbncumpriu.Checked = true;
                        tbfaltasdesconsideradas.Text = "Faltas não recuperadas";
                    }
                    lbat.Enabled = true; lbat.Visible = true;
                    tbavaliaçaoatividade.Enabled = true; tbavaliaçaoatividade.Visible = true;
                    lbfd.Enabled = true; lbfd.Visible = true;
                    tbfaltasdesconsideradas.Enabled = false; tbfaltasdesconsideradas.Visible = true;
                    binserir3.Enabled = true; binserir3.Visible = true;
                    bcancelar3.Enabled = true; bcancelar3.Visible = true;
                }
                else if ((prhpagina.id_avaliaçoes != null) && (string.IsNullOrEmpty(avaliacao.nome_aluno)) && Session["role"].ToString().Equals("AL"))
                {
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
                    lbda.Enabled = false; lbda.Visible = true;
                    lbati.Enabled = false; lbati.Visible = true;
                    tbatividades.Enabled = false; tbatividades.Visible = true;
                    tbatividades.Text = descricaoatividades.atividades;
                    lblocal.Enabled = false; lblocal.Visible = true;
                    tblocal1.Enabled = false; tblocal1.Visible = true;
                    tblocal1.Text = descricaoatividades.local;
                    lbrp.Enabled = false; lbrp.Visible = true;
                    lbinicio.Enabled = false; lbinicio.Visible = true;
                    lbfim.Enabled = false; lbfim.Visible = true;
                    tbinicio.Enabled = false; tbinicio.Visible = true;
                    tbinicio.Text = Convert.ToString(descricaoatividades.data_inicio.ToString("yyyy-MM-dd"));
                    tbfim.Enabled = false; tbfim.Visible = true;
                    tbfim.Text = Convert.ToString(descricaoatividades.data_final.ToString("yyyy-MM-dd"));
                    lbcumprimento.Enabled = false; lbcumprimento.Visible = true;
                    lbcumpriu.Enabled = false; lbcumpriu.Visible = true;
                    lbncumpriu.Enabled = false; lbncumpriu.Visible = true;
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
                    lbat.Enabled = false; lbat.Visible = true;
                    tbavaliaçaoatividade.Enabled = false; tbavaliaçaoatividade.Visible = true;
                    tbavaliaçaoatividade.Text = avaliacao.avaliaçao_atividade;
                    lbfd.Enabled = false; lbfd.Visible = true;
                    tbfaltasdesconsideradas.Enabled = false; tbfaltasdesconsideradas.Visible = true;
                    tbfaltasdesconsideradas.Text = avaliacao.faltas_desconsideradas;
                    lbd.Enabled = true; lbd.Visible = true;
                    lboa.Enabled = false; lboa.Visible = true;
                    lbaal.Enabled = false; lbaal.Visible = true;
                    tbdecisaoaluno.Enabled = true; tbdecisaoaluno.Visible = true;
                    dataassaluno.Enabled = true; dataassaluno.Visible = true;
                    dataassaluno.Text = hoje;
                    dataassaluno.Enabled = false;
                    binserir4.Enabled = true; binserir4.Visible = true;
                    bcancelar4.Enabled = true; bcancelar4.Visible = true;
                }
                else if ((prhpagina.id_avaliaçoes != null) && (!string.IsNullOrEmpty(avaliacao.nome_aluno)) && (string.IsNullOrEmpty(avaliacao.nome_professor)) && Session["role"].ToString().Equals("PR"))
                {
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
                    lbda.Enabled = false; lbda.Visible = true;
                    lbati.Enabled = false; lbati.Visible = true;
                    tbatividades.Enabled = false; tbatividades.Visible = true;
                    tbatividades.Text = descricaoatividades.atividades;
                    lblocal.Enabled = false; lblocal.Visible = true;
                    tblocal1.Enabled = false; tblocal1.Visible = true;
                    tblocal1.Text = descricaoatividades.local;
                    lbrp.Enabled = false; lbrp.Visible = true;
                    lbinicio.Enabled = false; lbinicio.Visible = true;
                    lbfim.Enabled = false; lbfim.Visible = true;
                    tbinicio.Enabled = false; tbinicio.Visible = true;
                    tbinicio.Text = Convert.ToString(descricaoatividades.data_inicio.ToString("yyyy-MM-dd"));
                    tbfim.Enabled = false; tbfim.Visible = true;
                    tbfim.Text = Convert.ToString(descricaoatividades.data_final.ToString("yyyy-MM-dd"));
                    lbcumprimento.Enabled = false; lbcumprimento.Visible = true;
                    lbcumpriu.Enabled = false; lbcumpriu.Visible = true;
                    lbncumpriu.Enabled = false; lbncumpriu.Visible = true;
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
                    lbat.Enabled = false; lbat.Visible = true;
                    tbavaliaçaoatividade.Enabled = false; tbavaliaçaoatividade.Visible = true;
                    tbavaliaçaoatividade.Text = avaliacao.avaliaçao_atividade;
                    lbfd.Enabled = false; lbfd.Visible = true;
                    tbfaltasdesconsideradas.Enabled = false; tbfaltasdesconsideradas.Visible = true;
                    tbfaltasdesconsideradas.Text = avaliacao.faltas_desconsideradas;
                    lbd.Enabled = true; lbd.Visible = true;
                    lboa.Enabled = false; lboa.Visible = true;
                    lbaal.Enabled = false; lbaal.Visible = true;
                    tbdecisaoaluno.Enabled = false; tbdecisaoaluno.Visible = true;
                    tbdecisaoaluno.Text = avaliacao.nome_aluno;
                    dataassaluno.Enabled = false; dataassaluno.Visible = true;
                    dataassaluno.Text = Convert.ToString(avaliacao.data_assinatura_aluno);
                    lbop.Enabled = false; lbop.Visible = true;
                    lbaal2.Enabled = false; lbaal2.Visible = true;
                    tbdecisaoprofessor.Enabled = true; tbdecisaoprofessor.Visible = true;
                    dataassprof.Enabled = false; dataassprof.Visible = true;
                    dataassprof.Text = hoje;
                    binserir5.Enabled = true; binserir5.Visible = true;
                    bcancelar5.Enabled = true; bcancelar5.Visible = true;
                }
                else if ((prhpagina.id_avaliaçoes != null) && (avaliacao.nome_professor != null) && Session["role"].ToString().Equals("DT"))
                {
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
                    lbda.Enabled = false; lbda.Visible = true;
                    lbati.Enabled = false; lbati.Visible = true;
                    tbatividades.Enabled = false; tbatividades.Visible = true;
                    tbatividades.Text = descricaoatividades.atividades;
                    lblocal.Enabled = false; lblocal.Visible = true;
                    tblocal1.Enabled = false; tblocal1.Visible = true;
                    tblocal1.Text = descricaoatividades.local;
                    lbrp.Enabled = false; lbrp.Visible = true;
                    lbinicio.Enabled = false; lbinicio.Visible = true;
                    lbfim.Enabled = false; lbfim.Visible = true;
                    tbinicio.Enabled = false; tbinicio.Visible = true;
                    tbinicio.Text = Convert.ToString(descricaoatividades.data_inicio.ToString("yyyy-MM-dd"));
                    tbfim.Enabled = false; tbfim.Visible = true;
                    tbfim.Text = Convert.ToString(descricaoatividades.data_final.ToString("yyyy-MM-dd"));
                    lbcumprimento.Enabled = false; lbcumprimento.Visible = true;
                    lbcumpriu.Enabled = false; lbcumpriu.Visible = true;
                    lbncumpriu.Enabled = false; lbncumpriu.Visible = true;
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
                    lbat.Enabled = false; lbat.Visible = true;
                    tbavaliaçaoatividade.Enabled = false; tbavaliaçaoatividade.Visible = true;
                    tbavaliaçaoatividade.Text = avaliacao.avaliaçao_atividade;
                    lbfd.Enabled = false; lbfd.Visible = true;
                    tbfaltasdesconsideradas.Enabled = false; tbfaltasdesconsideradas.Visible = true;
                    tbfaltasdesconsideradas.Text = avaliacao.faltas_desconsideradas;
                    lbd.Enabled = true; lbd.Visible = true;
                    lboa.Enabled = false; lboa.Visible = true;
                    lbaal.Enabled = false; lbaal.Visible = true;
                    tbdecisaoaluno.Enabled = false; tbdecisaoaluno.Visible = true;
                    tbdecisaoaluno.Text = avaliacao.nome_aluno;
                    dataassaluno.Enabled = false; dataassaluno.Visible = true;
                    dataassaluno.Text = Convert.ToString(avaliacao.data_assinatura_aluno);
                    lbop.Enabled = false; lbop.Visible = true;
                    lbaal2.Enabled = false; lbaal2.Visible = true;
                    tbdecisaoprofessor.Enabled = false; tbdecisaoprofessor.Visible = true;
                    tbdecisaoprofessor.Text = avaliacao.nome_professor;
                    dataassprof.Enabled = false; dataassprof.Visible = true;
                    dataassprof.Text = Convert.ToString(avaliacao.data_assinatura_professor);
                    lbodt.Enabled = false; lbodt.Visible = true;
                    lbaal3.Enabled = false; lbaal3.Visible = true;
                    tbdecisaodt.Enabled = true; tbdecisaodt.Visible = true;
                    dataassdt.Enabled = false; dataassdt.Visible = true;
                    dataassdt.Text = hoje;
                    binserir6.Enabled = true; binserir6.Visible = true;
                    bcancelar6.Enabled = true; bcancelar6.Visible = true;
                }
                else
                {
                    Response.Redirect("~/Home/Home.aspx");
                }

            }
        }
        public static string GenerateCoupon(int length, Random random)
        {
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }


        protected void bcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Home.aspx");
        }

        protected void cbmodalidadeea_CheckedChanged(object sender, EventArgs e)
        {
            if (cbmodalidadeea.Checked == true)
            {
                cbmodalidadertp.Checked = false;
                cbmodalidaderafal.Checked = false;
                cbmodalidaderot.Checked = false;
                cbmodalidadeo.Checked = false;
            }
        }

        protected void cbmodalidadertp_CheckedChanged(object sender, EventArgs e)
        {
            if (cbmodalidadertp.Checked == true)
            {
                cbmodalidadeea.Checked = false;
                cbmodalidaderafal.Checked = false;
                cbmodalidaderot.Checked = false;
                cbmodalidadeo.Checked = false;
            }
        }

        protected void cbmodalidaderafal_CheckedChanged(object sender, EventArgs e)
        {
            if (cbmodalidaderafal.Checked == true)
            {
                cbmodalidadeea.Checked = false;
                cbmodalidadertp.Checked = false;
                cbmodalidaderot.Checked = false;
                cbmodalidadeo.Checked = false;
            }
        }

        protected void cbmodalidaderot_CheckedChanged(object sender, EventArgs e)
        {
            if (cbmodalidaderot.Checked == true)
            {
                cbmodalidadeea.Checked = false;
                cbmodalidadertp.Checked = false;
                cbmodalidaderafal.Checked = false;
                cbmodalidadeo.Checked = false;
            }
        }

        protected void cbmodalidadeo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbmodalidadeo.Checked == true)
            {
                cbmodalidadeea.Checked = false;
                cbmodalidadertp.Checked = false;
                cbmodalidaderafal.Checked = false;
                cbmodalidaderot.Checked = false;

            }
        }

        protected void cbcumpriu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbcumpriu.Checked == true)
            {
                cbncumpriu.Checked = false;
            }
        }

        protected void cbncumpriu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbncumpriu.Checked == true)
            {
                cbcumpriu.Checked = false;
            }
        }
        protected void binserir1_Click(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["id_prh"];
            int id_prh = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_prh))
            {
                Response.Redirect("~/Home/Home.aspx");
            }

            hiddenid_prh.Value = id_prh.ToString();
            PrhPagina prhpagina = PrhDAO.GetPrhByID(id_prh);
            PrhPrincipal prhprincipal = PrhPrincipalDAO.GetPrhPrincipalByPrh(id_prh);
            Aluno aluno = AlunoDAO.GetAlunoByID(prhpagina.id_aluno);
            User user = UserDAO.GetUserByID(aluno.Id_User);

            string modalidades;
            if (cbmodalidadeea.Checked)
            {
                modalidades = "Estudo acompanhado.";
            }
            else if (cbmodalidadertp.Checked)
            {
                modalidades = "Realização de trabalhos práticos.";
            }
            else if (cbmodalidaderafal.Checked)
            {
                modalidades = "Recuperação das aulas fora das atividades letivas.";
            }
            else if (cbmodalidaderot.Checked)
            {
                modalidades = "Relatórios ou outros trabalhos.";
            }
            else
            {
                modalidades = "Outra(s):";
            }
            if (cbmodalidadeea.Checked || cbmodalidadertp.Checked || cbmodalidaderafal.Checked || cbmodalidaderot.Checked || cbmodalidadeo.Checked)
            {
                PrhPrincipal prhprincipal2 = new PrhPrincipal()
                {
                    ano_letivo = prhprincipal.ano_letivo,
                    curso = prhprincipal.curso,
                    disciplina = prhprincipal.disciplina,
                    modalidade_adotada = modalidades,
                    id_aluno = prhprincipal.id_aluno,
                    numero_aluno = prhprincipal.numero_aluno,
                    outra_modalidade = string.IsNullOrWhiteSpace(tbmodalidadesoutras.Text) ? DBNull.Value.ToString() : Convert.ToString(tbmodalidadesoutras.Text),
                    tempo_letivos_faltas = prhprincipal.tempo_letivos_faltas,
                    turma = prhprincipal.turma,
                    codigo_prhprincipal = prhprincipal.codigo_prhprincipal,
                    id_principal = prhprincipal.id_principal,
                    id_prh = prhprincipal.id_prh
                };
                int returnCode100 = PrhPrincipalDAO.UpdatePrhPrincipalByID(prhprincipal2);

                var codigo_descricao1 = GenerateCoupon(50, new Random());

                DescricaoAtividades descricaoatividades = new DescricaoAtividades()
                {
                    atividades = tbatividades.Text,
                    local = tblocal1.Text,
                    data_inicio = Convert.ToDateTime(tbinicio.Text),
                    data_final = Convert.ToDateTime(tbfim.Text),
                    codigo_descricao = codigo_descricao1,
                    id_prh = id_prh
                };
                int returnCode21 = DescricaoAtividadesDAO.InsertDescricaoAtividades(descricaoatividades);

                DescricaoAtividades descricaoatividades1 = DescricaoAtividadesDAO.GetDescricaoAtividadesByCode(descricaoatividades.codigo_descricao);

                PrhPagina prhpagina1 = new PrhPagina()
                {
                    id_aluno = prhpagina.id_aluno,
                    codigo_prh = prhpagina.codigo_prh,
                    id_avaliaçoes = null,
                    id_descricao_atividade = descricaoatividades1.id_descriçao_atividade,
                    id_dt = prhpagina.id_dt,
                    id_principal = prhpagina.id_principal,
                    id_professor = prhpagina.id_professor,
                    id_turma = prhpagina.id_turma,
                    id_prh = id_prh,
                    estado="Incompleto",
                    progresso="Falta o preenchimento do cumprimento das atividades"
                };
                int returnCode102 = PrhDAO.UpdatePrhByID(prhpagina1);


                Send_Mail(user.Email, aluno.nome, tbatividades.Text, Convert.ToDateTime(tbinicio.Text), Convert.ToDateTime(tbfim.Text), tblocal1.Text);

                Response.Write("<script>alert('Preenchimento registado com sucesso!');window.location='/Home/Home.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('Introduza uma modalidade!')</script>");
            }


        }

        private void Send_Mail(string email, string nome_aluno, string descricaoatividades, DateTime data_inicial, DateTime data_final, string locais)
        {

            int hour = DateTime.Now.Hour;
            if (hour > 6 && hour < 12)
            {
                MailMessage mailMessage = new MailMessage();

                mailMessage.From = new MailAddress("pgestplanosrecuperacao@gmail.com");
                mailMessage.To.Add(new MailAddress(email));
                mailMessage.Subject = "PGest - Planos Recuperação : Detalhes das atividades a cumprir.";

                mailMessage.Body = "Bom dia " + nome_aluno + ".<br /> <br />" +
                "Devido ao excesso de faltas justificadas terá a oportunidade de realizar um (PRH)-Plano de Recuperação de Horas, <br /> para as recuperar, que consiste num conjunto de atividades que terão um tempo para as realizar! <br />" +
                "<br /> <br /><h1>Informações</h1> <br />Atividades:" + descricaoatividades +
                "<br> As atividades terão de ser realizadas entre os dias " + data_inicial.ToString("dd/MM/yyyy") + " e " + data_final.ToString("dd/MM/yyyy") + ". <br />" +
                "No ou nos locais seguintes " + locais + ".";
                mailMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("pgestplanosrecuperacao@gmail.com", "Pgestplanosrecuperacao1234");
                smtpClient.Send(mailMessage);
            }
            else if (hour >= 12 && hour < 19)
            {
                MailMessage mailMessage = new MailMessage();

                mailMessage.From = new MailAddress("pgestplanosrecuperacao@gmail.com");
                mailMessage.To.Add(new MailAddress(email));
                mailMessage.Subject = "PGest - Planos Recuperação : Detalhes das atividades a cumprir.";

                mailMessage.Body = "Boa tarde " + nome_aluno + ".<br /> <br />" +
                "Devido ao excesso de faltas justificadas terá a oportunidade de realizar um (PRH)-Plano de Recuperação de Horas, <br /> para as recuperar, que consiste num conjunto de atividades que terão um tempo para as realizar! <br />" +
                "<br /> <br /><h1>Informações</h1> <br />Atividades:" + descricaoatividades +
                "<br> As atividades terão de ser realizadas entre os dias " + data_inicial.ToString("dd/MM/yyyy") + " e " + data_final.ToString("dd/MM/yyyy") + ". <br />" +
                "No ou nos locais seguintes " + locais + ".";
                mailMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("pgestplanosrecuperacao@gmail.com", "Pgestplanosrecuperacao1234");
                smtpClient.Send(mailMessage);
            }
            else if (hour >= 19 && hour < 24 || hour >= 0 && hour <= 6)
            {
                MailMessage mailMessage = new MailMessage();

                mailMessage.From = new MailAddress("pgestplanosrecuperacao@gmail.com");
                mailMessage.To.Add(new MailAddress(email));
                mailMessage.Subject = "PGest - Planos Recuperação : Detalhes das atividades a cumprir.";

                mailMessage.Body = "Boa noite " + nome_aluno + ".<br /> <br />" +
                "Devido ao excesso de faltas justificadas terá a oportunidade de realizar um (PRH)-Plano de Recuperação de Horas, <br /> para as recuperar, que consiste num conjunto de atividades que terão um tempo para as realizar! <br />" +
                "<br /> <br /><h1>Informações</h1> <br />Atividades:" + descricaoatividades +
                "<br> As atividades terão de ser realizadas entre os dias " + data_inicial.ToString("dd/MM/yyyy") + " e " + data_final.ToString("dd/MM/yyyy") + ". <br />" +
                "No ou nos locais seguintes " + locais + ".";
                mailMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("pgestplanosrecuperacao@gmail.com", "Pgestplanosrecuperacao1234");
                smtpClient.Send(mailMessage);
            }

        }

        protected void binserir2_Click(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["id_prh"];
            int id_prh = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_prh))
            {
                Response.Redirect("~/Home/Home.aspx");
            }

            hiddenid_prh.Value = id_prh.ToString();
            PrhPagina prhpagina = PrhDAO.GetPrhByID(id_prh);
            DescricaoAtividades descricaoatividades1 = DescricaoAtividadesDAO.GetDescricaoAtividadesByPrh(id_prh);
            string cump;
            if (cbcumpriu.Checked || cbncumpriu.Checked)
            {
                if (cbcumpriu.Checked)
                {
                    cump = "Cumpriu";
                }
                else
                {
                    cump = "Nao cumpriu";
                }
                DescricaoAtividades descricaoatividades = new DescricaoAtividades()
                {
                    atividades = descricaoatividades1.atividades,
                    local = descricaoatividades1.local,
                    data_inicio = Convert.ToDateTime(descricaoatividades1.data_inicio),
                    data_final = Convert.ToDateTime(descricaoatividades1.data_final),
                    codigo_descricao = descricaoatividades1.codigo_descricao,
                    id_prh = descricaoatividades1.id_prh,
                    cumprimento = cump,
                    id_descriçao_atividade = descricaoatividades1.id_descriçao_atividade
                };
                int returnCode102 = DescricaoAtividadesDAO.UpdateDescricaoAtividadesByID(descricaoatividades);

                PrhPagina prhpagina1 = new PrhPagina()
                {
                    id_aluno = prhpagina.id_aluno,
                    codigo_prh = prhpagina.codigo_prh,
                    id_avaliaçoes = null,
                    id_descricao_atividade = descricaoatividades1.id_descriçao_atividade,
                    id_dt = prhpagina.id_dt,
                    id_principal = prhpagina.id_principal,
                    id_professor = prhpagina.id_professor,
                    id_turma = prhpagina.id_turma,
                    id_prh = id_prh,
                    estado = "Incompleto",
                    progresso = "Falta o preenchimento da avaliação das atividades e as faltas desconcideradas"
                };
                int returnCode1 = PrhDAO.UpdatePrhByID(prhpagina1);

                Response.Write("<script>alert('Preenchimento registado com sucesso!');window.location='/Home/Home.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('Introduza o cumprimento das atividades!')</script>");
            }


        }

        protected void binserir3_Click(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["id_prh"];
            int id_prh = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_prh))
            {
                Response.Redirect("~/Home/Home.aspx");
            }

            hiddenid_prh.Value = id_prh.ToString();
            PrhPagina prhpagina = PrhDAO.GetPrhByID(id_prh);
            var codigo_avaliacao1 = GenerateCoupon(65, new Random());

            Avaliacao avaliacao = new Avaliacao()
            {
                avaliaçao_atividade = tbavaliaçaoatividade.Text,
                codigo_avaliacao = codigo_avaliacao1,
                faltas_desconsideradas = tbfaltasdesconsideradas.Text,
                id_prh = id_prh

            };
            int returnCode21 = AvaliacaoDAO.InsertAvaliacao(avaliacao);

            Avaliacao avaliacao1 = AvaliacaoDAO.GetPrhAvaliacaoByCode(avaliacao.codigo_avaliacao);

            PrhPagina prhpagina1 = new PrhPagina()
            {
                id_aluno = prhpagina.id_aluno,
                codigo_prh = prhpagina.codigo_prh,
                id_avaliaçoes = avaliacao1.id_avaliaçoes,
                id_descricao_atividade = prhpagina.id_descricao_atividade,
                id_dt = prhpagina.id_dt,
                id_principal = prhpagina.id_principal,
                id_professor = prhpagina.id_professor,
                id_turma = prhpagina.id_turma,
                id_prh = id_prh,
                estado= "Incompleto",
                progresso="Falta a assinatura do aluno"
            };
            int returnCode102 = PrhDAO.UpdatePrhByID(prhpagina1);

            Response.Write("<script>alert('Preenchimento registado com sucesso!');window.location='/Home/Home.aspx';</script>");
        }


        protected void binserir4_Click(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["id_prh"];
            int id_prh = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_prh))
            {
                Response.Redirect("~/Home/Home.aspx");
            }

            hiddenid_prh.Value = id_prh.ToString();
            Avaliacao avaliacao = AvaliacaoDAO.GetAvaliacaoByPrh(id_prh);
            DateTime hoje = DateTime.Today;
            Avaliacao avaliacao1 = new Avaliacao()
            {
                id_avaliaçoes = avaliacao.id_avaliaçoes,
                avaliaçao_atividade = avaliacao.avaliaçao_atividade,
                codigo_avaliacao = avaliacao.codigo_avaliacao,
                faltas_desconsideradas = avaliacao.faltas_desconsideradas,
                id_prh = avaliacao.id_prh,
                nome_aluno = tbdecisaoaluno.Text,
                data_assinatura_aluno = Convert.ToDateTime(hoje)

            };
            int returnCode21 = AvaliacaoDAO.UpdatePrhAlunoAvaliacaoByID(avaliacao1);

            PrhPagina prhpagina = PrhDAO.GetPrhByID(id_prh);

            PrhPagina prhpagina1 = new PrhPagina()
            {
                id_aluno = prhpagina.id_aluno,
                codigo_prh = prhpagina.codigo_prh,
                id_avaliaçoes = avaliacao1.id_avaliaçoes,
                id_descricao_atividade = prhpagina.id_descricao_atividade,
                id_dt = prhpagina.id_dt,
                id_principal = prhpagina.id_principal,
                id_professor = prhpagina.id_professor,
                id_turma = prhpagina.id_turma,
                id_prh = id_prh,
                estado = "Incompleto",
                progresso = "Falta a assinatura do professor"
            };
            int returnCode102 = PrhDAO.UpdatePrhByID(prhpagina1);

            Response.Write("<script>alert('Preenchimento registado com sucesso!');window.location='/Home/Home.aspx';</script>");
        }

        protected void binserir5_Click(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["id_prh"];
            int id_prh = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_prh))
            {
                Response.Redirect("~/Home/Home.aspx");
            }

            hiddenid_prh.Value = id_prh.ToString();
            Avaliacao avaliacao = AvaliacaoDAO.GetAvaliacaoByPrh(id_prh);
            DateTime hoje = DateTime.Today;
            Avaliacao avaliacao1 = new Avaliacao()
            {
                id_avaliaçoes = avaliacao.id_avaliaçoes,
                avaliaçao_atividade = avaliacao.avaliaçao_atividade,
                codigo_avaliacao = avaliacao.codigo_avaliacao,
                faltas_desconsideradas = avaliacao.faltas_desconsideradas,
                id_prh = avaliacao.id_prh,
                nome_professor = tbdecisaoprofessor.Text,
                data_assinatura_professor = Convert.ToDateTime(hoje)

            };
            int returnCode21 = AvaliacaoDAO.UpdatePrhProfessorAvaliacaoByID(avaliacao1);

            PrhPagina prhpagina = PrhDAO.GetPrhByID(id_prh);

            PrhPagina prhpagina1 = new PrhPagina()
            {
                id_aluno = prhpagina.id_aluno,
                codigo_prh = prhpagina.codigo_prh,
                id_avaliaçoes = avaliacao1.id_avaliaçoes,
                id_descricao_atividade = prhpagina.id_descricao_atividade,
                id_dt = prhpagina.id_dt,
                id_principal = prhpagina.id_principal,
                id_professor = prhpagina.id_professor,
                id_turma = prhpagina.id_turma,
                id_prh = id_prh,
                estado = "Incompleto",
                progresso = "Falta a assinatura do diretor de turma"
            };
            int returnCode102 = PrhDAO.UpdatePrhByID(prhpagina1);

            Response.Write("<script>alert('Preenchimento registado com sucesso!');window.location='/Home/Home.aspx';</script>");
        }

        protected void binserir6_Click(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["id_prh"];
            int id_prh = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_prh))
            {
                Response.Redirect("~/Home/Home.aspx");
            }

            hiddenid_prh.Value = id_prh.ToString();
            Avaliacao avaliacao = AvaliacaoDAO.GetAvaliacaoByPrh(id_prh);
            DateTime hoje = DateTime.Today;
            Avaliacao avaliacao1 = new Avaliacao()
            {
                id_avaliaçoes = avaliacao.id_avaliaçoes,
                avaliaçao_atividade = avaliacao.avaliaçao_atividade,
                codigo_avaliacao = avaliacao.codigo_avaliacao,
                faltas_desconsideradas = avaliacao.faltas_desconsideradas,
                id_prh = avaliacao.id_prh,
                dt_assinatura = tbdecisaodt.Text,
                data_assinatura_dt = Convert.ToDateTime(hoje)
            };
            int returnCode21 = AvaliacaoDAO.UpdatePrhDTAvaliacaoByID(avaliacao1);
            PrhPagina prhpagina = PrhDAO.GetPrhByID(id_prh);

            PrhPagina prhpagina1 = new PrhPagina()
            {
                id_aluno = prhpagina.id_aluno,
                codigo_prh = prhpagina.codigo_prh,
                id_avaliaçoes = avaliacao1.id_avaliaçoes,
                id_descricao_atividade = prhpagina.id_descricao_atividade,
                id_dt = prhpagina.id_dt,
                id_principal = prhpagina.id_principal,
                id_professor = prhpagina.id_professor,
                id_turma = prhpagina.id_turma,
                id_prh = id_prh,
                estado = "Completo",
                progresso=""
            };
            int returnCode102 = PrhDAO.UpdatePrhByID(prhpagina1);

            Response.Write("<script>alert('Preenchimento registado com sucesso!');window.location='/Home/Home.aspx';</script>");

        }
        protected void bcancelar1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Home.aspx");
        }
        protected void bcancelar2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Home.aspx");
        }
        protected void bcancelar3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Home.aspx");
        }
        protected void bcancelar4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Home.aspx");
        }
        protected void bcancelar5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Home.aspx");
        }
        protected void bcancelar6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home/Home.aspx");
        }
    }
}