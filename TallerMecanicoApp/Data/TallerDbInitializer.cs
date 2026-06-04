using Microsoft.Data.SqlClient;

namespace TallerMecanicoApp.Data;

public static class TallerDbInitializer
{
    public static void Inicializar()
    {
        var cadenaCompleta = DatabaseConnection.Obtener();
        var builder = new SqlConnectionStringBuilder(cadenaCompleta);
        var nombreBase = builder.InitialCatalog;

        if (string.IsNullOrWhiteSpace(nombreBase))
        {
            throw new InvalidOperationException(
                "La cadena de conexión debe incluir Database=TallerMecanicoDb (o el nombre de tu base).");
        }

        builder.InitialCatalog = "master";
        CrearBaseSiNoExiste(builder.ConnectionString, nombreBase);

        using var conexion = new SqlConnection(cadenaCompleta);
        conexion.Open();

        // Ejecución de scripts automáticos
        EjecutarScript(conexion, ScriptUsuarios); // <-- SE AGREGA LA TABLA DE LOGINS AQUÍ
        EjecutarScript(conexion, ScriptVehiculos);
        EjecutarScript(conexion, ScriptTrabajos);
        EjecutarScript(conexion, ScriptColumnasAdicionales);
    }

    private static void CrearBaseSiNoExiste(string cadenaMaster, string nombreBase)
    {
        using var conexion = new SqlConnection(cadenaMaster);
        conexion.Open();

        var nombreSeguro = nombreBase.Replace("]", "]]");
        using var comando = conexion.CreateCommand();
        comando.CommandText = $"""
            IF DB_ID(N'{nombreBase.Replace("'", "''")}') IS NULL
            BEGIN
                CREATE DATABASE [{nombreSeguro}];
            END
            """;
        comando.ExecuteNonQuery();
    }

    private static void EjecutarScript(SqlConnection conexion, string script)
    {
        using var comando = conexion.CreateCommand();
        comando.CommandText = script;
        comando.ExecuteNonQuery();
    }

    // ==========================================
    // SCRIPT NUEVO: TABLA DE USUARIOS
    // ==========================================
    private const string ScriptUsuarios =
        """
        IF OBJECT_ID(N'dbo.Usuarios', N'U') IS NULL
        BEGIN
            CREATE TABLE dbo.Usuarios
            (
                Id            INT IDENTITY(1, 1) NOT NULL CONSTRAINT PK_Usuarios PRIMARY KEY,
                Nombres       NVARCHAR(150)      NOT NULL,
                NombreUsuario NVARCHAR(50)       NOT NULL,
                Contrasena    NVARCHAR(100)      NOT NULL,
                FechaRegistro DATETIME2(0)       NOT NULL CONSTRAINT DF_Usuarios_FechaRegistro DEFAULT (SYSUTCDATETIME()),
                CONSTRAINT UQ_Usuarios_NombreUsuario UNIQUE (NombreUsuario)
            );
        END
        """;

    // ==========================================
    // SCRIPTS EXISTENTES
    // ==========================================
    private const string ScriptVehiculos =
            """
        IF OBJECT_ID(N'dbo.Vehiculos', N'U') IS NULL
        BEGIN
            CREATE TABLE dbo.Vehiculos
            (
                Id            INT IDENTITY(1, 1) NOT NULL CONSTRAINT PK_Vehiculos PRIMARY KEY,
                Placa         NVARCHAR(15)       NOT NULL,
                Cliente       NVARCHAR(120)      NOT NULL,
                Telefono      NVARCHAR(20)       NOT NULL CONSTRAINT DF_Vehiculos_Telefono DEFAULT (N''),
                Modelo        NVARCHAR(80)       NOT NULL,
                Dni           NVARCHAR(15)       NOT NULL CONSTRAINT DF_Vehiculos_Dni DEFAULT (N''),
                FechaRegistro DATETIME2(0)       NOT NULL CONSTRAINT DF_Vehiculos_FechaRegistro DEFAULT (SYSUTCDATETIME()),
                CONSTRAINT UQ_Vehiculos_Placa UNIQUE (Placa)
            );
        END
        """;

        private const string ScriptTrabajos =
            """
        IF OBJECT_ID(N'dbo.Trabajos', N'U') IS NULL
        BEGIN
            CREATE TABLE dbo.Trabajos
            (
                Id                    INT IDENTITY(1, 1) NOT NULL CONSTRAINT PK_Trabajos PRIMARY KEY,
                Placa                 NVARCHAR(15)       NOT NULL,
                Mecanico              NVARCHAR(120)      NOT NULL,
                Descripcion           NVARCHAR(500)      NOT NULL,
                Estado                NVARCHAR(30)       NOT NULL,
                ServicioNombre        NVARCHAR(80)       NOT NULL,
                PrecioBase            DECIMAL(10, 2)     NOT NULL,
                TiempoBaseMinutos     INT                NOT NULL,
                CambioRefrigerante    BIT                NOT NULL,
                CambioLiquidoFrenos   BIT                NOT NULL,
                CambioBujias          BIT                NOT NULL,
                TotalPagar            DECIMAL(10, 2)     NOT NULL,
                TiempoEstimadoMinutos INT                NOT NULL,
                FechaRegistro         DATETIME2(0)       NOT NULL CONSTRAINT DF_Trabajos_FechaRegistro DEFAULT (SYSDATETIME()),
                
                CONSTRAINT FK_Trabajos_Vehiculos FOREIGN KEY (Placa) REFERENCES dbo.Vehiculos (Placa) ON DELETE CASCADE
            );
        END
        """;

    private const string ScriptColumnasAdicionales =
        """
        IF OBJECT_ID(N'dbo.Vehiculos', N'U') IS NOT NULL
           AND COL_LENGTH(N'dbo.Vehiculos', N'Telefono') IS NULL
        BEGIN
            ALTER TABLE dbo.Vehiculos
            ADD Telefono NVARCHAR(20) NOT NULL CONSTRAINT DF_Vehiculos_Telefono_Alt DEFAULT (N'') WITH VALUES;
        END

        IF OBJECT_ID(N'dbo.Trabajos', N'U') IS NOT NULL
           AND COL_LENGTH(N'dbo.Trabajos', N'Mecanico') IS NULL
        BEGIN
            ALTER TABLE dbo.Trabajos
            ADD Mecanico NVARCHAR(120) NOT NULL CONSTRAINT DF_Trabajos_Mecanico DEFAULT (N'Sin asignar') WITH VALUES;
        END
        """;
}