using System;
using System.Drawing;
using System.Windows.Forms;
using TallerMecanicoApp.Data;

namespace TallerMecanicoApp;

public partial class FrmNuevaCuenta : Form
{
    private readonly TallerRepository _repositorio = new();
    private bool mostrandoContrasena = false;

    public FrmNuevaCuenta()
    {
        InitializeComponent();

        this.AcceptButton = btnCrear;
    }

    // ==========================================
    // 1. CONTROL DEL BOTÓN OJO (MOSTRAR/OCULTAR)
    // ==========================================
    private void btnOjo_Click(object sender, EventArgs e)
    {
        mostrandoContrasena = !mostrandoContrasena;

        if (txtContrasena.Text != "Nueva Contraseña")
        {
            //txtContrasena.UseSystemPasswordChar = !mostrandoContrasena;
            txtContrasena.PasswordChar = mostrandoContrasena ? '\0' : '●';
        }
    }

    // ==========================================
    // 2. EFECTOS PLACEHOLDER (TEXTOS GUÍA)
    // ==========================================
    private void txtNombres_Enter(object sender, EventArgs e)
    {
        if (txtNombres.Text == "Nombres")
        {
            txtNombres.Text = "";
            txtNombres.ForeColor = Color.Black;
        }
    }

    private void txtNombres_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombres.Text))
        {
            txtNombres.Text = "Nombres";
            txtNombres.ForeColor = SystemColors.ControlDark;
        }
    }

    private void txtUsuario_Enter(object sender, EventArgs e)
    {
        if (txtUsuario.Text == "Usuario")
        {
            txtUsuario.Text = "";
            txtUsuario.ForeColor = Color.Black;
        }
    }

    private void txtUsuario_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtUsuario.Text))
        {
            txtUsuario.Text = "Usuario";
            txtUsuario.ForeColor = SystemColors.ControlDark;
        }
    }

    private void txtContrasena_Enter(object sender, EventArgs e)
    {
        if (txtContrasena.Text == "Nueva Contraseña")
        {
            txtContrasena.Text = "";
            txtContrasena.ForeColor = Color.Black;
            //txtContrasena.UseSystemPasswordChar = !mostrandoContrasena;

            // Si el ojo está desactivado (falso), ocultamos al entrar a escribir
            txtContrasena.PasswordChar = mostrandoContrasena ? '\0' : '●';
        }
    }

    private void txtContrasena_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtContrasena.Text))
        {
            txtContrasena.Text = "Nueva Contraseña";
            txtContrasena.ForeColor = SystemColors.ControlDark;
            //txtContrasena.UseSystemPasswordChar = false;

            // Quitamos el enmascaramiento para que se lea la palabra "Nueva Contraseña"
            txtContrasena.PasswordChar = '\0';
        }
    }

    // ==========================================
    // 3. LÓGICA DE REGISTRO MEDIANTE REPOSITORIO
    // ==========================================
    private void btnCrear_Click(object sender, EventArgs e)
    {
        string nombres = txtNombres.Text.Trim();
        string usuario = txtUsuario.Text.Trim();
        string contrasena = txtContrasena.Text;

        if (string.IsNullOrWhiteSpace(nombres) || nombres == "Nombres" ||
            string.IsNullOrWhiteSpace(usuario) || usuario == "Usuario" ||
            string.IsNullOrWhiteSpace(contrasena) || contrasena == "Nueva Contraseña")
        {
            MessageBox.Show("Por favor, complete todos los campos antes de continuar.",
                "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            // Validamos duplicados usando el repositorio central
            if (_repositorio.ExisteUsuario(usuario))
            {
                MessageBox.Show("El nombre de usuario ya se encuentra registrado. Intente con otro.",
                    "Usuario Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insertamos el usuario a través de la persistencia de datos
            _repositorio.RegistrarUsuario(nombres, usuario, contrasena);

            MessageBox.Show("¡Cuenta creada exitosamente! Ahora puede iniciar sesión.",
                "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ocurrió un error al intentar registrar la cuenta:\n" + ex.Message,
                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}