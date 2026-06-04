namespace TallerMecanicoApp;

partial class FrmNuevaCuenta
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevaCuenta));
        lblTitulo = new Label();
        lblCardTitulo = new Label();
        pnlPass = new Panel();
        pnlCard = new Panel();
        btnOjo = new Button();
        txtContrasena = new TextBox();
        txtUsuario = new TextBox();
        txtNombres = new TextBox();
        btnCrear = new Button();
        pnlPass.SuspendLayout();
        pnlCard.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.BackColor = SystemColors.AppWorkspace;
        lblTitulo.Font = new Font("Rockwell", 36F, FontStyle.Bold);
        lblTitulo.Location = new Point(182, 14);
        lblTitulo.Margin = new Padding(4, 0, 4, 0);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(395, 59);
        lblTitulo.TabIndex = 2;
        lblTitulo.Text = "MECHA PRIME";
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblCardTitulo
        // 
        lblCardTitulo.AutoSize = true;
        lblCardTitulo.BackColor = Color.White;
        lblCardTitulo.Font = new Font("Dubai", 15.75F);
        lblCardTitulo.Location = new Point(133, 13);
        lblCardTitulo.Margin = new Padding(4, 0, 4, 0);
        lblCardTitulo.Name = "lblCardTitulo";
        lblCardTitulo.Size = new Size(137, 36);
        lblCardTitulo.TabIndex = 1;
        lblCardTitulo.Text = "Nueva Cuenta";
        // 
        // pnlPass
        // 
        pnlPass.BackColor = Color.White;
        pnlPass.Controls.Add(lblCardTitulo);
        pnlPass.Location = new Point(205, 85);
        pnlPass.Margin = new Padding(4, 3, 4, 3);
        pnlPass.Name = "pnlPass";
        pnlPass.Size = new Size(411, 245);
        pnlPass.TabIndex = 2;
        // 
        // pnlCard
        // 
        pnlCard.BackColor = SystemColors.AppWorkspace;
        pnlCard.Controls.Add(btnOjo);
        pnlCard.Controls.Add(txtContrasena);
        pnlCard.Controls.Add(txtUsuario);
        pnlCard.Controls.Add(lblTitulo);
        pnlCard.Controls.Add(txtNombres);
        pnlCard.Controls.Add(btnCrear);
        pnlCard.Controls.Add(pnlPass);
        pnlCard.Location = new Point(14, 36);
        pnlCard.Margin = new Padding(4, 3, 4, 3);
        pnlCard.Name = "pnlCard";
        pnlCard.Size = new Size(802, 428);
        pnlCard.TabIndex = 5;
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
        btnOjo.Location = new Point(534, 248);
        btnOjo.Margin = new Padding(4, 3, 4, 3);
        btnOjo.Name = "btnOjo";
        btnOjo.Size = new Size(49, 42);
        btnOjo.TabIndex = 1;
        btnOjo.UseVisualStyleBackColor = false;
        btnOjo.Click += btnOjo_Click;
        // 
        // txtContrasena
        // 
        txtContrasena.BorderStyle = BorderStyle.FixedSingle;
        txtContrasena.Font = new Font("Microsoft Sans Serif", 15.75F);
        txtContrasena.ForeColor = SystemColors.ControlDark;
        txtContrasena.Location = new Point(239, 248);
        txtContrasena.Margin = new Padding(4, 3, 4, 3);
        txtContrasena.Multiline = true;
        txtContrasena.Name = "txtContrasena";
        txtContrasena.Size = new Size(342, 41);
        txtContrasena.TabIndex = 6;
        txtContrasena.Text = "Nueva Contraseña";
        txtContrasena.Enter += txtContrasena_Enter;
        txtContrasena.Leave += txtContrasena_Leave;
        // 
        // txtUsuario
        // 
        txtUsuario.BorderStyle = BorderStyle.FixedSingle;
        txtUsuario.Font = new Font("Microsoft Sans Serif", 15.75F);
        txtUsuario.ForeColor = SystemColors.ControlDark;
        txtUsuario.Location = new Point(239, 193);
        txtUsuario.Margin = new Padding(4, 3, 4, 3);
        txtUsuario.Multiline = true;
        txtUsuario.Name = "txtUsuario";
        txtUsuario.Size = new Size(342, 41);
        txtUsuario.TabIndex = 5;
        txtUsuario.Text = "Usuario";
        txtUsuario.Enter += txtUsuario_Enter;
        txtUsuario.Leave += txtUsuario_Leave;
        // 
        // txtNombres
        // 
        txtNombres.BorderStyle = BorderStyle.FixedSingle;
        txtNombres.Font = new Font("Microsoft Sans Serif", 14.25F);
        txtNombres.ForeColor = SystemColors.ControlDark;
        txtNombres.Location = new Point(239, 140);
        txtNombres.Margin = new Padding(4, 3, 4, 3);
        txtNombres.Multiline = true;
        txtNombres.Name = "txtNombres";
        txtNombres.Size = new Size(342, 41);
        txtNombres.TabIndex = 6;
        txtNombres.Text = "Nombres";
        txtNombres.Enter += txtNombres_Enter;
        txtNombres.Leave += txtNombres_Leave;
        // 
        // btnCrear
        // 
        btnCrear.Font = new Font("Dubai", 12F);
        btnCrear.Location = new Point(324, 350);
        btnCrear.Margin = new Padding(4, 3, 4, 3);
        btnCrear.Name = "btnCrear";
        btnCrear.Size = new Size(183, 48);
        btnCrear.TabIndex = 7;
        btnCrear.Text = "CREAR";
        btnCrear.UseVisualStyleBackColor = true;
        btnCrear.Click += btnCrear_Click;
        // 
        // FrmNuevaCuenta
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(933, 519);
        Controls.Add(pnlCard);
        Margin = new Padding(4, 3, 4, 3);
        Name = "FrmNuevaCuenta";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Registrar Nueva Cuenta - Mecha Prime";
        pnlPass.ResumeLayout(false);
        pnlPass.PerformLayout();
        pnlCard.ResumeLayout(false);
        pnlCard.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Label lblTitulo;
    private System.Windows.Forms.Label lblCardTitulo;
    private System.Windows.Forms.Panel pnlPass;
    private System.Windows.Forms.Panel pnlCard;
    private System.Windows.Forms.TextBox txtNombres;
    private System.Windows.Forms.TextBox txtUsuario;
    private System.Windows.Forms.TextBox txtContrasena;
    private System.Windows.Forms.Button btnCrear;
    private System.Windows.Forms.Button btnOjo;
}