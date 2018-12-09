﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR1Tokenizado2018
{
    public partial class Form1 : Form
    {
        string cadAbrir = "";///< representa a la cadena que se abrira, todo el archivo se lee primero como una cadena grande, despues de debe separar por renglones

        public Form1()
        {
            InitializeComponent();
        }
        /**
         * @brief Método para abrir un archivo txt 
         **/
        public void abrir()
        {
            cadAbrir = System.IO.File.ReadAllText("G4.txt");

        }
        private void lR1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                abrir();
            }catch(Exception ex)
            {
                MessageBox.Show("Error al iniciar aplicación " + ex, "Compiladores B ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}