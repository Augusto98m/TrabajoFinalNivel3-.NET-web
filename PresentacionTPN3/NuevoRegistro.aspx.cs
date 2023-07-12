using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Services;
using System.Web.Services.Description;
using System.Windows;

namespace PresentacionTPN3
{
    public partial class NuevoRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrearPerfil_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                Usuario user = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();
                

                string consultar = "select email from USERS where email = '" + txtEmail.Text + "'";
                string consulta = "";
                datos.setearConsulta(consultar);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    consulta = (string)datos.Lector["email"];
                }
                

                user.Email = txtEmail.Text;
                user.Password = txtPass.Text;                

                if (consulta == user.Email)
                {
                    Response.Write("<script>alert('El email ya se encuentra registrado ⚠️ ')</script>");                    
                }
                else
                {
                    user.Id = negocio.RegistrarNuevo(user);
                    Session.Add("Usuario", user);

                    emailService.armarCorreo(user.Email, "Bienvenida SMART!");
                    emailService.enviarEmail();

                    Response.Redirect("MiPerfil.aspx", false);
                }
                

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}