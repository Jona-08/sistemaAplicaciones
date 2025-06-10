using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sistemaAplicaciones
{
    public partial class Aplicaciones : System.Web.UI.Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
                MostrarAplicaciones();
            }
        }

        private void CargarCategorias()
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_VisualizarCategorias", con);
                SqlDataReader dr = cmd.ExecuteReader();
                ddlCategoria.DataSource = dr;
                ddlCategoria.DataTextField = "nombre";
                ddlCategoria.DataValueField = "id";
                ddlCategoria.DataBind();
                ddlCategoria.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione una categoría", "0"));
            }
        }

        private void MostrarAplicaciones()
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_VisualizarAplicaciones", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvAplicaciones.DataSource = dt;
                gvAplicaciones.DataBind();
            }
        }

    }
}