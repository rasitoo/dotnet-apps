using P03_02_DI_Contactos_TAPIADOR_rodrigo.Presenters;
using System.Collections.Generic;


namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Views;

public class MainView : Form, IView
{
    private System.ComponentModel.IContainer components = null;
    private SplitContainer splitContainer1;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem archivoToolStripMenuItem;
    private ToolStripMenuItem editarToolStripMenuItem;
    private ToolStripMenuItem verToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem salirToolStripMenuItem;
    private ToolStripMenuItem eliminarToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator3;
    private ListBox listBox1;
    private TableLayoutPanel tableLayoutPanel1;
    private PictureBox pictureBox1;
    private ToolStripMenuItem productosToolStripMenuItem;
    private ToolStripMenuItem categoriasToolStripMenuItem;
    private Label headerNombre;
    private Label headerDesc;
    private Label headerPrecio;
    private Label headerCategoria;
    private TextBox textBoxNombre;
    private TextBox textBoxDesc;
    private TextBox textBoxPrecio;
    private TextBox textBoxInfo;
    private ListBox listBoxInfo;
    private Label headerId;
    private TextBox textBoxId;
    private Button buttonModificar;
    private Button buttonEliminar;
    private ToolStripMenuItem guardarToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem nuevoToolStripMenuItem;
    private ToolStripMenuItem productoAnadir;
    private ToolStripMenuItem categoríaAnadir;

    public int SelectedItem => listBox1.SelectedIndex;
    public int SelectedProductoPerteneciente => listBoxInfo.SelectedIndex;
    public string DisplayId { get => textBoxId.Text; set => textBoxId.Text = value; }
    public string DisplayNombre { get => textBoxNombre.Text; set => textBoxNombre.Text = value; }
    public string DisplayPertenencia { get => textBoxInfo.Text; set => textBoxInfo.Text = value; }
    public List<String> DisplayPertenecientes { set => listBoxInfo.DataSource = value; }
    public string DisplayPrecio { get => textBoxPrecio.Text; set => textBoxPrecio.Text = value; }
    public string DisplayDescripcion { get => textBoxDesc.Text; set => textBoxDesc.Text = value; }
    public List<String> DisplayListaGeneral { set => listBox1.DataSource = value; }
    public bool InterfazProductos { get; set; }

    public event EventHandler ListBoxItemSelected;
    public event EventHandler ListBoxInfoItemSelected;
    public event EventHandler ListBoxInfoItemClicked;
    public event EventHandler productoAnadir_Click;
    public event EventHandler categoriaAnadir_Click;
    public event EventHandler buttonEliminar_Click;
    public event EventHandler buttonModificar_Click;
    public event EventHandler productosToolStripMenuItem_Click;
    public event EventHandler categoriasToolStripMenuItem_Click;
    public event EventHandler guardarToolStripMenuItem_Click;

    public MainView()
    {
        InitializeComponent();
        AttachEventHandlers();
        listBoxInfo.Visible = false;
        textBoxId.Enabled = false;
        InterfazProductos = true;
    }
    private void AttachEventHandlers()
    {
        listBox1.SelectedIndexChanged += (sender, e) => ListBoxItemSelected?.Invoke(sender, e);
        listBoxInfo.SelectedIndexChanged += (sender, e) => ListBoxInfoItemSelected?.Invoke(sender, e);
        productoAnadir.Click += (sender, e) => productoAnadir_Click?.Invoke(sender, e);
        categoríaAnadir.Click += (sender, e) => categoriaAnadir_Click?.Invoke(sender, e);
        buttonEliminar.Click += (sender, e) => buttonEliminar_Click?.Invoke(sender, e);
        eliminarToolStripMenuItem.Click += (sender, e) => buttonEliminar_Click?.Invoke(sender, e);
        buttonModificar.Click += (sender, e) => buttonModificar_Click?.Invoke(sender, e);
        productosToolStripMenuItem.Click += (sender, e) => productosToolStripMenuItem_Click?.Invoke(sender, e);
        categoriasToolStripMenuItem.Click += (sender, e) => categoriasToolStripMenuItem_Click?.Invoke(sender, e);
        listBoxInfo.Click += (sender, e) => ListBoxInfoItemClicked?.Invoke(sender, e);
        salirToolStripMenuItem.Click += (sender, e) => Dispose(true);
        guardarToolStripMenuItem.Click += (sender, e) => guardarToolStripMenuItem_Click?.Invoke(sender, e);


    }

