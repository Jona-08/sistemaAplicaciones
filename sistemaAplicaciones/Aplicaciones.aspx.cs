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


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarAplicacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@categoria_id", ddlCategoria.SelectedValue);
                con.Open();
                cmd.ExecuteNonQuery();
                lblMensaje.Text = "Aplicación agregada correctamente.";
                LimpiarFormulario();
                MostrarAplicaciones();
            }
        }

        protected void gvAplicaciones_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarRegistro")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Aplicacion WHERE id = @id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        hfId.Value = dr["id"].ToString();
                        txtNombre.Text = dr["nombre"].ToString();
                        txtDescripcion.Text = dr["descripcion"].ToString();
                        ddlCategoria.SelectedValue = dr["categoria_id"].ToString();

                        btnAgregar.Visible = false;
                        btnActualizar.Visible = true;
                        btnCancelar.Visible = true;
                    }
                }
            }
            else if (e.CommandName == "EliminarRegistro")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarAplicacion", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblMensaje.Text = "Aplicación eliminada correctamente.";
                    MostrarAplicaciones();
                }
            }
        }


    }
}