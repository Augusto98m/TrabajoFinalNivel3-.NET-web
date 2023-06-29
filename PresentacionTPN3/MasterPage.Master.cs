using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Services;

namespace PresentacionTPN3
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!(Page is Inicio || Page is Nosotros || Page is Login || Page is NuevoRegistro || Page is Error || Page is DetalleProducto))
            {
                if (!Seguridad.sesionActiva(Session["Usuario"]))
                    Response.Redirect("Login.aspx", false);
            }
            if (Seguridad.sesionActiva(Session["Usuario"]) && ((Usuario)Session["Usuario"]).ImagenPerfil != null)
            {
                imgAvatar.ImageUrl = "~/ImagenesPerfil/" + ((Usuario)Session["usuario"]).ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
            }
            else
            {
                imgAvatar.ImageUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png";
            }                               
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}