using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using negocio;
using System.Text.RegularExpressions;


namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulos> listarSP()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    }
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulos> listarArtById(List<int> listaArtId)
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion TipoMarca, " +
                    "C.Descripcion TipoCategoria, ImagenUrl, A.Precio, A.IdMarca, A.IdCategoria " +
                    "FROM ARTICULOS A, CATEGORIAS C, MARCAS M " +
                    "WHERE C.Id = A.IdCategoria AND A.IdCategoria = M.Id AND A.Id IN (" + string.Join(",", listaArtId) + ")";
                datos.setearConsulta(consulta);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Articulos> listar(string id = "")
        {
            List<Articulos> lista = new List<Articulos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Codigo, Nombre, A.Descripcion, Precio, ImagenUrl, A.Id, M.Descripcion Marca, C.Descripcion Categoria, A.IdMarca, A.IdCategoria from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca AND C.Id = A.IdCategoria ";
                if (id != "")
                {
                    comando.CommandText += " and A.Id = " + id;
                }
                    

                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulos aux = new Articulos();

                    aux.Id = (int)lector["Id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Precio = (decimal)lector["Precio"];
                    if (!(lector["ImagenUrl"] is DBNull))
                    {
                        aux.UrlImagen = (string)lector["ImagenUrl"];
                    }                    
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)lector["IdMarca"];
                    aux.Marca.Descripcion = (string)lector["Marca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)lector["Categoria"];

                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

        public void agregar(Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, Precio, ImagenUrl, IdMarca, IdCategoria) values (@Codigo, @Nombre, @Descripcion, @Precio, @UrlImagen, @idMarca, @idCategoria)");
                datos.setearParametros("@Codigo", nuevo.Codigo);
                datos.setearParametros("@Nombre", nuevo.Nombre);
                datos.setearParametros("@Descripcion", nuevo.Descripcion);
                datos.setearParametros("@Precio", nuevo.Precio);
                datos.setearParametros("@UrlImagen", nuevo.UrlImagen);
                datos.setearParametros("@idMarca", nuevo.Marca.Id);
                datos.setearParametros("@idCategoria", nuevo.Categoria.Id);
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

        public void agregarConSP(Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearProcedimiento("storedAltaArticulo");
                datos.setearParametros("@codigo", nuevo.Codigo);
                datos.setearParametros("@nombre", nuevo.Nombre);
                datos.setearParametros("@descripcion", nuevo.Descripcion);
                datos.setearParametros("@precio", nuevo.Precio);
                datos.setearParametros("@imagen", nuevo.UrlImagen);
                datos.setearParametros("@idMarca", nuevo.Marca.Id);
                datos.setearParametros("@idCategoria", nuevo.Categoria.Id);
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

        public void modificar(Articulos arti)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, ImagenUrl = @urlImagen, Precio = @Precio, IdMarca = @idMarca, IdCategoria = @idCat WHERE Id = @Id");
                datos.setearParametros("@Codigo", arti.Codigo);
                datos.setearParametros("@Nombre", arti.Nombre);
                datos.setearParametros("@Descripcion", arti.Descripcion);
                datos.setearParametros("@urlImagen", arti.UrlImagen);
                datos.setearParametros("@Precio", arti.Precio);
                datos.setearParametros("@idMarca", arti.Marca.Id);
                datos.setearParametros("idCat", arti.Categoria.Id);
                datos.setearParametros("@Id", arti.Id);

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

        public void modificarConSP(Articulos artiNuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedModificarArticulo");
                datos.setearParametros("@Codigo", artiNuevo.Codigo);
                datos.setearParametros("@Nombre", artiNuevo.Nombre);
                datos.setearParametros("@Descripcion", artiNuevo.Descripcion);
                datos.setearParametros("@urlImagen", artiNuevo.UrlImagen);
                datos.setearParametros("@Precio", artiNuevo.Precio);
                datos.setearParametros("@idMarca", artiNuevo.Marca.Id);
                datos.setearParametros("idCat", artiNuevo.Categoria.Id);
                datos.setearParametros("@Id", artiNuevo.Id);

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

        public void eliminarConSP(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedEliminar");
                datos.setearParametros("@Id", Id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulos> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select Codigo, Nombre, A.Descripcion, Precio, ImagenUrl, A.Id, M.Descripcion Marca, C.Descripcion Categoria, A.IdMarca, A.IdCategoria from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca AND C.Id = A.IdCategoria AND ";
                if(campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Contiene":
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                        default:
                                consulta += "Nombre like '%" + filtro + "'";
                            break;
                    }
                }else if(campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += "M.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Contiene":
                            consulta += "M.Descripcion like '%" + filtro + "%'";
                            break;
                        default:                            
                                consulta += "M.Descripcion like '%" + filtro + "'";
                            break;
                    }
                }
                else if (campo == "Categoría")
                {
                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += "C.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Contiene":
                            consulta += "C.Descripcion like '%" + filtro + "%'";
                            break;
                        default:
                            consulta += "C.Descripcion like '%" + filtro + "'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        case "Igual a":
                            consulta += "Precio = " + filtro;
                            break;
                        default:                           
                                consulta += "Precio > " + filtro;
                            break;
                    }
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    }
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    lista.Add(aux);
                }
                return lista;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }        
    }

}
