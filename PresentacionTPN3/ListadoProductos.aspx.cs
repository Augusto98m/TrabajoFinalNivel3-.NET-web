using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
using Services;

namespace PresentacionTPN3
{
    public partial class ListadoProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["Usuario"]))
            {
                Session.Add("error", "Se requieren permisos de administrador");
                Response.Redirect("Error.aspx", false);
            }

            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listarSP());
                gvArticulos.DataSource = Session["listaArticulos"];
                gvArticulos.DataBind();
            }
            
        }
        protected void gvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArtículo.aspx?id=" + id);
        }

        protected void gvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvArticulos.DataSource = Session["listaArticulos"];
            gvArticulos.PageIndex = e.NewPageIndex;
            gvArticulos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioArtículo.aspx", false);
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if(ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBusqueadAvanzada_Click(object sender, EventArgs e)
        {
            string campo = ddlCampo.SelectedItem.ToString();
            string criterio = ddlCriterio.SelectedItem.ToString();
            string filtro = txtFiltroAvanzado.Text;
            
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                gvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);
                gvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}