using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;

namespace PresentacionTPN3
{
    public partial class Inicio : System.Web.UI.Page
    {
        public List<Articulos> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Session.Add("listaArticulos", negocio.listarSP());
            repRepetidor.DataSource = Session["listaArticulos"];
            repRepetidor.DataBind();
        }

        protected void btnBuscando_Click(object sender, EventArgs e)
        {
            List<Articulos> lista = (List<Articulos>)Session["listaArticulos"];
            List<Articulos> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltrar.Text.ToUpper()));
            repRepetidor.DataSource = listaFiltrada;
            repRepetidor.DataBind();
        }

        //protected void ddlOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if(ddlOrdenar.SelectedItem.ToString() == "Por defecto")
        //    {
        //        List<Articulos> articulos = new List<Articulos>();
        //        articulos = (List<Articulos>)articulos.OrderBy(x => x.Nombre);     
        //    }
        //    else if(ddlOrdenar.SelectedItem.ToString() == "Menor precio")
        //    {
        //        List<Articulos> articulos = new List<Articulos>();
        //        articulos = (List<Articulos>)articulos.OrderBy(x => x.Precio).Reverse();
        //    }
        //    else if (ddlOrdenar.SelectedItem.ToString() == "Mayor precio")
        //    {
        //        List<Articulos> articulos = new List<Articulos>();
        //        articulos = (List<Articulos>)articulos.OrderBy(x => x.Precio);
        //    }
        //}        
    }
}