    public void interfazCategorias()
    {
        InterfazProductos = false;

        listBoxInfo.Visible = true;
        textBoxInfo.Visible = false;
        headerDesc.Visible = false;
        textBoxDesc.Visible = false;
        headerPrecio.Visible = false;
        textBoxPrecio.Visible = false;
        headerCategoria.Text = "Productos";

    }

    public void interfazProductos()
    {
        InterfazProductos = true;

        listBoxInfo.Visible = false;
        textBoxInfo.Visible = true;
        headerDesc.Visible = true;
        textBoxDesc.Visible = true;
        headerPrecio.Visible = true;
        textBoxPrecio.Visible = true;
        headerCategoria.Text = "Categoria";
    }
    private void InitializeComponent()
    {
        splitContainer1 = new SplitContainer();
        listBox1 = new ListBox();
        tableLayoutPanel1 = new TableLayoutPanel();
        pictureBox1 = new PictureBox();
        buttonModificar = new Button();
        listBoxInfo = new ListBox();
        headerCategoria = new Label();
        textBoxInfo = new TextBox();
        headerPrecio = new Label();
        textBoxPrecio = new TextBox();
        headerDesc = new Label();
        textBoxDesc = new TextBox();
        headerNombre = new Label();
        textBoxNombre = new TextBox();
        headerId = new Label();
        textBoxId = new TextBox();
        buttonEliminar = new Button();
        menuStrip1 = new MenuStrip();
        archivoToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator1 = new ToolStripSeparator();
        salirToolStripMenuItem = new ToolStripMenuItem();
        editarToolStripMenuItem = new ToolStripMenuItem();
        eliminarToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator3 = new ToolStripSeparator();
        verToolStripMenuItem = new ToolStripMenuItem();
        productosToolStripMenuItem = new ToolStripMenuItem();
        categoriasToolStripMenuItem = new ToolStripMenuItem();
        guardarToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator2 = new ToolStripSeparator();
        nuevoToolStripMenuItem = new ToolStripMenuItem();
        productoAnadir = new ToolStripMenuItem();
        categoríaAnadir = new ToolStripMenuItem();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(0, 28);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(listBox1);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
        splitContainer1.Size = new Size(800, 422);
        splitContainer1.SplitterDistance = 265;
        splitContainer1.TabIndex = 0;
        // 
        // listBox1
        // 
        listBox1.Dock = DockStyle.Fill;
        listBox1.FormattingEnabled = true;
        listBox1.Location = new Point(0, 0);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(265, 422);
        listBox1.TabIndex = 1;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.AutoSize = true;
        tableLayoutPanel1.ColumnCount = 3;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
        tableLayoutPanel1.Controls.Add(buttonModificar, 0, 6);
        tableLayoutPanel1.Controls.Add(listBoxInfo, 2, 4);
        tableLayoutPanel1.Controls.Add(headerCategoria, 0, 5);
        tableLayoutPanel1.Controls.Add(textBoxInfo, 1, 5);
        tableLayoutPanel1.Controls.Add(headerPrecio, 0, 4);
        tableLayoutPanel1.Controls.Add(textBoxPrecio, 1, 4);
        tableLayoutPanel1.Controls.Add(headerDesc, 0, 3);
        tableLayoutPanel1.Controls.Add(textBoxDesc, 1, 3);
        tableLayoutPanel1.Controls.Add(headerNombre, 0, 2);
        tableLayoutPanel1.Controls.Add(textBoxNombre, 1, 2);
        tableLayoutPanel1.Controls.Add(headerId, 0, 1);
        tableLayoutPanel1.Controls.Add(textBoxId, 1, 1);
        tableLayoutPanel1.Controls.Add(buttonEliminar, 2, 6);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 2;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 22.5891418F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.0685072F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.0685072F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.0685072F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.0685072F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.0685072F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.530806F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.1895733F));
        tableLayoutPanel1.Size = new Size(531, 422);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // pictureBox1
        // 
        tableLayoutPanel1.SetColumnSpan(pictureBox1, 3);
        pictureBox1.Dock = DockStyle.Fill;
        pictureBox1.Location = new Point(3, 3);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(525, 87);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // buttonModificar
        // 
        buttonModificar.BackColor = Color.YellowGreen;
        tableLayoutPanel1.SetColumnSpan(buttonModificar, 2);
        buttonModificar.Dock = DockStyle.Fill;
        buttonModificar.Location = new Point(3, 381);
        buttonModificar.Name = "buttonModificar";
        buttonModificar.Size = new Size(258, 38);
        buttonModificar.TabIndex = 10;
        buttonModificar.Text = "Guardar";
        buttonModificar.UseVisualStyleBackColor = false;
        // 
        // listBoxInfo
        // 
        listBoxInfo.Dock = DockStyle.Fill;
        listBoxInfo.FormattingEnabled = true;
        listBoxInfo.Location = new Point(267, 246);
        listBoxInfo.Name = "listBoxInfo";
        tableLayoutPanel1.SetRowSpan(listBoxInfo, 2);
        listBoxInfo.Size = new Size(261, 94);
        listBoxInfo.TabIndex = 16;
        // 
        // headerCategoria
        // 
        headerCategoria.AutoSize = true;
        headerCategoria.Location = new Point(3, 293);
        headerCategoria.Name = "headerCategoria";
        headerCategoria.Size = new Size(74, 20);
        headerCategoria.TabIndex = 7;
        headerCategoria.Text = "Categoria";
        // 
        // textBoxInfo
        // 
        textBoxInfo.Location = new Point(135, 296);
        textBoxInfo.Name = "textBoxInfo";
        tableLayoutPanel1.SetRowSpan(textBoxInfo, 2);
        textBoxInfo.Size = new Size(125, 27);
        textBoxInfo.TabIndex = 15;
        // 
        // headerPrecio
        // 
        headerPrecio.AutoSize = true;
        headerPrecio.Location = new Point(3, 243);
        headerPrecio.Name = "headerPrecio";
        headerPrecio.Size = new Size(50, 20);
        headerPrecio.TabIndex = 5;
        headerPrecio.Text = "Precio";
        // 
        // textBoxPrecio
        // 
        textBoxPrecio.Location = new Point(135, 246);
        textBoxPrecio.Name = "textBoxPrecio";
        textBoxPrecio.Size = new Size(125, 27);
        textBoxPrecio.TabIndex = 14;
        // 
        // headerDesc
        // 
        headerDesc.AutoSize = true;
        headerDesc.Location = new Point(3, 193);
        headerDesc.Name = "headerDesc";
        headerDesc.Size = new Size(87, 20);
        headerDesc.TabIndex = 4;
        headerDesc.Text = "Descripción";
        // 
        // textBoxDesc
        // 
        tableLayoutPanel1.SetColumnSpan(textBoxDesc, 2);
        textBoxDesc.Location = new Point(135, 196);
        textBoxDesc.Name = "textBoxDesc";
        textBoxDesc.Size = new Size(125, 27);
        textBoxDesc.TabIndex = 13;
        // 
        // headerNombre
        // 
        headerNombre.AutoSize = true;
        headerNombre.Location = new Point(3, 143);
        headerNombre.Name = "headerNombre";
        headerNombre.Size = new Size(64, 20);
        headerNombre.TabIndex = 3;
        headerNombre.Text = "Nombre";
        // 
        // textBoxNombre
        // 
        textBoxNombre.Location = new Point(135, 146);
        textBoxNombre.Name = "textBoxNombre";
        textBoxNombre.Size = new Size(125, 27);
        textBoxNombre.TabIndex = 12;
        // 
        // headerId
        // 
        headerId.AutoSize = true;
        headerId.Location = new Point(3, 93);
        headerId.Name = "headerId";
        headerId.Size = new Size(24, 20);
        headerId.TabIndex = 17;
        headerId.Text = "ID";
        // 
        // textBoxId
        // 
        textBoxId.Location = new Point(135, 96);
        textBoxId.Name = "textBoxId";
        textBoxId.Size = new Size(125, 27);
        textBoxId.TabIndex = 18;
        // 
        // buttonEliminar
        // 
        buttonEliminar.BackColor = Color.IndianRed;
        buttonEliminar.Dock = DockStyle.Fill;
        buttonEliminar.Location = new Point(267, 381);
        buttonEliminar.Name = "buttonEliminar";
        buttonEliminar.Size = new Size(261, 38);
        buttonEliminar.TabIndex = 11;
        buttonEliminar.Text = "Eliminar";
        buttonEliminar.UseVisualStyleBackColor = false;
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(20, 20);
        menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, editarToolStripMenuItem, verToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Margin = new Padding(3);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(800, 28);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // archivoToolStripMenuItem
        // 
        archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator1, guardarToolStripMenuItem, toolStripSeparator2, salirToolStripMenuItem });
        archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
        archivoToolStripMenuItem.Size = new Size(73, 24);
        archivoToolStripMenuItem.Text = "Archivo";
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(221, 6);
        // 
        // salirToolStripMenuItem
        // 
        salirToolStripMenuItem.Name = "salirToolStripMenuItem";
        salirToolStripMenuItem.Size = new Size(224, 26);
        salirToolStripMenuItem.Text = "Salir";
        // 
        // editarToolStripMenuItem
        // 
        editarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { eliminarToolStripMenuItem, toolStripSeparator3, nuevoToolStripMenuItem });
        editarToolStripMenuItem.Name = "editarToolStripMenuItem";
        editarToolStripMenuItem.Size = new Size(62, 24);
        editarToolStripMenuItem.Text = "Editar";
        // 
        // eliminarToolStripMenuItem
        // 
        eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
        eliminarToolStripMenuItem.ShortcutKeys = Keys.Delete;
        eliminarToolStripMenuItem.Size = new Size(224, 26);
        eliminarToolStripMenuItem.Text = "Eliminar";
        // 
        // toolStripSeparator3
        // 
        toolStripSeparator3.Name = "toolStripSeparator3";
        toolStripSeparator3.Size = new Size(221, 6);
        // 
        // verToolStripMenuItem
        // 
        verToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productosToolStripMenuItem, categoriasToolStripMenuItem });
        verToolStripMenuItem.Name = "verToolStripMenuItem";
        verToolStripMenuItem.Size = new Size(44, 24);
        verToolStripMenuItem.Text = "Ver";
        // 
        // productosToolStripMenuItem
        // 
        productosToolStripMenuItem.Name = "productosToolStripMenuItem";
        productosToolStripMenuItem.Size = new Size(224, 26);
        productosToolStripMenuItem.Text = "Productos";
        // 
        // categoriasToolStripMenuItem
        // 
        categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
        categoriasToolStripMenuItem.Size = new Size(224, 26);
        categoriasToolStripMenuItem.Text = "Categorías";
        // 
        // guardarToolStripMenuItem
        // 
        guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
        guardarToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
        guardarToolStripMenuItem.Size = new Size(224, 26);
        guardarToolStripMenuItem.Text = "Guardar";
        // 
        // toolStripSeparator2
        // 
        toolStripSeparator2.Name = "toolStripSeparator2";
        toolStripSeparator2.Size = new Size(221, 6);
        // 
        // nuevoToolStripMenuItem
        // 
        nuevoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productoAnadir, categoríaAnadir });
        nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
        nuevoToolStripMenuItem.Size = new Size(211, 26);
        nuevoToolStripMenuItem.Text = "Nuevo";
        // 
        // productoAnadir
        // 
        productoAnadir.Name = "productoAnadir";
        productoAnadir.ShortcutKeys = Keys.Control | Keys.N;
        productoAnadir.Size = new Size(295, 26);
        productoAnadir.Text = "Producto";
        // 
        // categoríaAnadir
        // 
        categoríaAnadir.Name = "categoríaAnadir";
        categoríaAnadir.ShortcutKeys = Keys.Control | Keys.Shift | Keys.N;
        categoríaAnadir.Size = new Size(295, 26);
        categoríaAnadir.Text = "Categoría";
        // 
        // MainView
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(splitContainer1);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Name = "MainView";
        Text = "Form1";
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        splitContainer1.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
}

