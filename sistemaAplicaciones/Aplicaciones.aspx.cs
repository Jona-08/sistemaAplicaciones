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
    }
}