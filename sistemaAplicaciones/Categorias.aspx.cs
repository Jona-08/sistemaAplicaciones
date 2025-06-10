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
    public partial class Categorias : System.Web.UI.Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
            }
        }

        private void CargarCategorias()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("sp_VisualizarCategorias", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvCategorias.DataSource = dt;
                    gvCategorias.DataBind();
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertarCategoria", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                txtNombre.Text = "";
                CargarCategorias();
            }
        }

        protected void gvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Eliminar")
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_EliminarCategoria", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                CargarCategorias();
            }
            if (e.CommandName == "Editar")
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Categoria WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            txtNombre.Text = dr["nombre"].ToString();

                        }
                        conn.Close();
                    }
                }
            }

        }
    }
}