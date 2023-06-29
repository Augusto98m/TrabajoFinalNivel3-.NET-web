using negocio;
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
    public partial class NuevoRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrearPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                Usuario user = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();

                user.Email = txtEmail.Text;
                user.Password = txtPass.Text;
                user.Id = negocio.RegistrarNuevo(user);
                Session.Add("Usuario", user);

                emailService.armarCorreo(user.Email, "Bienvenida SMART!");
                emailService.enviarEmail();

                Response.Redirect("MiPerfil.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            finally
            {
                //Datos.CerrarConexion();
            }
        }
    }
}