using Microsoft.Data.SqlClient;
using TallerMecanicoApp.Models;

namespace TallerMecanicoApp.Data;

public sealed class TallerRepository
{
    // ==========================================
    // MÉTODOS DE USUARIOS (LOGIN Y REGISTRO)
    // ==========================================

    public bool ValidarUsuario(string usuario, string contrasena)
    {
        const string sql =
            """
            SELECT COUNT(1)
            FROM dbo.Usuarios
            WHERE NombreUsuario = @usuario 
              AND Contrasena = @contrasena;
            """;

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.Add("@usuario", System.Data.SqlDbType.NVarChar).Value = usuario.Trim();
        comando.Parameters.Add("@contrasena", System.Data.SqlDbType.NVarChar).Value = contrasena.Trim();

        int resultado = Convert.ToInt32(comando.ExecuteScalar());
        return resultado > 0;
    }

    public bool ExisteUsuario(string usuario)
    {
        const string sql =
            """
            SELECT 1
            FROM dbo.Usuarios
            WHERE NombreUsuario = @usuario;
            """;

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@usuario", usuario);
        return comando.ExecuteScalar() is not null;
    }

    public void RegistrarUsuario(string nombres, string usuario, string contrasena)
    {
        const string sql =
            """
            INSERT INTO dbo.Usuarios (Nombres, NombreUsuario, Contrasena)
            VALUES (@nombres, @usuario, @contrasena);
            """;

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@nombres", nombres);
        comando.Parameters.AddWithValue("@usuario", usuario);
        comando.Parameters.AddWithValue("@contrasena", contrasena);
        comando.ExecuteNonQuery();
    }

    // ==========================================
    // MÉTODOS DE VEHÍCULOS
    // ==========================================

    public IReadOnlyList<Vehiculo> ObtenerVehiculos()
    {
        // Esta consulta trae todos los datos del vehículo más el estado de su TRABAJO MÁS RECIENTE
        const string sql =
            """
        SELECT 
            v.Id, 
            v.Placa, 
            v.Cliente, 
            v.Telefono, 
            v.Modelo, 
            v.Dni, 
            v.FechaRegistro,
            ISNULL(t.Estado, 'Sin Trabajos') AS Estado
        FROM dbo.Vehiculos v
        OUTER APPLY (
            SELECT TOP 1 t.Estado
            FROM dbo.Trabajos t
            WHERE t.Placa = v.Placa
            ORDER BY t.FechaRegistro DESC, t.Id DESC
        ) t
        ORDER BY v.FechaRegistro DESC, v.Id DESC;
        """;

        var vehiculos = new List<Vehiculo>();

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        using var lector = comando.ExecuteReader();

        while (lector.Read())
        {
            vehiculos.Add(new Vehiculo(
                lector.GetInt32(0),      // Id
                lector.GetString(1),   // Placa
                lector.GetString(2),   // Cliente
                lector.GetString(4),   // Modelo
                lector.GetString(5),   // Dni
                lector.GetString(3),   // Telefono
                lector.GetDateTime(6),  // FechaRegistro
                lector.GetString(7)    // Estado (NUEVO)
            ));
        }

        return vehiculos;
    }

    public bool ExistePlaca(string placa)
    {
        const string sql =
            """
            SELECT 1
            FROM dbo.Vehiculos
            WHERE Placa = @placa;
            """;

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@placa", placa);
        return comando.ExecuteScalar() is not null;
    }

    public void RegistrarVehiculo(Vehiculo vehiculo)
    {
        const string sql =
            """
            INSERT INTO dbo.Vehiculos (Placa, Cliente, Telefono, Modelo, Dni, FechaRegistro)
            VALUES (@placa, @cliente, @telefono, @modelo, @dni, @fechaRegistro);
            """;

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@placa", vehiculo.Placa);
        comando.Parameters.AddWithValue("@cliente", vehiculo.Cliente);
        comando.Parameters.AddWithValue("@telefono", vehiculo.Telefono);
        comando.Parameters.AddWithValue("@modelo", vehiculo.Modelo);
        comando.Parameters.AddWithValue("@dni", vehiculo.Dni);
        comando.Parameters.AddWithValue("@fechaRegistro", vehiculo.FechaRegistro);
        comando.ExecuteNonQuery();
    }

