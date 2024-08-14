using PortafolioMALH2.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PortafolioMALH2.Datos
{
    public class ProyectoTecsDatos
    {
        public List<ProyectoTecs> Listar()
        {
            var oLista = new List<ProyectoTecs>();

            var cn = new conexion();

            using (var conn = new SqlConnection(cn.getCadenaSQL()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_obtenerProyectoTecs", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ProyectoTecs()
                        {
                            NombreProyecto = dr["NombreProyecto"].ToString(),
                            descripcion = dr["descripcion"].ToString(),
                            NombreTecnologia = dr["NombreTecnologia"].ToString(),
                            Version_tec = dr["Version_tec"].ToString(),
                            porcentaje = Convert.ToInt16(dr["porcentaje"])
                        });
                    }

                }
            }
            return oLista;
        }

        public List<ProyectoTecs> ListarPorProyecto(string nombreProyecto)
        {
            
            var oLista = new List<ProyectoTecs>();

            var cn = new conexion();

            using (var conn = new SqlConnection(cn.getCadenaSQL()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_obtenerProyectoTecsPorProy", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreProy", nombreProyecto);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ProyectoTecs()
                        {
                            NombreProyecto = dr["NombreProyecto"].ToString(),
                            descripcion = dr["descripcion"].ToString(),
                            NombreTecnologia = dr["NombreTecnologia"].ToString(),
                            Version_tec = dr["Version_tec"].ToString(),
                            porcentaje = Convert.ToInt16(dr["porcentaje"])
                        });
                    }

                }
            }
            return oLista;
        }

        public List<SelectListItem> ListarProyectos()
        {
            var oLista = new List<SelectListItem>();

            var cn = new conexion();

            using (var conn = new SqlConnection(cn.getCadenaSQL()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_obtenerProyectos", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new SelectListItem()
                        {
                            Value = dr["NombreProyecto"].ToString(),
                            Text = dr["NombreProyecto"].ToString()
                        });
                    }

                }
            }
            return oLista;
        }

    }


}
