using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionTPN3
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ID = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (ID != "" && !IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulos> lista = negocio.listar(ID);
                Articulos seleccionado = lista[0];
                
                lblDescripcion.Text = seleccionado.Descripcion;
                imgArticulo.ImageUrl = seleccionado.UrlImagen;
                lblNombre.InnerText = seleccionado.Nombre;
                lblPrecio.Text = "$ " + seleccionado.Precio.ToString("0.00");
                lblCategoria.Text = seleccionado.Categoria.Descripcion.ToString();
                lblMarca.Text = seleccionado.Marca.ToString();
            }
        }
    }
}