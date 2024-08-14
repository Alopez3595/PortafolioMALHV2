using PortafolioMALH2.Models;
using System.Data.SqlClient;
using System.Data;

namespace PortafolioMALH2.Datos
{
    public class desarrolladorDatos
    {
        public List<DesarrolladorModel> Listar()
        {
            var oLista = new List<DesarrolladorModel>();

            var cn = new conexion();

            using (var conn = new SqlConnection(cn.getCadenaSQL()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Consultar_Desa", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new DesarrolladorModel()
                        {
                            Id = Convert.ToInt32(dr["IdPersona"]),
                            NombreCompleto = dr["NombreCom"].ToString(),
                            FechaNacimineto = Convert.ToDateTime(dr["FechaNac"]),
                            NumCel = dr["NumTel"].ToString(),
                            CorreoElec = dr["Email"].ToString(),
                            ImagenURL = dr["ImagenUrl"].ToString(),
                            Descripcion = dr["Descripcion"].ToString()
                        });
                    }

                }
            }
            return oLista;
        }
        public bool Guardar(DesarrolladorModel desarrolladorModel)
        {
            bool resp;

            try { 

                var cn = new conexion();

                using (var conn = new SqlConnection(cn.getCadenaSQL()))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insertar_Desa", conn);

                    cmd.Parameters.AddWithValue("NombreCom", desarrolladorModel.NombreCompleto);
                    cmd.Parameters.AddWithValue("FechaNac", desarrolladorModel.FechaNacimineto);
                    cmd.Parameters.AddWithValue("NumTel", desarrolladorModel.NumCel);
                    cmd.Parameters.AddWithValue("Email", desarrolladorModel.CorreoElec);
                    cmd.Parameters.AddWithValue("ImagenUrl", desarrolladorModel.ImagenURL);
                    cmd.Parameters.AddWithValue("Descripcion", desarrolladorModel.Descripcion);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }
                resp = true;
            }
            catch(Exception ex)
            {
                string error=ex.Message;
                resp= false;
            }
            return resp;
        }
    }
}