    public void ActualizarVehiculo(Vehiculo vehiculo)
    {
        const string sql =
            """
            UPDATE dbo.Vehiculos
            SET Cliente = @cliente,
                Telefono = @telefono,
                Modelo = @modelo,
                Dni = @dni,
                FechaRegistro = SYSDATETIME() -- Actualiza a la hora local actual de Lima
            WHERE Placa = @placa;
            """;

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@placa", vehiculo.Placa);
        comando.Parameters.AddWithValue("@cliente", vehiculo.Cliente);
        comando.Parameters.AddWithValue("@telefono", vehiculo.Telefono);
        comando.Parameters.AddWithValue("@modelo", vehiculo.Modelo);
        comando.Parameters.AddWithValue("@dni", vehiculo.Dni);

        comando.ExecuteNonQuery();
    }

    // ----------------------------------------------------------
    // METODO INYECTADO: ELIMINAR POR PLACA
    // ----------------------------------------------------------
    public void EliminarVehiculo(string placa)
    {
        const string sql =
            """
            DELETE FROM dbo.Vehiculos
            WHERE Placa = @placa;
            """;

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@placa", placa);

        comando.ExecuteNonQuery();
    }

    // ==========================================
    // MÉTODOS DE TRABAJOS
    // ==========================================

    public IReadOnlyList<Trabajo> ObtenerTrabajos()
    {
        const string sql =
            """
            SELECT Id, Placa, Mecanico, Descripcion, Estado, ServicioNombre, PrecioBase, TiempoBaseMinutos,
                   CambioRefrigerante, CambioLiquidoFrenos, CambioBujias, TotalPagar, TiempoEstimadoMinutos
            FROM dbo.Trabajos
            ORDER BY FechaRegistro DESC, Id DESC;
            """;

        var trabajos = new List<Trabajo>();

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        using var lector = comando.ExecuteReader();

        while (lector.Read())
        {
            trabajos.Add(new Trabajo
            {
                Id = lector.GetInt32(0),
                Placa = lector.GetString(1),
                Mecanico = lector.GetString(2),
                Descripcion = lector.GetString(3),
                Estado = lector.GetString(4),
                ServicioNombre = lector.GetString(5),
                PrecioBase = lector.GetDecimal(6),
                TiempoBase = TimeSpan.FromMinutes(lector.GetInt32(7)),
                CambioRefrigerante = lector.GetBoolean(8),
                CambioLiquidoFrenos = lector.GetBoolean(9),
                CambioBujias = lector.GetBoolean(10),
                TotalPagar = lector.GetDecimal(11),
                TiempoEstimado = TimeSpan.FromMinutes(lector.GetInt32(12))
            });
        }

        return trabajos;
    }

    public void RegistrarTrabajo(Trabajo trabajo)
    {
        const string sql =
            """
            INSERT INTO dbo.Trabajos
            (
                Placa, Mecanico, Descripcion, Estado, ServicioNombre, PrecioBase, TiempoBaseMinutos,
                CambioRefrigerante, CambioLiquidoFrenos, CambioBujias, TotalPagar, TiempoEstimadoMinutos
            )
            VALUES
            (
                @placa, @mecanico, @descripcion, @estado, @servicioNombre, @precioBase, @tiempoBaseMinutos,
                @cambioRefrigerante, @cambioLiquidoFrenos, @cambioBujias, @totalPagar, @tiempoEstimadoMinutos
            );
            """;

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@placa", trabajo.Placa);
        comando.Parameters.AddWithValue("@mecanico", trabajo.Mecanico);
        comando.Parameters.AddWithValue("@descripcion", trabajo.Descripcion);
        comando.Parameters.AddWithValue("@estado", trabajo.Estado);
        comando.Parameters.AddWithValue("@servicioNombre", trabajo.ServicioNombre);
        comando.Parameters.AddWithValue("@precioBase", trabajo.PrecioBase);
        comando.Parameters.AddWithValue("@tiempoBaseMinutos", (int)trabajo.TiempoBase.TotalMinutes);
        comando.Parameters.AddWithValue("@cambioRefrigerante", trabajo.CambioRefrigerante);
        comando.Parameters.AddWithValue("@cambioLiquidoFrenos", trabajo.CambioLiquidoFrenos);
        comando.Parameters.AddWithValue("@cambioBujias", trabajo.CambioBujias);
        comando.Parameters.AddWithValue("@totalPagar", trabajo.TotalPagar);
        comando.Parameters.AddWithValue("@tiempoEstimadoMinutos", (int)trabajo.TiempoEstimado.TotalMinutes);
        comando.ExecuteNonQuery();
    }

