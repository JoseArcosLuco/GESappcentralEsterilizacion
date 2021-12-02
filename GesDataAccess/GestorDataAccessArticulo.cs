using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ges.data.model;
using System.Data.SqlClient;
using System.Data;

namespace ges.data.access
{
    public class GestorDataAccessArticulo
    {
        private static string connstring = ConfigurationManager.ConnectionStrings["connGes"].ToString(); 
        public listaArticulo Listar()
        {
            try
            {
                listaArticulo result = new listaArticulo();
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("cruListarArticulo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        Articulo obj = new Articulo();
                        obj.idArticulo = Convert.ToInt32(dt.Rows[i]["IDARTICULO"]);
                        obj.nombreArticulo = dt.Rows[i]["NOMBREARTICULO"].ToString();
                        obj.nombreComercial = dt.Rows[i]["NOMBRECOMERCIAL"].ToString();
                        obj.codigoArticulo = dt.Rows[i]["CODIGOARTICULO"].ToString();
                        obj.codigoBarra = dt.Rows[i]["CODIGOBARRA"].ToString();
                        obj.codigoExterno = dt.Rows[i]["CODIGOEXTERNO"].ToString();
                        obj.ancho = Convert.ToDecimal(dt.Rows[i]["ANCHO"]);
                        obj.alto = Convert.ToDecimal(dt.Rows[i]["ALTO"]);
                        obj.profundidad = Convert.ToDecimal(dt.Rows[i]["PROFUNDIDAD"]);
                        obj.defaultStockMinimo = Convert.ToInt32(dt.Rows[i]["DEFAULTSTOCKMINIMO"]);
                        obj.defaultStockMaximo = Convert.ToInt32(dt.Rows[i]["DEFAULTSTOCKMAXIMO"]);
                        obj.defaultStockCritico = Convert.ToInt32(dt.Rows[i]["DEFAULTSTOCKCRITICO"]);
                        obj.defaultCosto = Convert.ToInt32(dt.Rows[i]["DEFAULTCOSTO"]);
                        obj.defaultPrecio = Convert.ToInt32(dt.Rows[i]["DEFAULTPRECIO"]);
                        obj.defaultRotacionMantencion = Convert.ToInt32(dt.Rows[i]["DEFAULTROTACIONMANTENCION"]);
                        obj.vencimiento = Convert.ToBoolean(dt.Rows[i]["VENCIMIENTO"]);
                        obj.fechaReg = dt.Rows[i]["fechaReg"].ToString();
                        obj.fechaAct = dt.Rows[i]["fechaAct"].ToString();
                        obj.estado = Convert.ToInt32(dt.Rows[i]["estado"]);
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

        public Respuesta Grabar(Articulo a)
        {

            Respuesta r = new Respuesta();

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed) { conn.Open(); }
                    SqlCommand cmd = new SqlCommand("AgregarArticulo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombreArticulo", a.nombreArticulo);
                    cmd.Parameters.AddWithValue("@nombreComercial", a.nombreComercial);
                    cmd.Parameters.AddWithValue("@codigoArticulo", a.codigoArticulo);
                    cmd.Parameters.AddWithValue("@codigoBarra", a.codigoBarra);
                    cmd.Parameters.AddWithValue("@codigoExterno", a.codigoExterno);
                    cmd.Parameters.AddWithValue("@ancho", a.ancho);
                    cmd.Parameters.AddWithValue("@alto", a.alto);
                    cmd.Parameters.AddWithValue("@profundidad", a.profundidad);
                    cmd.Parameters.AddWithValue("@defaultStockMinimo", a.defaultStockMinimo);
                    cmd.Parameters.AddWithValue("@defaultStockMaximo", a.defaultStockMaximo);
                    cmd.Parameters.AddWithValue("@defaultStockCritico", a.defaultStockCritico);
                    cmd.Parameters.AddWithValue("@defaultCosto", a.defaultCosto);
                    cmd.Parameters.AddWithValue("@defaultPrecio", a.defaultPrecio);
                    cmd.Parameters.AddWithValue("@defaultRotacion", a.defaultRotacionMantencion);
                    cmd.Parameters.AddWithValue("@vencimiento", a.vencimiento);
                    


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


        public Respuesta Eliminar(Int64 id)
        {

            Respuesta r = new Respuesta();

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed) { conn.Open(); }
                    SqlCommand cmd = new SqlCommand("EliminarArticulo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdArticulo", id);


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

        public Respuesta CambioEstado(Int16 id, int estadonuevo)
        {

            Respuesta r = new Respuesta();

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed) { conn.Open(); }
                    SqlCommand cmd = new SqlCommand("CambiarEstadoArticulo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdArticulo", id);
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
