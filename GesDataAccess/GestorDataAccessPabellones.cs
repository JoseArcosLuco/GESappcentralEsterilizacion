using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ges.data.model;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ges.data.access
{
    public class GestorDataAccessPabellones
    {
        private static string connstring = ConfigurationManager.ConnectionStrings["connGes"].ToString();

        /* La Base de Datos tiene una relación Pabellon a ServicioClinicoArea, actualmente el sistema opera con una relación a la tabla ServicioClinico, tener en cuenta que los nombres pueden terminar ser confusos
         * de corregirse la nomenclatura debe revisarse de Pabellones la Tabla en la BD, los procedimientos de almacenado en la BD, el Data Access y el Modelo  */

        public listaPabellones Listar(Int32 id)
        {
            try
            {
                listaPabellones result = new listaPabellones();
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("cruListarPabellones", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        Pabellones obj = new Pabellones();
                        obj.idPabellon = Convert.ToInt32(dt.Rows[i]["idPabellon"]);
                        obj.idServicioClinico = Convert.ToInt32(dt.Rows[i]["idServicioClinicoArea"]);
                        obj.nombre = dt.Rows[i]["nombre"].ToString();
                        obj.nombreServicio = dt.Rows[i]["NOMBRESERVICIO"].ToString();
                        obj.descripcion = dt.Rows[i]["descripcion"].ToString();
                        obj.fechaReg = dt.Rows[i]["fechaReg"].ToString();
                        obj.fechaAct = dt.Rows[i]["fechaAct"].ToString();
                        obj.estado = Convert.ToInt16(dt.Rows[i]["estado"]);
                        result.Add(obj);
                        i++;
                    }
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Respuesta Grabar(Pabellones a)
        {

            Respuesta r = new Respuesta();

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed) { conn.Open(); }
                    SqlCommand cmd = new SqlCommand("AgregarPabellones", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idServicioClinicoArea", a.idServicioClinico);
                    cmd.Parameters.AddWithValue("@nombre", a.nombre);
                    cmd.Parameters.AddWithValue("@descripcion", a.descripcion);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        r.estado = Convert.ToInt32(dt.Rows[0]["estadosp"]);
                        r.descripcion = dt.Rows[0]["mensajesp"].ToString();
                    }
                    return r;
                }
            }
            catch (Exception e)
            {
                r.estado = 0;
                r.descripcion = e.Message.ToString();
                return r;
            }
        }

        public Respuesta Eliminar(Int32 id)
        {
            Respuesta r = new Respuesta();

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed) { conn.Open(); }
                    SqlCommand cmd = new SqlCommand("EliminarPabellones", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdPabellon", id);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        r.estado = Convert.ToInt32(dt.Rows[0]["estadosp"]);
                        r.descripcion = dt.Rows[0]["mensajesp"].ToString();
                    }
                    return r;
                }
            }
            catch (Exception e)
            {
                r.estado = 0;
                r.descripcion = e.Message.ToString();
                return r;
            }
        }

        public Respuesta CambioEstado(Int32 id, int estadonuevo)
        {

            Respuesta r = new Respuesta();

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed) { conn.Open(); }
                    SqlCommand cmd = new SqlCommand("CambiarEstadoPabellones", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdPabellon", id);
                    cmd.Parameters.AddWithValue("@EstadoNuevo", estadonuevo);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        r.estado = Convert.ToInt32(dt.Rows[0]["estadosp"]);
                        r.descripcion = dt.Rows[0]["mensajesp"].ToString();
                    }
                    return r;
                }
            }
            catch (Exception e)
            {
                r.estado = 0;
                r.descripcion = e.Message.ToString();
                return r;
            }
        }
    }
}
