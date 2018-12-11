using System;
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
        string[] renglonesArch;///< representa los renglones del archivo de la grámatica 
        Gramatica gramatica;
        public Form1()
        {
            InitializeComponent();
                
        }
        /**
         * @brief Método para abrir un archivo txt 
         **/
        public void abrir()
        {
            //el archivo se llama g4 por el nombre que le da antlr a sus grámaticas
            cadAbrir = System.IO.File.ReadAllText("G4.txt");
            renglonesArch = cadAbrir.Split('\r');//se hace un split por renglon
            for (int i = 0; i < renglonesArch.Length; i++)
            {
                if (renglonesArch[i].Contains('\n'))
                    renglonesArch[i] = renglonesArch[i].Trim('\n');//se quitan los caracteres \n, no se imprimen pero hacen ruido al analizar la cadena
            }

            gramatica = new Gramatica(renglonesArch.ToList());///<Se crea la variable para el manejo de la gramática
            visualizaNTyT();
            gramatica.primero();

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

        public void visualizaNTyT()//Metodo que agrega a un treeview la lista de nt y t
        {
            treeViewNTT.Nodes.Add("No Terminales");
            for (int i = 0; i < gramatica.getSetNoTerminales.Count; i++)
            {
                treeViewNTT.Nodes[0].Nodes.Add(gramatica.getSetNoTerminales[i].getSetSimbolo);
            }
            treeViewNTT.Nodes.Add("Terminales");
            for (int i = 0; i < gramatica.getSetTerminales.Count; i++)
            {
                treeViewNTT.Nodes[1].Nodes.Add(gramatica.getSetTerminales[i].getSetSimbolo);
            }
        }


    }
}
