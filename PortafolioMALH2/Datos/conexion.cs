namespace PortafolioMALH2.Datos
{
    public class conexion
    {
        private string cadenaSQL = string.Empty;

        public conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaConexionSQL").Value;
        }

        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}
