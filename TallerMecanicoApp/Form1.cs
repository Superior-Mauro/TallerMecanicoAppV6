using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TallerMecanicoApp.Data;
using TallerMecanicoApp.Helpers;
using TallerMecanicoApp.Models;

namespace TallerMecanicoApp;

public partial class Form1 : Form
{
    private readonly TallerRepository _repositorio = new();
    private readonly BindingList<Vehiculo> _vehiculos;

    // Código nativo de Windows para activar la marca de agua gris
    private const int EM_SETCUEBANNER = 0x1501;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

    public Form1()
    {
        InitializeComponent();
        _vehiculos = new BindingList<Vehiculo>();
        dgvVehiculos.AutoGenerateColumns = false;
        dgvVehiculos.DataSource = _vehiculos;

        // Hace que las columnas cubran todo el ancho gris disponible
        dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // Cada vez que el usuario seleccione una fila, los datos suben automáticamente
        dgvVehiculos.SelectionChanged += dgvVehiculos_SelectionChanged;

        // VINCULAMOS EL CAMPO DE TEXTO CON EL FILTRO
        txtBuscar.TextChanged += txtBuscar_TextChanged;

        SendMessage(txtBuscar.Handle, EM_SETCUEBANNER, 1, "Ingresa el DNI o Número de Placa...");
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        CargarVehiculos();

        // Controlamos los anchos proporcionales de tus 6 columnas de datos reales
        if (dgvVehiculos.Columns["colPlaca"] != null) dgvVehiculos.Columns["colPlaca"].FillWeight = 12;
        if (dgvVehiculos.Columns["colCliente"] != null) dgvVehiculos.Columns["colCliente"].FillWeight = 24;
        if (dgvVehiculos.Columns["colTelefono"] != null) dgvVehiculos.Columns["colTelefono"].FillWeight = 14;
        if (dgvVehiculos.Columns["colModelo"] != null) dgvVehiculos.Columns["colModelo"].FillWeight = 20;
        if (dgvVehiculos.Columns["colDni"] != null) dgvVehiculos.Columns["colDni"].FillWeight = 14;
        if (dgvVehiculos.Columns["colFechaRegistro"] != null) dgvVehiculos.Columns["colFechaRegistro"].FillWeight = 16;

        dgvVehiculos.ClearSelection();
        LimpiarCamposVehiculo();
    }



