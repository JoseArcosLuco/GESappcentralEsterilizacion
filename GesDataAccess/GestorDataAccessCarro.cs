using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ges.data.model;

namespace ges.data.access
{
    public class GestorDataAccessCarro
    {
        private static string connstring = ConfigurationManager.ConnectionStrings["connGes"].ToString();
        public listaCarro Listar()
        {
            try
            {
                listaCarro result = new listaCarro();
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    if (conn != null && conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("cruListarCarro", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int i = 0;
                    while (i < dt.Rows.Count)
                    {
                        Carro obj = new Carro();
                        obj.idCarro = Convert.ToInt32(dt.Rows[i]["IDCARRO"]);
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
    }
}
