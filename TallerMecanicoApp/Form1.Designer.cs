namespace TallerMecanicoApp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.Windows.Forms.DataGridViewCellStyle DataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();

        colTelefono = new DataGridViewTextBoxColumn();
        lblTitulo = new Label();
        gbRecepcion = new GroupBox();
        txtDni = new TextBox();
        txtModelo = new TextBox();
        txtTelefono = new TextBox();
        txtCliente = new TextBox();
        txtPlaca = new TextBox();
        lblDni = new Label();
        lblModelo = new Label();
        lblTelefono = new Label();
        lblCliente = new Label();
        lblPlaca = new Label();
        btnRegistrarVehiculo = new Button();
        btnRegistroTrabajos = new Button();
        dgvVehiculos = new DataGridView();
        colPlaca = new DataGridViewTextBoxColumn();
        colCliente = new DataGridViewTextBoxColumn();
        colModelo = new DataGridViewTextBoxColumn();
        colDni = new DataGridViewTextBoxColumn();
        colFechaRegistro = new DataGridViewTextBoxColumn();

        // DECLARACIÓN DE TUS BOTONES SUPERIORES NUEVOS
        btnUpdate = new Button();
        btnDelete = new Button();

        // INSTANCIAMOS EL NUEVO BUSCADOR
        lblBuscar = new Label();
        txtBuscar = new TextBox();

        gbRecepcion.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitulo.Location = new Point(22, 18);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(258, 25);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Recepción - Taller Mecánico";
        // 
        // gbRecepcion
        // 
        gbRecepcion.Controls.Add(txtDni);
        gbRecepcion.Controls.Add(txtModelo);
        gbRecepcion.Controls.Add(txtTelefono);
        gbRecepcion.Controls.Add(txtCliente);
        gbRecepcion.Controls.Add(txtPlaca);
        gbRecepcion.Controls.Add(lblDni);
        gbRecepcion.Controls.Add(lblModelo);
        gbRecepcion.Controls.Add(lblTelefono);
        gbRecepcion.Controls.Add(lblCliente);
        gbRecepcion.Controls.Add(lblPlaca);

        gbRecepcion.Controls.Add(lblBuscar);
        gbRecepcion.Controls.Add(txtBuscar);

        gbRecepcion.Location = new Point(24, 56);
        gbRecepcion.Name = "gbRecepcion";
        gbRecepcion.Size = new Size(845, 150);
        gbRecepcion.TabIndex = 1;
        gbRecepcion.TabStop = false;
        gbRecepcion.Text = "Datos de ingreso";
        // 
        // txtDni
        // 
        txtDni.Location = new Point(544, 110);
        txtDni.MaxLength = 8;
        txtDni.Name = "txtDni";
        txtDni.Size = new Size(282, 23);
        txtDni.TabIndex = 9;
        // 
        // txtModelo
        // 
        txtModelo.Location = new Point(92, 77);
        txtModelo.Name = "txtModelo";
        txtModelo.Size = new Size(282, 23);
        txtModelo.TabIndex = 6;
        // 
        // txtBuscar
        // 
        txtBuscar.CharacterCasing = CharacterCasing.Upper;
        txtBuscar.Location = new Point(115, 110); // Posicionado exactamente debajo de Marca/Modelo
        txtBuscar.Name = "txtBuscar";
        txtBuscar.Size = new Size(259, 23);
        txtBuscar.TabIndex = 12;
        // 
        // txtTelefono
        // 
        txtTelefono.Location = new Point(544, 77);
        txtTelefono.Name = "txtTelefono";
        txtTelefono.Size = new Size(282, 23);
        txtTelefono.TabIndex = 8;
        // 
        // txtCliente
        // 
        txtCliente.Location = new Point(544, 35);
        txtCliente.Name = "txtCliente";
        txtCliente.Size = new Size(282, 23);
        txtCliente.TabIndex = 5;
        // 
        // txtPlaca
        // 
        txtPlaca.CharacterCasing = CharacterCasing.Upper;
        txtPlaca.Location = new Point(92, 35);
        txtPlaca.MaxLength = 15;
        txtPlaca.Name = "txtPlaca";
        txtPlaca.Size = new Size(282, 23);
        txtPlaca.TabIndex = 4;
        // 
        // lblDni
        // 
        lblDni.AutoSize = true;
        lblDni.Location = new Point(470, 113);
        lblDni.Name = "lblDni";
        lblDni.Size = new Size(30, 15);
        lblDni.TabIndex = 3;
        lblDni.Text = "DNI:";
        // 
        // lblModelo
        // 
        lblModelo.AutoSize = true;
        lblModelo.Location = new Point(0, 80);
        lblModelo.Name = "lblModelo";
        lblModelo.Size = new Size(95, 15);
        lblModelo.TabIndex = 2;
        lblModelo.Text = "Marca / Modelo:";
        // 
        // lblBuscar
        // 
        lblBuscar.AutoSize = true;
        lblBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblBuscar.ForeColor = Color.Blue; // Color azul para diferenciar que es un buscador
        lblBuscar.Location = new Point(54, 113);
        lblBuscar.Name = "lblBuscar";
        lblBuscar.Size = new Size(54, 15);
        lblBuscar.TabIndex = 13;
        lblBuscar.Text = "Buscar:";
        // 
        // lblTelefono
        // 
        lblTelefono.AutoSize = true;
        lblTelefono.Location = new Point(470, 80);
        lblTelefono.Name = "lblTelefono";
        lblTelefono.Size = new Size(55, 15);
        lblTelefono.TabIndex = 4;
        lblTelefono.Text = "Teléfono:";
        // 
        // lblCliente
        // 
        lblCliente.AutoSize = true;
        lblCliente.Location = new Point(482, 38);
        lblCliente.Name = "lblCliente";
        lblCliente.Size = new Size(47, 15);
        lblCliente.TabIndex = 1;
        lblCliente.Text = "Cliente:";
        // 
        // lblPlaca
        // 
        lblPlaca.AutoSize = true;
        lblPlaca.Location = new Point(47, 38);
        lblPlaca.Name = "lblPlaca";
        lblPlaca.Size = new Size(38, 15);
        lblPlaca.TabIndex = 0;
        lblPlaca.Text = "Placa:";
        // 
        // btnRegistrarVehiculo
        // 
        btnRegistrarVehiculo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnRegistrarVehiculo.Location = new Point(24, 218);
        btnRegistrarVehiculo.Name = "btnRegistrarVehiculo";
        btnRegistrarVehiculo.Size = new Size(130, 33);
        btnRegistrarVehiculo.TabIndex = 2;
        btnRegistrarVehiculo.Text = "Registrar vehículo";
        btnRegistrarVehiculo.UseVisualStyleBackColor = true;
        btnRegistrarVehiculo.Click += btnRegistrarVehiculo_Click;
        // 
        // btnUpdate
        // 
        btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnUpdate.Location = new Point(165, 218);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new Size(90, 33);
        btnUpdate.TabIndex = 10;
        btnUpdate.Text = "Update";
        btnUpdate.UseVisualStyleBackColor = true;
        btnUpdate.Click += btnUpdate_Click;
        // 
        // btnDelete
        // 
        btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnDelete.Location = new Point(265, 218);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(90, 33);
        btnDelete.TabIndex = 11;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        // 
        // btnRegistroTrabajos
        // 
        btnRegistroTrabajos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnRegistroTrabajos.Location = new Point(365, 218);
        btnRegistroTrabajos.Name = "btnRegistroTrabajos";
        btnRegistroTrabajos.Size = new Size(147, 33);
        btnRegistroTrabajos.TabIndex = 3;
        btnRegistroTrabajos.Text = "Registro de trabajos";
        btnRegistroTrabajos.UseVisualStyleBackColor = true;
        btnRegistroTrabajos.Click += btnRegistroTrabajos_Click;
        // 
        // dgvVehiculos
        // 
        dgvVehiculos.AllowUserToAddRows = false;
        dgvVehiculos.AllowUserToDeleteRows = false;
        dgvVehiculos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvVehiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvVehiculos.Columns.AddRange(new DataGridViewColumn[] { colPlaca, colCliente, colTelefono, colModelo, colDni, colFechaRegistro });
        dgvVehiculos.Location = new Point(24, 265);
        dgvVehiculos.MultiSelect = false;
        dgvVehiculos.Name = "dgvVehiculos";
        dgvVehiculos.ReadOnly = true;
        dgvVehiculos.RowHeadersVisible = false;
        dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvVehiculos.Size = new Size(845, 254);
        dgvVehiculos.TabIndex = 4;
        // 
        // colPlaca
        // 
        colPlaca.DataPropertyName = "Placa";
        colPlaca.HeaderText = "Placa";
        colPlaca.Name = "colPlaca";
        colPlaca.ReadOnly = true;
        colPlaca.Width = 90;
        // 
        // colCliente
        // 
        colCliente.DataPropertyName = "Cliente";
        colCliente.HeaderText = "Cliente";
        colCliente.Name = "colCliente";
        colCliente.ReadOnly = true;
        colCliente.Width = 180;
        // 
        // colTelefono
        // 
        colTelefono.DataPropertyName = "Telefono";
        colTelefono.HeaderText = "Teléfono";
        colTelefono.Name = "colTelefono";
        colTelefono.ReadOnly = true;
        colTelefono.Width = 110;
        // 
        // colModelo
        // 
        colModelo.DataPropertyName = "Modelo";
        colModelo.HeaderText = "Modelo";
        colModelo.Name = "colModelo";
        colModelo.ReadOnly = true;
        colModelo.Width = 140;
        // 
        // colDni
        // 
        colDni.DataPropertyName = "Dni";
        colDni.HeaderText = "DNI Cliente";
        colDni.Name = "colDni";
        colDni.ReadOnly = true;
        colDni.Width = 110;
        // 
        // colFechaRegistro
        // 
        colFechaRegistro.DataPropertyName = "FechaRegistro";
        DataGridViewCellStyle1.Format = "dd/MM/yyyy hh:mm tt";
        colFechaRegistro.DefaultCellStyle = DataGridViewCellStyle1;
        colFechaRegistro.HeaderText = "Fecha de Ingreso";
        colFechaRegistro.Name = "colFechaRegistro";
        colFechaRegistro.ReadOnly = true;
        colFechaRegistro.Width = 145;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(892, 541);
        Controls.Add(btnDelete);
        Controls.Add(btnUpdate);
        Controls.Add(dgvVehiculos);
        Controls.Add(btnRegistroTrabajos);
        Controls.Add(btnRegistrarVehiculo);
        Controls.Add(gbRecepcion);
        Controls.Add(lblTitulo);
        MinimumSize = new Size(908, 580);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Gestión de Taller Mecánico - Mecha Prime";
        Load += Form1_Load;
        gbRecepcion.ResumeLayout(false);
        gbRecepcion.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitulo;
    private GroupBox gbRecepcion;
    private TextBox txtDni;
    private TextBox txtModelo;
    private TextBox txtTelefono;
    private TextBox txtCliente;
    private TextBox txtPlaca;
    private Label lblDni;
    private Label lblModelo;
    private Label lblTelefono;
    private Label lblCliente;
    private Label lblPlaca;
    private Button btnRegistrarVehiculo;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnRegistroTrabajos;
    private DataGridView dgvVehiculos;

    private DataGridViewTextBoxColumn colPlaca;
    private DataGridViewTextBoxColumn colCliente;
    private DataGridViewTextBoxColumn colModelo;
    private DataGridViewTextBoxColumn colDni;
    private DataGridViewTextBoxColumn colFechaRegistro;
    private DataGridViewTextBoxColumn colTelefono;

    // DECLARACIONES AL FINAL DE LAS VARIABLES DEL BUSCADOR
    private Label lblBuscar;
    private TextBox txtBuscar;
}