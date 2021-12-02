using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ges.data.model;

namespace ges.data.access
{
    public class GestorDataAccessMetodoEsterilizacion
    {

        private static string connstring = ConfigurationManager.ConnectionStrings["connGes"].ToString();

        public listaMetodoEsterilizacion Listar(Int32 id)
        {
            try
            {
                listaMetodoEsterilizacion result = new listaMetodoEsterilizacion();
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("cruListarMetodoEsterilizacion", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idMaquinaEsterilizacion", id);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        MetodoEsterilizacion obj = new MetodoEsterilizacion();
                        obj.idMetodoEsterilizacion = Convert.ToInt32(dt.Rows[i]["IDMETODOESTERILIZACION"]);
                        obj.idMaquinaEsterilizacion = Convert.ToInt32(dt.Rows[i]["idMaquinaEsterilizacion"]);
                        obj.codigo = dt.Rows[i]["CODIGO"].ToString();
                        obj.nombre = dt.Rows[i]["NOMBRE"].ToString();
                        obj.fechaReg = dt.Rows[i]["FECHAREG"].ToString();
                        obj.fechaAct = dt.Rows[i]["FECHAACT"].ToString();
                        obj.estado = Convert.ToInt16(dt.Rows[i]["ESTADO"]);
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

        public Respuesta Grabar(MetodoEsterilizacion a)
        {

            Respuesta r = new Respuesta();

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed) { conn.Open(); }
                    SqlCommand cmd = new SqlCommand("AgregarMetodoEsterilizacion", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idMaquinaEsterilizacion", a.idMaquinaEsterilizacion);
                    cmd.Parameters.AddWithValue("@codigo", a.codigo);
                    cmd.Parameters.AddWithValue("@nombre", a.nombre);

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
            finally {
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
                    SqlCommand cmd = new SqlCommand("EliminarMetodoEsterilizacion", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);


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
                    SqlCommand cmd = new SqlCommand("CambiarEstadoMetodoEsterilizacion", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);
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
