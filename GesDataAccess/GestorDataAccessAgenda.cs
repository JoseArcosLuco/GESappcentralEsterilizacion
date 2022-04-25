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
                    cmd.Parameters.AddWithValue("@idUsuario", a.idUsuario);
                    cmd.Parameters.AddWithValue("@idUsuarioPaciente", a.idUsuarioPaciente);
                    cmd.Parameters.AddWithValue("@idUsuarioProfesional", a.idUsuarioProfesional);
                    cmd.Parameters.AddWithValue("@idAgendaConfiguracion", a.idAgendaConfiguracion);
                    cmd.Parameters.AddWithValue("@idArea", a.idArea);
                    */
                    cmd.Parameters.AddWithValue("@idServicioClinico", a.idServicioClinico);
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
    }
}
