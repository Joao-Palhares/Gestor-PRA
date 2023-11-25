using Gestor.Models;
using Gestor.DataAccess.UserDA;
using Gestor.DataAccess.AlunoDA;
using Gestor.DataAccess.CursoDA;
using Gestor.DataAccess.TurmaDA;
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
using Gestor.DataAccess.ProfessorDA;

namespace Gestor.Site.Home
{

    public partial class PraPreenchimento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                ndisciplinas.Enabled = false; ndisciplinas.Visible = false;
                ddldisciplina1.Enabled = false; ddldisciplina1.Visible = false;
                ddlmodulo1.Enabled = false; ddlmodulo1.Visible = false;
                tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = false;
                tbassprofdisci1.Enabled = false; tbassprofdisci1.Visible = false;
                tbdataassprof1.Enabled = false; tbdataassprof1.Visible = false;
                cbsat1.Enabled = false; cbsat1.Visible = false;
                cbnsat1.Enabled = false; cbnsat1.Visible = false;
                cbexcluido1.Enabled = false; cbexcluido1.Visible = false;

                ddldisciplina2.Enabled = false; ddldisciplina2.Visible = false;
                ddlmodulo2.Enabled = false; ddlmodulo2.Visible = false;
                tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = false;
                tbassprofdisci2.Enabled = false; tbassprofdisci2.Visible = false;
                tbdataassprof2.Enabled = false; tbdataassprof2.Visible = false;
                cbsat2.Enabled = false; cbsat2.Visible = false;
                cbnsat2.Enabled = false; cbnsat2.Visible = false;
                cbexcluido2.Enabled = false; cbexcluido2.Visible = false;

                ddldisciplina3.Enabled = false; ddldisciplina3.Visible = false;
                ddlmodulo3.Enabled = false; ddlmodulo3.Visible = false;
                tbfaltasexcesso3.Enabled = false; tbfaltasexcesso3.Visible = false;
                tbassprofdisci3.Enabled = false; tbassprofdisci3.Visible = false;
                tbdataassprof3.Enabled = false; tbdataassprof3.Visible = false;
                cbsat3.Enabled = false; cbsat3.Visible = false;
                cbnsat3.Enabled = false; cbnsat3.Visible = false;
                cbexcluido3.Enabled = false; cbexcluido3.Visible = false;

                ddldisciplina4.Enabled = false; ddldisciplina4.Visible = false;
                ddlmodulo4.Enabled = false; ddlmodulo4.Visible = false;
                tbfaltasexcesso4.Enabled = false; tbfaltasexcesso4.Visible = false;
                tbassprofdisci4.Enabled = false; tbassprofdisci4.Visible = false;
                tbdataassprof4.Enabled = false; tbdataassprof4.Visible = false;
                cbsat4.Enabled = false; cbsat4.Visible = false;
                cbnsat4.Enabled = false; cbnsat4.Visible = false;
                cbexcluido4.Enabled = false; cbexcluido4.Visible = false;

                ddldisciplina5.Enabled = false; ddldisciplina5.Visible = false;
                ddlmodulo5.Enabled = false; ddlmodulo5.Visible = false;
                tbfaltasexcesso5.Enabled = false; tbfaltasexcesso5.Visible = false;
                tbassprofdisci5.Enabled = false; tbassprofdisci5.Visible = false;
                tbdataassprof5.Enabled = false; tbdataassprof5.Visible = false;
                cbsat5.Enabled = false; cbsat5.Visible = false;
                cbnsat5.Enabled = false; cbnsat5.Visible = false;
                cbexcluido5.Enabled = false; cbexcluido5.Visible = false;

                binserir1.Enabled = false; binserir1.Visible = false;
                binserir2.Enabled = false; binserir2.Visible = false;
                binserir3.Enabled = false; binserir3.Visible = false;
                binserir5.Enabled = false; binserir5.Visible = false;
                binserir6.Enabled = false; binserir6.Visible = false;
                binserir7.Enabled = false; binserir7.Visible = false;
                binserir8.Enabled = false; binserir8.Visible = false;
                binserir9.Enabled = false; binserir9.Visible = false;
                binserir10.Enabled = false; binserir10.Visible = false;
                binserir11.Enabled = false; binserir11.Visible = false;
                binserir12.Enabled = false; binserir12.Visible = false;

                titmraiec.Enabled = false; titmraiec.Visible = false;
                lbeee.Enabled = false; lbeee.Visible = false;
                tbeee.Enabled = false; tbeee.Visible = false;
                lbrnp.Enabled = false; lbrnp.Visible = false;
                tbdataperiodoinicio.Enabled = false; tbdataperiodoinicio.Visible = false;
                lbtexta.Enabled = false; lbtexta.Visible = false;
                tbdataperiodofim.Enabled = false; tbdataperiodofim.Visible = false;

                lbmedi.Enabled = false; lbmedi.Visible = false;
                tbmedidas.Enabled = false; tbmedidas.Visible = false;

                lbcdp.Enabled = false; lbcdp.Visible = false;
                lbcdi.Enabled = false; lbcdi.Visible = false;
                lbcumprimentosim.Enabled = false; lbcumprimentosim.Visible = false;
                lbcumprimentonao.Enabled = false; lbcumprimentonao.Visible = false;
                cbcumprimentonao.Enabled = false; cbcumprimentonao.Visible = false;
                cbcumprimentosim.Enabled = false; cbcumprimentosim.Visible = false;
                cbincumprimentonao.Enabled = false; cbincumprimentonao.Visible = false;
                cbincumprimentosim.Enabled = false; cbincumprimentosim.Visible = false;
                lbincumprimentonao.Enabled = false; lbincumprimentonao.Visible = false;
                lbincumprimentosim.Enabled = false; lbincumprimentosim.Visible = false;
                datacumprimento.Enabled = false; datacumprimento.Visible = false;
                dataincumprimento.Enabled = false; dataincumprimento.Visible = false;

                lbfd.Enabled = false; lbfd.Visible = false;
                tbfaltasdesconsideradas.Enabled = false; tbfaltasdesconsideradas.Visible = false;

                lbn.Enabled = false; lbn.Visible = false;
                lbpeea.Enabled = false; lbpeea.Visible = false;
                tbpeeanotificacoes.Enabled = false; tbpeeanotificacoes.Visible = false;
                datapeeanotificacoes.Enabled = false; datapeeanotificacoes.Visible = false;

                lbdt.Enabled = false; lbdt.Visible = false;
                tbdtnotificacoes.Enabled = false; tbdtnotificacoes.Visible = false;
                datadtnotificacoes.Enabled = false; datadtnotificacoes.Visible = false;

                lbpt.Enabled = false; lbpt.Visible = false;
                tbptnotificacoes.Enabled = false; tbptnotificacoes.Visible = false;
                dataptnotificacoes.Enabled = false; dataptnotificacoes.Visible = false;

                lbcpcjr.Enabled = false; lbcpcjr.Visible = false;
                datacpcjnotificacoes.Enabled = false; datacpcjnotificacoes.Visible = false;

                lbdre.Enabled = false; lbdre.Visible = false;
                lbct.Enabled = false; lbct.Visible = false;
                datactdecisaoretencao.Enabled = false; datactdecisaoretencao.Visible = false;

                lbac.Enabled = false; lbac.Visible = false;
                cbpiaaverbamento.Enabled = false; cbpiaaverbamento.Visible = false;
                cbeadpfaverbamento.Enabled = false; cbeadpfaverbamento.Visible = false;
                cbmcsaverbamento.Enabled = false; cbmcsaverbamento.Visible = false;
                lbpia.Enabled = false; lbpia.Visible = false;
                lbeadpf.Enabled = false; lbeadpf.Visible = false;
                lbmcs.Enabled = false; lbmcs.Visible = false;
                dataeadpfaverbamento.Enabled = false; dataeadpfaverbamento.Visible = false;
                tbmedidasaverbamento.Enabled = false; tbmedidasaverbamento.Visible = false;
                lbd.Enabled = false; lbd.Visible = false;
                lbaal.Enabled = false; lbaal.Visible = false;
                tbassdiretoraverbamento.Enabled = false; tbassdiretoraverbamento.Visible = false;
                dataassdaverbamento.Enabled = false; dataassdaverbamento.Visible = false;

                lbendr.Enabled = false; lbendr.Visible = false;
                bcancelar.Enabled = false; bcancelar.Visible = false;
                lbfe.Enabled = false; lbfe.Visible = false;
                lbe.Enabled = false; lbe.Visible = false;
                lbassi.Enabled = false; lbassi.Visible = false;
                lbda.Enabled = false; lbda.Visible = false;
                lbava.Enabled = false; lbava.Visible = false;
                lbsatis.Enabled = false; lbsatis.Visible = false;
                lbnsatis.Enabled = false; lbnsatis.Visible = false;
                lbret.Enabled = false; lbret.Visible = false;
                lbexcl.Enabled = false; lbexcl.Visible = false;

                tbdisciplina1.Enabled = false; tbdisciplina1.Visible = false;
                tbdisciplina2.Enabled = false; tbdisciplina2.Visible = false;
                tbdisciplina3.Enabled = false; tbdisciplina3.Visible = false;
                tbdisciplina4.Enabled = false; tbdisciplina4.Visible = false;
                tbdisciplina5.Enabled = false; tbdisciplina5.Visible = false;
                tbmodulo1.Enabled = false; tbmodulo1.Visible = false;
                tbmodulo2.Enabled = false; tbmodulo2.Visible = false;
                tbmodulo3.Enabled = false; tbmodulo3.Visible = false;
                tbmodulo4.Enabled = false; tbmodulo4.Visible = false;
                tbmodulo5.Enabled = false; tbmodulo5.Visible = false;

                List<Disciplina> listaDisciplinas = DisciplinaDAO.GetDisciplinas();

                ddldisciplina1.DataSource = listaDisciplinas;
                ddldisciplina1.DataValueField = "id_disciplina";
                ddldisciplina1.DataTextField = "nome";
                ddldisciplina1.DataBind();

                List<Disciplina> listaDisciplinas2 = DisciplinaDAO.GetDisciplinas();

                ddldisciplina2.DataSource = listaDisciplinas2;
                ddldisciplina2.DataValueField = "id_disciplina";
                ddldisciplina2.DataTextField = "nome";
                ddldisciplina2.DataBind();

                List<Disciplina> listaDisciplinas3 = DisciplinaDAO.GetDisciplinas();

                ddldisciplina3.DataSource = listaDisciplinas3;
                ddldisciplina3.DataValueField = "id_disciplina";
                ddldisciplina3.DataTextField = "nome";
                ddldisciplina3.DataBind();

                List<Disciplina> listaDisciplinas4 = DisciplinaDAO.GetDisciplinas();

                ddldisciplina4.DataSource = listaDisciplinas4;
                ddldisciplina4.DataValueField = "id_disciplina";
                ddldisciplina4.DataTextField = "nome";
                ddldisciplina4.DataBind();

                List<Disciplina> listaDisciplinas5 = DisciplinaDAO.GetDisciplinas();

                ddldisciplina5.DataSource = listaDisciplinas5;
                ddldisciplina5.DataValueField = "id_disciplina";
                ddldisciplina5.DataTextField = "nome";
                ddldisciplina5.DataBind();



                List<Modulo> listaModulos1 = ModuloDAO.GetModuloWhereDisciplina(Convert.ToInt32(ddldisciplina1.SelectedValue));

                ddlmodulo1.DataSource = listaModulos1;
                ddlmodulo1.DataValueField = "id_modulo";
                ddlmodulo1.DataTextField = "nome";
                ddlmodulo1.DataBind();

                List<Modulo> listaModulos2 = ModuloDAO.GetModuloWhereDisciplina(Convert.ToInt32(ddldisciplina2.SelectedValue));

                ddlmodulo2.DataSource = listaModulos2;
                ddlmodulo2.DataValueField = "id_modulo";
                ddlmodulo2.DataTextField = "nome";
                ddlmodulo2.DataBind();

                List<Modulo> listaModulos3 = ModuloDAO.GetModuloWhereDisciplina(Convert.ToInt32(ddldisciplina3.SelectedValue));

                ddlmodulo3.DataSource = listaModulos3;
                ddlmodulo3.DataValueField = "id_modulo";
                ddlmodulo3.DataTextField = "nome";
                ddlmodulo3.DataBind();

                List<Modulo> listaModulos4 = ModuloDAO.GetModuloWhereDisciplina(Convert.ToInt32(ddldisciplina4.SelectedValue));

                ddlmodulo4.DataSource = listaModulos4;
                ddlmodulo4.DataValueField = "id_modulo";
                ddlmodulo4.DataTextField = "nome";
                ddlmodulo4.DataBind();

                List<Modulo> listaModulos5 = ModuloDAO.GetModuloWhereDisciplina(Convert.ToInt32(ddldisciplina5.SelectedValue));

                ddlmodulo5.DataSource = listaModulos5;
                ddlmodulo5.DataValueField = "id_modulo";
                ddlmodulo5.DataTextField = "nome";
                ddlmodulo5.DataBind();

                string hoje = DateTime.Today.ToString("yyyy-MM-dd");

                /*if (Session["role"].ToString() == "U")
                {
                    Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
                }*/
                string rawID = Request.QueryString["id_pra"];
                int id_pra = -1;

