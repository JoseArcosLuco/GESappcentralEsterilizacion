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
    public class GestorDataAccessBodega
    {
        private static string connstring = ConfigurationManager.ConnectionStrings["connGes"].ToString();
        public listaBodega Listar()
        {
            try
            {
                listaBodega result = new listaBodega();
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("cruListarBodega", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        Bodega obj = new Bodega();
                        obj.idBodega = Convert.ToInt32(dt.Rows[i]["IDBODEGA"]);
                        obj.nombreBodega = dt.Rows[i]["NOMBREBODEGA"].ToString();
                        obj.codigoBodega = dt.Rows[i]["CODIGO"].ToString();
                        obj.layout = Convert.ToBoolean(dt.Rows[i]["LAYOUT"]);
                        obj.centroCosto = dt.Rows[i]["CENTROCOSTO"].ToString();
                        obj.nivel = Convert.ToInt16(dt.Rows[i]["NIVEL"]);
                        obj.orden = Convert.ToInt16(dt.Rows[i]["ORDEN"]);
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

        public Respuesta Grabar(Bodega a)
        {

            Respuesta r = new Respuesta();

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed) { conn.Open(); }
                    SqlCommand cmd = new SqlCommand("AgregarBodega", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombreBodega", a.nombreBodega);
                    cmd.Parameters.AddWithValue("@codigo", a.codigoBodega);
                    cmd.Parameters.AddWithValue("@layout", a.layout);
                    cmd.Parameters.AddWithValue("@centrocosto", a.centroCosto);
                    cmd.Parameters.AddWithValue("@nivel", a.nivel);
                    cmd.Parameters.AddWithValue("@orden", a.orden);
                    

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


        public Respuesta Eliminar(Int16 idBodega)
        {

            Respuesta r = new Respuesta();

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed) { conn.Open(); }
                    SqlCommand cmd = new SqlCommand("EliminarBodega", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdBodega", idBodega);


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

        public Respuesta CambioEstado(Int16 idBodega,int estadonuevo)
        {

            Respuesta r = new Respuesta();

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed) { conn.Open(); }
                    SqlCommand cmd = new SqlCommand("CambiarEstadoBodega", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdBodega", idBodega);
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
