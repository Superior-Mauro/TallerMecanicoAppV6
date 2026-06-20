using Microsoft.Extensions.Configuration;

namespace TallerMecanicoApp.Data;

// Gestiona la conexión segura a SQL Server leyendo el archivo de configuración.
public static class DatabaseConnection
{
    private static readonly Lazy<string> ConnectionString = new(ObtenerCadenaConexion);

    // Retorna la cadena de conexión activa.
    public static string Obtener() => ConnectionString.Value;

    // Lee y valida la configuración desde el archivo appsettings.json
    private static string ObtenerCadenaConexion()
    {
        var configuracion = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var cadena = configuracion.GetConnectionString("TallerMecanico");

        // Validación de seguridad por si el archivo está vacío o mal configurado
        if (string.IsNullOrWhiteSpace(cadena))
        {
            throw new InvalidOperationException(
                "No se encontró la cadena de conexión 'TallerMecanico' en appsettings.json.");
        }

        return cadena;
    }
}
