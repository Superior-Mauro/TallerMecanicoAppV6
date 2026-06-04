using System;
using System.Collections.Generic;
using TallerMecanicoApp.Models;

namespace TallerMecanicoApp.Models;

public static class CatalogoServicios
{
    public static readonly Servicio MantenimientoSimple = new(
        "Mantenimiento Simple",
        240m,
        TimeSpan.FromHours(2),
        "Cambio de aceite de motor, cambio de filtro de aire y aceite,\r\nrevisión de líquidos: refrigerante y frenos.");

    public static readonly Servicio MantenimientoRegular = new(
        "Mantenimiento Regular",
        350m,
        TimeSpan.FromMinutes(160),
        "Cambio de aceite de motor, cambio de filtro de aire y aceite, revisión de bujías,\r\nlimpieza de obturador, revisión de líquidos: refrigerante y frenos.");

    public static readonly Servicio MantenimientoCompleto = new(
        "Mantenimiento Completo",
        450m,
        TimeSpan.FromMinutes(220),
        "Cambio de aceite de motor, cambio de filtro de aire y aceite, revisión de bujías, limpieza de obturador,\r\nrevisión de líquidos: refrigerante y frenos, revisión de pastillas de frenos y zapatas de freno, escáner.");

    public static readonly Servicio Afinamiento = new(
        "Afinamiento",
        250m,
        TimeSpan.FromHours(2),
        "Escáner, limpieza de obturador, limpieza de inyectores y cambio de orrines o jebes,\r\ncambio de filtro de gasolina, revisión de bujías.");

    public static readonly Servicio Otros = new(
        "Otros",
        0m,
        TimeSpan.Zero,
        "Trabajo personalizado.\r\nDetallar manualmente las tareas en la descripción del recuadro.");

    public static List<Servicio> ObtenerTodos()
    {
        return
        [
            MantenimientoSimple,
            MantenimientoRegular,
            MantenimientoCompleto,
            Afinamiento,
            Otros
        ];
    }
}