using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace Libreria
{
    /// <summary>
    /// Clase que realiza el acceso a la base de datos para manipular los hilos.
    /// </summary>
    class HiloCAD
    {
        private String cadenaConexion;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public HiloCAD()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cacatua"].ConnectionString;
        }

        /// <summary>
        /// Obtiene una entidad de negocio Hilo desde una lectura de la base de datos.
        /// </summary>
        /// <param name="dataReader">Lectura de la base de datos desde la que se genera el ENHilo.</param>
        /// <returns>Devuelve un ENHilo.</returns>
        private ENHilo obtenerDatos(SqlDataReader dataReader)
        {
            ENHilo hilo = new ENHilo();
            hilo.Id = int.Parse(dataReader["id"].ToString());
            hilo.Autor = ENUsuario.Obtener(int.Parse(dataReader["autor"].ToString()));
            hilo.AutorUltimaRespuesta = ENUsuario.Obtener(int.Parse(dataReader["autorrespuesta"].ToString()));
            hilo.Texto = dataReader["texto"].ToString();
            hilo.Titulo = dataReader["titulo"].ToString();
            hilo.Categoria = new ENCategoria(int.Parse(dataReader["categoria"].ToString()));
            hilo.Fecha = (DateTime) dataReader["fechacreacion"];
            hilo.FechaUltimaRespuesta = (DateTime)dataReader["fecharespuesta"];
            hilo.NumRespuestas = int.Parse(dataReader["respuestas"].ToString());
            hilo.NumVisitas = int.Parse(dataReader["visitas"].ToString());
            return hilo;
        }

        /// <summary>
        /// Obtiene un hilo desde la base de datos según su identificador (id).
        /// </summary>
        /// <param name="id">Identificador (id) del hilo que se va a obtener.</param>
        /// <returns>Devuelve un hilo extraído desde la base de datos. Si falla, devuelve null.</returns>
        public ENHilo Obtener(int id)
        {
            ENHilo hilo = null;

            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;
                comando.CommandText = "select * from vistaHilos where id = @id";
                comando.Parameters.AddWithValue("@id", id);

                // Realizamos la consulta.
                SqlDataReader dataReader = comando.ExecuteReader();

                // Si hay al menos una fila, extraemos los valores de la primera.
                if (dataReader.Read())
                {
                    hilo = obtenerDatos(dataReader);
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: ENHilo HiloCAD.Obtener(ind id) " + ex.Message);
            }
            finally
            {
                if (conexion!=null)
                    conexion.Close();
            }

            return hilo;
        }

        /// <summary>
        /// Obtiene todos los hilos del foro (lista de ENHilo).
        /// </summary>
        /// <returns>Devuelve una lista de ENHilo con todos los hilos del foro. Si falla, devuelve null.</returns>
        public ArrayList Obtener()
        {
            ArrayList hilos = null;

            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string sentencia = "select * from vistaHilos";
                SqlCommand comando = new SqlCommand(sentencia, conexion);
                SqlDataReader dataReader = comando.ExecuteReader();

                hilos = new ArrayList();

                // Insertamos todas las filas extraidas en el vector.
                while (dataReader.Read())
                {
                    ENHilo hilo = obtenerDatos(dataReader);
                    hilos.Add(hilo);
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: ArrayList HiloCAD.Obtener() " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return hilos;
        }

        /// <summary>
        /// Obtiene una lista de hilos (ArrayList de ENHilo) indicando el número de página y la cantidad de
        /// hilos por página. También es necesario especificar el identificador (id) del hilo desde el que se
        /// va a empezar a contar.
        /// </summary>
        /// <param name="cantidad">Cantidad de hilos en cada página.</param>
        /// <param name="ultimo">Último hilo que se devolvió.</param>
        /// <param name="ordenar">Columna por la que se va a ordenar.</param>
        /// <param name="ascendente">Indica si es un filtro ascendente o descendente.</param>
        /// <returns>Devuelve una lista de hilos (ArrayList de ENHilo). Si falla, devuelve null.</returns>
        public ArrayList Obtener(int cantidad, ENHilo ultimo, string ordenar, bool ascendente)
        {
            ENUsuario usuario = null;
            ENCategoria categoria = null;
            DateTime fecha = DateTime.Now;
            return Obtener(cantidad, ultimo, ordenar, ascendente, "", "", ref usuario, ref fecha, ref fecha, ref categoria);
        }

        /// <summary>
        /// Obtiene una lista de hilos (ArrayList de ENHilo) según un filtro de búsqueda. Es necesario
        /// indicar un número de página, la cantidad de elementos por página y un identificador desde el que se van a 
        /// obtener los hilos.
        /// Sólo devuelve aquellos hilos que coincidan con el título especificado, texto especificado, etc.
        /// Si se especifican con cadena vacía, todos los hilos son coincidentes.
        /// </summary>
        /// <param name="cantidad">Cantidad de hilos en cada página.</param>
        /// <param name="ultimo">Último hilo que se devolvió.</param>
        /// <param name="ordenar">
        /// Columna por la que se va a ordenar. Debe coincide con el nombre de alguna columna de la base de datos.
        /// Para la tabla vistaHilos: "id", "titulo", "texto", "fechacreacion", "autor", "respuestas".
        /// En el caso del autor, como es un valor entero que hace referencia al id, hay que obtener el nombre
        /// por separado, haciendo el producto cartesiano típico e igualando los ids.
        /// </param>
        /// <param name="ascendente">Indica si es un filtro ascendente o descendente.</param>
        /// <param name="titulo">Título para el filtro de búsqueda.</param>
        /// <param name="texto">Texto para el filtro de búsqueda.</param>
        /// <param name="autor">Autor para el filtro de búsqueda.</param>
        /// <param name="fechaInicio">Fecha de inicio para el filtro de búsqueda.</param>
        /// <param name="fechaFin">Fecha de fin para el filtro de búsqueda.</param>
        /// <param name="categoria">Categoria para el filtro de búsqueda.</param>
        /// <returns>Devuelve una lista de hilos (ArrayList de ENHilo). Si falla, devuelve null.</returns>
        public ArrayList Obtener(int cantidad, ENHilo ultimo, string ordenar, bool ascendente, String titulo, String texto
            , ref ENUsuario autor, ref DateTime fechaInicio, ref DateTime fechaFin, ref ENCategoria categoria)
        {
            ArrayList hilos = null;
            if (ordenar == "") ordenar = "vistaHilos.id";
            else if (ordenar == "id") ordenar = "vistaHilos.id";
            else if (ordenar == "autor") ordenar = "nombreusuario";

            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                // Componemos la cadena de la sentencia.
                string sentencia = "";

                if (cantidad > 0)
                    sentencia += "SET ROWCOUNT " + cantidad + " \n";
                sentencia += "select vistaHilos.*, usuarios.usuario as nombreusuario \nfrom vistaHilos, usuarios \nwhere autor = usuarios.id \n";
                if (titulo != "")
                    sentencia += "and (titulo like '%" + @titulo + "%' \n";
                else
                    sentencia += "and (titulo like '%' \n";
                if (texto != "")
                    sentencia += "or texto like '%" + @texto + "%') \n";
                else
                    sentencia += "or texto like '%') \n";
                if (autor != null)
                    sentencia += "and autor = @autor \n";
                if (fechaInicio != fechaFin)
                    sentencia += "and fechacreacion between @fechainicio and @fechafin \n";
                if (categoria != null)
                {
                    ArrayList categorias = categoria.ObtenerDescendencia();
                    string categoriasStr = categoria.Id.ToString();
                    foreach (ENCategoria i in categorias)
                    {
                        categoriasStr += ", " + i.Id;
                    }

                    sentencia += "and categoria in (" + categoriasStr + ") \n";
                }

                if (ultimo != null)
                {
                    // Siempre comparamos el id.
                    sentencia += "and vistaHilos.id ";
                    if (ascendente) sentencia += ">"; else sentencia += "<";
                    sentencia += " @ordenarUltimoId \n";

                    // Si además estamos ordenando por otra columna distinta, comparamos también.
                    /*if (ordenar != "vistaHilos.id")
                    {
                        sentencia += "and " + @ordenar + " ";
                        if (ascendente) sentencia += ">"; else sentencia += "<";
                        sentencia += " @ordenarUltimo \n";
                    }*/
                }

                // Siempre se ordena por el identificador según el orden.
                sentencia += "order by vistaHilos.id ";
                if (ascendente) sentencia += "ASC "; else sentencia += "DESC ";

                // Si además estamos ordenando por otra columna distinta, la añadimos al order by también.
                /*if (ordenar != "vistaHilos.id")
                {
                    sentencia += ", " + @ordenar + " ";
                    if (ascendente) sentencia += "ASC \n"; else sentencia += "DESC \n";
                }*/

                // Asignamos la cadena de sentencia y establecemos los parámetros.
                SqlCommand comando = new SqlCommand(sentencia, conexion);
                if (titulo != "")
                    comando.Parameters.AddWithValue("@titulo", titulo);
                if (texto != "")
                    comando.Parameters.AddWithValue("@texto", texto);
                if (autor != null)
                    comando.Parameters.AddWithValue("@autor", autor.Id);
                if (fechaInicio <= fechaFin)
                {
                    comando.Parameters.AddWithValue("@fechainicio", fechaInicio);
                    comando.Parameters.AddWithValue("@fechafin", fechaFin);
                }

                if (ultimo != null)
                {
                    comando.Parameters.AddWithValue("@ordenarUltimoId", ultimo.Id);
                    /*switch (ordenar)
                    {
                        case "texto":
                            comando.Parameters.AddWithValue("@ordenarUltimo", ultimo.Texto); break;
                        case "titulo":
                            comando.Parameters.AddWithValue("@ordenarUltimo", ultimo.Titulo); break;
                        case "fechacreacion":
                            comando.Parameters.AddWithValue("@ordenarUltimo", ultimo.Fecha); break;
                        case "respuestas":
                            comando.Parameters.AddWithValue("@ordenarUltimo", ultimo.NumRespuestas); break;
                        case "autor":
                            comando.Parameters.AddWithValue("@ordenarUltimo", ultimo.Autor.Usuario); break;
                    }*/
                }

                /*Console.WriteLine("");
                Console.WriteLine("--------------------------");
                Console.WriteLine(sentencia);
                Console.WriteLine("--------------------------");
                Console.WriteLine("");*/

                // Realizamos la consulta.
                SqlDataReader dataReader = comando.ExecuteReader();

                // Insertamos todas las filas extraidas en el vector.
                hilos = new ArrayList();
                while (dataReader.Read())
                {
                    ENHilo material = obtenerDatos(dataReader);
                    hilos.Add(material);
                }

                // Cerramos la consulta.
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: ArrayList HiloCAD.Obtener(monton de gente) " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return hilos;
        }

        /// <summary>
        /// Obtiene todos los hilos según la categoría, el autor, la fecha, el filtro de búsqueda, etc., ordenándolos
        /// según los criterios de orden. También considera el rango según "cantidad" y "orden".
        /// </summary>
        /// <param name="cantidad">Cantidad de resultados que se muestran.</param>
        /// <param name="pagina">Página de resultado que se muestra.</param>
        /// <param name="ordenar">Campo por el que se va a ordenar el resultado.</param>
        /// <param name="ascendente">Indica si es ascendente o descendente.</param>
        /// <param name="titulo">Título para el filtro de búsqueda.</param>
        /// <param name="texto">Texto para el filtro de búsqueda.</param>
        /// <param name="autor">Autor para el filtro de búsqueda.</param>
        /// <param name="fechaInicio">Fecha de inicio para el filtro de búsqueda.</param>
        /// <param name="fechaFin">Fecha de fin para el filtro de búsqueda.</param>
        /// <param name="categoria">Categoria para el filtro de búsqueda.</param>
        /// <returns>Devuelve una lista de hilos (ArrayList de ENHilo). Si falla, devuelve null.</returns>
        public ArrayList Obtener (int cantidad, int pagina, string ordenar, bool ascendente, string titulo, string texto,
            ref ENUsuario autor, ref DateTime fechaInicio, ref DateTime fechaFin, ref ENCategoria categoria)
        {
            ArrayList hilos = null;
            if (ordenar == "") ordenar = "vistaHilos.id";
            else if (ordenar == "id") ordenar = "vistaHilos.id";
            else if (ordenar == "autor") ordenar = "nombreusuario";

            String ordenStr = "ASC";
            if (!ascendente) ordenStr = "DESC";

            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                // Componemos la cadena de la sentencia.
                string sentencia = "select * from (select vistaHilos.*, usuarios.usuario as nombreusuario, ROW_NUMBER() OVER (ORDER BY " + @ordenar + " " + ordenStr + ") AS filas \n";
                sentencia += "from vistaHilos, usuarios \nwhere autor = usuarios.id \n";

                if (titulo != "")
                    sentencia += "and (titulo like '%" + @titulo + "%' \n";
                else
                    sentencia += "and (titulo like '%' \n";
                if (texto != "")
                    sentencia += "or texto like '%" + @texto + "%') \n";
                else
                    sentencia += "or texto like '%') \n";
                if (autor != null)
                    sentencia += "and autor = @autor \n";
                if (fechaInicio != fechaFin)
                    sentencia += "and fechacreacion between @fechainicio and @fechafin \n";
                if (categoria != null)
                {
                    ArrayList categorias = categoria.ObtenerDescendencia();
                    string categoriasStr = categoria.Id.ToString();
                    foreach (ENCategoria i in categorias)
                    {
                        categoriasStr += ", " + i.Id;
                    }

                    sentencia += "and categoria in ("+categoriasStr+") \n";
                }
                sentencia += ") as alias where filas > @filaInicio and filas <= @filaFin \n";

                // Asignamos la cadena de sentencia y establecemos los parámetros.
                SqlCommand comando = new SqlCommand(sentencia, conexion);
                if (titulo != "")
                    comando.Parameters.AddWithValue("@titulo", titulo);
                if (texto != "")
                    comando.Parameters.AddWithValue("@texto", texto);
                if (autor != null)
                    comando.Parameters.AddWithValue("@autor", autor.Id);
                if (fechaInicio <= fechaFin)
                {
                    comando.Parameters.AddWithValue("@fechainicio", fechaInicio);
                    comando.Parameters.AddWithValue("@fechafin", fechaFin);
                }
                comando.Parameters.AddWithValue("@filaInicio", (pagina-1)*cantidad);
                comando.Parameters.AddWithValue("@filaFin", pagina*cantidad);

                Console.WriteLine("");
                Console.WriteLine("--------------------------");
                Console.WriteLine(sentencia);
                Console.WriteLine("--------------------------");
                Console.WriteLine("");

                // Realizamos la consulta.
                SqlDataReader dataReader = comando.ExecuteReader();

                // Insertamos todas las filas extraidas en el vector.
                hilos = new ArrayList();
                while (dataReader.Read())
                {
                    ENHilo material = obtenerDatos(dataReader);
                    hilos.Add(material);
                }

                // Cerramos la consulta.
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: ArrayList HiloCAD.Obtener(monton de gente2) " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return hilos;
        }

        /// <summary>
        /// Obtiene la cantidad de resultados totales que hay con el filtro de búsqueda indicado.
        /// Sólo devuelve aquellos hilos que coincidan con el título especificado, texto especificado, etc.
        /// Si se especifican con cadena vacía, todos los hilos son coincidentes.
        /// </summary>
        /// <param name="titulo">Título para el filtro de búsqueda.</param>
        /// <param name="texto">Texto para el filtro de búsqueda.</param>
        /// <param name="autor">Autor para el filtro de búsqueda.</param>
        /// <param name="fechaInicio">Fecha de inicio para el filtro de búsqueda.</param>
        /// <param name="fechaFin">Fecha de fin para el filtro de búsqueda.</param>
        /// <param name="categoria">Categoria para el filtro de búsqueda.</param>
        /// <returns>Devuelve una lista de hilos (ArrayList de ENHilo). Si falla, devuelve null.</returns>
        public int Cantidad(String titulo, String texto, ref ENUsuario autor,
            ref DateTime fechaInicio, ref DateTime fechaFin, ref ENCategoria categoria)
        {
            int cantidad = 0;

            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                // Componemos la cadena de la sentencia.
                string sentencia = "";

                sentencia += "select count(*) as cantidad \nfrom vistaHilos, usuarios \nwhere autor = usuarios.id \n";
                if (titulo != "")
                    sentencia += "and (titulo like '%" + @titulo + "%' \n";
                else
                    sentencia += "and (titulo like '%' \n";
                if (texto != "")
                    sentencia += "or texto like '%" + @texto + "%') \n";
                else
                    sentencia += "or texto like '%') \n";
                if (autor != null)
                    sentencia += "and autor = @autor \n";
                if (fechaInicio != fechaFin)
                    sentencia += "and fechacreacion between @fechainicio and @fechafin \n";
                if (categoria != null)
                {
                    ArrayList categorias = categoria.ObtenerDescendencia();
                    string categoriasStr = categoria.Id.ToString();
                    foreach (ENCategoria i in categorias)
                    {
                        categoriasStr += ", " + i.Id;
                    }

                    sentencia += "and categoria in (" + categoriasStr + ") \n";
                }

                // Asignamos la cadena de sentencia y establecemos los parámetros.
                SqlCommand comando = new SqlCommand(sentencia, conexion);
                if (titulo != "")
                    comando.Parameters.AddWithValue("@titulo", titulo);
                if (texto != "")
                    comando.Parameters.AddWithValue("@texto", texto);
                if (autor != null)
                    comando.Parameters.AddWithValue("@autor", autor.Id);
                if (fechaInicio <= fechaFin)
                {
                    comando.Parameters.AddWithValue("@fechainicio", fechaInicio);
                    comando.Parameters.AddWithValue("@fechafin", fechaFin);
                }

                // Realizamos la consulta.
                SqlDataReader dataReader = comando.ExecuteReader();

                // Extraemos el valor.
                if (dataReader.Read())
                {
                    cantidad = int.Parse(dataReader["cantidad"].ToString());
                }

                // Cerramos la consulta.
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: int HiloCAD.Cantidad(monton de gente) " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return cantidad;
        }

        /// <summary>
        /// Guarda el nuevo hilo recibido por los parámetros en la base de datos.
        /// </summary>
        /// <param name="hilo">Hilo que se va a guardar en la base de datos.</param>
        /// <param name="id">Identificador que se le asigna al hilo después de insertarse.</param>
        /// <returns>Devuelve verdadero si se ha introducido correctamente.</returns>
        public bool Guardar(ENHilo hilo, out int id)
        {
            bool insertado = false;
            id = 0;

            if (hilo.Autor != null && hilo.Categoria != null)
            {
                SqlConnection conexion = null;
                try
                {
                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();

                    string cadena0 = "BEGIN TRAN";
                    string cadena1 = "insert into hilos (titulo, texto, autor, categoria) values (@titulo, @texto, @autor, @categoria);";
                    string cadena2 = "select max(id) as id from hilos;";
                    string cadena3 = "COMMIT TRAN";

                    string sentencia = cadena0 + " " + cadena1 + " " + cadena2 + " " + cadena3;

                    SqlCommand comando = new SqlCommand(sentencia, conexion);
                    comando.Parameters.AddWithValue("@titulo", hilo.Titulo);
                    comando.Parameters.AddWithValue("@texto", hilo.Texto);
                    comando.Parameters.AddWithValue("@autor", hilo.Autor.Id);
                    comando.Parameters.AddWithValue("@categoria", hilo.Categoria.Id);

                    SqlDataReader dataReader = comando.ExecuteReader();

                    if (dataReader.Read())
                    {
                        insertado = true;
                        id = int.Parse(dataReader["id"].ToString());
                    }

                    dataReader.Close();

                    ArrayList usuarios = hilo.Categoria.UsuariosSuscritos();
                    foreach (ENUsuario i in usuarios)
                    {
                        ENMensaje mensaje = new ENMensaje();
                        mensaje.Emisor = i;
                        mensaje.Receptor = i;
                        mensaje.Texto = "Se ha creado un nuevo hilo con el título \"" + hilo.Titulo + "\" en la categoría \"" + hilo.Categoria.Nombre + "\"";
                        mensaje.Guardar();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: bool HiloCAD.Guardar(ENHilo, out int) " + ex.Message);
                }
                finally
                {
                    if (conexion != null)
                        conexion.Close();
                }
            }

            return insertado;
        }

        /// <summary>
        /// Borra el hilo que se corresponda con el 'id' recibido en los parámetros.
        /// </summary>
        /// <param name="id">Identificador (id) del hilo que se va a borrar desde la base de datos.</param>
        /// <returns>Devuelve verdadero si se ha borrado correctamente.</returns>
        public bool Borrar(int id)
        {
            bool borrado = false;

            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string cadenaComando = "delete from hilos where id = @id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@id", id);

                if (comando.ExecuteNonQuery() == 1)
                    borrado = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("bool HiloCAD.Borrar(int) " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return borrado;
        }

        /// <summary>
        /// Guarda los cambios del hilo recibido en los parámetros. El hilo ya debe existir.
        /// </summary>
        /// <param name="hilo">Hilo que se va a actualizar.</param>
        /// <returns>Devuelve verdadero si se ha guardado correctamente.</returns>
        public bool Actualizar(ENHilo hilo)
        {
            bool actualizado = false;

            if (hilo.Autor != null && hilo.Categoria != null)
            {
                SqlConnection conexion = null;
                try
                {
                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();

                    string sentencia = "update hilos set titulo = @titulo, texto = @texto, autor = @autor, categoria = @categoria, visitas = @visitas where id = @id";

                    SqlCommand comando = new SqlCommand(sentencia, conexion);
                    comando.Parameters.AddWithValue("@titulo", hilo.Titulo);
                    comando.Parameters.AddWithValue("@texto", hilo.Texto);
                    comando.Parameters.AddWithValue("@autor", hilo.Autor.Id);
                    comando.Parameters.AddWithValue("@categoria", hilo.Categoria.Id);
                    comando.Parameters.AddWithValue("@visitas", hilo.NumVisitas);
                    comando.Parameters.AddWithValue("@id", hilo.Id);

                    if (comando.ExecuteNonQuery() == 1)
                    {
                        actualizado = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: bool HiloCAD.Actualizar(ENHilo) " + ex.Message);
                }
                finally
                {
                    if (conexion != null)
                        conexion.Close();
                }
            }

            return actualizado;
        }

        /// <summary>
        /// Realiza una consulta a la base de datos para obtener la cantidad de hilos totales
        /// que hay en el foro.
        /// </summary>
        /// <returns>Devuelve un valor entero con la cantidad de hilos del foro.</returns>
        public int Cantidad()
        {
            ENUsuario usuario = null;
            ENCategoria categoria = null;
            return Cantidad(usuario, categoria);
        }

        /// <summary>
        /// Realiza una consulta a la base de datos para obtener la cantidad de hilos totales
        /// que hay en el foro y que pertenecen a un usuario y/o categoría concreta. Si el usuario
        /// o la categoría indicada en los parámetros es una referencia nula (null), no se considera
        /// esa reestricción. Es decir, si quiero conocer la cantidad de hilos de un usuario en
        /// cualquier categoría, el segundo parámetro debería ser nulo.
        /// </summary>
        /// <param name="usuario">
        /// Usuario del que se obtendrá su número de hilos. Si el valor es nulo, se obtiene el número
        /// de hilos de cualquier usuario.
        /// </param>
        /// <param name="categoria">
        /// Categoría de la que se obtendrá su número de hilos. Si el valor es nulo, se obtienen los
        /// hilos de todas las categorías.
        /// </param>
        /// <returns>Devuelve un valor entero con la cantidad de hilos del foro.</returns>
        public int Cantidad(ENUsuario usuario, ENCategoria categoria)
        {
            int cantidad = 0;
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string sentencia = "select count(*) as cantidad from hilos where 1=1";
                if (usuario != null)
                    sentencia += " and autor = @autor";
                if (categoria != null)
                    sentencia += " and categoria = @categoria";

                SqlCommand comando = new SqlCommand(sentencia, conexion);
                if (usuario != null)
                    comando.Parameters.AddWithValue("@autor", usuario.Id);
                if (categoria != null)
                    comando.Parameters.AddWithValue("@categoria", categoria.Id);

                SqlDataReader dataReader = comando.ExecuteReader();

                if (dataReader.Read())
                {
                    cantidad = int.Parse(dataReader["cantidad"].ToString());
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: int HiloCAD.Cantidad(ENUsuario, ENCategoria) " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return cantidad;
        }

        /// <summary>
        /// Obtiene el último hilo desde la base de datos.
        /// </summary>
        /// <returns>Devuelve el último hilo insertado en la base de datos. Si falla, devuelve null.</returns>
        public ENHilo Ultimo()
        {
            ENHilo hilo = null;

            SqlConnection conexion = null;
            try
            {
                // Creamos y abrimos la conexión.
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                // Creamos el comando.
                SqlCommand comando = new SqlCommand();

                // Le asignamos la conexión al comando.
                comando.Connection = conexion;
                comando.CommandText = "select * from vistaHilos where id in (select max(id) from vistaHilos)";

                // Realizamos la consulta.
                SqlDataReader dataReader = comando.ExecuteReader();

                // Si hay al menos una fila, extraemos los valores de la primera.
                if (dataReader.Read())
                {
                    hilo = obtenerDatos(dataReader);
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: ENHilo HiloCAD.Ultimo() " + ex.Message);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return hilo;
        }
    }
}
