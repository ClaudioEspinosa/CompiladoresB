using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        private List<string> columnas;//guarda las columnas del datagrid tabla de analisis sintactico // es la union de los terminales y no terminales (listas)
        LR1 lr1;
        public Form1()
        {
            InitializeComponent();


        }
        /**
         * @brief Método para abrir un archivo txt 
         **/
        public void abrir()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error en la funcion abrir " + ex, "Compiladores B ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void lR1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                abrir();
                lr1 = new LR1(gramatica);
                lr1.elementos();
                visualizaEdos();
                visualizaTablaAS();
            }
            catch (Exception ex)
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
        /// <summary>
        /// Metodo que recibe un objeto tipo tablaAnalisisS y lo serializa
        /// </summary>
        public void serializaTabla(tablaAnalisisS unaTabla)
        {

            BinaryFormatter bf = new BinaryFormatter();//binary Fromatter =bf
            FileStream fsout = new FileStream("tablaAS.binary", FileMode.Create, FileAccess.Write, FileShare.None);

            try
            {
                using (fsout)//filesreamout es el archivo de salida
                {
                    bf.Serialize(fsout, unaTabla);// se le manda e archivo y el objeto a serializar
                    //obviamente se debe de tener otro metodo para deserealizar 
                    MessageBox.Show("Tabla Serializada");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
            }

        }
        public tablaAnalisisS deserealizaTabla()
        {
            tablaAnalisisS tablaAsDeserealizada;

            BinaryFormatter bf = new BinaryFormatter();

            FileStream fsin = new FileStream("tablaAS.binary", FileMode.Open, FileAccess.Read, FileShare.None);
            try
            {
                using (fsin)
                {
                    tablaAsDeserealizada = (tablaAnalisisS)bf.Deserialize(fsin);
                    MessageBox.Show("Tabla Deserializada");


                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
                return null;
            }

            return tablaAsDeserealizada;
        }
        public void visualizaTablaAS()//visualiza tabla de analisis sintactico
        {
            GridAnalisisSintact.Columns.Add("Estados", "Estados");
            GridAnalisisSintact.Columns[0].HeaderText = "Estados";
            columnas = new List<string>();
            foreach(Token t in gramatica.getSetTerminales)
            {
                columnas.Add(t.getSetSimbolo);
            }
            columnas.Add("$");
            foreach (Token t in gramatica.getSetNoTerminales)
            {
                columnas.Add(t.getSetSimbolo);
            }
            for (int i = 0; i < lr1.getListaEstadosLr1.Count; i++)
            {
                GridAnalisisSintact.Rows.Add(i.ToString());
            }
            for (int i = 0; i < columnas.Count; i++)
            {
                GridAnalisisSintact.Columns.Add("NoTerminal", columnas[i]);
            }

            llenaDataGrid(lr1.getTransicionesLr1);
        }
        /// <summary>
        /// Funcion para llenar el datagrid de tabla de analisis sintactico
        /// </summary>
        /// <param name="transiciones"></param>
        private void llenaDataGrid(List<String> transiciones)
        {
            string[] aux;//auxiliar para hacer el parse de una cadena
            int ren, col;//renglon y columna del datagrid de tabla de analisis sintactico
            for (int i = 0; i < transiciones.Count; i++)
            {
                aux = transiciones[i].Split('°');
                ren = int.Parse(aux[0]);//como llega como cadena, lo convierto a int

                col = columnas.IndexOf(aux[1]);
                GridAnalisisSintact.Rows[ren].Cells[col + 1].Value = aux[2];//columnas +1 porque la columna 0 es el numero del estado

            }

        }

        public void visualizaEdos()
        {
            List<EdoLR1> aux = lr1.getListaEstadosLr1;
            string auxCadProduccion = "";
            string auxCadcAdelanto = "";
            for (int i = 0; i < aux.Count; i++)
            {
                treeViewEdoAFD.Nodes.Add("Estado " + i);
                foreach (ElementoLR1 elemento in aux[i].getSetListElementos)
                {
                    foreach (Token t in elemento.getSetListaProduccion)
                    {
                        auxCadProduccion += t.getSetSimbolo;
                    }
                    foreach (string t in elemento.getSetLadocAdelanto)
                    {
                        auxCadcAdelanto += t;
                    }
                    treeViewEdoAFD.Nodes[i].Nodes.Add(elemento.getSetSimbolo + "->" + auxCadProduccion + "," + auxCadcAdelanto);
                    auxCadProduccion = "";
                    auxCadcAdelanto = "";
                }
            }
        }
    }
}
