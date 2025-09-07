using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GestorTareasBlue
{


    public partial class MainForm : Form
    {
        private readonly List<Tarea> tareas = new();

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            // Configuración inicial de combos
            if (cbEstado.Items.Count == 0)
                cbEstado.Items.AddRange(new object[] { "Pendiente", "En progreso", "Finalizada" });
            if (cbEstado.SelectedIndex < 0) cbEstado.SelectedIndex = 0;

            if (cbFiltroEstado.Items.Count == 0)
                cbFiltroEstado.Items.AddRange(new object[] { "Todos", "Pendiente", "En progreso", "Finalizada" });
            cbFiltroEstado.SelectedIndex = 0;

            // Configuración de fechas
            dtpFiltroDesde.ShowCheckBox = true;
            dtpFiltroHasta.ShowCheckBox = true;

            // Eventos de filtros
            txtFiltroCodigo.TextChanged += (s, ev) => AplicarFiltros();
            cbFiltroEstado.SelectedIndexChanged += (s, ev) => AplicarFiltros();
            dtpFiltroDesde.ValueChanged += (s, ev) => AplicarFiltros();
            dtpFiltroHasta.ValueChanged += (s, ev) => AplicarFiltros();
            btnReiniciarFiltros.Click += (s, ev) => LimpiarFiltros();

            // Configuración del grid
            gridTareas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridTareas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridTareas.MultiSelect = false;
            gridTareas.ReadOnly = true;

            // Botones principales
            btnNuevo.Click += BtnNuevo_Click;
            btnModificar.Click += BtnModificar_Click;
            btnQuitar.Click += BtnQuitar_Click;

            ActualizarGrid();
        }

        private void ActualizarGrid(IEnumerable<Tarea>? datos = null)
        {
            var fuente = (datos ?? tareas).ToList();
            gridTareas.DataSource = null;
            gridTareas.DataSource = fuente;

            if (gridTareas.Columns.Contains("Fecha"))
            {
                var col = gridTareas.Columns["Fecha"];
                if (col != null)
                    col.DefaultCellStyle.Format = "dd/MM/yyyy";
            }

        }

        private void AplicarFiltros()
        {
            IEnumerable<Tarea> query = tareas;

            // Filtrar por código
            var code = txtFiltroCodigo.Text?.Trim();
            if (!string.IsNullOrEmpty(code))
                query = query.Where(t => t.Codigo.Contains(code, StringComparison.OrdinalIgnoreCase));

            // Filtrar por estado
            if (cbFiltroEstado.SelectedIndex > 0)
            {
                var estado = cbFiltroEstado.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(estado))
                    query = query.Where(t => string.Equals(t.Estado, estado, StringComparison.OrdinalIgnoreCase));
            }

            // Filtrar por fechas
            if (dtpFiltroDesde.Checked)
                query = query.Where(t => t.Fecha.Date >= dtpFiltroDesde.Value.Date);
            if (dtpFiltroHasta.Checked)
                query = query.Where(t => t.Fecha.Date <= dtpFiltroHasta.Value.Date);

            ActualizarGrid(query);
        }

        private void LimpiarFiltros()
        {
            txtFiltroCodigo.Clear();
            cbFiltroEstado.SelectedIndex = 0;
            dtpFiltroDesde.Checked = false;
            dtpFiltroHasta.Checked = false;
            ActualizarGrid();
        }

        private void BtnNuevo_Click(object? sender, EventArgs e)
        {
            var codigo = txtCodigo.Text?.Trim() ?? string.Empty;
            var nombre = txtTitulo.Text?.Trim() ?? string.Empty;
            var estado = cbEstado.SelectedItem?.ToString() ?? "Pendiente";

            if (string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("El código es obligatorio.", "Aviso");
                return;
            }
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El título es obligatorio.", "Aviso");
                return;
            }
            if (tareas.Any(t => string.Equals(t.Codigo, codigo, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe una tarea con ese código.", "Aviso");
                return;
            }

            var nueva = new Tarea
            {
                Codigo = codigo,
                Nombre = nombre,
                Descripcion = txtDetalles.Text?.Trim() ?? string.Empty,
                Fecha = dtpFechaTarea.Value,
                Lugar = txtLugar.Text?.Trim() ?? string.Empty,
                Estado = estado
            };

            tareas.Add(nueva);
            MessageBox.Show("Tarea registrada correctamente.", "Info");
            AplicarFiltros();
        }

        private void BtnModificar_Click(object? sender, EventArgs e)
        {
            if (gridTareas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una tarea.");
                return;
            }

            string? codigoFila = gridTareas.SelectedRows[0].Cells["Codigo"]?.Value?.ToString();
            var tarea = tareas.FirstOrDefault(t => t.Codigo == codigoFila);
            if (tarea == null) return;

            var nuevoCodigo = txtCodigo.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(nuevoCodigo))
            {
                MessageBox.Show("El código es obligatorio.");
                return;
            }
            if (!string.Equals(tarea.Codigo, nuevoCodigo, StringComparison.OrdinalIgnoreCase) &&
                tareas.Any(t => string.Equals(t.Codigo, nuevoCodigo, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe una tarea con ese código.");
                return;
            }

            tarea.Codigo = nuevoCodigo;
            tarea.Nombre = txtTitulo.Text?.Trim() ?? string.Empty;
            tarea.Descripcion = txtDetalles.Text?.Trim() ?? string.Empty;
            tarea.Fecha = dtpFechaTarea.Value;
            tarea.Lugar = txtLugar.Text?.Trim() ?? string.Empty;
            tarea.Estado = cbEstado.SelectedItem?.ToString() ?? tarea.Estado;

            AplicarFiltros();
            MessageBox.Show("Tarea modificada con éxito.");
        }

        private void BtnQuitar_Click(object? sender, EventArgs e)
        {
            if (gridTareas.SelectedRows.Count == 0) return;

            string? codigoFila = gridTareas.SelectedRows[0].Cells["Codigo"]?.Value?.ToString();
            var tarea = tareas.FirstOrDefault(t => t.Codigo == codigoFila);
            if (tarea == null) return;

            tareas.Remove(tarea);
            AplicarFiltros();
            MessageBox.Show("Tarea eliminada.");
        }

        private void gridTareas_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = gridTareas.Rows[e.RowIndex];
            txtCodigo.Text = fila.Cells["Codigo"].Value?.ToString() ?? string.Empty;
            txtTitulo.Text = fila.Cells["Nombre"].Value?.ToString() ?? string.Empty;
            txtDetalles.Text = fila.Cells["Descripcion"].Value?.ToString() ?? string.Empty;
            if (DateTime.TryParse(fila.Cells["Fecha"].Value?.ToString(), out var f))
                dtpFechaTarea.Value = f;
            txtLugar.Text = fila.Cells["Lugar"].Value?.ToString() ?? string.Empty;
            cbEstado.SelectedItem = fila.Cells["Estado"].Value?.ToString();
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