    // ============================================================
    // LOGICA AUTOMÁTICA DE BÚSQUEDA / SELECCIÓN
    // ============================================================
    private void dgvVehiculos_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvVehiculos.CurrentRow?.DataBoundItem is Vehiculo vehiculo)
        {
            txtPlaca.Text = vehiculo.Placa;
            txtCliente.Text = vehiculo.Cliente;
            txtModelo.Text = vehiculo.Modelo;
            txtTelefono.Text = vehiculo.Telefono;
            txtDni.Text = vehiculo.Dni;

            // Congelamos la placa para que no la alteren en el UPDATE, ya que es la llave en SQL
            txtPlaca.ReadOnly = true;
        }
    }

    // ============================================================
    // BOTÓN: REGISTRAR VEHÍCULO
    // ============================================================
    private void btnRegistrarVehiculo_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtCliente.Text) ||
            string.IsNullOrWhiteSpace(txtModelo.Text) ||
            string.IsNullOrWhiteSpace(txtDni.Text) ||
            string.IsNullOrWhiteSpace(txtPlaca.Text))
        {
            MessageBox.Show("Completa todos los campos para registrar el vehículo.", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!PlacaValidator.EsValida(txtPlaca.Text, out var mensajePlaca))
        {
            MessageBox.Show(mensajePlaca, "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPlaca.Focus();
            return;
        }

        var placa = PlacaValidator.Normalizar(txtPlaca.Text);

        try
        {
            if (_repositorio.ExistePlaca(placa))
            {
                MessageBox.Show("La placa ya está registrada.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Se registra con la hora local actual de Lima
            var vehiculo = new Vehiculo(
                placa,
                txtCliente.Text.Trim(),
                txtModelo.Text.Trim(),
                txtDni.Text.Trim(),
                txtTelefono.Text.Trim());

            _repositorio.RegistrarVehiculo(vehiculo);
            CargarVehiculos();
            LimpiarCamposVehiculo();
        }
        catch (Exception ex)
        {
            MostrarErrorBaseDatos(ex);
        }
    }

    // ============================================================
    // BOTÓN NUEVO: UPDATE (Actualizar por Placa)
    // ============================================================
    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (dgvVehiculos.CurrentRow?.DataBoundItem is Vehiculo vehiculo)
        {
            if (string.IsNullOrWhiteSpace(txtCliente.Text) ||
                string.IsNullOrWhiteSpace(txtModelo.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Por favor, llena los datos en los campos superiores antes de actualizar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var respuesta = MessageBox.Show($"¿Deseas actualizar los datos del vehículo con Placa {vehiculo.Placa}?", "Confirmar Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    vehiculo.Cliente = txtCliente.Text.Trim();
                    vehiculo.Modelo = txtModelo.Text.Trim();
                    vehiculo.Telefono = txtTelefono.Text.Trim();
                    vehiculo.Dni = txtDni.Text.Trim();

                    _repositorio.ActualizarVehiculo(vehiculo);
                    CargarVehiculos();
                    LimpiarCamposVehiculo();
                    MessageBox.Show("Registro modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MostrarErrorBaseDatos(ex);
                }
            }
        }
        else
        {
            MessageBox.Show("Selecciona un vehículo de la lista de abajo para actualizar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    // ============================================================
    // BOTÓN NUEVO: DELETE (Eliminar por Placa)
    // ============================================================
    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvVehiculos.CurrentRow?.DataBoundItem is Vehiculo vehiculo)
        {
            var respuesta = MessageBox.Show($"¿Estás seguro de que deseas eliminar permanentemente el vehículo con placa {vehiculo.Placa}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    _repositorio.EliminarVehiculo(vehiculo.Placa);
                    CargarVehiculos();
                    LimpiarCamposVehiculo();
                    MessageBox.Show("Vehículo removido con éxito de la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MostrarErrorBaseDatos(ex);
                }
            }
        }
        else
        {
            MessageBox.Show("Selecciona el vehículo de la lista que deseas remover.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }


    // ============================================================
    // FILTRO DE BUSCADOR, POR PLACA O DNI
    // ============================================================
    private void txtBuscar_TextChanged(object sender, EventArgs e)
    {
        // 1. Si el usuario borró todo lo que había en la caja de búsqueda...
        if (string.IsNullOrWhiteSpace(txtBuscar.Text))
        {
            // Desactivamos temporalmente el evento de la grilla para que no haga autorelleno
            dgvVehiculos.SelectionChanged -= dgvVehiculos_SelectionChanged;

            // Cargamos todos los vehículos de nuevo a la grilla
            CargarVehiculos("");

            // Quitamos cualquier fila azul seleccionada
            dgvVehiculos.ClearSelection();

            // Vaciamos todos los recuadros superiores y habilitamos la placa
            txtPlaca.Clear();
            txtPlaca.ReadOnly = false;
            txtCliente.Clear();
            txtTelefono.Clear();
            txtModelo.Clear();
            txtDni.Clear();

            // Volvemos a activar el evento de la grilla para futuras búsquedas manuales
            dgvVehiculos.SelectionChanged += dgvVehiculos_SelectionChanged;
        }
        else
        {
            // 2. Si el usuario sí está escribiendo una placa o DNI, filtramos normalmente
            CargarVehiculos(txtBuscar.Text);
        }
    }



    private void btnRegistroTrabajos_Click(object sender, EventArgs e)
    {
        CargarVehiculos();

        if (_vehiculos.Count == 0)
        {
            MessageBox.Show("Debes registrar al menos un vehículo para asignar trabajos.", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var placaSeleccionada = dgvVehiculos.CurrentRow?.DataBoundItem is Vehiculo vehiculo
            ? vehiculo.Placa
            : null;

        using var formTrabajos = new Form2(placaSeleccionada);
        formTrabajos.ShowDialog(this);
    }

    private void CargarVehiculos(string filtro = "")
    {
        try
        {
            _vehiculos.Clear();
            // Traemos la lista completa desde el repositorio
            var listaCompleta = _repositorio.ObtenerVehiculos();

            // Si el usuario escribió algo en el buscador, filtramos con LINQ
            if (!string.IsNullOrWhiteSpace(filtro))
            {
                filtro = filtro.Trim().ToUpper(); // Normalizamos a mayúsculas

                listaCompleta = listaCompleta.Where(v =>
                    v.Placa.ToUpper().Contains(filtro) ||
                    v.Dni.Contains(filtro)
                ).ToList();
            }

            // Cargamos los vehículos filtrados a la grilla
            foreach (var vehiculo in listaCompleta)
            {
                _vehiculos.Add(vehiculo);
            }
        }
        catch (Exception ex)
        {
            MostrarErrorBaseDatos(ex);
        }
    }

    private void LimpiarCamposVehiculo()
    {
        txtPlaca.Clear();
        txtPlaca.ReadOnly = false;
        txtCliente.Clear();
        txtTelefono.Clear();
        txtModelo.Clear();
        txtDni.Clear();
        txtBuscar.Clear();
        txtPlaca.Focus();
    }

    private static void MostrarErrorBaseDatos(Exception ex)
    {
        MessageBox.Show(
            $"No se pudo conectar o guardar en SQL Server.{Environment.NewLine}{Environment.NewLine}{ex.Message}",
            "Base de datos",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}