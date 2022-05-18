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
    public class GestorDataAccessAgenda
    {
        private static string connstring = ConfigurationManager.ConnectionStrings["connGes"].ToString();

        public Respuesta Grabar(Agenda a)
        {

            Respuesta r = new Respuesta();

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed) { conn.Open(); }
                    SqlCommand cmd = new SqlCommand("AgregarAgenda", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    /*
                    cmd.Parameters.AddWithValue("@idServicioClinico", a.idServicioClinico);
                    cmd.Parameters.AddWithValue("@idUsuarioPaciente", a.idUsuarioPaciente);
                    cmd.Parameters.AddWithValue("@idUsuarioProfesional", a.idUsuarioProfesional);
                    cmd.Parameters.AddWithValue("@idAgendaConfiguracion", a.idAgendaConfiguracion);
                    cmd.Parameters.AddWithValue("@idArea", a.idArea);
                    */
                    cmd.Parameters.AddWithValue("@idUsuario", a.idUsuario);
                    cmd.Parameters.AddWithValue("@idPabellon", a.idPabellon);
                    cmd.Parameters.AddWithValue("@asunto", a.asunto);
                    cmd.Parameters.AddWithValue("@descripcion", a.descripcion);
                    cmd.Parameters.AddWithValue("@fechaAgenda", a.fechaAgenda);
                    cmd.Parameters.AddWithValue("@horaAgenda", a.horaAgenda);

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
        public listaAgenda Listar(int id)
        {
            try
            {
                listaAgenda result = new listaAgenda();
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("cruListarAgenda", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdUsuario", id);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        Agenda obj = new Agenda();
                        obj.idAgenda = Convert.ToInt32(dt.Rows[i]["IDAGENDA"]);
                        obj.idUsuario = Convert.ToInt32(dt.Rows[i]["IDUSUARIO"]);
                        obj.idPabellon = Convert.ToInt32(dt.Rows[i]["IDPABELLON"]);
                        obj.nombreServicio = dt.Rows[i]["NOMBRESERVICIO"].ToString();
                        obj.nombrePabellon = dt.Rows[i]["nombre"].ToString();
                        obj.asunto = dt.Rows[i]["ASUNTO"].ToString();
                        obj.descripcion = dt.Rows[i]["DESCRIPCION"].ToString();
                        obj.fechaAgenda = dt.Rows[i]["FECHAAGENDA"].ToString();
                        obj.horaAgenda = (dt.Rows[i]["HORAAGENDA"].ToString());
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

        public Respuesta CambioEstado(Int32 id, Int16 estadonuevo)
        {

            Respuesta r = new Respuesta();

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed) { conn.Open(); }
                    SqlCommand cmd = new SqlCommand("CambiarEstadoAgenda", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdAgenda", id);
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
