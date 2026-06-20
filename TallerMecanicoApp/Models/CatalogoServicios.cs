using System;
using System.Collections.Generic;
using TallerMecanicoApp.Models;

namespace TallerMecanicoApp.Models;

// Catálogo estático que centraliza las tarifas, tiempos base y descripciones
// de los servicios técnicos estándar y personalizados de Mecha Prime.
public static class CatalogoServicios
{
    // DEFINICIÓN DE SERVICIOS ESTÁNDAR (OBJETOS INMUTABLES)

    // Mantenimiento preventivo básico. S/240.00 | Duración: 2 Horas.
    public static readonly Servicio MantenimientoSimple = new(
        "Mantenimiento Simple",
        240m,
        TimeSpan.FromHours(2),
        "Cambio de aceite de motor, cambio de filtro de aire y aceite,\r\nrevisión de líquidos: refrigerante y frenos.");

    // Mantenimiento preventivo intermedio. S/350.00 | Duración: 160 Minutos (2h 40m).
    public static readonly Servicio MantenimientoRegular = new(
        "Mantenimiento Regular",
        350m,
        TimeSpan.FromMinutes(160),
        "Cambio de aceite de motor, cambio de filtro de aire y aceite, revisión de bujías,\r\nlimpieza de obturador, revisión de líquidos: refrigerante y frenos.");

    // Mantenimiento profundo de sistema. S/450.00 | Duración: 220 Minutos (3h 40m).
    public static readonly Servicio MantenimientoCompleto = new(
        "Mantenimiento Completo",
        450m,
        TimeSpan.FromMinutes(220),
        "Cambio de aceite de motor, cambio de filtro de aire y aceite, revisión de bujías, limpieza de obturador,\r\nrevisión de líquidos: refrigerante y frenos, revisión de pastillas de frenos y zapatas de freno, escáner.");

    // Servicio específico de optimización de combustión. S/250.00 | Duración: 2 Horas.
    public static readonly Servicio Afinamiento = new(
        "Afinamiento",
        250m,
        TimeSpan.FromHours(2),
        "Escáner, limpieza de obturador, limpieza de inyectores y cambio de orrines o jebes,\r\ncambio de filtro de gasolina, revisión de bujías.");

    // Servicio especial tipo "Comodín". Inicializa en cero y se redefine dinámicamente
    // mediante una ventana emergente (Popup) en Form2 cuando el operador requiere un trabajo personalizado.
    public static readonly Servicio Otros = new(
        "Otros",
        0m,
        TimeSpan.Zero,
        "Trabajo personalizado.\r\nDetallar manualmente las tareas en la descripción del recuadro.");


    // MÉTODO DE ACCESO AL CATÁLOGO

    // Retorna la colección completa de servicios disponibles para cargar los ComboBoxes del sistema.
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