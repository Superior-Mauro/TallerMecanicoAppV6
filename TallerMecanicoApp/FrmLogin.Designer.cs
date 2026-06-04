namespace TallerMecanicoApp;

partial class FrmLogin
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
        btnSiguiente = new Button();
        btnOjo = new Button();
        lblTitulo = new Label();
        lblSubtitulo = new Label();
        lblCrearCuenta = new Label();
        pnlCard = new Panel();
        txtUsuario = new TextBox();
        lnkCrearCuenta = new LinkLabel();
        txtContrasena = new TextBox();
        pnlCard.SuspendLayout();
        SuspendLayout();
        // 
        // btnSiguiente
        // 
        btnSiguiente.Location = new Point(328, 243);
        btnSiguiente.Margin = new Padding(4, 3, 4, 3);
        btnSiguiente.Name = "btnSiguiente";
        btnSiguiente.Size = new Size(178, 40);
        btnSiguiente.TabIndex = 0;
        btnSiguiente.Text = "Siguiente";
        btnSiguiente.UseVisualStyleBackColor = true;
        btnSiguiente.Click += btnSiguiente_Click;
        // 
        // btnOjo
        // 
        btnOjo.BackColor = Color.Transparent;
        btnOjo.BackgroundImage = (Image)resources.GetObject("btnOjo.BackgroundImage");
        btnOjo.BackgroundImageLayout = ImageLayout.Zoom;
        btnOjo.FlatAppearance.BorderColor = Color.White;
        btnOjo.FlatAppearance.BorderSize = 0;
        btnOjo.FlatAppearance.MouseDownBackColor = Color.Transparent;
        btnOjo.FlatAppearance.MouseOverBackColor = Color.Transparent;
        btnOjo.FlatStyle = FlatStyle.Flat;
        btnOjo.Location = new Point(555, 190);
        btnOjo.Margin = new Padding(4, 3, 4, 3);
        btnOjo.Name = "btnOjo";
        btnOjo.Size = new Size(52, 46);
        btnOjo.TabIndex = 1;
        btnOjo.UseVisualStyleBackColor = false;
        btnOjo.Click += btnOjo_Click;
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Rockwell", 36F, FontStyle.Bold);
        lblTitulo.Location = new Point(191, 16);
        lblTitulo.Margin = new Padding(4, 0, 4, 0);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(395, 59);
        lblTitulo.TabIndex = 2;
        lblTitulo.Text = "MECHA PRIME";
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSubtitulo
        // 
        lblSubtitulo.AutoSize = true;
        lblSubtitulo.Font = new Font("Microsoft Sans Serif", 9.75F);
        lblSubtitulo.Location = new Point(276, 84);
        lblSubtitulo.Margin = new Padding(4, 0, 4, 0);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Size = new Size(225, 16);
        lblSubtitulo.TabIndex = 3;
        lblSubtitulo.Text = "Ingrese sus datos para iniciar sesión";
        // 
        // lblCrearCuenta
        // 
        lblCrearCuenta.AutoSize = true;
        lblCrearCuenta.ForeColor = SystemColors.InactiveCaptionText;
        lblCrearCuenta.Location = new Point(292, 298);
        lblCrearCuenta.Margin = new Padding(4, 0, 4, 0);
        lblCrearCuenta.Name = "lblCrearCuenta";
        lblCrearCuenta.Size = new Size(129, 15);
        lblCrearCuenta.TabIndex = 4;
        lblCrearCuenta.Text = "¿No tienes una cuenta?";
        // 
        // pnlCard
        // 
        pnlCard.BackColor = SystemColors.AppWorkspace;
        pnlCard.Controls.Add(btnOjo);
        pnlCard.Controls.Add(txtUsuario);
        pnlCard.Controls.Add(lnkCrearCuenta);
        pnlCard.Controls.Add(txtContrasena);
        pnlCard.Controls.Add(lblCrearCuenta);
        pnlCard.Controls.Add(lblSubtitulo);
        pnlCard.Controls.Add(btnSiguiente);
        pnlCard.Controls.Add(lblTitulo);
        pnlCard.Location = new Point(61, 47);
        pnlCard.Margin = new Padding(4, 3, 4, 3);
        pnlCard.Name = "pnlCard";
        pnlCard.Size = new Size(802, 428);
        pnlCard.TabIndex = 5;
        // 
        // txtUsuario
        // 
        txtUsuario.BorderStyle = BorderStyle.FixedSingle;
        txtUsuario.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
        txtUsuario.ForeColor = SystemColors.ControlDark;
        txtUsuario.Location = new Point(219, 126);
        txtUsuario.Margin = new Padding(4, 3, 4, 3);
        txtUsuario.Multiline = true;
        txtUsuario.Name = "txtUsuario";
        txtUsuario.RightToLeft = RightToLeft.No;
        txtUsuario.Size = new Size(388, 45);
        txtUsuario.TabIndex = 6;
        txtUsuario.Text = "Usuario";
        txtUsuario.Enter += txtUsuario_Enter;
        txtUsuario.Leave += txtUsuario_Leave;
        // 
        // lnkCrearCuenta
        // 
        lnkCrearCuenta.AutoSize = true;
        lnkCrearCuenta.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
        lnkCrearCuenta.Location = new Point(440, 298);
        lnkCrearCuenta.Margin = new Padding(4, 0, 4, 0);
        lnkCrearCuenta.Name = "lnkCrearCuenta";
        lnkCrearCuenta.Size = new Size(81, 13);
        lnkCrearCuenta.TabIndex = 8;
        lnkCrearCuenta.TabStop = true;
        lnkCrearCuenta.Text = "Crear Cuenta";
        lnkCrearCuenta.LinkClicked += lnkCrearCuenta_LinkClicked;
        // 
        // txtContrasena
        // 
        txtContrasena.BorderStyle = BorderStyle.FixedSingle;
        txtContrasena.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
        txtContrasena.ForeColor = SystemColors.ControlDark;
        txtContrasena.Location = new Point(219, 190);
        txtContrasena.Margin = new Padding(4, 3, 4, 3);
        txtContrasena.Multiline = true;
        txtContrasena.Name = "txtContrasena";
        txtContrasena.Size = new Size(388, 46);
        txtContrasena.TabIndex = 7;
        txtContrasena.Text = "Contraseña";
        txtContrasena.Enter += txtContrasena_Enter;
        txtContrasena.Leave += txtContrasena_Leave;
        // 
        // FrmLogin
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(933, 519);
        Controls.Add(pnlCard);
        Margin = new Padding(4, 3, 4, 3);
        Name = "FrmLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Inicio de Sesión - Mecha Prime";
        pnlCard.ResumeLayout(false);
        pnlCard.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Button btnSiguiente;
    private System.Windows.Forms.Button btnOjo;
    private System.Windows.Forms.Label lblTitulo;
    private System.Windows.Forms.Label lblSubtitulo;
    private System.Windows.Forms.Label lblCrearCuenta;
    private System.Windows.Forms.Panel pnlCard;
    private System.Windows.Forms.TextBox txtUsuario;
    private System.Windows.Forms.TextBox txtContrasena;
    private System.Windows.Forms.LinkLabel lnkCrearCuenta;
}