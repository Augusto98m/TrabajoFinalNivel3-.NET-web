using dominio;
using negocio;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace PresentacionTPN3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                if (Validacion.validaVacio(txtEmail) || Validacion.validaVacio(txtPass))
                {
                    Response.Write("<script>alert('Complete todos los campos ‼️  ')</script>");
                    //MessageBox.Show("Completa todos los campos", "Ingreso Inválido", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    user.Email = txtEmail.Text;
                    user.Password = txtPass.Text;
                    if (negocio.loguear(user))
                    {
                        Session.Add("Usuario", user);
                        Response.Redirect("MiPerfil.aspx", false);
                    }
                    else
                    {
                        Response.Write("<script>alert('Email o Contraseña incorrectas ❌ ')</script>");
                        //MessageBox.Show("Email o Password incorrectas", "Ingreso Inválido", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                                
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);               
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}