    public void ActualizarTrabajo(Trabajo trabajo)
    {
        const string sql =
            """
            UPDATE dbo.Trabajos
            SET Placa = @placa,
                Mecanico = @mecanico,
                Descripcion = @descripcion,
                Estado = @estado,
                ServicioNombre = @servicioNombre,
                PrecioBase = @precioBase,
                TiempoBaseMinutos = @tiempoBaseMinutos,
                CambioRefrigerante = @cambioRefrigerante,
                CambioLiquidoFrenos = @cambioLiquidoFrenos,
                CambioBujias = @cambioBujias,
                TotalPagar = @totalPagar,
                TiempoEstimadoMinutos = @tiempoEstimadoMinutos
            WHERE Id = @id;
            """;

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@id", trabajo.Id);
        comando.Parameters.AddWithValue("@placa", trabajo.Placa);
        comando.Parameters.AddWithValue("@mecanico", trabajo.Mecanico);
        comando.Parameters.AddWithValue("@descripcion", trabajo.Descripcion);
        comando.Parameters.AddWithValue("@estado", trabajo.Estado);
        comando.Parameters.AddWithValue("@servicioNombre", trabajo.ServicioNombre);
        comando.Parameters.AddWithValue("@precioBase", trabajo.PrecioBase);
        comando.Parameters.AddWithValue("@tiempoBaseMinutos", (int)trabajo.TiempoBase.TotalMinutes);
        comando.Parameters.AddWithValue("@cambioRefrigerante", trabajo.CambioRefrigerante);
        comando.Parameters.AddWithValue("@cambioLiquidoFrenos", trabajo.CambioLiquidoFrenos);
        comando.Parameters.AddWithValue("@cambioBujias", trabajo.CambioBujias);
        comando.Parameters.AddWithValue("@totalPagar", trabajo.TotalPagar);
        comando.Parameters.AddWithValue("@tiempoEstimadoMinutos", (int)trabajo.TiempoEstimado.TotalMinutes);

        comando.ExecuteNonQuery();
    }

    public void EliminarTrabajo(int id)
    {
        const string sql =
            """
            DELETE FROM dbo.Trabajos
            WHERE Id = @id;
            """;

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.AddWithValue("@id", id);

        comando.ExecuteNonQuery();
    }

    // ============================================================
    // MÉTODOS PARA GALERÍA DE IMÁGENES MÚLTIPLES
    // ============================================================

    public void GuardarImagenVehiculo(string placa, byte[] imagenBytes)
    {
        const string sql =
            """
            INSERT INTO dbo.VehiculosImagenes (Placa, datosImagen, FechaRegistro)
            VALUES (@placa, @datosImagen, SYSDATETIME());
            """;

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);

        comando.Parameters.Add("@placa", System.Data.SqlDbType.NVarChar, 15).Value = placa;
        comando.Parameters.Add("@datosImagen", System.Data.SqlDbType.VarBinary, -1).Value = imagenBytes;

        comando.ExecuteNonQuery();
    }

    public IReadOnlyList<byte[]> ObtenerImagenesPorPlaca(string placa)
    {
        const string sql =
            """
            SELECT datosImagen
            FROM dbo.VehiculosImagenes
            WHERE Placa = @placa
            ORDER BY Id ASC;
            """;

        var imagenes = new List<byte[]>();

        using var conexion = AbrirConexion();
        using var comando = new SqlCommand(sql, conexion);
        comando.Parameters.Add("@placa", System.Data.SqlDbType.NVarChar, 15).Value = placa;

        using var lector = comando.ExecuteReader();
        while (lector.Read())
        {
            byte[] buffer = (byte[])lector["DatosImagen"];
            imagenes.Add(buffer);
        }

        return imagenes;
    }

    // ==========================================
    // CONEXIÓN CENTRALIZADA
    // ==========================================

    private static SqlConnection AbrirConexion()
    {
        var conexion = new SqlConnection(DatabaseConnection.Obtener());
        conexion.Open();
        return conexion;
    }
}