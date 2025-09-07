namespace GestorTareasBlue
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtCodigo = new TextBox();
            txtTitulo = new TextBox();
            txtDetalles = new TextBox();
            dtpFechaTarea = new DateTimePicker();
            txtLugar = new TextBox();
            cbEstado = new ComboBox();
            btnNuevo = new Button();
            btnModificar = new Button();
            btnQuitar = new Button();
            gridTareas = new DataGridView();
            txtFiltroCodigo = new TextBox();
            cbFiltroEstado = new ComboBox();
            dtpFiltroDesde = new DateTimePicker();
            dtpFiltroHasta = new DateTimePicker();
            btnReiniciarFiltros = new Button();
            ((System.ComponentModel.ISupportInitialize)gridTareas).BeginInit();
            SuspendLayout();
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(50, 40);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(250, 27);
            txtCodigo.TabIndex = 0;
            txtCodigo.Text = "Codigo";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(320, 40);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.PlaceholderText = "Título de la tarea";
            txtTitulo.Size = new Size(350, 27);
            txtTitulo.TabIndex = 1;
            // 
            // txtDetalles
            // 
            txtDetalles.Location = new Point(50, 90);
            txtDetalles.Multiline = true;
            txtDetalles.Name = "txtDetalles";
            txtDetalles.PlaceholderText = "Detalles";
            txtDetalles.Size = new Size(620, 120);
            txtDetalles.TabIndex = 2;
            // 
            // dtpFechaTarea
            // 
            dtpFechaTarea.Format = DateTimePickerFormat.Short;
            dtpFechaTarea.Location = new Point(50, 230);
            dtpFechaTarea.Name = "dtpFechaTarea";
            dtpFechaTarea.Size = new Size(200, 27);
            dtpFechaTarea.TabIndex = 3;
            // 
            // txtLugar
            // 
            txtLugar.Location = new Point(250, 230);
            txtLugar.Name = "txtLugar";
            txtLugar.PlaceholderText = "Lugar";
            txtLugar.Size = new Size(200, 27);
            txtLugar.TabIndex = 4;
            // 
            // cbEstado
            // 
            cbEstado.Location = new Point(480, 230);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(190, 28);
            cbEstado.TabIndex = 5;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(700, 40);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(120, 50);
            btnNuevo.TabIndex = 6;
            btnNuevo.Text = "Agregar";
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(700, 110);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(120, 50);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "Editar";
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(700, 180);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(120, 50);
            btnQuitar.TabIndex = 8;
            btnQuitar.Text = "Eliminar";
            // 
            // gridTareas
            // 
            gridTareas.ColumnHeadersHeight = 29;
            gridTareas.Location = new Point(50, 350);
            gridTareas.Name = "gridTareas";
            gridTareas.RowHeadersWidth = 51;
            gridTareas.Size = new Size(1000, 200);
            gridTareas.TabIndex = 9;
            gridTareas.CellClick += gridTareas_CellClick;
            // 
            // txtFiltroCodigo
            // 
            txtFiltroCodigo.Location = new Point(50, 300);
            txtFiltroCodigo.Name = "txtFiltroCodigo";
            txtFiltroCodigo.PlaceholderText = "Buscar por código";
            txtFiltroCodigo.Size = new Size(200, 27);
            txtFiltroCodigo.TabIndex = 10;
            // 
            // cbFiltroEstado
            // 
            cbFiltroEstado.Location = new Point(270, 300);
            cbFiltroEstado.Name = "cbFiltroEstado";
            cbFiltroEstado.Size = new Size(200, 28);
            cbFiltroEstado.TabIndex = 11;
            // 
            // dtpFiltroDesde
            // 
            dtpFiltroDesde.Location = new Point(490, 300);
            dtpFiltroDesde.Name = "dtpFiltroDesde";
            dtpFiltroDesde.Size = new Size(200, 27);
            dtpFiltroDesde.TabIndex = 12;
            // 
            // dtpFiltroHasta
            // 
            dtpFiltroHasta.Location = new Point(710, 300);
            dtpFiltroHasta.Name = "dtpFiltroHasta";
            dtpFiltroHasta.Size = new Size(200, 27);
            dtpFiltroHasta.TabIndex = 13;
            // 
            // btnReiniciarFiltros
            // 
            btnReiniciarFiltros.Location = new Point(930, 295);
            btnReiniciarFiltros.Name = "btnReiniciarFiltros";
            btnReiniciarFiltros.Size = new Size(120, 40);
            btnReiniciarFiltros.TabIndex = 14;
            btnReiniciarFiltros.Text = "Limpiar";
            // 
            // MainForm
            // 
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(1400, 850);
            Controls.Add(txtCodigo);
            Controls.Add(txtTitulo);
            Controls.Add(txtDetalles);
            Controls.Add(dtpFechaTarea);
            Controls.Add(txtLugar);
            Controls.Add(cbEstado);
            Controls.Add(btnNuevo);
            Controls.Add(btnModificar);
            Controls.Add(btnQuitar);
            Controls.Add(gridTareas);
            Controls.Add(txtFiltroCodigo);
            Controls.Add(cbFiltroEstado);
            Controls.Add(dtpFiltroDesde);
            Controls.Add(dtpFiltroHasta);
            Controls.Add(btnReiniciarFiltros);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestor de Tareas";
            Load += MainForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)gridTareas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtDetalles;
        private System.Windows.Forms.DateTimePicker dtpFechaTarea;
        private System.Windows.Forms.TextBox txtLugar;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.DataGridView gridTareas;
        private System.Windows.Forms.TextBox txtFiltroCodigo;
        private System.Windows.Forms.ComboBox cbFiltroEstado;
        private System.Windows.Forms.DateTimePicker dtpFiltroDesde;
        private System.Windows.Forms.DateTimePicker dtpFiltroHasta;
        private System.Windows.Forms.Button btnReiniciarFiltros;
    }
}
