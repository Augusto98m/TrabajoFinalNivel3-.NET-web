using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {

		public int RegistrarNuevo(Usuario nuevo)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearProcedimiento("InsertarNuevo");
				datos.setearParametros("@email", nuevo.Email);
                datos.setearParametros("@pass", nuevo.Password);
				return datos.ejecutarAccionScalar();
            }
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
		}
        public bool loguear(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
			{				
				datos.setearConsulta("Select Id, email, pass, admin, nombre, apellido, urlImagenPerfil from USERS where email = @email AND pass = @pass");
				datos.setearParametros("@email", user.Email);
				datos.setearParametros("@pass", user.Password);

				datos.ejecutarLectura();
				while (datos.Lector.Read())
				{
                    user.Id = (int)datos.Lector["Id"];
                    user.TipoUsuario = (bool)(datos.Lector["admin"]);
					if(!(datos.Lector["urlImagenPerfil"] is DBNull))
						user.ImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
					if(!(datos.Lector["nombre"] is DBNull))
						user.Nombre = (string)datos.Lector["nombre"];
					if(!(datos.Lector["apellido"] is DBNull))
						user.Apellido = (string)datos.Lector["apellido"];

                    return true;
				}
				return false;
			}
			catch (Exception ex)
			{				
				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }

        public void actualizar(Usuario user)
        {

            AccesoDatos datos = new AccesoDatos();
            try
			{				
				datos.setearProcedimiento("storedActualizarPerfil");
				datos.setearParametros("@imagen", user.ImagenPerfil != null ? user.ImagenPerfil : (object)DBNull.Value);
                datos.setearParametros("@nombre", user.Nombre);
                datos.setearParametros("@apellido", user.Apellido);
                datos.setearParametros("@id", user.Id);
				datos.ejecutarAccion();

			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }
    }
}
