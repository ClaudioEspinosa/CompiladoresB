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
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridAnalisisSintact)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algoritmosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(962, 24);
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
            this.label2.Location = new System.Drawing.Point(525, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Listas de Terminales y No Terminales";
            // 
            // treeViewNTT
            // 
            this.treeViewNTT.Location = new System.Drawing.Point(527, 63);
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
            this.label3.Location = new System.Drawing.Point(12, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Estados AFD";
            // 
            // treeViewEdoAFD
            // 
            this.treeViewEdoAFD.Location = new System.Drawing.Point(15, 346);
            this.treeViewEdoAFD.Name = "treeViewEdoAFD";
            this.treeViewEdoAFD.Size = new System.Drawing.Size(298, 213);
            this.treeViewEdoAFD.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 588);
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
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridAnalisisSintact)).EndInit();
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
    }
}

