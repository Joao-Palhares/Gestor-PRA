using Gestor.Models;
using Gestor.DataAccess.UserDA;
using Gestor.DataAccess.AlunoDA;
using Gestor.DataAccess.ProfessorDA;
using Gestor.DataAccess.DTDA;
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
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Gestor.Site.Home
{
    public partial class PlanosPra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bnpra.Enabled = false;
                bnpra.Visible = false;
                int iduser = Convert.ToInt32(Session["id_user"]);
                PraPagina prapagina = PraDAO.GetPra();
                if (Session["role"].ToString().Equals("AL"))
                {
                    Aluno aluno = AlunoDAO.GetAlunoByUserID(iduser);
                    RefreshGValuno(aluno.Id_Aluno);
                    bnpra.Enabled = true;
                    bnpra.Visible = true;
                }
                else if (Session["role"].ToString().Equals("DT"))
                {
                    Professor professor = ProfessorDAO.GetProfessorByUserID(iduser);
                    DT dt = DTDAO.GetDTByProfessor1(professor.Id_Professor);
                    RefreshGVDT(dt.id_dt);
                    bnpra.Enabled = true;
                    bnpra.Visible = true;
                }
                else if (prapagina.id_professor1!=null && Session["role"].ToString().Equals("PR"))
                {
                    Professor professor = ProfessorDAO.GetProfessorByUserID(iduser);
                    RefreshGVProfessor1(professor.Id_Professor);
                    bnpra.Enabled = true;
                    bnpra.Visible = true;
                }
                else if (prapagina.id_professor2 != null && Session["role"].ToString().Equals("PR"))
                {
                    Professor professor = ProfessorDAO.GetProfessorByUserID(iduser);
                    RefreshGVProfessor2(professor.Id_Professor);
                    bnpra.Enabled = true;
                    bnpra.Visible = true;
                }
                else if (prapagina.id_professor3 != null && Session["role"].ToString().Equals("PR"))
                {
                    Professor professor = ProfessorDAO.GetProfessorByUserID(iduser);
                    RefreshGVProfessor3(professor.Id_Professor);
                    bnpra.Enabled = true;
                    bnpra.Visible = true;
                }
                else if (prapagina.id_professor4 != null && Session["role"].ToString().Equals("PR"))
                {
                    Professor professor = ProfessorDAO.GetProfessorByUserID(iduser);
                    RefreshGVProfessor4(professor.Id_Professor);
                    bnpra.Enabled = true;
                    bnpra.Visible = true;
                }
                else if (prapagina.id_professor5 != null && Session["role"].ToString().Equals("PR"))
                {
                    Professor professor = ProfessorDAO.GetProfessorByUserID(iduser);
                    RefreshGVProfessor5(professor.Id_Professor);
                    bnpra.Enabled = true;
                    bnpra.Visible = true;
                }

            }
        }

        protected void bnpra_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Home/InserirPra.aspx");
        }

        protected void gvpra_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton lnk = (LinkButton)e.Row.FindControl("lbtSelect");
            LinkButton lnk2 = (LinkButton)e.Row.FindControl("lbtEdit");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                PraPagina prapagina = PraDAO.GetPraByID(Convert.ToInt32(e.Row.Cells[0].Text));
                PraPrincipal prhprincipal = PraPrincipalDAO.GetPraPrincipalByPra(prapagina.id_pra);
                Decisao decisao = DecisaoDAO.GetPraDecisaoByPra(prapagina.id_pra);
                DM dm = DMDAO.GetDMByPra(prapagina.id_pra);
                Medidas medidas = MedidasDAO.GetPraMedidasByPra(prapagina.id_pra);
                Notificacoes notificacoes = NotificacoesDAO.GetPraNotificacoesByPra(prapagina.id_pra);
                

                int iduser = Convert.ToInt32(Session["id_user"]);
                Professor professor = ProfessorDAO.GetProfessorByUserID(iduser);
                DT dt = DTDAO.GetDTByProfessor1(professor.Id_Professor);
                if ((prapagina.id_medidas==null) && (prapagina.id_dt == dt.id_dt) && Session["role"].ToString().Equals("DT"))
                {
                    lnk2.Visible = true;
                }/*
                else if ((prhpagina.id_descricao_atividade != null) && (string.IsNullOrEmpty(descricaoatividades.cumprimento)) && Session["role"].ToString().Equals("PR"))
                {
                    lnk2.Visible = true;
                }
                else if ((prhpagina.id_descricao_atividade != null) && (descricaoatividades.cumprimento != null) && (prhpagina.id_avaliaçoes == null) && Session["role"].ToString().Equals("PR"))
                {
                    lnk2.Visible = true;
                }
                else if ((prhpagina.id_avaliaçoes != null) && (string.IsNullOrEmpty(avaliacao.nome_aluno)) && Session["role"].ToString().Equals("AL"))
                {
                    lnk2.Visible = true;
                }
                else if ((prhpagina.id_avaliaçoes != null) && (!string.IsNullOrEmpty(avaliacao.nome_aluno)) && (string.IsNullOrEmpty(avaliacao.nome_professor)) && Session["role"].ToString().Equals("PR"))
                {
                    lnk2.Visible = true;
                }
                else if ((prhpagina.id_avaliaçoes != null) && (avaliacao.nome_professor != null) && Session["role"].ToString().Equals("DT"))
                {
                    lnk2.Visible = true;
                }
                else if ((prhpagina.id_avaliaçoes != null) && (avaliacao.nome_professor != null) && Session["role"].ToString().Equals("DT"))
                {
                    lnk2.Visible = true;
                }*/

                if (prapagina.estado == "Incompleto")
                {
                    ((Label)e.Row.FindControl("lbestado")).Text = prapagina.estado;
                    ((Label)e.Row.FindControl("lbestado")).ForeColor = System.Drawing.Color.DarkGoldenrod;
                    lnk.Visible = false;
                }
                else if (prapagina.estado == "Completo")
                {
                    ((Label)e.Row.FindControl("lbestado")).Text = prapagina.estado;
                    ((Label)e.Row.FindControl("lbestado")).ForeColor = System.Drawing.Color.Green;
                    lnk.Visible = true;
                }
            }
        }

        protected void gvpra_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvpra_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RefreshGValuno(int id_aluno)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPrasByAluno";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_aluno", id_aluno);

                    connection.Open();
                    using (SqlDataReader datareader = command.ExecuteReader())
                    {
                        gvpra.DataSource = datareader;
                        gvpra.DataBind();
                    }
                }
            }
        }

        private void RefreshGVDT(int id_dt)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPrasByDT";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_dt", id_dt);

                    connection.Open();
                    using (SqlDataReader datareader = command.ExecuteReader())
                    {
                        gvpra.DataSource = datareader;
                        gvpra.DataBind();
                    }
                }
            }
        }

        private void RefreshGVProfessor1(int id_professor1)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPrasByProfessor1";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_professor1", id_professor1);

                    connection.Open();
                    using (SqlDataReader datareader = command.ExecuteReader())
                    {
                        gvpra.DataSource = datareader;
                        gvpra.DataBind();
                    }
                }
            }
        }

        private void RefreshGVProfessor2(int id_professor2)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPrasByProfessor2";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_professor2", id_professor2);

                    connection.Open();
                    using (SqlDataReader datareader = command.ExecuteReader())
                    {
                        gvpra.DataSource = datareader;
                        gvpra.DataBind();
                    }
                }
            }
        }

        private void RefreshGVProfessor3(int id_professor3)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPrasByProfessor3";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_professor3", id_professor3);

                    connection.Open();
                    using (SqlDataReader datareader = command.ExecuteReader())
                    {
                        gvpra.DataSource = datareader;
                        gvpra.DataBind();
                    }
                }
            }
        }

        private void RefreshGVProfessor4(int id_professor4)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPrasByProfessor4";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_professor4", id_professor4);

                    connection.Open();
                    using (SqlDataReader datareader = command.ExecuteReader())
                    {
                        gvpra.DataSource = datareader;
                        gvpra.DataBind();
                    }
                }
            }
        }

        private void RefreshGVProfessor5(int id_professor5)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPrasByProfessor5";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_professor5", id_professor5);

                    connection.Open();
                    using (SqlDataReader datareader = command.ExecuteReader())
                    {
                        gvpra.DataSource = datareader;
                        gvpra.DataBind();
                    }
                }
            }
        }

        private void RefreshGVProfessor6(int id_professor6)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GestorDB"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPrasByProfessor6";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_professor6", id_professor6);

                    connection.Open();
                    using (SqlDataReader datareader = command.ExecuteReader())
                    {
                        gvpra.DataSource = datareader;
                        gvpra.DataBind();
                    }
                }
            }
        }

        protected void FormCommands(object sender, EventArgs e)
        {
            //Init control variables
            LinkButton lbGridView = new LinkButton();
            object senderObj;
            string senderType;

            //Init command argument text
            string command = string.Empty;

            //Get type from sender and 
            //convert to string
            senderObj = sender.GetType();
            senderType = senderObj.ToString();

            //if sender is a linkbutton
            if (senderType.Contains("LinkButton"))
            {
                //Get control references
                lbGridView = (LinkButton)sender;
                //Get selected index of gridview and command arg
                //selectedRowIndex = gridView.SelectedIndex;
                //command = lbGridView.CommandArgument;
                var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

                Response.Write(rowIndex.ToString());
                int id_pra = Convert.ToInt32(gvpra.DataKeys[rowIndex].Value);
                Response.Redirect("../Home/PraVisualizacao.aspx?id_pra=" + id_pra);

            }
        }

        protected void FormCommandsEdit(object sender, EventArgs e)
        {
            //Init control variables
            LinkButton lbGridView = new LinkButton();
            object senderObj;
            string senderType;

            //Init command argument text
            string command = string.Empty;

            //Get type from sender and 
            //convert to string
            senderObj = sender.GetType();
            senderType = senderObj.ToString();

            //if sender is a linkbutton
            if (senderType.Contains("LinkButton"))
            {
                //Get control references
                lbGridView = (LinkButton)sender;
                //Get selected index of gridview and command arg
                //selectedRowIndex = gridView.SelectedIndex;
                //command = lbGridView.CommandArgument;
                var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

                Response.Write(rowIndex.ToString());
                int id_pra = Convert.ToInt32(gvpra.DataKeys[rowIndex].Value);
                Response.Redirect("../Home/PraPreenchimento.aspx?id_pra=" + id_pra);

            }
        }
    }
}