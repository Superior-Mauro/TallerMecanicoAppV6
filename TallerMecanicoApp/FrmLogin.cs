using System;
using System.Drawing;
using System.Windows.Forms;
using TallerMecanicoApp.Data;

namespace TallerMecanicoApp;

public partial class FrmLogin : Form
{
    private readonly TallerRepository _repositorio = new();
    private bool mostrandoContrasena = false;

    public FrmLogin()
    {
        InitializeComponent();
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
        if (txtContrasena.Text == "Contraseña")
        {
            txtContrasena.Text = "";
            txtContrasena.ForeColor = Color.Black;
            //txtContrasena.UseSystemPasswordChar = !mostrandoContrasena;
            txtContrasena.PasswordChar = mostrandoContrasena ? '\0' : '●';
        }
    }

    private void txtContrasena_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtContrasena.Text))
        {
            txtContrasena.Text = "Contraseña";
            txtContrasena.ForeColor = SystemColors.ControlDark;
            //txtContrasena.UseSystemPasswordChar = false;
            txtContrasena.PasswordChar = '\0';
        }
    }

    private void btnOjo_Click(object sender, EventArgs e)
    {
        mostrandoContrasena = !mostrandoContrasena;
        if (txtContrasena.Text != "Contraseña")
        {
            //txtContrasena.UseSystemPasswordChar = !mostrandoContrasena;
            txtContrasena.PasswordChar = mostrandoContrasena ? '\0' : '●';
        }
    }

    private void lnkCrearCuenta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        // Creamos la instancia de la ventana de registro que acabamos de armar
        using var frmNueva = new FrmNuevaCuenta();

        this.Hide(); // Ocultamos el Login momentáneamente

        // Abrimos FrmNuevaCuenta como ventana modal (se queda al frente)
        frmNueva.ShowDialog();

        // Al cerrarse la ventana de registro (cuando le dan a CREAR o cierran la X), 
        // volvemos a mostrar el login para que inicien sesión
        this.Show();
    }

    private void btnSiguiente_Click(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text.Trim();
        string contrasena = txtContrasena.Text;

        if (string.IsNullOrWhiteSpace(usuario) || usuario == "Usuario" ||
            string.IsNullOrWhiteSpace(contrasena) || contrasena == "Contraseña")
        {
            MessageBox.Show("Por favor ingrese usuario y contraseña válidos.",
                "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            // Ejecutamos la validación usando tu repositorio central de SQL Server
            if (_repositorio.ValidarUsuario(usuario, contrasena))
            {
                Form1 frmRecepcion = new Form1();
                frmRecepcion.Show();
                this.Hide();

                frmRecepcion.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.",
                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtContrasena.Text = "Contraseña";
                txtContrasena.ForeColor = SystemColors.ControlDark;
                //txtContrasena.UseSystemPasswordChar = false;
                txtContrasena.PasswordChar = '\0';
                mostrandoContrasena = false;
                txtUsuario.Focus();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al validar credenciales en SQL Server:\n" + ex.Message,
                "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

}
}