                if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_pra))
                {
                    Response.Redirect("~/Home/Home.aspx");
                }

                int iduser = Convert.ToInt32(Session["id_user"]);
                Professor professor = ProfessorDAO.GetProfessorByUserID(iduser);
                hiddenid_pra.Value = id_pra.ToString();
                ndisciplinas.SelectedIndex = 0;

                PraPagina prapagina1001 = PraDAO.GetPraByID(id_pra);
                DM dm1001 = DMDAO.GetDMByPra(id_pra);
                DM dm1002 = DMDAO.GetDMByPra2(id_pra);
                DM dm1003 = DMDAO.GetDMByPra3(id_pra);
                DM dm1004 = DMDAO.GetDMByPra4(id_pra);
                DM dm1005 = DMDAO.GetDMByPra5(id_pra);
                Decisao decisao1001 = DecisaoDAO.GetPraDecisaoByPra(id_pra);
                PraPrincipal praprincipal1001 = PraPrincipalDAO.GetPraPrincipalByPra(id_pra);
                Medidas medidas1001 = MedidasDAO.GetPraMedidasByPra(id_pra);
                Notificacoes notificacoes1001 = NotificacoesDAO.GetPraNotificacoesByPra(id_pra);
                int ndis = Convert.ToInt32(ndisciplinas.SelectedValue);
                if ((prapagina1001.id_medidas == null) && (prapagina1001.id_professor1 == null) && Session["role"].ToString().Equals("DT"))
                {
                    lbdmtt.Enabled = true; lbdmtt.Visible = true;
                    lbendr.Enabled = true; lbendr.Visible = true;
                    lbfe.Enabled = true; lbfe.Visible = true;
                    lbe.Enabled = true; lbe.Visible = true;
                    ndisciplinas.Enabled = true; ndisciplinas.Visible = true;
                    lbdmtt.Enabled = true; lbdmtt.Visible = true;
                    ddldisciplina1.Enabled = true; ddldisciplina1.Visible = true;
                    ddlmodulo1.Enabled = true; ddlmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = true; tbfaltasexcesso1.Visible = true;
                    binserir1.Enabled = true; binserir1.Visible = true;
                }
                else if ((prapagina1001.id_medidas == null) && (prapagina1001.id_professor1 != null) && Session["role"].ToString().Equals("DT"))
                {
                    int? ndisc = prapagina1001.ndisciplinas;


                    if (ndisc == 1)
                    {
                        DM dm1 = DMDAO.GetDMByID1(prapagina1001.id_dm1);
                        Disciplina disciplina1 = DisciplinaDAO.GetDisciplinasByModulo(dm1.disciplina_modulo);
                        Modulo modulo1 = ModuloDAO.GetModuloByID(dm1.disciplina_modulo);
                        ddldisciplina1.Enabled = false; ddldisciplina1.Visible = false;
                        ddldisciplina2.Enabled = false; ddldisciplina2.Visible = false;
                        ddldisciplina3.Enabled = false; ddldisciplina3.Visible = false;
                        ddldisciplina4.Enabled = false; ddldisciplina4.Visible = false;
                        ddldisciplina5.Enabled = false; ddldisciplina5.Visible = false;
                        ddlmodulo1.Enabled = false; ddlmodulo1.Visible = false;
                        ddlmodulo2.Enabled = false; ddlmodulo2.Visible = false;
                        ddlmodulo3.Enabled = false; ddlmodulo3.Visible = false;
                        ddlmodulo4.Enabled = false; ddlmodulo4.Visible = false;
                        ddlmodulo5.Enabled = false; ddlmodulo5.Visible = false;
                        tbdisciplina1.Text = Convert.ToString(disciplina1.nome);
                        tbmodulo1.Text = Convert.ToString(modulo1.nome);
                        tbfaltasexcesso1.Text = Convert.ToString(dm1.faltas_excesso);
                        tbdisciplina1.Enabled = false; tbdisciplina1.Visible = true;
                        tbmodulo1.Enabled = false; tbmodulo1.Visible = true;
                        tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                    }
                    else if (ndisc == 2)
                    {
                        DM dm1 = DMDAO.GetDMByID1(prapagina1001.id_dm1);
                        DM2 dm2 = DMDAO.GetDMByID2(prapagina1001.id_dm2);
                        Disciplina disciplina1 = DisciplinaDAO.GetDisciplinasByModulo(dm1.disciplina_modulo);
                        Disciplina disciplina2 = DisciplinaDAO.GetDisciplinasByModulo(dm2.disciplina_modulo);
                        Modulo modulo1 = ModuloDAO.GetModuloByID(dm1.disciplina_modulo);
                        Modulo modulo2 = ModuloDAO.GetModuloByID(dm2.disciplina_modulo);
                        ddldisciplina1.Enabled = false; ddldisciplina1.Visible = false;
                        ddldisciplina2.Enabled = false; ddldisciplina2.Visible = false;
                        ddldisciplina3.Enabled = false; ddldisciplina3.Visible = false;
                        ddldisciplina4.Enabled = false; ddldisciplina4.Visible = false;
                        ddldisciplina5.Enabled = false; ddldisciplina5.Visible = false;
                        ddlmodulo1.Enabled = false; ddlmodulo1.Visible = false;
                        ddlmodulo2.Enabled = false; ddlmodulo2.Visible = false;
                        ddlmodulo3.Enabled = false; ddlmodulo3.Visible = false;
                        ddlmodulo4.Enabled = false; ddlmodulo4.Visible = false;
                        ddlmodulo5.Enabled = false; ddlmodulo5.Visible = false;
                        tbdisciplina1.Text = Convert.ToString(disciplina1.nome);
                        tbmodulo1.Text = Convert.ToString(modulo1.nome);
                        tbfaltasexcesso1.Text = Convert.ToString(dm1.faltas_excesso);
                        tbdisciplina2.Text = Convert.ToString(disciplina2.nome);
                        tbmodulo2.Text = Convert.ToString(modulo2.nome);
                        tbfaltasexcesso2.Text = Convert.ToString(dm2.faltas_excesso);
                        tbdisciplina1.Enabled = false; tbdisciplina1.Visible = true;
                        tbmodulo1.Enabled = false; tbmodulo1.Visible = true;
                        tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                        tbdisciplina2.Enabled = false; tbdisciplina2.Visible = true;
                        tbmodulo2.Enabled = false; tbmodulo2.Visible = true;
                        tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = true;
                    }
                    else if (ndisc == 3)
                    {
                        DM dm1 = DMDAO.GetDMByID1(prapagina1001.id_dm1);
                        DM2 dm2 = DMDAO.GetDMByID2(prapagina1001.id_dm2);
                        DM3 dm3 = DMDAO.GetDMByID3(prapagina1001.id_dm3);
                        Disciplina disciplina1 = DisciplinaDAO.GetDisciplinasByModulo(dm1.disciplina_modulo);
                        Disciplina disciplina2 = DisciplinaDAO.GetDisciplinasByModulo(dm2.disciplina_modulo);
                        Disciplina disciplina3 = DisciplinaDAO.GetDisciplinasByModulo(dm3.disciplina_modulo);
                        Modulo modulo1 = ModuloDAO.GetModuloByID(dm1.disciplina_modulo);
                        Modulo modulo2 = ModuloDAO.GetModuloByID(dm2.disciplina_modulo);
                        Modulo modulo3 = ModuloDAO.GetModuloByID(dm3.disciplina_modulo);
                        ddldisciplina1.Enabled = false; ddldisciplina1.Visible = false;
                        ddldisciplina2.Enabled = false; ddldisciplina2.Visible = false;
                        ddldisciplina3.Enabled = false; ddldisciplina3.Visible = false;
                        ddldisciplina4.Enabled = false; ddldisciplina4.Visible = false;
                        ddldisciplina5.Enabled = false; ddldisciplina5.Visible = false;
                        ddlmodulo1.Enabled = false; ddlmodulo1.Visible = false;
                        ddlmodulo2.Enabled = false; ddlmodulo2.Visible = false;
                        ddlmodulo3.Enabled = false; ddlmodulo3.Visible = false;
                        ddlmodulo4.Enabled = false; ddlmodulo4.Visible = false;
                        ddlmodulo5.Enabled = false; ddlmodulo5.Visible = false;
                        tbdisciplina1.Text = Convert.ToString(disciplina1.nome);
                        tbmodulo1.Text = Convert.ToString(modulo1.nome);
                        tbfaltasexcesso1.Text = Convert.ToString(dm1.faltas_excesso);
                        tbdisciplina2.Text = Convert.ToString(disciplina2.nome);
                        tbmodulo2.Text = Convert.ToString(modulo2.nome);
                        tbfaltasexcesso2.Text = Convert.ToString(dm2.faltas_excesso);
                        tbdisciplina3.Text = Convert.ToString(disciplina3.nome);
                        tbmodulo3.Text = Convert.ToString(modulo3.nome);
                        tbfaltasexcesso3.Text = Convert.ToString(dm3.faltas_excesso);

                        tbdisciplina1.Enabled = false; tbdisciplina1.Visible = true;
                        tbmodulo1.Enabled = false; tbmodulo1.Visible = true;
                        tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                        tbdisciplina2.Enabled = false; tbdisciplina2.Visible = true;
                        tbmodulo2.Enabled = false; tbmodulo2.Visible = true;
                        tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = true;
                        tbdisciplina3.Enabled = false; tbdisciplina3.Visible = true;
                        tbmodulo3.Enabled = false; tbmodulo3.Visible = true;
                        tbfaltasexcesso3.Enabled = false; tbfaltasexcesso3.Visible = true;
                    }
                    else if (ndisc == 4)
                    {
                        DM dm1 = DMDAO.GetDMByID1(prapagina1001.id_dm1);
                        DM2 dm2 = DMDAO.GetDMByID2(prapagina1001.id_dm2);
                        DM3 dm3 = DMDAO.GetDMByID3(prapagina1001.id_dm3);
                        DM4 dm4 = DMDAO.GetDMByID4(prapagina1001.id_dm4);
                        Disciplina disciplina1 = DisciplinaDAO.GetDisciplinasByModulo(dm1.disciplina_modulo);
                        Disciplina disciplina2 = DisciplinaDAO.GetDisciplinasByModulo(dm2.disciplina_modulo);
                        Disciplina disciplina3 = DisciplinaDAO.GetDisciplinasByModulo(dm3.disciplina_modulo);
                        Disciplina disciplina4 = DisciplinaDAO.GetDisciplinasByModulo(dm4.disciplina_modulo);
                        Modulo modulo1 = ModuloDAO.GetModuloByID(dm1.disciplina_modulo);
                        Modulo modulo2 = ModuloDAO.GetModuloByID(dm2.disciplina_modulo);
                        Modulo modulo3 = ModuloDAO.GetModuloByID(dm3.disciplina_modulo);
                        Modulo modulo4 = ModuloDAO.GetModuloByID(dm4.disciplina_modulo);

                        ddldisciplina1.Enabled = false; ddldisciplina1.Visible = false;
                        ddldisciplina2.Enabled = false; ddldisciplina2.Visible = false;
                        ddldisciplina3.Enabled = false; ddldisciplina3.Visible = false;
                        ddldisciplina4.Enabled = false; ddldisciplina4.Visible = false;
                        ddldisciplina5.Enabled = false; ddldisciplina5.Visible = false;
                        ddlmodulo1.Enabled = false; ddlmodulo1.Visible = false;
                        ddlmodulo2.Enabled = false; ddlmodulo2.Visible = false;
                        ddlmodulo3.Enabled = false; ddlmodulo3.Visible = false;
                        ddlmodulo4.Enabled = false; ddlmodulo4.Visible = false;
                        ddlmodulo5.Enabled = false; ddlmodulo5.Visible = false;

                        tbdisciplina1.Text = Convert.ToString(disciplina1.nome);
                        tbmodulo1.Text = Convert.ToString(modulo1.nome);
                        tbfaltasexcesso1.Text = Convert.ToString(dm1.faltas_excesso);
                        tbdisciplina2.Text = Convert.ToString(disciplina2.nome);
                        tbmodulo2.Text = Convert.ToString(modulo2.nome);
                        tbfaltasexcesso2.Text = Convert.ToString(dm2.faltas_excesso);
                        tbdisciplina3.Text = Convert.ToString(disciplina3.nome);
                        tbmodulo3.Text = Convert.ToString(modulo3.nome);
                        tbfaltasexcesso3.Text = Convert.ToString(dm3.faltas_excesso);
                        tbdisciplina4.Text = Convert.ToString(disciplina4.nome);
                        tbmodulo4.Text = Convert.ToString(modulo4.nome);
                        tbfaltasexcesso4.Text = Convert.ToString(dm4.faltas_excesso);

                        tbdisciplina1.Enabled = false; tbdisciplina1.Visible = true;
                        tbmodulo1.Enabled = false; tbmodulo1.Visible = true;
                        tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                        tbdisciplina2.Enabled = false; tbdisciplina2.Visible = true;
                        tbmodulo2.Enabled = false; tbmodulo2.Visible = true;
                        tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = true;
                        tbdisciplina3.Enabled = false; tbdisciplina3.Visible = true;
                        tbmodulo3.Enabled = false; tbmodulo3.Visible = true;
                        tbfaltasexcesso3.Enabled = false; tbfaltasexcesso3.Visible = true;
                        tbdisciplina4.Enabled = false; tbdisciplina4.Visible = true;
                        tbmodulo4.Enabled = false; tbmodulo4.Visible = true;
                        tbfaltasexcesso4.Enabled = false; tbfaltasexcesso4.Visible = true;


                    }
                    else if (ndisc == 5)
                    {
                        DM dm1 = DMDAO.GetDMByID1(prapagina1001.id_dm1);
                        DM2 dm2 = DMDAO.GetDMByID2(prapagina1001.id_dm2);
                        DM3 dm3 = DMDAO.GetDMByID3(prapagina1001.id_dm3);
                        DM4 dm4 = DMDAO.GetDMByID4(prapagina1001.id_dm4);
                        DM5 dm5 = DMDAO.GetDMByID5(prapagina1001.id_dm5);
                        Disciplina disciplina1 = DisciplinaDAO.GetDisciplinasByModulo(dm1.disciplina_modulo);
                        Disciplina disciplina2 = DisciplinaDAO.GetDisciplinasByModulo(dm2.disciplina_modulo);
                        Disciplina disciplina3 = DisciplinaDAO.GetDisciplinasByModulo(dm3.disciplina_modulo);
                        Disciplina disciplina4 = DisciplinaDAO.GetDisciplinasByModulo(dm4.disciplina_modulo);
                        Disciplina disciplina5 = DisciplinaDAO.GetDisciplinasByModulo(dm5.disciplina_modulo);
                        Modulo modulo1 = ModuloDAO.GetModuloByID(dm1.disciplina_modulo);
                        Modulo modulo2 = ModuloDAO.GetModuloByID(dm2.disciplina_modulo);
                        Modulo modulo3 = ModuloDAO.GetModuloByID(dm3.disciplina_modulo);
                        Modulo modulo4 = ModuloDAO.GetModuloByID(dm4.disciplina_modulo);
                        Modulo modulo5 = ModuloDAO.GetModuloByID(dm5.disciplina_modulo);
                        ddldisciplina1.Enabled = false; ddldisciplina1.Visible = false;
                        ddldisciplina2.Enabled = false; ddldisciplina2.Visible = false;
                        ddldisciplina3.Enabled = false; ddldisciplina3.Visible = false;
                        ddldisciplina4.Enabled = false; ddldisciplina4.Visible = false;
                        ddldisciplina5.Enabled = false; ddldisciplina5.Visible = false;
                        ddlmodulo1.Enabled = false; ddlmodulo1.Visible = false;
                        ddlmodulo2.Enabled = false; ddlmodulo2.Visible = false;
                        ddlmodulo3.Enabled = false; ddlmodulo3.Visible = false;
                        ddlmodulo4.Enabled = false; ddlmodulo4.Visible = false;
                        ddlmodulo5.Enabled = false; ddlmodulo5.Visible = false;

                        tbdisciplina1.Text = Convert.ToString(disciplina1.nome);
                        tbmodulo1.Text = Convert.ToString(modulo1.nome);
                        tbfaltasexcesso1.Text = Convert.ToString(dm1.faltas_excesso);
                        tbdisciplina2.Text = Convert.ToString(disciplina2.nome);
                        tbmodulo2.Text = Convert.ToString(modulo2.nome);
                        tbfaltasexcesso2.Text = Convert.ToString(dm2.faltas_excesso);
                        tbdisciplina3.Text = Convert.ToString(disciplina3.nome);
                        tbmodulo3.Text = Convert.ToString(modulo3.nome);
                        tbfaltasexcesso3.Text = Convert.ToString(dm3.faltas_excesso);
                        tbdisciplina4.Text = Convert.ToString(disciplina4.nome);
                        tbmodulo4.Text = Convert.ToString(modulo4.nome);
                        tbfaltasexcesso4.Text = Convert.ToString(dm4.faltas_excesso);
                        tbdisciplina5.Text = Convert.ToString(disciplina5.nome);
                        tbmodulo5.Text = Convert.ToString(modulo5.nome);
                        tbfaltasexcesso5.Text = Convert.ToString(dm5.faltas_excesso);

                        tbdisciplina1.Enabled = false; tbdisciplina1.Visible = true;
                        tbmodulo1.Enabled = false; tbmodulo1.Visible = true;
                        tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                        tbdisciplina2.Enabled = false; tbdisciplina2.Visible = true;
                        tbmodulo2.Enabled = false; tbmodulo2.Visible = true;
                        tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = true;
                        tbdisciplina3.Enabled = false; tbdisciplina3.Visible = true;
                        tbmodulo3.Enabled = false; tbmodulo3.Visible = true;
                        tbfaltasexcesso3.Enabled = false; tbfaltasexcesso3.Visible = true;
                        tbdisciplina4.Enabled = false; tbdisciplina4.Visible = true;
                        tbmodulo4.Enabled = false; tbmodulo4.Visible = true;
                        tbfaltasexcesso4.Enabled = false; tbfaltasexcesso4.Visible = true;
                        tbdisciplina5.Enabled = false; tbdisciplina5.Visible = true;
                        tbmodulo5.Enabled = false; tbmodulo5.Visible = true;
                        tbfaltasexcesso5.Enabled = false; tbfaltasexcesso5.Visible = true;
                    }
                    lbdmtt.Enabled = false; lbdmtt.Visible = true;
                    lbendr.Enabled = false; lbendr.Visible = false;
                    ndisciplinas.Enabled = false; ndisciplinas.Visible = false;
                    lbfe.Enabled = true; lbfe.Visible = true;
                    lbe.Enabled = true; lbe.Visible = true;
                    lbdmtt.Enabled = false; lbdmtt.Visible = true;
                    ddldisciplina1.Enabled = false; ddldisciplina1.Visible = false;
                    ddlmodulo1.Enabled = false; ddlmodulo1.Visible = false;
                    tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                    titmraiec.Enabled = true; titmraiec.Visible = true;
                    lbeee.Enabled = true; lbeee.Visible = true;
                    tbeee.Enabled = true; tbeee.Visible = true;
                    lbrnp.Enabled = true; lbrnp.Visible = true;
                    tbdataperiodoinicio.Enabled = true; tbdataperiodoinicio.Visible = true;
                    lbtexta.Enabled = true; lbtexta.Visible = true;
                    tbdataperiodofim.Enabled = true; tbdataperiodofim.Visible = true;
                    lbmedi.Enabled = true; lbmedi.Visible = true;
                    tbmedidas.Enabled = true; tbmedidas.Visible = true;
                    binserir3.Enabled = true; binserir3.Visible = true;

                }
                else if ((prapagina1001.id_medidas != null) && (professor.Id_Professor == prapagina1001.id_professor1) && Session["role"].ToString().Equals("PR"))
                {
                    tbdisciplina1.Enabled = false; tbdisciplina1.Visible = true;
                    tbmodulo1.Enabled = false; tbmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                    tbdisciplina2.Enabled = false; tbdisciplina2.Visible = true;
                    tbmodulo2.Enabled = false; tbmodulo2.Visible = true;
                    tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = true;
                    tbdisciplina3.Enabled = false; tbdisciplina3.Visible = true;
                    tbmodulo3.Enabled = false; tbmodulo3.Visible = true;
                    tbfaltasexcesso3.Enabled = false; tbfaltasexcesso3.Visible = true;
                    tbdisciplina4.Enabled = false; tbdisciplina4.Visible = true;
                    tbmodulo4.Enabled = false; tbmodulo4.Visible = true;
                    tbfaltasexcesso4.Enabled = false; tbfaltasexcesso4.Visible = true;
                    tbdisciplina5.Enabled = false; tbdisciplina5.Visible = true;
                    tbmodulo5.Enabled = false; tbmodulo5.Visible = true;
                    tbfaltasexcesso5.Enabled = false; tbfaltasexcesso5.Visible = true;
                    tbassprofdisci1.Enabled = true; tbassprofdisci1.Visible = true;
                    tbdataassprof1.Enabled = true; tbdataassprof1.Visible = true;
                    cbsat1.Enabled = true; cbsat1.Visible = true;
                    cbnsat1.Enabled = true; cbnsat1.Visible = true;
                    cbexcluido1.Enabled = true; cbexcluido1.Visible = true;

                    lbeee.Enabled = true; lbeee.Visible = true;
                    tbeee.Enabled = false; tbeee.Visible = true;
                    lbrnp.Enabled = false; lbrnp.Visible = true;
                    tbdataperiodoinicio.Enabled = false; tbdataperiodoinicio.Visible = true;
                    lbtexta.Enabled = false; lbtexta.Visible = true;
                    tbdataperiodofim.Enabled = false; tbdataperiodofim.Visible = true;
                    lbmedi.Enabled = false; lbmedi.Visible = true;
                    tbmedidas.Enabled = false; tbmedidas.Visible = true;
                }
                else if ((prapagina1001.id_medidas != null) && (professor.Id_Professor == prapagina1001.id_professor2) && Session["role"].ToString().Equals("PR"))
                {
                    tbdisciplina1.Enabled = false; tbdisciplina1.Visible = true;
                    tbmodulo1.Enabled = false; tbmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                    tbdisciplina2.Enabled = false; tbdisciplina2.Visible = true;
                    tbmodulo2.Enabled = false; tbmodulo2.Visible = true;
                    tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = true;
                    tbdisciplina3.Enabled = false; tbdisciplina3.Visible = true;
                    tbmodulo3.Enabled = false; tbmodulo3.Visible = true;
                    tbfaltasexcesso3.Enabled = false; tbfaltasexcesso3.Visible = true;
                    tbdisciplina4.Enabled = false; tbdisciplina4.Visible = true;
                    tbmodulo4.Enabled = false; tbmodulo4.Visible = true;
                    tbfaltasexcesso4.Enabled = false; tbfaltasexcesso4.Visible = true;
                    tbdisciplina5.Enabled = false; tbdisciplina5.Visible = true;
                    tbmodulo5.Enabled = false; tbmodulo5.Visible = true;
                    tbfaltasexcesso5.Enabled = false; tbfaltasexcesso5.Visible = true;

                    tbassprofdisci1.Enabled = false; tbassprofdisci1.Visible = true;
                    tbdataassprof1.Enabled = false; tbdataassprof1.Visible = true;
                    cbsat1.Enabled = false; cbsat1.Visible = true;
                    cbnsat1.Enabled = false; cbnsat1.Visible = true;
                    cbexcluido1.Enabled = false; cbexcluido1.Visible = true;

                    tbassprofdisci2.Enabled = true; tbassprofdisci2.Visible = true;
                    tbdataassprof2.Enabled = true; tbdataassprof2.Visible = true;
                    cbsat2.Enabled = true; cbsat2.Visible = true;
                    cbnsat2.Enabled = true; cbnsat2.Visible = true;
                    cbexcluido2.Enabled = true; cbexcluido2.Visible = true;

                    lbeee.Enabled = true; lbeee.Visible = true;
                    tbeee.Enabled = false; tbeee.Visible = true;
                    lbrnp.Enabled = false; lbrnp.Visible = true;
                    tbdataperiodoinicio.Enabled = false; tbdataperiodoinicio.Visible = true;
                    lbtexta.Enabled = false; lbtexta.Visible = true;
                    tbdataperiodofim.Enabled = false; tbdataperiodofim.Visible = true;
                    lbmedi.Enabled = false; lbmedi.Visible = true;
                    tbmedidas.Enabled = false; tbmedidas.Visible = true;

                }
                else if ((prapagina1001.id_medidas != null) && (professor.Id_Professor == prapagina1001.id_professor3) && Session["role"].ToString().Equals("PR"))
                {
                    tbdisciplina1.Enabled = false; tbdisciplina1.Visible = true;
                    tbmodulo1.Enabled = false; tbmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                    tbdisciplina2.Enabled = false; tbdisciplina2.Visible = true;
                    tbmodulo2.Enabled = false; tbmodulo2.Visible = true;
                    tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = true;
                    tbdisciplina3.Enabled = false; tbdisciplina3.Visible = true;
                    tbmodulo3.Enabled = false; tbmodulo3.Visible = true;
                    tbfaltasexcesso3.Enabled = false; tbfaltasexcesso3.Visible = true;
                    tbdisciplina4.Enabled = false; tbdisciplina4.Visible = true;
                    tbmodulo4.Enabled = false; tbmodulo4.Visible = true;
                    tbfaltasexcesso4.Enabled = false; tbfaltasexcesso4.Visible = true;
                    tbdisciplina5.Enabled = false; tbdisciplina5.Visible = true;
                    tbmodulo5.Enabled = false; tbmodulo5.Visible = true;
                    tbfaltasexcesso5.Enabled = false; tbfaltasexcesso5.Visible = true;

                    tbassprofdisci1.Enabled = false; tbassprofdisci1.Visible = true;
                    tbdataassprof1.Enabled = false; tbdataassprof1.Visible = true;
                    cbsat1.Enabled = false; cbsat1.Visible = true;
                    cbnsat1.Enabled = false; cbnsat1.Visible = true;
                    cbexcluido1.Enabled = false; cbexcluido1.Visible = true;

                    tbassprofdisci2.Enabled = false; tbassprofdisci2.Visible = true;
                    tbdataassprof2.Enabled = false; tbdataassprof2.Visible = true;
                    cbsat2.Enabled = false; cbsat2.Visible = true;
                    cbnsat2.Enabled = false; cbnsat2.Visible = true;
                    cbexcluido2.Enabled = false; cbexcluido2.Visible = true;

                    tbassprofdisci3.Enabled = true; tbassprofdisci3.Visible = true;
                    tbdataassprof3.Enabled = true; tbdataassprof3.Visible = true;
                    cbsat3.Enabled = true; cbsat3.Visible = true;
                    cbnsat3.Enabled = true; cbnsat3.Visible = true;
                    cbexcluido3.Enabled = true; cbexcluido3.Visible = true;

                    lbeee.Enabled = true; lbeee.Visible = true;
                    tbeee.Enabled = false; tbeee.Visible = true;
                    lbrnp.Enabled = false; lbrnp.Visible = true;
                    tbdataperiodoinicio.Enabled = false; tbdataperiodoinicio.Visible = true;
                    lbtexta.Enabled = false; lbtexta.Visible = true;
                    tbdataperiodofim.Enabled = false; tbdataperiodofim.Visible = true;
                    lbmedi.Enabled = false; lbmedi.Visible = true;
                    tbmedidas.Enabled = false; tbmedidas.Visible = true;
                }
                else if ((prapagina1001.id_medidas != null) && (professor.Id_Professor == prapagina1001.id_professor4) && Session["role"].ToString().Equals("PR"))
                {
                    tbdisciplina1.Enabled = false; tbdisciplina1.Visible = true;
                    tbmodulo1.Enabled = false; tbmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                    tbdisciplina2.Enabled = false; tbdisciplina2.Visible = true;
                    tbmodulo2.Enabled = false; tbmodulo2.Visible = true;
                    tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = true;
                    tbdisciplina3.Enabled = false; tbdisciplina3.Visible = true;
                    tbmodulo3.Enabled = false; tbmodulo3.Visible = true;
                    tbfaltasexcesso3.Enabled = false; tbfaltasexcesso3.Visible = true;
                    tbdisciplina4.Enabled = false; tbdisciplina4.Visible = true;
                    tbmodulo4.Enabled = false; tbmodulo4.Visible = true;
                    tbfaltasexcesso4.Enabled = false; tbfaltasexcesso4.Visible = true;
                    tbdisciplina5.Enabled = false; tbdisciplina5.Visible = true;
                    tbmodulo5.Enabled = false; tbmodulo5.Visible = true;
                    tbfaltasexcesso5.Enabled = false; tbfaltasexcesso5.Visible = true;

                    tbassprofdisci1.Enabled = false; tbassprofdisci1.Visible = true;
                    tbdataassprof1.Enabled = false; tbdataassprof1.Visible = true;
                    cbsat1.Enabled = false; cbsat1.Visible = true;
                    cbnsat1.Enabled = false; cbnsat1.Visible = true;
                    cbexcluido1.Enabled = false; cbexcluido1.Visible = true;

                    tbassprofdisci2.Enabled = false; tbassprofdisci2.Visible = true;
                    tbdataassprof2.Enabled = false; tbdataassprof2.Visible = true;
                    cbsat2.Enabled = false; cbsat2.Visible = true;
                    cbnsat2.Enabled = false; cbnsat2.Visible = true;
                    cbexcluido2.Enabled = false; cbexcluido2.Visible = true;

                    tbassprofdisci3.Enabled = false; tbassprofdisci3.Visible = true;
                    tbdataassprof3.Enabled = false; tbdataassprof3.Visible = true;
                    cbsat3.Enabled = false; cbsat3.Visible = true;
                    cbnsat3.Enabled = false; cbnsat3.Visible = true;
                    cbexcluido3.Enabled = false; cbexcluido3.Visible = true;

                    tbassprofdisci4.Enabled = true; tbassprofdisci4.Visible = true;
                    tbdataassprof4.Enabled = true; tbdataassprof4.Visible = true;
                    cbsat4.Enabled = true; cbsat4.Visible = true;
                    cbnsat4.Enabled = true; cbnsat4.Visible = true;
                    cbexcluido4.Enabled = true; cbexcluido4.Visible = true;

                    lbeee.Enabled = true; lbeee.Visible = true;
                    tbeee.Enabled = false; tbeee.Visible = true;
                    lbrnp.Enabled = false; lbrnp.Visible = true;
                    tbdataperiodoinicio.Enabled = false; tbdataperiodoinicio.Visible = true;
                    lbtexta.Enabled = false; lbtexta.Visible = true;
                    tbdataperiodofim.Enabled = false; tbdataperiodofim.Visible = true;
                    lbmedi.Enabled = false; lbmedi.Visible = true;
                    tbmedidas.Enabled = false; tbmedidas.Visible = true;
                }
                else if ((prapagina1001.id_medidas != null) && (professor.Id_Professor == prapagina1001.id_professor5) && Session["role"].ToString().Equals("PR"))
                {
                    tbdisciplina1.Enabled = false; tbdisciplina1.Visible = true;
                    tbmodulo1.Enabled = false; tbmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                    tbdisciplina2.Enabled = false; tbdisciplina2.Visible = true;
                    tbmodulo2.Enabled = false; tbmodulo2.Visible = true;
                    tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = true;
                    tbdisciplina3.Enabled = false; tbdisciplina3.Visible = true;
                    tbmodulo3.Enabled = false; tbmodulo3.Visible = true;
                    tbfaltasexcesso3.Enabled = false; tbfaltasexcesso3.Visible = true;
                    tbdisciplina4.Enabled = false; tbdisciplina4.Visible = true;
                    tbmodulo4.Enabled = false; tbmodulo4.Visible = true;
                    tbfaltasexcesso4.Enabled = false; tbfaltasexcesso4.Visible = true;
                    tbdisciplina5.Enabled = false; tbdisciplina5.Visible = true;
                    tbmodulo5.Enabled = false; tbmodulo5.Visible = true;
                    tbfaltasexcesso5.Enabled = false; tbfaltasexcesso5.Visible = true;

                    tbassprofdisci1.Enabled = false; tbassprofdisci1.Visible = true;
                    tbdataassprof1.Enabled = false; tbdataassprof1.Visible = true;
                    cbsat1.Enabled = false; cbsat1.Visible = true;
                    cbnsat1.Enabled = false; cbnsat1.Visible = true;
                    cbexcluido1.Enabled = false; cbexcluido1.Visible = true;

                    tbassprofdisci2.Enabled = false; tbassprofdisci2.Visible = true;
                    tbdataassprof2.Enabled = false; tbdataassprof2.Visible = true;
                    cbsat2.Enabled = false; cbsat2.Visible = true;
                    cbnsat2.Enabled = false; cbnsat2.Visible = true;
                    cbexcluido2.Enabled = false; cbexcluido2.Visible = true;

                    tbassprofdisci3.Enabled = false; tbassprofdisci3.Visible = true;
                    tbdataassprof3.Enabled = false; tbdataassprof3.Visible = true;
                    cbsat3.Enabled = false; cbsat3.Visible = true;
                    cbnsat3.Enabled = false; cbnsat3.Visible = true;
                    cbexcluido3.Enabled = false; cbexcluido3.Visible = true;

                    tbassprofdisci4.Enabled = false; tbassprofdisci4.Visible = true;
                    tbdataassprof4.Enabled = false; tbdataassprof4.Visible = true;
                    cbsat4.Enabled = false; cbsat4.Visible = true;
                    cbnsat4.Enabled = false; cbnsat4.Visible = true;
                    cbexcluido4.Enabled = false; cbexcluido4.Visible = true;

                    tbassprofdisci5.Enabled = true; tbassprofdisci5.Visible = true;
                    tbdataassprof5.Enabled = true; tbdataassprof5.Visible = true;
                    cbsat5.Enabled = true; cbsat5.Visible = true;
                    cbnsat5.Enabled = true; cbnsat5.Visible = true;
                    cbexcluido5.Enabled = true; cbexcluido5.Visible = true;

                    lbeee.Enabled = true; lbeee.Visible = true;
                    tbeee.Enabled = false; tbeee.Visible = true;
                    lbrnp.Enabled = false; lbrnp.Visible = true;
                    tbdataperiodoinicio.Enabled = false; tbdataperiodoinicio.Visible = true;
                    lbtexta.Enabled = false; lbtexta.Visible = true;
                    tbdataperiodofim.Enabled = false; tbdataperiodofim.Visible = true;
                    lbmedi.Enabled = false; lbmedi.Visible = true;
                    tbmedidas.Enabled = false; tbmedidas.Visible = true;
                }
                else
                {
                    Response.Redirect("~/Home/Home.aspx");
                }
            }
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
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


        protected void ddldisciplina1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Modulo> listamodulos = ModuloDAO.GetModuloWhereDisciplina(Convert.ToInt32(ddldisciplina1.SelectedValue));

            ddlmodulo1.DataSource = listamodulos;
            ddlmodulo1.DataValueField = "id_modulo";
            ddlmodulo1.DataTextField = "nome";

            ddlmodulo1.DataBind();
        }

        protected void ddldisciplina2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Modulo> listamodulos = ModuloDAO.GetModuloWhereDisciplina(Convert.ToInt32(ddldisciplina2.SelectedValue));

            ddlmodulo2.DataSource = listamodulos;
            ddlmodulo2.DataValueField = "id_modulo";
            ddlmodulo2.DataTextField = "nome";

            ddlmodulo2.DataBind();
        }

        protected void ddldisciplina3_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Modulo> listamodulos = ModuloDAO.GetModuloWhereDisciplina(Convert.ToInt32(ddldisciplina3.SelectedValue));

            ddlmodulo3.DataSource = listamodulos;
            ddlmodulo3.DataValueField = "id_modulo";
            ddlmodulo3.DataTextField = "nome";

            ddlmodulo3.DataBind();
        }

        protected void ddldisciplina4_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Modulo> listamodulos = ModuloDAO.GetModuloWhereDisciplina(Convert.ToInt32(ddldisciplina4.SelectedValue));

            ddlmodulo4.DataSource = listamodulos;
            ddlmodulo4.DataValueField = "id_modulo";
            ddlmodulo4.DataTextField = "nome";

            ddlmodulo4.DataBind();
        }

        protected void ddldisciplina5_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Modulo> listamodulos = ModuloDAO.GetModuloWhereDisciplina(Convert.ToInt32(ddldisciplina5.SelectedValue));

            ddlmodulo5.DataSource = listamodulos;
            ddlmodulo5.DataValueField = "id_modulo";
            ddlmodulo5.DataTextField = "nome";

            ddlmodulo5.DataBind();
        }

        protected void ndisciplinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["id_pra"];
            int id_pra = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_pra))
            {
                Response.Redirect("~/Home/Home.aspx");
            }

            int iduser = Convert.ToInt32(Session["id_user"]);
            Professor professor = ProfessorDAO.GetProfessorByUserID(iduser);
            hiddenid_pra.Value = id_pra.ToString();
            PraPagina prapagina1001 = PraDAO.GetPraByID(id_pra);
            DM dm1001 = DMDAO.GetDMByPra(id_pra);
            DM dm1002 = DMDAO.GetDMByPra2(id_pra);
            DM dm1003 = DMDAO.GetDMByPra3(id_pra);
            DM dm1004 = DMDAO.GetDMByPra4(id_pra);
            DM dm1005 = DMDAO.GetDMByPra5(id_pra);
            Decisao decisao1001 = DecisaoDAO.GetPraDecisaoByPra(id_pra);
            PraPrincipal praprincipal1001 = PraPrincipalDAO.GetPraPrincipalByPra(id_pra);
            Medidas medidas1001 = MedidasDAO.GetPraMedidasByPra(id_pra);
            Notificacoes notificacoes1001 = NotificacoesDAO.GetPraNotificacoesByPra(id_pra);
            int ndis = Convert.ToInt32(ndisciplinas.SelectedValue);
            if ((prapagina1001.id_medidas == null) && (prapagina1001.id_professor1 == null) && Session["role"].ToString().Equals("DT"))
            {
                if (ndis == 1)
                {
                    ddldisciplina1.Enabled = true; ddldisciplina1.Visible = true;
                    ddlmodulo1.Enabled = true; ddlmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = true; tbfaltasexcesso1.Visible = true;

                    ddldisciplina2.Enabled = false; ddldisciplina2.Visible = false;
                    ddlmodulo2.Enabled = false; ddlmodulo2.Visible = false;
                    tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = false;
                    tbassprofdisci2.Enabled = false; tbassprofdisci2.Visible = false;
                    tbdataassprof2.Enabled = false; tbdataassprof2.Visible = false;
                    cbsat2.Enabled = false; cbsat2.Visible = false;
                    cbnsat2.Enabled = false; cbnsat2.Visible = false;
                    cbexcluido2.Enabled = false; cbexcluido2.Visible = false;

                    ddldisciplina3.Enabled = false; ddldisciplina3.Visible = false;
                    ddlmodulo3.Enabled = false; ddlmodulo3.Visible = false;
                    tbfaltasexcesso3.Enabled = false; tbfaltasexcesso3.Visible = false;
                    tbassprofdisci3.Enabled = false; tbassprofdisci3.Visible = false;
                    tbdataassprof3.Enabled = false; tbdataassprof3.Visible = false;
                    cbsat3.Enabled = false; cbsat3.Visible = false;
                    cbnsat3.Enabled = false; cbnsat3.Visible = false;
                    cbexcluido3.Enabled = false; cbexcluido3.Visible = false;

                    ddldisciplina4.Enabled = false; ddldisciplina4.Visible = false;
                    ddlmodulo4.Enabled = false; ddlmodulo4.Visible = false;
                    tbfaltasexcesso4.Enabled = false; tbfaltasexcesso4.Visible = false;
                    tbassprofdisci4.Enabled = false; tbassprofdisci4.Visible = false;
                    tbdataassprof4.Enabled = false; tbdataassprof4.Visible = false;
                    cbsat4.Enabled = false; cbsat4.Visible = false;
                    cbnsat4.Enabled = false; cbnsat4.Visible = false;
                    cbexcluido4.Enabled = false; cbexcluido4.Visible = false;

                    ddldisciplina5.Enabled = false; ddldisciplina5.Visible = false;
                    ddlmodulo5.Enabled = false; ddlmodulo5.Visible = false;
                    tbfaltasexcesso5.Enabled = false; tbfaltasexcesso5.Visible = false;
                    tbassprofdisci5.Enabled = false; tbassprofdisci5.Visible = false;
                    tbdataassprof5.Enabled = false; tbdataassprof5.Visible = false;
                    cbsat5.Enabled = false; cbsat5.Visible = false;
                    cbnsat5.Enabled = false; cbnsat5.Visible = false;
                    cbexcluido5.Enabled = false; cbexcluido5.Visible = false;

                }
                else if (ndis == 2)
                {
                    ddldisciplina1.Enabled = true; ddldisciplina1.Visible = true;
                    ddlmodulo1.Enabled = true; ddlmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = true; tbfaltasexcesso1.Visible = true;

                    ddldisciplina2.Enabled = true; ddldisciplina2.Visible = true;
                    ddlmodulo2.Enabled = true; ddlmodulo2.Visible = true;
                    tbfaltasexcesso2.Enabled = true; tbfaltasexcesso2.Visible = true;

                    ddldisciplina3.Enabled = false; ddldisciplina3.Visible = false;
                    ddlmodulo3.Enabled = false; ddlmodulo3.Visible = false;
                    tbfaltasexcesso3.Enabled = false; tbfaltasexcesso3.Visible = false;
                    tbassprofdisci3.Enabled = false; tbassprofdisci3.Visible = false;
                    tbdataassprof3.Enabled = false; tbdataassprof3.Visible = false;
                    cbsat3.Enabled = false; cbsat3.Visible = false;
                    cbnsat3.Enabled = false; cbnsat3.Visible = false;
                    cbexcluido3.Enabled = false; cbexcluido3.Visible = false;

                    ddldisciplina4.Enabled = false; ddldisciplina4.Visible = false;
                    ddlmodulo4.Enabled = false; ddlmodulo4.Visible = false;
                    tbfaltasexcesso4.Enabled = false; tbfaltasexcesso4.Visible = false;
                    tbassprofdisci4.Enabled = false; tbassprofdisci4.Visible = false;
                    tbdataassprof4.Enabled = false; tbdataassprof4.Visible = false;
                    cbsat4.Enabled = false; cbsat4.Visible = false;
                    cbnsat4.Enabled = false; cbnsat4.Visible = false;
                    cbexcluido4.Enabled = false; cbexcluido4.Visible = false;

                    ddldisciplina5.Enabled = false; ddldisciplina5.Visible = false;
                    ddlmodulo5.Enabled = false; ddlmodulo5.Visible = false;
                    tbfaltasexcesso5.Enabled = false; tbfaltasexcesso5.Visible = false;
                    tbassprofdisci5.Enabled = false; tbassprofdisci5.Visible = false;
                    tbdataassprof5.Enabled = false; tbdataassprof5.Visible = false;
                    cbsat5.Enabled = false; cbsat5.Visible = false;
                    cbnsat5.Enabled = false; cbnsat5.Visible = false;
                    cbexcluido5.Enabled = false; cbexcluido5.Visible = false;
                }
                else if (ndis == 3)
                {
                    ddldisciplina1.Enabled = true; ddldisciplina1.Visible = true;
                    ddlmodulo1.Enabled = true; ddlmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = true; tbfaltasexcesso1.Visible = true;

                    ddldisciplina2.Enabled = true; ddldisciplina2.Visible = true;
                    ddlmodulo2.Enabled = true; ddlmodulo2.Visible = true;
                    tbfaltasexcesso2.Enabled = true; tbfaltasexcesso2.Visible = true;

                    ddldisciplina3.Enabled = true; ddldisciplina3.Visible = true;
                    ddlmodulo3.Enabled = true; ddlmodulo3.Visible = true;
                    tbfaltasexcesso3.Enabled = true; tbfaltasexcesso3.Visible = true;

                    ddldisciplina4.Enabled = false; ddldisciplina4.Visible = false;
                    ddlmodulo4.Enabled = false; ddlmodulo4.Visible = false;
                    tbfaltasexcesso4.Enabled = false; tbfaltasexcesso4.Visible = false;
                    tbassprofdisci4.Enabled = false; tbassprofdisci4.Visible = false;
                    tbdataassprof4.Enabled = false; tbdataassprof4.Visible = false;
                    cbsat4.Enabled = false; cbsat4.Visible = false;
                    cbnsat4.Enabled = false; cbnsat4.Visible = false;
                    cbexcluido4.Enabled = false; cbexcluido4.Visible = false;

                    ddldisciplina5.Enabled = false; ddldisciplina5.Visible = false;
                    ddlmodulo5.Enabled = false; ddlmodulo5.Visible = false;
                    tbfaltasexcesso5.Enabled = false; tbfaltasexcesso5.Visible = false;
                    tbassprofdisci5.Enabled = false; tbassprofdisci5.Visible = false;
                    tbdataassprof5.Enabled = false; tbdataassprof5.Visible = false;
                    cbsat5.Enabled = false; cbsat5.Visible = false;
                    cbnsat5.Enabled = false; cbnsat5.Visible = false;
                    cbexcluido5.Enabled = false; cbexcluido5.Visible = false;
                }
                else if (ndis == 4)
                {
                    ddldisciplina1.Enabled = true; ddldisciplina1.Visible = true;
                    ddlmodulo1.Enabled = true; ddlmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = true; tbfaltasexcesso1.Visible = true;

                    ddldisciplina2.Enabled = true; ddldisciplina2.Visible = true;
                    ddlmodulo2.Enabled = true; ddlmodulo2.Visible = true;
                    tbfaltasexcesso2.Enabled = true; tbfaltasexcesso2.Visible = true;

                    ddldisciplina3.Enabled = true; ddldisciplina3.Visible = true;
                    ddlmodulo3.Enabled = true; ddlmodulo3.Visible = true;
                    tbfaltasexcesso3.Enabled = true; tbfaltasexcesso3.Visible = true;

                    ddldisciplina4.Enabled = true; ddldisciplina4.Visible = true;
                    ddlmodulo4.Enabled = true; ddlmodulo4.Visible = true;
                    tbfaltasexcesso4.Enabled = true; tbfaltasexcesso4.Visible = true;

                    ddldisciplina5.Enabled = false; ddldisciplina5.Visible = false;
                    ddlmodulo5.Enabled = false; ddlmodulo5.Visible = false;
                    tbfaltasexcesso5.Enabled = false; tbfaltasexcesso5.Visible = false;
                    tbassprofdisci5.Enabled = false; tbassprofdisci5.Visible = false;
                    tbdataassprof5.Enabled = false; tbdataassprof5.Visible = false;
                    cbsat5.Enabled = false; cbsat5.Visible = false;
                    cbnsat5.Enabled = false; cbnsat5.Visible = false;
                    cbexcluido5.Enabled = false; cbexcluido5.Visible = false;
                }
                else if (ndis == 5)
                {
                    ddldisciplina1.Enabled = true; ddldisciplina1.Visible = true;
                    ddlmodulo1.Enabled = true; ddlmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = true; tbfaltasexcesso1.Visible = true;

                    ddldisciplina2.Enabled = true; ddldisciplina2.Visible = true;
                    ddlmodulo2.Enabled = true; ddlmodulo2.Visible = true;
                    tbfaltasexcesso2.Enabled = true; tbfaltasexcesso2.Visible = true;

                    ddldisciplina3.Enabled = true; ddldisciplina3.Visible = true;
                    ddlmodulo3.Enabled = true; ddlmodulo3.Visible = true;
                    tbfaltasexcesso3.Enabled = true; tbfaltasexcesso3.Visible = true;

                    ddldisciplina4.Enabled = true; ddldisciplina4.Visible = true;
                    ddlmodulo4.Enabled = true; ddlmodulo4.Visible = true;
                    tbfaltasexcesso4.Enabled = true; tbfaltasexcesso4.Visible = true;

                    ddldisciplina5.Enabled = true; ddldisciplina5.Visible = true;
                    ddlmodulo5.Enabled = true; ddlmodulo5.Visible = true;
                    tbfaltasexcesso5.Enabled = true; tbfaltasexcesso5.Visible = true;



                }
            }
            else if (prapagina1001.id_medidas != null)
            {
                if (ndis == 1)
                {
                    ddldisciplina1.Enabled = false; ddldisciplina1.Visible = true;
                    ddlmodulo1.Enabled = false; ddlmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                    tbassprofdisci1.Enabled = true; tbassprofdisci1.Visible = true;
                    tbdataassprof1.Enabled = true; tbdataassprof1.Visible = true;
                    cbsat1.Enabled = true; cbsat1.Visible = true;
                    cbnsat1.Enabled = true; cbnsat1.Visible = true;
                    cbexcluido1.Enabled = true; cbexcluido1.Visible = true;

                    tbdisciplina1.Enabled = false; tbdisciplina1.Visible = true;
                    tbmodulo1.Enabled = false; tbmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                }
                else if (ndis == 2)
                {
                    ddldisciplina1.Enabled = false; ddldisciplina1.Visible = true;
                    ddlmodulo1.Enabled = false; ddlmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                    tbassprofdisci1.Enabled = true; tbassprofdisci1.Visible = true;
                    tbdataassprof1.Enabled = true; tbdataassprof1.Visible = true;
                    cbsat1.Enabled = true; cbsat1.Visible = true;
                    cbnsat1.Enabled = true; cbnsat1.Visible = true;
                    cbexcluido1.Enabled = true; cbexcluido1.Visible = true;

                    ddldisciplina2.Enabled = false; ddldisciplina2.Visible = true;
                    ddlmodulo2.Enabled = false; ddlmodulo2.Visible = true;
                    tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = true;
                    tbassprofdisci2.Enabled = true; tbassprofdisci2.Visible = true;
                    tbdataassprof2.Enabled = true; tbdataassprof2.Visible = true;
                    cbsat2.Enabled = true; cbsat2.Visible = true;
                    cbnsat2.Enabled = true; cbnsat2.Visible = true;
                    cbexcluido2.Enabled = true; cbexcluido2.Visible = true;

                    tbdisciplina1.Enabled = false; tbdisciplina1.Visible = true;
                    tbmodulo1.Enabled = false; tbmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                    tbdisciplina2.Enabled = false; tbdisciplina2.Visible = true;
                    tbmodulo2.Enabled = false; tbmodulo2.Visible = true;
                    tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = true;
                }
                else if (ndis == 3)
                {
                    ddldisciplina1.Enabled = false; ddldisciplina1.Visible = true;
                    ddlmodulo1.Enabled = false; ddlmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                    tbassprofdisci1.Enabled = true; tbassprofdisci1.Visible = true;
                    tbdataassprof1.Enabled = true; tbdataassprof1.Visible = true;
                    cbsat1.Enabled = true; cbsat1.Visible = true;
                    cbnsat1.Enabled = true; cbnsat1.Visible = true;
                    cbexcluido1.Enabled = true; cbexcluido1.Visible = true;

                    ddldisciplina2.Enabled = false; ddldisciplina2.Visible = true;
                    ddlmodulo2.Enabled = false; ddlmodulo2.Visible = true;
                    tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = true;
                    tbassprofdisci2.Enabled = true; tbassprofdisci2.Visible = true;
                    tbdataassprof2.Enabled = true; tbdataassprof2.Visible = true;
                    cbsat2.Enabled = true; cbsat2.Visible = true;
                    cbnsat2.Enabled = true; cbnsat2.Visible = true;
                    cbexcluido2.Enabled = true; cbexcluido2.Visible = true;

                    ddldisciplina3.Enabled = false; ddldisciplina3.Visible = true;
                    ddlmodulo3.Enabled = false; ddlmodulo3.Visible = true;
                    tbfaltasexcesso3.Enabled = false; tbfaltasexcesso3.Visible = true;
                    tbassprofdisci3.Enabled = true; tbassprofdisci3.Visible = true;
                    tbdataassprof3.Enabled = true; tbdataassprof3.Visible = true;
                    cbsat3.Enabled = true; cbsat3.Visible = true;
                    cbnsat3.Enabled = true; cbnsat3.Visible = true;
                    cbexcluido3.Enabled = true; cbexcluido3.Visible = true;

                    tbdisciplina1.Enabled = false; tbdisciplina1.Visible = true;
                    tbmodulo1.Enabled = false; tbmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                    tbdisciplina2.Enabled = false; tbdisciplina2.Visible = true;
                    tbmodulo2.Enabled = false; tbmodulo2.Visible = true;
                    tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = true;
                    tbdisciplina3.Enabled = false; tbdisciplina3.Visible = true;
                    tbmodulo3.Enabled = false; tbmodulo3.Visible = true;
                    tbfaltasexcesso3.Enabled = false; tbfaltasexcesso3.Visible = true;
                }
                else if (ndis == 4)
                {
                    ddldisciplina1.Enabled = false; ddldisciplina1.Visible = true;
                    ddlmodulo1.Enabled = false; ddlmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                    tbassprofdisci1.Enabled = true; tbassprofdisci1.Visible = true;
                    tbdataassprof1.Enabled = true; tbdataassprof1.Visible = true;
                    cbsat1.Enabled = true; cbsat1.Visible = true;
                    cbnsat1.Enabled = true; cbnsat1.Visible = true;
                    cbexcluido1.Enabled = true; cbexcluido1.Visible = true;

                    ddldisciplina2.Enabled = false; ddldisciplina2.Visible = true;
                    ddlmodulo2.Enabled = false; ddlmodulo2.Visible = true;
                    tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = true;
                    tbassprofdisci2.Enabled = true; tbassprofdisci2.Visible = true;
                    tbdataassprof2.Enabled = true; tbdataassprof2.Visible = true;
                    cbsat2.Enabled = true; cbsat2.Visible = true;
                    cbnsat2.Enabled = true; cbnsat2.Visible = true;
                    cbexcluido2.Enabled = true; cbexcluido2.Visible = true;

                    ddldisciplina3.Enabled = false; ddldisciplina3.Visible = true;
                    ddlmodulo3.Enabled = false; ddlmodulo3.Visible = true;
                    tbfaltasexcesso3.Enabled = false; tbfaltasexcesso3.Visible = true;
                    tbassprofdisci3.Enabled = true; tbassprofdisci3.Visible = true;
                    tbdataassprof3.Enabled = true; tbdataassprof3.Visible = true;
                    cbsat3.Enabled = true; cbsat3.Visible = true;
                    cbnsat3.Enabled = true; cbnsat3.Visible = true;
                    cbexcluido3.Enabled = true; cbexcluido3.Visible = true;

                    ddldisciplina4.Enabled = false; ddldisciplina4.Visible = true;
                    ddlmodulo4.Enabled = false; ddlmodulo4.Visible = true;
                    tbfaltasexcesso4.Enabled = false; tbfaltasexcesso4.Visible = true;
                    tbassprofdisci4.Enabled = true; tbassprofdisci4.Visible = true;
                    tbdataassprof4.Enabled = true; tbdataassprof4.Visible = true;
                    cbsat4.Enabled = true; cbsat4.Visible = true;
                    cbnsat4.Enabled = true; cbnsat4.Visible = true;
                    cbexcluido4.Enabled = true; cbexcluido4.Visible = true;

                    tbdisciplina1.Enabled = false; tbdisciplina1.Visible = true;
                    tbmodulo1.Enabled = false; tbmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                    tbdisciplina2.Enabled = false; tbdisciplina2.Visible = true;
                    tbmodulo2.Enabled = false; tbmodulo2.Visible = true;
                    tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = true;
                    tbdisciplina3.Enabled = false; tbdisciplina3.Visible = true;
                    tbmodulo3.Enabled = false; tbmodulo3.Visible = true;
                    tbfaltasexcesso3.Enabled = false; tbfaltasexcesso3.Visible = true;
                    tbdisciplina4.Enabled = false; tbdisciplina4.Visible = true;
                    tbmodulo4.Enabled = false; tbmodulo4.Visible = true;
                    tbfaltasexcesso4.Enabled = false; tbfaltasexcesso4.Visible = true;
                }
                else if (ndis == 5)
                {
                    ddldisciplina1.Enabled = false; ddldisciplina1.Visible = true;
                    ddlmodulo1.Enabled = false; ddlmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                    tbassprofdisci1.Enabled = true; tbassprofdisci1.Visible = true;
                    tbdataassprof1.Enabled = true; tbdataassprof1.Visible = true;
                    cbsat1.Enabled = true; cbsat1.Visible = true;
                    cbnsat1.Enabled = true; cbnsat1.Visible = true;
                    cbexcluido1.Enabled = true; cbexcluido1.Visible = true;

                    ddldisciplina2.Enabled = false; ddldisciplina2.Visible = true;
                    ddlmodulo2.Enabled = false; ddlmodulo2.Visible = true;
                    tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = true;
                    tbassprofdisci2.Enabled = true; tbassprofdisci2.Visible = true;
                    tbdataassprof2.Enabled = true; tbdataassprof2.Visible = true;
                    cbsat2.Enabled = true; cbsat2.Visible = true;
                    cbnsat2.Enabled = true; cbnsat2.Visible = true;
                    cbexcluido2.Enabled = true; cbexcluido2.Visible = true;

                    ddldisciplina3.Enabled = false; ddldisciplina3.Visible = true;
                    ddlmodulo3.Enabled = false; ddlmodulo3.Visible = true;
                    tbfaltasexcesso3.Enabled = false; tbfaltasexcesso3.Visible = true;
                    tbassprofdisci3.Enabled = true; tbassprofdisci3.Visible = true;
                    tbdataassprof3.Enabled = true; tbdataassprof3.Visible = true;
                    cbsat3.Enabled = true; cbsat3.Visible = true;
                    cbnsat3.Enabled = true; cbnsat3.Visible = true;
                    cbexcluido3.Enabled = true; cbexcluido3.Visible = true;

                    ddldisciplina4.Enabled = false; ddldisciplina4.Visible = true;
                    ddlmodulo4.Enabled = false; ddlmodulo4.Visible = true;
                    tbfaltasexcesso4.Enabled = false; tbfaltasexcesso4.Visible = true;
                    tbassprofdisci4.Enabled = true; tbassprofdisci4.Visible = true;
                    tbdataassprof4.Enabled = true; tbdataassprof4.Visible = true;
                    cbsat4.Enabled = true; cbsat4.Visible = true;
                    cbnsat4.Enabled = true; cbnsat4.Visible = true;
                    cbexcluido4.Enabled = true; cbexcluido4.Visible = true;

                    ddldisciplina5.Enabled = false; ddldisciplina5.Visible = true;
                    ddlmodulo5.Enabled = false; ddlmodulo5.Visible = true;
                    tbfaltasexcesso5.Enabled = false; tbfaltasexcesso5.Visible = true;
                    tbassprofdisci5.Enabled = true; tbassprofdisci5.Visible = true;
                    tbdataassprof5.Enabled = true; tbdataassprof5.Visible = true;
                    cbsat5.Enabled = true; cbsat5.Visible = true;
                    cbnsat5.Enabled = true; cbnsat5.Visible = true;
                    cbexcluido5.Enabled = true; cbexcluido5.Visible = true;

                    tbdisciplina1.Enabled = false; tbdisciplina1.Visible = true;
                    tbmodulo1.Enabled = false; tbmodulo1.Visible = true;
                    tbfaltasexcesso1.Enabled = false; tbfaltasexcesso1.Visible = true;
                    tbdisciplina2.Enabled = false; tbdisciplina2.Visible = true;
                    tbmodulo2.Enabled = false; tbmodulo2.Visible = true;
                    tbfaltasexcesso2.Enabled = false; tbfaltasexcesso2.Visible = true;
                    tbdisciplina3.Enabled = false; tbdisciplina3.Visible = true;
                    tbmodulo3.Enabled = false; tbmodulo3.Visible = true;
                    tbfaltasexcesso3.Enabled = false; tbfaltasexcesso3.Visible = true;
                    tbdisciplina4.Enabled = false; tbdisciplina4.Visible = true;
                    tbmodulo4.Enabled = false; tbmodulo4.Visible = true;
                    tbfaltasexcesso4.Enabled = false; tbfaltasexcesso4.Visible = true;
                    tbdisciplina5.Enabled = false; tbdisciplina5.Visible = true;
                    tbmodulo5.Enabled = false; tbmodulo5.Visible = true;
                    tbfaltasexcesso5.Enabled = false; tbfaltasexcesso5.Visible = true;
                }
            }
        }


        protected void binserir1_Click(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["id_pra"];
            int id_pra = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_pra))
            {
                Response.Redirect("~/Home/Home.aspx");
            }

            PraPagina prapagina10 = PraDAO.GetPraByID(id_pra);
            if (prapagina10.id_medidas == null && Session["role"].ToString().Equals("DT"))
            {

                int iduser = Convert.ToInt32(Session["id_user"]);
                Professor professor = ProfessorDAO.GetProfessorByUserID(iduser);
                TurmaDT turmadt = TurmaDAO.GetTurmaByDT(professor.Id_Professor);
                hiddenid_pra.Value = id_pra.ToString();


                Professor professor1 = ProfessorDAO.GetProfessorByDisciplinaTurma(Convert.ToInt32(ddldisciplina1.SelectedValue), turmadt.id_turma);
                Professor professor2 = ProfessorDAO.GetProfessorByDisciplinaTurma(Convert.ToInt32(ddldisciplina2.SelectedValue), turmadt.id_turma);
                Professor professor3 = ProfessorDAO.GetProfessorByDisciplinaTurma(Convert.ToInt32(ddldisciplina3.SelectedValue), turmadt.id_turma);
                Professor professor4 = ProfessorDAO.GetProfessorByDisciplinaTurma(Convert.ToInt32(ddldisciplina4.SelectedValue), turmadt.id_turma);
                Professor professor5 = ProfessorDAO.GetProfessorByDisciplinaTurma(Convert.ToInt32(ddldisciplina5.SelectedValue), turmadt.id_turma);
                int ndis = Convert.ToInt32(ndisciplinas.SelectedValue);
                if (ndis == 1)
                {
                    var dmcode1 = GenerateCoupon(50, new Random());
                    DM dm = new DM()
                    {
                        disciplina_modulo = Convert.ToInt32(ddlmodulo1.SelectedValue),
                        faltas_excesso = Convert.ToInt32(tbfaltasexcesso1.Text),
                        dmcode = dmcode1,
                        id_pra = id_pra,
                        id_professor = professor1.Id_Professor

                    };
                    int returnCode2 = DMDAO.InsertDM(dm);
                    DM dm11 = DMDAO.GetDMByCode(dm.dmcode);

                    PraPagina prapagina = PraDAO.GetPraByID(id_pra);

                    PraPagina prapagina1 = new PraPagina()
                    {
                        id_pra = id_pra,
                        id_principal = prapagina.id_principal,
                        codigo_pra = prapagina.codigo_pra,
                        id_aluno = prapagina.id_aluno,
                        id_dt = prapagina.id_dt,
                        id_turma = prapagina.id_turma,
                        estado = "Incompleto",
                        progresso = "Falta a introdução das medidas",
                        id_professor1 = professor1.Id_Professor,
                        ndisciplinas = ndis,
                        id_dm1 = dm11.id_dm
                    };
                    int returnCode102 = PraDAO.UpdatePra(prapagina1);

                    PraDMLigacao pradmligacao = new PraDMLigacao()
                    {
                        id_dm = dm11.id_dm,
                        id_pra = id_pra
                    };
                    int returnCodePraDMlig = PRADMLigacaoDAO.InsertPRADMLigacao(pradmligacao);


                }
                else if (ndis == 2)
                {
                    var dmcode1 = GenerateCoupon(50, new Random());
                    var dmcode2 = GenerateCoupon(51, new Random());
                    dmcode2 = dmcode2.Substring(1);

                    DM dm = new DM()
                    {
                        disciplina_modulo = Convert.ToInt32(ddlmodulo1.SelectedValue),
                        faltas_excesso = Convert.ToInt32(tbfaltasexcesso1.Text),
                        dmcode = dmcode1,
                        id_pra = id_pra,
                        id_professor = professor1.Id_Professor

                    };
                    int returnCode2 = DMDAO.InsertDM(dm);
                    DM dm11 = DMDAO.GetDMByCode(dm.dmcode);

                    DM2 dm2 = new DM2()
                    {
                        disciplina_modulo = Convert.ToInt32(ddlmodulo2.SelectedValue),
                        faltas_excesso = Convert.ToInt32(tbfaltasexcesso2.Text),
                        dmcode = dmcode2,
                        id_pra = id_pra,
                        id_professor = professor2.Id_Professor

                    };
                    int returnCode22 = DMDAO.InsertDM2(dm2);
                    DM2 dm22 = DMDAO.GetDMByCode2(dm2.dmcode);

                    PraPagina prapagina = PraDAO.GetPraByID(id_pra);

                    PraPagina prapagina1 = new PraPagina()
                    {
                        id_pra = id_pra,
                        id_principal = prapagina.id_principal,
                        codigo_pra = prapagina.codigo_pra,
                        id_aluno = prapagina.id_aluno,
                        id_dt = prapagina.id_dt,
                        id_turma = prapagina.id_turma,
                        estado = "Incompleto",
                        progresso = "Falta a introdução das medidas",
                        id_professor1 = professor1.Id_Professor,
                        id_professor2 = professor2.Id_Professor,
                        ndisciplinas = ndis,
                        id_dm1 = dm11.id_dm,
                        id_dm2 = dm22.id_dm
                    };
                    int returnCode102 = PraDAO.UpdatePra(prapagina1);

                    PraDMLigacao pradmligacao = new PraDMLigacao()
                    {
                        id_dm = dm11.id_dm,
                        id_pra = id_pra
                    };
                    int returnCodePraDMlig = PRADMLigacaoDAO.InsertPRADMLigacao(pradmligacao);

                    PraDMLigacao2 pradmligacao2 = new PraDMLigacao2()
                    {
                        id_dm = dm22.id_dm,
                        id_pra = id_pra
                    };
                    int returnCodePraDMlig2 = PRADMLigacaoDAO.InsertPRADMLigacao2(pradmligacao2);

                }
                else if (ndis == 3)
                {
                    var dmcode1 = GenerateCoupon(50, new Random());
                    var dmcode2 = GenerateCoupon(51, new Random());
                    dmcode2 = dmcode2.Substring(1);
                    string dmcode3 = GenerateCoupon(52, new Random());
                    dmcode3 = dmcode3.Substring(2);

                    DM dm = new DM()
                    {
                        disciplina_modulo = Convert.ToInt32(ddlmodulo1.SelectedValue),
                        faltas_excesso = Convert.ToInt32(tbfaltasexcesso1.Text),
                        dmcode = dmcode1,
                        id_pra = id_pra,
                        id_professor = professor1.Id_Professor

                    };
                    int returnCode2 = DMDAO.InsertDM(dm);
                    DM dm11 = DMDAO.GetDMByCode(dm.dmcode);

                    DM2 dm2 = new DM2()
                    {
                        disciplina_modulo = Convert.ToInt32(ddlmodulo2.SelectedValue),
                        faltas_excesso = Convert.ToInt32(tbfaltasexcesso2.Text),
                        dmcode = dmcode2,
                        id_pra = id_pra,
                        id_professor = professor2.Id_Professor

                    };
                    int returnCode22 = DMDAO.InsertDM2(dm2);
                    DM2 dm22 = DMDAO.GetDMByCode2(dm2.dmcode);


                    DM3 dm3 = new DM3()
                    {
                        disciplina_modulo = Convert.ToInt32(ddlmodulo3.SelectedValue),
                        faltas_excesso = Convert.ToInt32(tbfaltasexcesso3.Text),
                        dmcode = dmcode3,
                        id_pra = id_pra,
                        id_professor = professor3.Id_Professor
                    };
                    int returnCode23 = DMDAO.InsertDM3(dm3);

                    DM3 dm33 = DMDAO.GetDMByCode3(dm3.dmcode);

                    PraPagina prapagina = PraDAO.GetPraByID(id_pra);

                    PraPagina prapagina1 = new PraPagina()
                    {
                        id_pra = id_pra,
                        id_principal = prapagina.id_principal,
                        codigo_pra = prapagina.codigo_pra,
                        id_aluno = prapagina.id_aluno,
                        id_dt = prapagina.id_dt,
                        id_turma = prapagina.id_turma,
                        estado = "Incompleto",
                        progresso = "Falta a introdução das medidas",
                        id_professor1 = professor1.Id_Professor,
                        id_professor2 = professor2.Id_Professor,
                        id_professor3 = professor3.Id_Professor,
                        ndisciplinas = ndis,
                        id_dm1 = dm11.id_dm,
                        id_dm2 = dm22.id_dm,
                        id_dm3 = dm33.id_dm
                    };
                    int returnCode102 = PraDAO.UpdatePra(prapagina1);

                    PraDMLigacao pradmligacao = new PraDMLigacao()
                    {
                        id_dm = dm11.id_dm,
                        id_pra = id_pra
                    };
                    int returnCodePraDMlig = PRADMLigacaoDAO.InsertPRADMLigacao(pradmligacao);

                    PraDMLigacao2 pradmligacao2 = new PraDMLigacao2()
                    {
                        id_dm = dm22.id_dm,
                        id_pra = id_pra
                    };
                    int returnCodePraDMlig2 = PRADMLigacaoDAO.InsertPRADMLigacao2(pradmligacao2);

                    PraDMLigacao3 pradmligacao3 = new PraDMLigacao3()
                    {
                        id_dm = dm33.id_dm,
                        id_pra = id_pra
                    };
                    int returnCodePraDMlig3 = PRADMLigacaoDAO.InsertPRADMLigacao3(pradmligacao3);

                }
                else if (ndis == 4)
                {
                    var dmcode1 = GenerateCoupon(50, new Random());
                    var dmcode2 = GenerateCoupon(51, new Random());
                    dmcode2 = dmcode2.Substring(1);
                    string dmcode3 = GenerateCoupon(52, new Random());
                    dmcode3 = dmcode3.Substring(2);
                    string dmcode4 = GenerateCoupon(53, new Random());
                    dmcode4 = dmcode4.Substring(3);

                    DM dm = new DM()
                    {
                        disciplina_modulo = Convert.ToInt32(ddlmodulo1.SelectedValue),
                        faltas_excesso = Convert.ToInt32(tbfaltasexcesso1.Text),
                        dmcode = dmcode1,
                        id_pra = id_pra,
                        id_professor = professor1.Id_Professor

                    };
                    int returnCode2 = DMDAO.InsertDM(dm);
                    DM dm11 = DMDAO.GetDMByCode(dm.dmcode);

                    DM2 dm2 = new DM2()
                    {
                        disciplina_modulo = Convert.ToInt32(ddlmodulo2.SelectedValue),
                        faltas_excesso = Convert.ToInt32(tbfaltasexcesso2.Text),
                        dmcode = dmcode2,
                        id_pra = id_pra,
                        id_professor = professor2.Id_Professor

                    };
                    int returnCode22 = DMDAO.InsertDM2(dm2);
                    DM2 dm22 = DMDAO.GetDMByCode2(dm2.dmcode);


                    DM3 dm3 = new DM3()
                    {
                        disciplina_modulo = Convert.ToInt32(ddlmodulo3.SelectedValue),
                        faltas_excesso = Convert.ToInt32(tbfaltasexcesso3.Text),
                        dmcode = dmcode3,
                        id_pra = id_pra,
                        id_professor = professor3.Id_Professor
                    };
                    int returnCode23 = DMDAO.InsertDM3(dm3);
                    DM3 dm33 = DMDAO.GetDMByCode3(dm3.dmcode);


                    DM4 dm4 = new DM4()
                    {
                        disciplina_modulo = Convert.ToInt32(ddlmodulo4.SelectedValue),
                        faltas_excesso = Convert.ToInt32(tbfaltasexcesso4.Text),
                        dmcode = dmcode4,
                        id_pra = id_pra,
                        id_professor = professor4.Id_Professor
                    };
                    int returnCode24 = DMDAO.InsertDM4(dm4);
                    DM4 dm44 = DMDAO.GetDMByCode4(dm4.dmcode);

                    PraPagina prapagina = PraDAO.GetPraByID(id_pra);

                    PraPagina prapagina1 = new PraPagina()
                    {
                        id_pra = id_pra,
                        id_principal = prapagina.id_principal,
                        codigo_pra = prapagina.codigo_pra,
                        id_aluno = prapagina.id_aluno,
                        id_dt = prapagina.id_dt,
                        id_turma = prapagina.id_turma,
                        estado = "Incompleto",
                        progresso = "Falta a introdução das medidas",
                        id_professor1 = professor1.Id_Professor,
                        id_professor2 = professor2.Id_Professor,
                        id_professor3 = professor3.Id_Professor,
                        id_professor4 = professor4.Id_Professor,
                        ndisciplinas = ndis,
                        id_dm1 = dm11.id_dm,
                        id_dm2 = dm22.id_dm,
                        id_dm3 = dm33.id_dm,
                        id_dm4 = dm44.id_dm
                    };
                    int returnCode102 = PraDAO.UpdatePra(prapagina1);

                    PraDMLigacao pradmligacao = new PraDMLigacao()
                    {
                        id_dm = dm11.id_dm,
                        id_pra = id_pra
                    };
                    int returnCodePraDMlig = PRADMLigacaoDAO.InsertPRADMLigacao(pradmligacao);

                    PraDMLigacao2 pradmligacao2 = new PraDMLigacao2()
                    {
                        id_dm = dm22.id_dm,
                        id_pra = id_pra
                    };
                    int returnCodePraDMlig2 = PRADMLigacaoDAO.InsertPRADMLigacao2(pradmligacao2);

                    PraDMLigacao3 pradmligacao3 = new PraDMLigacao3()
                    {
                        id_dm = dm33.id_dm,
                        id_pra = id_pra
                    };
                    int returnCodePraDMlig3 = PRADMLigacaoDAO.InsertPRADMLigacao3(pradmligacao3);

                    PraDMLigacao4 pradmligacao4 = new PraDMLigacao4()
                    {
                        id_dm = dm44.id_dm,
                        id_pra = id_pra
                    };
                    int returnCodePraDMlig4 = PRADMLigacaoDAO.InsertPRADMLigacao4(pradmligacao4);

                }
                else if (ndis == 5)
                {
                    var dmcode1 = GenerateCoupon(50, new Random());
                    var dmcode2 = GenerateCoupon(51, new Random());
                    dmcode2 = dmcode2.Substring(1);
                    string dmcode3 = GenerateCoupon(52, new Random());
                    dmcode3 = dmcode3.Substring(2);
                    string dmcode4 = GenerateCoupon(53, new Random());
                    dmcode4 = dmcode4.Substring(3);
                    string dmcode5 = GenerateCoupon(54, new Random());
                    dmcode5 = dmcode5.Substring(4);


                    DM dm = new DM()
                    {
                        disciplina_modulo = Convert.ToInt32(ddlmodulo1.SelectedValue),
                        faltas_excesso = Convert.ToInt32(tbfaltasexcesso1.Text),
                        dmcode = dmcode1,
                        id_pra = id_pra,
                        id_professor = professor1.Id_Professor

                    };
                    int returnCode2 = DMDAO.InsertDM(dm);
                    DM dm11 = DMDAO.GetDMByCode(dm.dmcode);

                    DM2 dm2 = new DM2()
                    {
                        disciplina_modulo = Convert.ToInt32(ddlmodulo2.SelectedValue),
                        faltas_excesso = Convert.ToInt32(tbfaltasexcesso2.Text),
                        dmcode = dmcode2,
                        id_pra = id_pra,
                        id_professor = professor2.Id_Professor

                    };
                    int returnCode22 = DMDAO.InsertDM2(dm2);
                    DM2 dm22 = DMDAO.GetDMByCode2(dm2.dmcode);


                    DM3 dm3 = new DM3()
                    {
                        disciplina_modulo = Convert.ToInt32(ddlmodulo3.SelectedValue),
                        faltas_excesso = Convert.ToInt32(tbfaltasexcesso3.Text),
                        dmcode = dmcode3,
                        id_pra = id_pra,
                        id_professor = professor3.Id_Professor
                    };
                    int returnCode23 = DMDAO.InsertDM3(dm3);
                    DM3 dm33 = DMDAO.GetDMByCode3(dm3.dmcode);


                    DM4 dm4 = new DM4()
                    {
                        disciplina_modulo = Convert.ToInt32(ddlmodulo4.SelectedValue),
                        faltas_excesso = Convert.ToInt32(tbfaltasexcesso4.Text),
                        dmcode = dmcode4,
                        id_pra = id_pra,
                        id_professor = professor4.Id_Professor
                    };
                    int returnCode24 = DMDAO.InsertDM4(dm4);
                    DM4 dm44 = DMDAO.GetDMByCode4(dm4.dmcode);


                    DM5 dm5 = new DM5()
                    {
                        disciplina_modulo = Convert.ToInt32(ddlmodulo5.SelectedValue),
                        faltas_excesso = Convert.ToInt32(tbfaltasexcesso5.Text),
                        dmcode = dmcode5,
                        id_pra = id_pra,
                        id_professor = professor5.Id_Professor
                    };
                    int returnCode25 = DMDAO.InsertDM5(dm5);
                    DM5 dm55 = DMDAO.GetDMByCode5(dm5.dmcode);

                    PraPagina prapagina = PraDAO.GetPraByID(id_pra);

                    PraPagina prapagina1 = new PraPagina()
                    {
                        id_pra = id_pra,
                        id_principal = prapagina.id_principal,
                        codigo_pra = prapagina.codigo_pra,
                        id_aluno = prapagina.id_aluno,
                        id_dt = prapagina.id_dt,
                        id_turma = prapagina.id_turma,
                        estado = "Incompleto",
                        progresso = "Falta a introdução das medidas",
                        id_professor1 = professor1.Id_Professor,
                        id_professor2 = professor2.Id_Professor,
                        id_professor3 = professor3.Id_Professor,
                        id_professor4 = professor4.Id_Professor,
                        id_professor5 = professor5.Id_Professor,
                        ndisciplinas = ndis,
                        id_dm1 = dm11.id_dm,
                        id_dm2 = dm22.id_dm,
                        id_dm3 = dm33.id_dm,
                        id_dm4 = dm44.id_dm,
                        id_dm5 = dm55.id_dm
                    };
                    int returnCode102 = PraDAO.UpdatePra(prapagina1);

                    PraDMLigacao pradmligacao = new PraDMLigacao()
                    {
                        id_dm = dm11.id_dm,
                        id_pra = id_pra
                    };
                    int returnCodePraDMlig = PRADMLigacaoDAO.InsertPRADMLigacao(pradmligacao);

                    PraDMLigacao2 pradmligacao2 = new PraDMLigacao2()
                    {
                        id_dm = dm22.id_dm,
                        id_pra = id_pra
                    };
                    int returnCodePraDMlig2 = PRADMLigacaoDAO.InsertPRADMLigacao2(pradmligacao2);

                    PraDMLigacao3 pradmligacao3 = new PraDMLigacao3()
                    {
                        id_dm = dm33.id_dm,
                        id_pra = id_pra
                    };
                    int returnCodePraDMlig3 = PRADMLigacaoDAO.InsertPRADMLigacao3(pradmligacao3);

                    PraDMLigacao4 pradmligacao4 = new PraDMLigacao4()
                    {
                        id_dm = dm44.id_dm,
                        id_pra = id_pra
                    };
                    int returnCodePraDMlig4 = PRADMLigacaoDAO.InsertPRADMLigacao4(pradmligacao4);

                    PraDMLigacao5 pradmligacao5 = new PraDMLigacao5()
                    {
                        id_dm = dm55.id_dm,
                        id_pra = id_pra
                    };
                    int returnCodePraDMlig5 = PRADMLigacaoDAO.InsertPRADMLigacao5(pradmligacao5);
                }


                Response.Write("<script>alert('Preenchimento registado com sucesso!');window.location='/Home/Home.aspx';</script>");

            }
            else
            {
                Response.Redirect("~/Home/Home.aspx");
            }
        }

        protected void binserir2_Click(object sender, EventArgs e)
        {

        }

        protected void binserir3_Click(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["id_pra"];
            int id_pra = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_pra))
            {
                Response.Redirect("~/Home/Home.aspx");
            }
            PraPagina prapagina10 = PraDAO.GetPraByID(id_pra);
            if (prapagina10.id_medidas == null && Session["role"].ToString().Equals("DT"))
            {
                var periodo_inicio1 = DateTimeOffset.Parse(tbdataperiodoinicio.Text).DateTime;
                var periodo_fim1 = DateTimeOffset.Parse(tbdataperiodofim.Text).DateTime;
                string codemedidas1 = GenerateCoupon(60, new Random());
                Medidas medidas = new Medidas()
                {
                    periodo_inicio = periodo_inicio1,
                    periodo_fim = periodo_fim1,
                    medida = Convert.ToString(tbmedidas.Text),
                    codemedidas = codemedidas1,
                    id_pra = id_pra
                };
                int returnCode3 = MedidasDAO.InsertMedidas(medidas);
                Medidas medidas1 = MedidasDAO.GetPraMedidasByCode(medidas.codemedidas);

                PraPagina prapagina = PraDAO.GetPraByID(id_pra);
                int? ndisc = prapagina.ndisciplinas;
                if (ndisc == 1)
                {
                    PraPagina prapagina1 = new PraPagina()
                    {
                        id_pra = id_pra,
                        id_principal = prapagina.id_principal,
                        codigo_pra = prapagina.codigo_pra,
                        id_aluno = prapagina.id_aluno,
                        id_dt = prapagina.id_dt,
                        id_turma = prapagina.id_turma,
                        estado = "Incompleto",
                        progresso = "Falta a introdução das medidas",
                        id_professor1 = prapagina.id_professor1
                    };
                    int returnCode102 = PraDAO.UpdatePra(prapagina1);
                }
                else if (ndisc == 2)
                {
                    PraPagina prapagina1 = new PraPagina()
                    {
                        id_pra = id_pra,
                        id_principal = prapagina.id_principal,
                        codigo_pra = prapagina.codigo_pra,
                        id_aluno = prapagina.id_aluno,
                        id_dt = prapagina.id_dt,
                        id_turma = prapagina.id_turma,
                        estado = "Incompleto",
                        progresso = "Falta a introdução das medidas",
                        id_professor1 = prapagina.id_professor1,
                        id_professor2 = prapagina.id_professor2
                    };
                    int returnCode102 = PraDAO.UpdatePra(prapagina1);
                }
                else if (ndisc == 3)
                {
                    PraPagina prapagina1 = new PraPagina()
                    {
                        id_pra = id_pra,
                        id_principal = prapagina.id_principal,
                        codigo_pra = prapagina.codigo_pra,
                        id_aluno = prapagina.id_aluno,
                        id_dt = prapagina.id_dt,
                        id_turma = prapagina.id_turma,
                        estado = "Incompleto",
                        progresso = "Falta a introdução das medidas",
                        id_professor1 = prapagina.id_professor1,
                        id_professor2 = prapagina.id_professor2,
                        id_professor3 = prapagina.id_professor3
                    };
                    int returnCode102 = PraDAO.UpdatePra(prapagina1);
                }
                else if (ndisc == 4)
                {
                    PraPagina prapagina1 = new PraPagina()
                    {
                        id_pra = id_pra,
                        id_principal = prapagina.id_principal,
                        codigo_pra = prapagina.codigo_pra,
                        id_aluno = prapagina.id_aluno,
                        id_dt = prapagina.id_dt,
                        id_turma = prapagina.id_turma,
                        estado = "Incompleto",
                        progresso = "Falta a introdução das medidas",
                        id_professor1 = prapagina.id_professor1,
                        id_professor2 = prapagina.id_professor2,
                        id_professor3 = prapagina.id_professor3,
                        id_professor4 = prapagina.id_professor4
                    };
                    int returnCode102 = PraDAO.UpdatePra(prapagina1);
                }
                else if (ndisc == 5)
                {
                    PraPagina prapagina1 = new PraPagina()
                    {
                        id_pra = id_pra,
                        id_principal = prapagina.id_principal,
                        codigo_pra = prapagina.codigo_pra,
                        id_aluno = prapagina.id_aluno,
                        id_dt = prapagina.id_dt,
                        id_turma = prapagina.id_turma,
                        estado = "Incompleto",
                        progresso = "Falta a introdução das medidas",
                        id_professor1 = prapagina.id_professor1,
                        id_professor2 = prapagina.id_professor2,
                        id_professor3 = prapagina.id_professor3,
                        id_professor4 = prapagina.id_professor4,
                        id_professor5 = prapagina.id_professor5
                    };
                    int returnCode102 = PraDAO.UpdatePra(prapagina1);
                }





                Response.Write("<script>alert('Preenchimento registado com sucesso!');window.location='/Home/Home.aspx';</script>");

            }
            else
            {
                Response.Redirect("~/Home/Home.aspx");
            }
        }

        protected void binserir4_Click(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["id_pra"];
            int id_pra = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_pra))
            {
                Response.Redirect("~/Home/Home.aspx");
            }

            PraPagina prapagina10 = PraDAO.GetPraByID(id_pra);

            Medidas medidas1 = MedidasDAO.GetPraMedidasByPra(id_pra);

            Medidas medidas2 = new Medidas()
            {
                id_medidas = medidas1.id_medidas,
                periodo_inicio = medidas1.periodo_fim,
                periodo_fim = medidas1.periodo_fim,
                medida = medidas1.medida,
                cumprimento = medidas1.cumprimento,
                data_cumprimento = medidas1.data_cumprimento,
                dever_incumprimento = medidas1.dever_incumprimento,
                data_incumprimento = medidas1.data_incumprimento,
                faltas_desconsideradas = medidas1.faltas_desconsideradas,
                codemedidas = medidas1.codemedidas,
                id_pra = id_pra
            };
            int returnCode103 = MedidasDAO.UpdateMedidasByID(medidas2);
        }

        protected void binserir5_Click(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["id_pra"];
            int id_pra = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_pra))
            {
                Response.Redirect("~/Home/Home.aspx");
            }

            PraPagina prapagina10 = PraDAO.GetPraByID(id_pra);

            Medidas medidas1 = MedidasDAO.GetPraMedidasByPra(id_pra);

            string cumprimento;
            string dever_incumprimento;
            if (cbcumprimentosim.Checked)
            {
                cumprimento = "Sim";
            }
            else if (cbcumprimentonao.Checked)
            {
                cumprimento = "Não";
            }
            else
            {
                cumprimento = "";
            }
            DateTime hoje = DateTime.Today;
            if (cbincumprimentosim.Checked)
            {
                dever_incumprimento = "Sim";
            }
            else if (cbincumprimentonao.Checked)
            {
                dever_incumprimento = "Não";
            }
            else
            {
                dever_incumprimento = "";
            }
            if (cbcumprimentosim.Checked || cbcumprimentonao.Checked)
            {
                Medidas medidas2 = new Medidas()
                {
                    id_medidas = medidas1.id_medidas,
                    periodo_inicio = medidas1.periodo_fim,
                    periodo_fim = medidas1.periodo_fim,
                    medida = medidas1.medida,
                    cumprimento = Convert.ToString(cumprimento),
                    data_cumprimento = Convert.ToDateTime(hoje),
                    dever_incumprimento = Convert.ToString(dever_incumprimento),
                    data_incumprimento = string.IsNullOrWhiteSpace(dataincumprimento.Text) ? (DateTime?)null : Convert.ToDateTime(dataincumprimento.Text),
                    faltas_desconsideradas = medidas1.faltas_desconsideradas,
                    codemedidas = medidas1.codemedidas,
                    id_pra = id_pra
                };
                int returnCode103 = MedidasDAO.UpdateMedidasByID(medidas2);
            }
            else if (cbincumprimentosim.Checked || cbincumprimentonao.Checked)
            {
                Medidas medidas2 = new Medidas()
                {
                    id_medidas = medidas1.id_medidas,
                    periodo_inicio = medidas1.periodo_fim,
                    periodo_fim = medidas1.periodo_fim,
                    medida = medidas1.medida,
                    cumprimento = Convert.ToString(cumprimento),
                    data_cumprimento = string.IsNullOrWhiteSpace(datacumprimento.Text) ? (DateTime?)null : Convert.ToDateTime(datacumprimento.Text),
                    dever_incumprimento = Convert.ToString(dever_incumprimento),
                    data_incumprimento = Convert.ToDateTime(hoje),
                    faltas_desconsideradas = medidas1.faltas_desconsideradas,
                    codemedidas = medidas1.codemedidas,
                    id_pra = id_pra
                };
                int returnCode103 = MedidasDAO.UpdateMedidasByID(medidas2);
            }

        }

        protected void binserir6_Click(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["id_pra"];
            int id_pra = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_pra))
            {
                Response.Redirect("~/Home/Home.aspx");
            }

            PraPagina prapagina = PraDAO.GetPraByID(id_pra);

            string codenotificacoes1 = GenerateCoupon(65, new Random());
            Notificacoes notificacoes = new Notificacoes()
            {
                assinatura_enc = tbpeeanotificacoes.Text,
                data_assinatura_enc = Convert.ToDateTime(datapeeanotificacoes.Text),
                codenotificaçoes = codenotificacoes1,
                id_pra = id_pra
            };
            int returnCode4 = NotificacoesDAO.InsertNotificacoes(notificacoes);
            Notificacoes notificacoes1 = NotificacoesDAO.GetPraNotificacoesByCode(notificacoes.codenotificaçoes);

            PraPagina prapagina1 = new PraPagina()
            {
                id_pra = id_pra,
                id_principal = prapagina.id_principal,
                codigo_pra = prapagina.codigo_pra,
                id_aluno = prapagina.id_aluno,
                id_dt = prapagina.id_dt,
                id_turma = prapagina.id_turma,
                estado = "Incompleto",
                progresso = "Falta a introdução das medidas",
                id_notificaçoes = notificacoes1.id_notificaçoes
            };
            int returnCode102 = PraDAO.UpdatePra(prapagina1);
        }

        protected void binserir7_Click(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["id_pra"];
            int id_pra = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_pra))
            {
                Response.Redirect("~/Home/Home.aspx");
            }

            PraPagina prapagina = PraDAO.GetPraByID(id_pra);
            Notificacoes notificacoes1 = NotificacoesDAO.GetPraNotificacoesByPra(id_pra);
            Notificacoes notificacoes2 = new Notificacoes()
            {
                id_notificaçoes = notificacoes1.id_notificaçoes,
                assinatura_enc = notificacoes1.assinatura_enc,
                data_assinatura_enc = notificacoes1.data_assinatura_enc,
                assinatura_dt = notificacoes1.assinatura_dt,
                data_assinatura_dt = notificacoes1.data_assinatura_dt,
                codenotificaçoes = notificacoes1.codenotificaçoes,
                id_pra = id_pra
            };
            int returnCode104 = NotificacoesDAO.UpdateNotificacoesByID(notificacoes2);
        }

        protected void binserir8_Click(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["id_pra"];
            int id_pra = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_pra))
            {
                Response.Redirect("~/Home/Home.aspx");
            }

            PraPagina prapagina = PraDAO.GetPraByID(id_pra);
            Notificacoes notificacoes1 = NotificacoesDAO.GetPraNotificacoesByPra(id_pra);
            Notificacoes notificacoes2 = new Notificacoes()
            {
                id_notificaçoes = notificacoes1.id_notificaçoes,
                assinatura_enc = notificacoes1.assinatura_enc,
                data_assinatura_enc = notificacoes1.data_assinatura_enc,
                assinatura_pt = notificacoes1.assinatura_pt,
                data_assinatura_pt = notificacoes1.data_assinatura_pt,
                codenotificaçoes = notificacoes1.codenotificaçoes,
                id_pra = id_pra
            };
            int returnCode104 = NotificacoesDAO.UpdateNotificacoesByID(notificacoes2);
        }

        protected void binserir9_Click(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["id_pra"];
            int id_pra = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_pra))
            {
                Response.Redirect("~/Home/Home.aspx");
            }

            PraPagina prapagina = PraDAO.GetPraByID(id_pra);
            Notificacoes notificacoes1 = NotificacoesDAO.GetPraNotificacoesByPra(id_pra);
            Notificacoes notificacoes2 = new Notificacoes()
            {
                id_notificaçoes = notificacoes1.id_notificaçoes,
                assinatura_enc = notificacoes1.assinatura_enc,
                data_assinatura_enc = notificacoes1.data_assinatura_enc,
                data_assinatura_cpcj = notificacoes1.data_assinatura_cpcj,
                codenotificaçoes = notificacoes1.codenotificaçoes,
                id_pra = id_pra
            };
            int returnCode104 = NotificacoesDAO.UpdateNotificacoesByID(notificacoes2);
        }

        protected void binserir10_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                string rawID = Request.QueryString["id_pra"];
                int id_pra = -1;

                if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_pra))
                {
                    Response.Redirect("~/Home/Home.aspx");
                }

                DateTime hoje = DateTime.Today;
                string codedecisao1 = GenerateCoupon(61, new Random());
                Decisao decisao = new Decisao()
                {
                    data_conselho = Convert.ToDateTime(hoje),
                    decisao_code = codedecisao1,
                    id_pra = id_pra
                };
                int returnCode1 = DecisaoDAO.InsertDecisao(decisao);
                Decisao decisao1 = DecisaoDAO.GetPraDecisaoByCode(decisao.decisao_code);


                PraPagina prapagina = PraDAO.GetPraByID(id_pra);

                PraPagina prapagina1 = new PraPagina()
                {
                    id_pra = id_pra,
                    id_principal = prapagina.id_principal,
                    codigo_pra = prapagina.codigo_pra,
                    id_aluno = prapagina.id_aluno,
                    id_dt = prapagina.id_dt,
                    id_turma = prapagina.id_turma,
                    estado = "Incompleto",
                    progresso = "Falta a introdução das medidas",
                    id_decisao = decisao1.id_decisao
                };
                int returnCode102 = PraDAO.UpdatePra(prapagina1);

            }

        }

        protected void binserir11_Click(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["id_pra"];
            int id_pra = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_pra))
            {
                Response.Redirect("~/Home/Home.aspx");
            }
            PraPagina prapagina = PraDAO.GetPraByID(id_pra);

            Decisao decisao1 = DecisaoDAO.GetPraDecisaoByPra(id_pra);

            Decisao decisao2 = new Decisao()
            {
                id_decisao = decisao1.id_decisao,
                data_eadpf = decisao1.data_eadpf,
                medidas_c_s = decisao1.medidas_c_s,
                data_conselho = decisao1.data_conselho,
                consequencia = decisao1.consequencia,
                assinatura_diretor = decisao1.assinatura_diretor,
                data_assinatura_diretor = decisao1.data_assinatura_diretor,
                decisao_code = decisao1.decisao_code,
                id_pra = prapagina.id_pra
            };
            int returnCode102 = DecisaoDAO.UpdateDecisaoByID(decisao2);
        }

        protected void binserir12_Click(object sender, EventArgs e)
        {


            if (Page.IsValid)
            {

                //########################################################
                //###  Pra Decisao                                     ###
                //########################################################

                string codedecisao1 = GenerateCoupon(61, new Random());
                string consequencia;
                if (cbpiaaverbamento.Checked)
                {
                    consequencia = "Processo Individual do Aluno";
                }
                else if (cbeadpfaverbamento.Checked)
                {
                    consequencia = "Encaminhamento do aluno para diferente percurso formativo";
                }
                else
                {
                    consequencia = "Medidas corretivas/ sancionatórias";
                }
                var test = dataeadpfaverbamento.Text;
                Decisao decisao = new Decisao()
                {
                    data_eadpf = string.IsNullOrWhiteSpace(dataeadpfaverbamento.Text) ? (DateTime?)null : Convert.ToDateTime(dataeadpfaverbamento.Text),
                    medidas_c_s = string.IsNullOrWhiteSpace(tbmedidasaverbamento.Text) ? DBNull.Value.ToString() : Convert.ToString(tbmedidasaverbamento.Text),
                    data_conselho = Convert.ToDateTime(datactdecisaoretencao.Text),
                    consequencia = consequencia,
                    assinatura_diretor = tbassdiretoraverbamento.Text,
                    data_assinatura_diretor = Convert.ToDateTime(dataassdaverbamento.Text),
                    decisao_code = codedecisao1
                };
                int returnCode1 = DecisaoDAO.InsertDecisao(decisao);
                Decisao decisao1 = DecisaoDAO.GetPraDecisaoByCode(decisao.decisao_code);


                //########################################################
                //###  Pra Disciplinas/modulos                         ###
                //########################################################



                //########################################################
                //###  Pra Medidas                                     ###
                //########################################################



                string cumprimento;
                string dever_incumprimento;
                if (cbcumprimentosim.Checked)
                {
                    cumprimento = "Sim";
                }
                else if (cbcumprimentonao.Checked)
                {
                    cumprimento = "Não";
                }
                else
                {
                    cumprimento = "";
                }

                if (cbincumprimentosim.Checked)
                {
                    dever_incumprimento = "Sim";
                }
                else if (cbincumprimentonao.Checked)
                {
                    dever_incumprimento = "Não";
                }
                else
                {
                    dever_incumprimento = "";
                }

                var periodo_inicio1 = DateTimeOffset.Parse(tbdataperiodoinicio.Text).DateTime;
                var periodo_fim1 = DateTimeOffset.Parse(tbdataperiodofim.Text).DateTime;
                string codemedidas1 = GenerateCoupon(60, new Random());
                Medidas medidas = new Medidas()
                {
                    periodo_inicio = periodo_inicio1,
                    periodo_fim = periodo_fim1,
                    medida = Convert.ToString(tbmedidas.Text),
                    cumprimento = Convert.ToString(cumprimento),
                    data_cumprimento = string.IsNullOrWhiteSpace(datacumprimento.Text) ? (DateTime?)null : Convert.ToDateTime(datacumprimento.Text),
                    dever_incumprimento = Convert.ToString(dever_incumprimento),
                    data_incumprimento = string.IsNullOrWhiteSpace(dataincumprimento.Text) ? (DateTime?)null : Convert.ToDateTime(dataincumprimento.Text),
                    faltas_desconsideradas = tbfaltasdesconsideradas.Text,
                    codemedidas = codemedidas1
                };
                int returnCode3 = MedidasDAO.InsertMedidas(medidas);
                Medidas medidas1 = MedidasDAO.GetPraMedidasByCode(medidas.codemedidas);

                //########################################################
                //###  Pra Notificaçoes                                ###
                //########################################################                


                string codenotificacoes1 = GenerateCoupon(65, new Random());
                Notificacoes notificacoes = new Notificacoes()
                {
                    assinatura_enc = tbpeeanotificacoes.Text,
                    data_assinatura_enc = Convert.ToDateTime(datapeeanotificacoes.Text),
                    assinatura_dt = tbdtnotificacoes.Text,
                    data_assinatura_dt = Convert.ToDateTime(datadtnotificacoes.Text),
                    assinatura_pt = tbptnotificacoes.Text,
                    data_assinatura_pt = Convert.ToDateTime(dataptnotificacoes.Text),
                    data_assinatura_cpcj = Convert.ToDateTime(datacpcjnotificacoes.Text),
                    codenotificaçoes = codenotificacoes1
                };
                int returnCode4 = NotificacoesDAO.InsertNotificacoes(notificacoes);
                Notificacoes notificacoes1 = NotificacoesDAO.GetPraNotificacoesByCode(notificacoes.codenotificaçoes);

                string codigopra = GenerateCoupon(20, new Random());

                PraPagina prapagina1 = PraDAO.GetPraByCode(codigopra);


                //########################################################
                //###  Pra Updates                                     ###
                //########################################################

                //########################################################
                //###  Pra Decisao Updates                             ###
                //########################################################

                Decisao decisao2 = new Decisao()
                {
                    id_decisao = decisao1.id_decisao,
                    data_eadpf = decisao1.data_eadpf,
                    medidas_c_s = decisao1.medidas_c_s,
                    data_conselho = decisao1.data_conselho,
                    consequencia = decisao1.consequencia,
                    assinatura_diretor = decisao1.assinatura_diretor,
                    data_assinatura_diretor = decisao1.data_assinatura_diretor,
                    decisao_code = decisao1.decisao_code,
                    id_pra = prapagina1.id_pra
                };
                int returnCode102 = DecisaoDAO.UpdateDecisaoByID(decisao2);

                //########################################################
                //###  Pra Medidas Updates                           ###
                //########################################################

                Medidas medidas2 = new Medidas()
                {
                    id_medidas = medidas1.id_medidas,
                    periodo_inicio = medidas1.periodo_fim,
                    periodo_fim = medidas1.periodo_fim,
                    medida = medidas1.medida,
                    cumprimento = medidas1.cumprimento,
                    data_cumprimento = medidas1.data_cumprimento,
                    dever_incumprimento = medidas1.dever_incumprimento,
                    data_incumprimento = medidas1.data_incumprimento,
                    faltas_desconsideradas = medidas1.faltas_desconsideradas,
                    codemedidas = medidas1.codemedidas,
                    id_pra = prapagina1.id_pra
                };
                int returnCode103 = MedidasDAO.UpdateMedidasByID(medidas2);

                //########################################################
                //###  Pra Notificacoes Updates                           ###
                //########################################################

                Notificacoes notificacoes2 = new Notificacoes()
                {
                    id_notificaçoes = notificacoes1.id_notificaçoes,
                    assinatura_enc = notificacoes1.assinatura_enc,
                    data_assinatura_enc = notificacoes1.data_assinatura_enc,
                    assinatura_dt = notificacoes1.assinatura_dt,
                    data_assinatura_dt = notificacoes1.data_assinatura_dt,
                    assinatura_pt = notificacoes1.assinatura_pt,
                    data_assinatura_pt = notificacoes1.data_assinatura_pt,
                    data_assinatura_cpcj = notificacoes1.data_assinatura_cpcj,
                    codenotificaçoes = notificacoes1.codenotificaçoes,
                    id_pra = prapagina1.id_pra
                };
                int returnCode104 = NotificacoesDAO.UpdateNotificacoesByID(notificacoes2);

                //########################################################
                //###  Pra DM Updates                                  ###
                //########################################################
                /*
                DM dm100 = new DM()
                {
                    id_dm = dm11.id_dm,
                    disciplina_modulo = dm11.disciplina_modulo,
                    faltas_excesso = dm11.faltas_excesso,
                    assinatura_professor_disciplina = dm11.assinatura_professor_disciplina,
                    data_assinatura = dm11.data_assinatura,
                    avaliaçao = dm11.avaliaçao,
                    retido = dm11.retido,
                    dmcode = dm11.dmcode,
                    id_pra = prapagina1.id_pra

                };
                int returnCode105 = DMDAO.UpdateDMByID(dm100);

                DM2 dm101 = new DM2()
                {
                    id_dm = dm22.id_dm,
                    disciplina_modulo = dm22.disciplina_modulo,
                    faltas_excesso = dm22.faltas_excesso,
                    assinatura_professor_disciplina = dm22.assinatura_professor_disciplina,
                    data_assinatura = dm22.data_assinatura,
                    avaliaçao = dm22.avaliaçao,
                    retido = dm22.retido,
                    dmcode = dm22.dmcode,
                    id_pra = prapagina1.id_pra

                };
                int returnCode106 = DMDAO.UpdateDMByID2(dm101);

                DM3 dm102 = new DM3()
                {
                    id_dm = dm33.id_dm,
                    disciplina_modulo = dm33.disciplina_modulo,
                    faltas_excesso = dm33.faltas_excesso,
                    assinatura_professor_disciplina = dm33.assinatura_professor_disciplina,
                    data_assinatura = dm33.data_assinatura,
                    avaliaçao = dm33.avaliaçao,
                    retido = dm33.retido,
                    dmcode = dm33.dmcode,
                    id_pra = prapagina1.id_pra

                };
                int returnCode107 = DMDAO.UpdateDMByID3(dm102);

                DM4 dm103 = new DM4()
                {
                    id_dm = dm44.id_dm,
                    disciplina_modulo = dm44.disciplina_modulo,
                    faltas_excesso = dm44.faltas_excesso,
                    assinatura_professor_disciplina = dm44.assinatura_professor_disciplina,
                    data_assinatura = dm44.data_assinatura,
                    avaliaçao = dm44.avaliaçao,
                    retido = dm44.retido,
                    dmcode = dm44.dmcode,
                    id_pra = prapagina1.id_pra

                };
                int returnCode108 = DMDAO.UpdateDMByID4(dm103);

                DM5 dm104 = new DM5()
                {
                    id_dm = dm55.id_dm,
                    disciplina_modulo = dm55.disciplina_modulo,
                    faltas_excesso = dm55.faltas_excesso,
                    assinatura_professor_disciplina = dm55.assinatura_professor_disciplina,
                    data_assinatura = dm55.data_assinatura,
                    avaliaçao = dm55.avaliaçao,
                    retido = dm55.retido,
                    dmcode = dm55.dmcode,
                    id_pra = prapagina1.id_pra

                };
                int returnCode109 = DMDAO.UpdateDMByID5(dm104);
                */

                //########################################################
                //###  Pra DMLigaçao                                   ###
                //########################################################

                /*
                PraDMLigacao pradmligacao = new PraDMLigacao()
                {
                    id_dm = dm11.id_dm,
                    id_pra = prapagina1.id_pra
                };
                int returnCodePraDMlig = PRADMLigacaoDAO.InsertPRADMLigacao(pradmligacao);

                PraDMLigacao2 pradmligacao2 = new PraDMLigacao2()
                {
                    id_dm = dm22.id_dm,
                    id_pra = prapagina1.id_pra
                };
                int returnCodePraDMlig2 = PRADMLigacaoDAO.InsertPRADMLigacao2(pradmligacao2);

                PraDMLigacao3 pradmligacao3 = new PraDMLigacao3()
                {
                    id_dm = dm33.id_dm,
                    id_pra = prapagina1.id_pra
                };
                int returnCodePraDMlig3 = PRADMLigacaoDAO.InsertPRADMLigacao3(pradmligacao3);

                PraDMLigacao4 pradmligacao4 = new PraDMLigacao4()
                {
                    id_dm = dm44.id_dm,
                    id_pra = prapagina1.id_pra
                };
                int returnCodePraDMlig4 = PRADMLigacaoDAO.InsertPRADMLigacao4(pradmligacao4);

                PraDMLigacao5 pradmligacao5 = new PraDMLigacao5()
                {
                    id_dm = dm55.id_dm,
                    id_pra = prapagina1.id_pra
                };
                int returnCodePraDMlig5 = PRADMLigacaoDAO.InsertPRADMLigacao5(pradmligacao5);
                */
            }

        }

        protected void cbcumprimentonao_CheckedChanged(object sender, EventArgs e)
        {
            if (cbcumprimentonao.Checked == true)
            {
                cbincumprimentonao.Checked = false;
                cbcumprimentosim.Checked = false;
                cbincumprimentosim.Checked = false;
                tbfaltasdesconsideradas.Text = "Faltas não recuperadas";
            }
        }

        protected void cbincumprimentonao_CheckedChanged(object sender, EventArgs e)
        {
            if (cbincumprimentonao.Checked == true)
            {
                cbcumprimentonao.Checked = false;
                cbcumprimentosim.Checked = false;
                cbincumprimentosim.Checked = false;
            }
        }

        protected void cbcumprimentosim_CheckedChanged(object sender, EventArgs e)
        {
            if (cbcumprimentosim.Checked == true)
            {
                cbincumprimentonao.Checked = false;
                cbcumprimentonao.Checked = false;
                cbincumprimentosim.Checked = false;
                tbfaltasdesconsideradas.Text = "Faltas desconcideradas";
            }
        }

        protected void cbincumprimentosim_CheckedChanged(object sender, EventArgs e)
        {
            if (cbincumprimentosim.Checked == true)
            {
                cbincumprimentonao.Checked = false;
                cbcumprimentosim.Checked = false;
                cbcumprimentonao.Checked = false;
            }
        }

        protected void cbpiaaverbamento_CheckedChanged(object sender, EventArgs e)
        {
            if (cbpiaaverbamento.Checked == true)
            {
                cbeadpfaverbamento.Checked = false;
                cbmcsaverbamento.Checked = false;
            }
        }

        protected void cbeadpfaverbamento_CheckedChanged(object sender, EventArgs e)
        {
            if (cbeadpfaverbamento.Checked == true)
            {
                cbpiaaverbamento.Checked = false;
                cbmcsaverbamento.Checked = false;
            }
        }

        protected void cbmcsaverbamento_CheckedChanged(object sender, EventArgs e)
        {
            if (cbmcsaverbamento.Checked == true)
            {
                cbeadpfaverbamento.Checked = false;
                cbpiaaverbamento.Checked = false;
            }
        }

        protected void cbsat1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbsat1.Checked == true && (cbnsat2.Checked == true || cbnsat3.Checked == true || cbnsat4.Checked == true || cbnsat5.Checked == true))
            {
                cbnsat1.Checked = false;
                cbexcluido1.Checked = true;
                cbexcluido2.Checked = true;
                cbexcluido3.Checked = true;
                cbexcluido4.Checked = true;
                cbexcluido5.Checked = true;
            }
            else if (cbsat1.Checked == true && (cbnsat4.Checked == false || cbnsat3.Checked == false || cbnsat5.Checked == false || cbnsat2.Checked == false))
            {
                cbnsat1.Checked = false;
            }
            else if (cbsat1.Checked == true && cbsat2.Checked == true && cbsat3.Checked == true && cbsat4.Checked == true && cbsat5.Checked == true)
            {
                cbnsat1.Checked = false;
                cbexcluido1.Checked = false;
                cbexcluido2.Checked = false;
                cbexcluido3.Checked = false;
                cbexcluido4.Checked = false;
                cbexcluido5.Checked = false;
            }
        }

        protected void cbsat2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbsat2.Checked == true && (cbnsat1.Checked == true || cbnsat3.Checked == true || cbnsat4.Checked == true || cbnsat5.Checked == true))
            {
                cbnsat2.Checked = false;
                cbexcluido1.Checked = true;
                cbexcluido2.Checked = true;
                cbexcluido3.Checked = true;
                cbexcluido4.Checked = true;
                cbexcluido5.Checked = true;
            }
            else if (cbsat2.Checked == true && (cbnsat1.Checked == false || cbnsat3.Checked == false || cbnsat5.Checked == false || cbnsat4.Checked == false))
            {
                cbnsat2.Checked = false;
            }
            else if (cbsat1.Checked == true && cbsat2.Checked == true && cbsat3.Checked == true && cbsat4.Checked == true && cbsat5.Checked == true)
            {
                cbnsat2.Checked = false;
                cbexcluido1.Checked = false;
                cbexcluido2.Checked = false;
                cbexcluido3.Checked = false;
                cbexcluido4.Checked = false;
                cbexcluido5.Checked = false;
            }
        }

        protected void cbsat3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbsat3.Checked == true && (cbnsat1.Checked == true || cbnsat2.Checked == true || cbnsat4.Checked == true || cbnsat5.Checked == true))
            {
                cbnsat3.Checked = false;
                cbexcluido1.Checked = true;
                cbexcluido2.Checked = true;
                cbexcluido3.Checked = true;
                cbexcluido4.Checked = true;
                cbexcluido5.Checked = true;
            }
            else if (cbsat3.Checked == true && (cbnsat1.Checked == false || cbnsat4.Checked == false || cbnsat5.Checked == false || cbnsat2.Checked == false))
            {
                cbnsat3.Checked = false;
            }
            else if (cbsat1.Checked == true && cbsat2.Checked == true && cbsat3.Checked == true && cbsat4.Checked == true && cbsat5.Checked == true)
            {
                cbnsat3.Checked = false;
                cbexcluido1.Checked = false;
                cbexcluido2.Checked = false;
                cbexcluido3.Checked = false;
                cbexcluido4.Checked = false;
                cbexcluido5.Checked = false;
            }
        }

        protected void cbsat4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbsat4.Checked == true && (cbnsat1.Checked == true || cbnsat3.Checked == true || cbnsat2.Checked == true || cbnsat5.Checked == true))
            {
                cbnsat4.Checked = false;
                cbexcluido1.Checked = true;
                cbexcluido2.Checked = true;
                cbexcluido3.Checked = true;
                cbexcluido4.Checked = true;
                cbexcluido5.Checked = true;
            }
            else if (cbsat4.Checked == true && (cbnsat1.Checked == false || cbnsat3.Checked == false || cbnsat5.Checked == false || cbnsat2.Checked == false))
            {
                cbnsat4.Checked = false;
            }
            else if (cbsat1.Checked == true && cbsat2.Checked == true && cbsat3.Checked == true && cbsat4.Checked == true && cbsat5.Checked == true)
            {
                cbnsat4.Checked = false;
                cbexcluido1.Checked = false;
                cbexcluido2.Checked = false;
                cbexcluido3.Checked = false;
                cbexcluido4.Checked = false;
                cbexcluido5.Checked = false;
            }
        }

        protected void cbsat5_CheckedChanged(object sender, EventArgs e)
        {
            if (cbsat5.Checked == true && (cbnsat1.Checked == true || cbnsat3.Checked == true || cbnsat4.Checked == true || cbnsat2.Checked == true))
            {
                cbnsat5.Checked = false;
                cbexcluido1.Checked = true;
                cbexcluido2.Checked = true;
                cbexcluido3.Checked = true;
                cbexcluido4.Checked = true;
                cbexcluido5.Checked = true;
            }
            else if (cbsat5.Checked == true && (cbnsat1.Checked == false || cbnsat3.Checked == false || cbnsat4.Checked == false || cbnsat2.Checked == false))
            {
                cbnsat5.Checked = false;
            }
            else if (cbsat1.Checked == true && cbsat2.Checked == true && cbsat3.Checked == true && cbsat4.Checked == true && cbsat5.Checked == true)
            {
                cbnsat5.Checked = false;
                cbexcluido1.Checked = false;
                cbexcluido2.Checked = false;
                cbexcluido3.Checked = false;
                cbexcluido4.Checked = false;
                cbexcluido5.Checked = false;
            }
        }

        protected void cbnsat1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbnsat1.Checked == true)
            {
                cbexcluido1.Checked = true;
                cbexcluido2.Checked = true;
                cbexcluido3.Checked = true;
                cbexcluido4.Checked = true;
                cbexcluido5.Checked = true;
                cbsat1.Checked = false;
            }
        }

        protected void cbnsat2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbnsat2.Checked == true)
            {
                cbexcluido1.Checked = true;
                cbexcluido2.Checked = true;
                cbexcluido3.Checked = true;
                cbexcluido4.Checked = true;
                cbexcluido5.Checked = true;
                cbsat2.Checked = false;
            }
        }

        protected void cbnsat3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbnsat3.Checked == true)
            {
                cbexcluido1.Checked = true;
                cbexcluido2.Checked = true;
                cbexcluido3.Checked = true;
                cbexcluido4.Checked = true;
                cbexcluido5.Checked = true;
                cbsat3.Checked = false;
            }
        }

        protected void cbnsat4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbnsat4.Checked == true)
            {
                cbexcluido1.Checked = true;
                cbexcluido2.Checked = true;
                cbexcluido3.Checked = true;
                cbexcluido4.Checked = true;
                cbexcluido5.Checked = true;
                cbsat4.Checked = false;
            }
        }

        protected void cbnsat5_CheckedChanged(object sender, EventArgs e)
        {
            if (cbnsat5.Checked == true)
            {
                cbexcluido1.Checked = true;
                cbexcluido2.Checked = true;
                cbexcluido3.Checked = true;
                cbexcluido4.Checked = true;
                cbexcluido5.Checked = true;
                cbsat5.Checked = false;
            }
        }

        protected void cbexcluido1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbexcluido1.Checked == true)
            {
                cbsat1.Checked = false;
            }
        }

        protected void cbexcluido2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbexcluido2.Checked == true)
            {
                cbsat2.Checked = false;
            }
        }


        protected void cbexcluido3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbexcluido3.Checked == true)
            {
                cbsat3.Checked = false;
            }
        }

        protected void cbexcluido4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbexcluido4.Checked == true)
            {
                cbsat4.Checked = false;
            }
        }

        protected void cbexcluido5_CheckedChanged(object sender, EventArgs e)
        {
            if (cbexcluido5.Checked == true)
            {
                cbsat5.Checked = false;
            }
        }

    }
}