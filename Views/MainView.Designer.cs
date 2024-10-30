namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Views;

partial class MainView
{
    private System.ComponentModel.IContainer components = null;
    private SplitContainer splitContainer1;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem archivoToolStripMenuItem;
    private ToolStripMenuItem editarToolStripMenuItem;
    private ToolStripMenuItem verToolStripMenuItem;
    private ToolStripMenuItem nuevoToolStripMenuItem;
    private ToolStripMenuItem productoAnadir;
    private ToolStripMenuItem categoríaAnadir;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem salir;
    private ToolStripMenuItem deshacerToolStripMenuItem;
    private ToolStripMenuItem copiarToolStripMenuItem;
    private ToolStripMenuItem copiarToolStripMenuItem1;
    private ToolStripMenuItem pegarToolStripMenuItem;
    private ToolStripMenuItem eliminarToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripMenuItem buscarToolStripMenuItem;
    private ToolStripMenuItem irAToolStripMenuItem;
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
        nuevoToolStripMenuItem = new ToolStripMenuItem();
        productoAnadir = new ToolStripMenuItem();
        categoríaAnadir = new ToolStripMenuItem();
        toolStripSeparator1 = new ToolStripSeparator();
        salir = new ToolStripMenuItem();
        editarToolStripMenuItem = new ToolStripMenuItem();
        deshacerToolStripMenuItem = new ToolStripMenuItem();
        copiarToolStripMenuItem = new ToolStripMenuItem();
        copiarToolStripMenuItem1 = new ToolStripMenuItem();
        pegarToolStripMenuItem = new ToolStripMenuItem();
        eliminarToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator3 = new ToolStripSeparator();
        buscarToolStripMenuItem = new ToolStripMenuItem();
        irAToolStripMenuItem = new ToolStripMenuItem();
        verToolStripMenuItem = new ToolStripMenuItem();
        productosToolStripMenuItem = new ToolStripMenuItem();
        categoriasToolStripMenuItem = new ToolStripMenuItem();
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
        archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevoToolStripMenuItem, toolStripSeparator1, salir });
        archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
        archivoToolStripMenuItem.Size = new Size(73, 24);
        archivoToolStripMenuItem.Text = "Archivo";
        // 
        // nuevoToolStripMenuItem
        // 
        nuevoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productoAnadir, categoríaAnadir });
        nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
        nuevoToolStripMenuItem.Size = new Size(135, 26);
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
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(132, 6);
        // 
        // salir
        // 
        salir.Name = "salir";
        salir.Size = new Size(135, 26);
        salir.Text = "Salir";
        // 
        // editarToolStripMenuItem
        // 
        editarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { deshacerToolStripMenuItem, copiarToolStripMenuItem, copiarToolStripMenuItem1, pegarToolStripMenuItem, eliminarToolStripMenuItem, toolStripSeparator3, buscarToolStripMenuItem, irAToolStripMenuItem });
        editarToolStripMenuItem.Name = "editarToolStripMenuItem";
        editarToolStripMenuItem.Size = new Size(62, 24);
        editarToolStripMenuItem.Text = "Editar";
        // 
        // deshacerToolStripMenuItem
        // 
        deshacerToolStripMenuItem.Name = "deshacerToolStripMenuItem";
        deshacerToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
        deshacerToolStripMenuItem.Size = new Size(211, 26);
        deshacerToolStripMenuItem.Text = "Deshacer";
        // 
        // copiarToolStripMenuItem
        // 
        copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
        copiarToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
        copiarToolStripMenuItem.Size = new Size(211, 26);
        copiarToolStripMenuItem.Text = "Cortar";
        // 
        // copiarToolStripMenuItem1
        // 
        copiarToolStripMenuItem1.Name = "copiarToolStripMenuItem1";
        copiarToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.C;
        copiarToolStripMenuItem1.Size = new Size(211, 26);
        copiarToolStripMenuItem1.Text = "Copiar";
        // 
        // pegarToolStripMenuItem
        // 
        pegarToolStripMenuItem.Name = "pegarToolStripMenuItem";
        pegarToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
        pegarToolStripMenuItem.Size = new Size(211, 26);
        pegarToolStripMenuItem.Text = "Pegar";
        // 
        // eliminarToolStripMenuItem
        // 
        eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
        eliminarToolStripMenuItem.ShortcutKeys = Keys.Delete;
        eliminarToolStripMenuItem.Size = new Size(211, 26);
        eliminarToolStripMenuItem.Text = "Eliminar";
        // 
        // toolStripSeparator3
        // 
        toolStripSeparator3.Name = "toolStripSeparator3";
        toolStripSeparator3.Size = new Size(208, 6);
        // 
        // buscarToolStripMenuItem
        // 
        buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
        buscarToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.B;
        buscarToolStripMenuItem.Size = new Size(211, 26);
        buscarToolStripMenuItem.Text = "Buscar";
        // 
        // irAToolStripMenuItem
        // 
        irAToolStripMenuItem.Name = "irAToolStripMenuItem";
        irAToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.T;
        irAToolStripMenuItem.Size = new Size(211, 26);
        irAToolStripMenuItem.Text = "Ir a";
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
        productosToolStripMenuItem.Size = new Size(163, 26);
        productosToolStripMenuItem.Text = "Productos";
        // 
        // categoriasToolStripMenuItem
        // 
        categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
        categoriasToolStripMenuItem.Size = new Size(163, 26);
        categoriasToolStripMenuItem.Text = "Categorías";
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

    private Label headerId;
    private TextBox textBoxId;
    private Button buttonModificar;
    private Button buttonEliminar;
}
