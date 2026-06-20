# 🛠️ Mecha Prime - Sistema de Gestión de Taller Mecánico

Sistema de escritorio profesional desarrollado en **C#** y **.NET Windows Forms** enfocado en la automatización del flujo de recepción de vehículos, asignación de órdenes de trabajo, cálculo de presupuestos y gestión multimedia de evidencias mediante almacenamiento binario en **SQL Server**.

---

## 🚀 Características Principales

### 📋 Módulo de Recepción (Form1)
* **Diseño de Alta Densidad en 3 Columnas:** Estructura optimizada para monitores de taller que organiza los datos esenciales sin solapamiento:
  * **Columna Izquierda:** Identificación física del vehículo (`Placa`, `Marca/Modelo`) y buscador integrado.
  * **Columna Central:** Datos de contacto del cliente (`Nombre`, `Teléfono`, `DNI`).
  * **Columna Derecha (Multimedia):** Panel de carga rápida y visor en tiempo real de imágenes.
* **Buscador Predictivo Nivel OS:** Caja de texto con Placeholder nativo mediante inyección de código binario de Windows (`user32.dll` / `EM_SETCUEBANNER`) para filtrado instantáneo multivariable (Placa o DNI).
* **Llave Primaria Protegida:** Bloqueo dinámico adaptativo del cuadro de texto de la placa (`ReadOnly = true`) al seleccionar registros existentes para resguardar la integridad referencial en cascada en la base de datos.
* **DataGrid Reactivo:** Enlazado mediante `BindingList<Vehiculo>` con cálculo de pesos proporcionales (`FillWeight`) para prevenir truncamiento de datos.

### 📷 Módulo Multimedia (Carga en Lote)
* **Persistencia Estricta en SQL Server:** Conversión de imágenes a arreglos de bytes puros (`byte[]`) indexados directamente por la placa, eliminando la dependencia de rutas locales de archivos propensas a roturas físicas.
* **Filtro de Seguridad por Peso:** Middleware que valida el tamaño de los archivos antes de la transmisión a la base de datos, omitiendo automáticamente archivos superiores a **3 MB** para mitigar la latencia de red y el crecimiento desmedido del archivo `.mdf`.
* **Visor Integrado y Carrusel Dinámico:** Miniatura instantánea acoplada a la grilla y apertura de galería interactiva flotante en caliente (memoria RAM) con controles de navegación secuencial (`Anterior` / `Siguiente`).

### ⚙️ Módulo de Registro de Trabajos (Form2)
* **Sincronización Bidireccional de Estados:** Acoplamiento mediante herencia de contexto de placa. Al cerrar las órdenes de trabajo, el formulario de control preserva el puntero de selección visual original en la grilla y sincroniza en caliente el nuevo estado de reparación (`Pendiente`, `En proceso`, `Terminado`).

---

## 🛠️ Stack Tecnológico

* **Lenguaje de Programación:** C# (.NET 8.0)
* **Arquitectura de UI:** Windows Forms (Programación Orientada a Eventos)
* **Base de Datos:** SQL Server (Transact-SQL)
* **Mapeador de Datos / Patrón:** Repository Pattern (`TallerRepository`) con desacoplamiento de consultas LINQ.
* **Interoperabilidad:** P/Invoke (`user32.dll` para renderizado avanzado de UI).

---

## 📁 Arquitectura del Código Fuente

```text
TallerMecanicoApp/
│
├── Data/
│   └── TallerRepository.cs       # Operaciones CRUD y persistencia binaria SQL Server.
│
├── Helpers/
│   └── PlacaValidator.cs         # Lógica de expresiones de control para normalización de patentes.
│
├── Models/
│   └── Vehiculo.cs               # Entidad de dominio / Modelo de datos del vehículo.
│
├── Form1.cs                      # Controlador de la UI de Recepción y Gestión de Fotos.
├── Form1.Designer.cs             # Layout posicional absoluto (Matriz en 3 Columnas).
│
├── Form2.cs                      # Módulo de Costos, Órdenes de Trabajo y Estados.
└── Program.cs                    # Punto de entrada de la aplicación.
