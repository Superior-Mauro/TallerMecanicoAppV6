using Microsoft.VisualBasic.Logging;

namespace TallerMecanicoApp.Models;

// Catálogo estático que centraliza el personal técnico del taller Mecha Prime.
public static class CatalogoMecanicos
{
    // Lista inmutable(de solo lectura) que almacena los nombres de los mecánicos estrella asignados.

    public static readonly IReadOnlyList<string> Nombres = new[]
    {
        "Taro Mizaki",     // Especialista técnico interno
        "Horacio Pagani",  // Leyenda de la ingeniería y fibra de carbono (Pagani Automobili)
        "Chip Foose",      // Maestro del diseño Restomod y personalización americana (Overhaulin')
        "Aaron Kaufman",   // Experto en construcción de chasis y Hot Rods (Gas Monkey Garage)
        "Kazuhiko Nagata", // "Smoky" Nagata - Mitad de la velocidad extrema JDM (Top Secret)
        "Akira Nakai"      // Artesano y maestro del tuning Porsche (RWB - Rauh-Welt Begriff)
    };
}
