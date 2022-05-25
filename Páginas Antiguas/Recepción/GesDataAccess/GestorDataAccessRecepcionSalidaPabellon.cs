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
    public class GestorDataAccessRecepcionSalidaPabellon
    {
        private static string connstring = ConfigurationManager.ConnectionStrings["connGes"].ToString();

        public listaRecepcionSalidaPabellon Listar(Int64 idBodega,string codigoTrazable)
        {
            try
            {
                listaRecepcionSalidaPabellon result = new listaRecepcionSalidaPabellon();
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("cruListarKitRecepcionSalidaPabellon", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idBodega", idBodega);
                    cmd.Parameters.AddWithValue("@codigoTrazable", codigoTrazable);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        RecepcionSalidaPabellon obj = new RecepcionSalidaPabellon();
                        obj.idStock = Convert.ToInt64(dt.Rows[i]["IDSTOCK"]);
                        obj.codigoTrazable = dt.Rows[i]["CODIGOTRAZABLE"].ToString();
                        obj.cantidadRotacion = Convert.ToInt32(dt.Rows[i]["CANTIDADROTACION"]);
                        obj.nombreArticulo = dt.Rows[i]["NOMBREARTICULO"].ToString();
                        obj.fechaMantencion = dt.Rows[i]["FECHAMANTENCION"].ToString();
                        obj.nombreBodega = dt.Rows[i]["NOMBREBODEGA"].ToString();
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
        public listaRecepcionSalidaPabellon Listar(Int64 idBodega)
        {
            try
            {
                listaRecepcionSalidaPabellon result = new listaRecepcionSalidaPabellon();
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("cruListarKitRecepcionSalidaPabellonBodega", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idBodega", idBodega);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        RecepcionSalidaPabellon obj = new RecepcionSalidaPabellon();
                        obj.idStock = Convert.ToInt64(dt.Rows[i]["IDSTOCK"]);
                        obj.codigoTrazable = dt.Rows[i]["CODIGOTRAZABLE"].ToString();
                        obj.cantidadRotacion = Convert.ToInt32(dt.Rows[i]["CANTIDADROTACION"]);
                        obj.nombreArticulo = dt.Rows[i]["NOMBREARTICULO"].ToString();
                        obj.fechaMantencion = dt.Rows[i]["FECHAMANTENCION"].ToString();
                        obj.nombreBodega = dt.Rows[i]["NOMBREBODEGA"].ToString();
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

        public listaRecepcionSalidaPabellon ListarRevisiones(string codigoTrazable)
        {
            try
            {
                listaRecepcionSalidaPabellon result = new listaRecepcionSalidaPabellon();
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("cruListarKitRecepcionSalidaPabellonRevision", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigoTrazable", codigoTrazable);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        RecepcionSalidaPabellon obj = new RecepcionSalidaPabellon();
                        obj.idForm = Convert.ToInt64(dt.Rows[i]["idform"]);
                        obj.fechaReg = dt.Rows[i]["fecha"].ToString();
                        obj.horaReg = dt.Rows[i]["hora"].ToString();
                        obj.nombreFormulario = dt.Rows[i]["nombreform"].ToString();
                        obj.nombreUsuario = dt.Rows[i]["nombreusuario"].ToString();
                        obj.estadoCheck = Convert.ToInt16(dt.Rows[i]["estadocheck"]);
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

        public Respuesta GrabarRecepcionSalidaPabellon(RecepcionSalidaPabellon r) {
            Respuesta s = new Respuesta();
            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed) { conn.Open(); }
                    SqlCommand cmd = new SqlCommand("AgregarRecepcionSalidaPabellon", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idUsuario", r.idUsuario);
                    cmd.Parameters.AddWithValue("@nombreFormulario", r.nombreFormulario);
                    cmd.Parameters.AddWithValue("@codigoTrazable", r.codigoTrazable);
                    cmd.Parameters.AddWithValue("@idServicio", r.idServicioClinico);
                    cmd.Parameters.AddWithValue("@idPabellon", r.idPabellon);
                    cmd.Parameters.AddWithValue("@observacion", r.observacion);
                    cmd.Parameters.AddWithValue("@puesto", r.puesto);
                    cmd.Parameters.AddWithValue("@hora", r.fechaHoraTerminoCirugia);

                    cmd.Parameters.AddWithValue("@arsenalera", r.nombreArsenalera);
                    cmd.Parameters.AddWithValue("@rutPaciente", r.rutPaciente);
                    cmd.Parameters.AddWithValue("@nombrePaciente", r.nombrePaciente);
                    cmd.Parameters.AddWithValue("@estadoCheck", r.estadoCheck);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        s.estado = Convert.ToInt32(dt.Rows[0]["estadosp"]);
                        s.descripcion = dt.Rows[0]["mensajesp"].ToString();
                    }
                    return s;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                throw;
            }
        }
    }
}
