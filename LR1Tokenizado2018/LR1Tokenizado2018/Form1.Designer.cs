namespace LR1Tokenizado2018
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.algoritmosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lR1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.treeViewNTT = new System.Windows.Forms.TreeView();
            this.labelTAS = new System.Windows.Forms.Label();
            this.GridAnalisisSintact = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.treeViewEdoAFD = new System.Windows.Forms.TreeView();
            this.btnAnalisis = new System.Windows.Forms.Button();
            this.btnlr1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridTAcciones = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.textCodFuente = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridAnalisisSintact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTAcciones)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algoritmosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1220, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // algoritmosToolStripMenuItem
            // 
            this.algoritmosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lR1ToolStripMenuItem});
            this.algoritmosToolStripMenuItem.Name = "algoritmosToolStripMenuItem";
            this.algoritmosToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.algoritmosToolStripMenuItem.Text = "Algoritmos";
            // 
            // lR1ToolStripMenuItem
            // 
            this.lR1ToolStripMenuItem.Name = "lR1ToolStripMenuItem";
            this.lR1ToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.lR1ToolStripMenuItem.Text = "LR1";
            this.lR1ToolStripMenuItem.Click += new System.EventHandler(this.lR1ToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(845, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Listas de Terminales y No Terminales";
            // 
            // treeViewNTT
            // 
            this.treeViewNTT.Location = new System.Drawing.Point(848, 63);
            this.treeViewNTT.Name = "treeViewNTT";
            this.treeViewNTT.Size = new System.Drawing.Size(199, 264);
            this.treeViewNTT.TabIndex = 7;
            // 
            // labelTAS
            // 
            this.labelTAS.AutoSize = true;
            this.labelTAS.ForeColor = System.Drawing.Color.Black;
            this.labelTAS.Location = new System.Drawing.Point(12, 37);
            this.labelTAS.Name = "labelTAS";
            this.labelTAS.Size = new System.Drawing.Size(137, 13);
            this.labelTAS.TabIndex = 10;
            this.labelTAS.Text = "Tabla de Analisis Sintactico";
            // 
            // GridAnalisisSintact
            // 
            this.GridAnalisisSintact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridAnalisisSintact.Location = new System.Drawing.Point(15, 63);
            this.GridAnalisisSintact.Name = "GridAnalisisSintact";
            this.GridAnalisisSintact.Size = new System.Drawing.Size(489, 264);
            this.GridAnalisisSintact.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(522, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Estados AFD";
            // 
            // treeViewEdoAFD
            // 
            this.treeViewEdoAFD.Location = new System.Drawing.Point(525, 63);
            this.treeViewEdoAFD.Name = "treeViewEdoAFD";
            this.treeViewEdoAFD.Size = new System.Drawing.Size(298, 264);
            this.treeViewEdoAFD.TabIndex = 11;
            // 
            // btnAnalisis
            // 
            this.btnAnalisis.Location = new System.Drawing.Point(451, 567);
            this.btnAnalisis.Name = "btnAnalisis";
            this.btnAnalisis.Size = new System.Drawing.Size(84, 33);
            this.btnAnalisis.TabIndex = 21;
            this.btnAnalisis.Text = "Analizar";
            this.btnAnalisis.UseVisualStyleBackColor = true;
            this.btnAnalisis.Click += new System.EventHandler(this.btnAnalisis_Click);
            // 
            // btnlr1
            // 
            this.btnlr1.Location = new System.Drawing.Point(12, 566);
            this.btnlr1.Name = "btnlr1";
            this.btnlr1.Size = new System.Drawing.Size(90, 33);
            this.btnlr1.TabIndex = 20;
            this.btnlr1.Text = "LR1";
            this.btnlr1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(448, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Tabla de Acciones";
            // 
            // dataGridTAcciones
            // 
            this.dataGridTAcciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTAcciones.Location = new System.Drawing.Point(451, 347);
            this.dataGridTAcciones.Name = "dataGridTAcciones";
            this.dataGridTAcciones.Size = new System.Drawing.Size(324, 214);
            this.dataGridTAcciones.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Codigo Fuente";
            // 
            // textCodFuente
            // 
            this.textCodFuente.Location = new System.Drawing.Point(12, 347);
            this.textCodFuente.Multiline = true;
            this.textCodFuente.Name = "textCodFuente";
            this.textCodFuente.Size = new System.Drawing.Size(411, 213);
            this.textCodFuente.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 618);
            this.Controls.Add(this.btnAnalisis);
            this.Controls.Add(this.btnlr1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridTAcciones);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textCodFuente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.treeViewEdoAFD);
            this.Controls.Add(this.labelTAS);
            this.Controls.Add(this.GridAnalisisSintact);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.treeViewNTT);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Compiladores B";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridAnalisisSintact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTAcciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem algoritmosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lR1ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeViewNTT;
        private System.Windows.Forms.Label labelTAS;
        private System.Windows.Forms.DataGridView GridAnalisisSintact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treeViewEdoAFD;
        private System.Windows.Forms.Button btnAnalisis;
        private System.Windows.Forms.Button btnlr1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridTAcciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textCodFuente;
    }
}

