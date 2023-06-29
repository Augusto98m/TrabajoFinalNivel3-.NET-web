using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace PresentacionTPN3
{
    public partial class FormularioArtículo : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled= false;
            try
            {
                if (!IsPostBack)
                {
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    List<Categorias> listaCategorias = categoriaNegocio.listar();
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    List<Marcas> listaMarcas = marcaNegocio.listar();

                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField= "Descripcion";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                }

                string ID = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (ID != "" && !IsPostBack)
                {                    
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    List<Articulos> lista = negocio.listar(ID);
                    Articulos seleccionado = lista[0];

                    txtId.Text = ID;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtUrlImagen.Text = seleccionado.UrlImagen;
                    txtPrecio.Text = seleccionado.Precio.ToString("0.00");
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    cargarImagen();

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoProductos.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                Articulos nuevo = new Articulos();
                ArticuloNegocio negocio = new ArticuloNegocio();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre= txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.UrlImagen= txtUrlImagen.Text;

                nuevo.Categoria = new Categorias();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Marca = new Marcas();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificarConSP(nuevo);
                }                    
                else
                    negocio.agregarConSP(nuevo);

                Response.Redirect("ListadoProductos.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            cargarImagen();
        }

        public void cargarImagen()
        {
            imgArticulo.ImageUrl = txtUrlImagen.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(chkEliminacion.Checked)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminarConSP(int.Parse(txtId.Text));
                    Response.Redirect("ListadoProductos.apsx", false);
                }                
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.apsx", false);
            }
            
        }
    }
}