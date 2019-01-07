using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR1Tokenizado2018
{
    [Serializable]
    class TablaAcciones
    {

        tablaAnalisisS tablaAnalisisS;///<Representa a la tabla de analisis sintactico que viene del lr1
        DataGridView tablaAnalisis = new DataGridView();//pudiera ser una arreglo de strings pero lo manejo de forma mas facil como datagrid
        string cadenaResult = "";
        List<string> cadEntrada;///<Aqui se guarda el codigo que ingresa el usuario
        List<string> pilaAS;///<Pila de analisis sintactico
        List<string> acciones;///<Pila de acciones 
        //funciona como una pila

        List<string> pilaCadenasAS;

        List<Produccion> Originales;///<Producciones de la gramática
        public TablaAcciones(List<Produccion> unasProducciones, List<string> Palabras)
        {
            try
            {
                List<string> resultado = new List<string>();
                tablaAnalisisS = deserealizaTabla();//llega la tabla de analisis sintactico serializada
                generaDataAnalisis();

                realizaTablaAC(Palabras);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al Deserealizar Tabla " + e);

            }
        }

        /***
         * @brief Método que deserealiza una tabla de analisis sintactico 
         * @return Retorna un objeto con información de la tabla de análisis sintáctico 
         * */
        public tablaAnalisisS deserealizaTabla()
        {
            tablaAnalisisS tablaAsDeserealizada;

            BinaryFormatter bf = new BinaryFormatter();

            FileStream fsin = new System.IO.FileStream("tablaAS.binary", FileMode.Open, FileAccess.Read, FileShare.None);
            try
            {
                using (fsin)
                {
                    tablaAsDeserealizada = (tablaAnalisisS)bf.Deserialize(fsin);
                    ///   MessageBox.Show("Tabla Deserializada");


                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e);
                return null;
            }

            return tablaAsDeserealizada;
        }
        /***
         * @brief Metodo para generar la tabla de analisis en un datagrid
         * */
        public void generaDataAnalisis()
        {
            //me es mas facil visualizarlo asi   
            tablaAnalisis.Columns.Add("Estados", "Estados");
            tablaAnalisis.Columns[0].HeaderText = "Estados";



            for (int i = 0; i < tablaAnalisisS.getSetRenglones; i++)
            {
                tablaAnalisis.Rows.Add(i.ToString());
            }

            for (int i = 0; i < tablaAnalisisS.getSetColumnas.Count; i++)
            {
                tablaAnalisis.Columns.Add("NoTerminal", tablaAnalisisS.getSetColumnas[i]);
            }
            llenaDataGrid(tablaAnalisisS.getSetTransiciones);
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

                col = tablaAnalisisS.getSetColumnas.IndexOf(aux[1]);
                tablaAnalisis.Rows[ren].Cells[col + 1].Value = aux[2];//columnas +1 porque la columna 0 es el numero del estado

            }

        }
        public string realizaTablaAC(List<string> unaCadEntrada)
        {

            Stack<string> PilaLetras = new Stack<string>();

            //algoritmo libro del dragon
            pilaAS = new List<string>();
            pilaCadenasAS = new List<string>();//aqui se guardara el resultado de la pila de analisis sintactico por ejecucion es decir por cada ciclo del while
            string auxpilaCadenas = "";//auxiliar para formar la cadena resultante, ya que mi pils AS es de chars 
            cadEntrada = new List<string>();
            acciones = new List<string>();
            pilaAS.Add("$");//se agrega el simbolo de pesos
            pilaAS.Add("0");//se agrega el inicio
            pilaCadenasAS.Add("$0");
            cadEntrada=generaCadEntrada(unaCadEntrada);
           // cadEntrada.Add(unaCadEntrada.ToLower() + "$");//convierte todo a minusculas 
            bool aceptado = false;
            int x, y;
            Produccion auxiliar = new Produccion();


            string auxSw = "";//auxiliar del switch
            int auxAccion;
            try
            {
                while (!aceptado)
                {

                    string aux = pilaAS.Last();
                    x = int.Parse(aux);//puede ser pila de chars
                                       //para sacar y existen varios casos
                    if (cadEntrada.Last() == '\\'.ToString())//casoMetacaracter
                    {
                        y = tablaAnalisisS.getSetColumnas.IndexOf(cadEntrada.Last().ToCharArray()[0].ToString() + cadEntrada.Last().ToCharArray()[1].ToString());//en este caso agarramos los primeros dos 
                    }
                    else
                    {
                        // MessageBox.Show(cadEntrada.Last().ToCharArray()[0].ToString());
                        y = tablaAnalisisS.getSetColumnas.IndexOf(cadEntrada.Last().ToString());//si no, es otro caracter
                    }
                    acciones.Add(tablaAnalisis.Rows[x].Cells[y].Value.ToString());
                    if (acciones.Last().Contains('s'))//quiere decir que es un desplazamiento
                    {
                        //se hace un despazamiento
                        //  pilaAS.Add(pilaAS.Last() + cadEntrada.Last().ToCharArray()[0]);
                        pilaAS.Add(cadEntrada.Last());

                        pilaAS.Add(acciones.Last().Replace("s", ""));
                        //aqui lo que se hace es generar un nuevo renglon de la pila AS 
                        //lo que ya tenia mas el caracter de entrada mas el numero del estado a desplzar
                        if (cadEntrada.Last() != "$")
                            cadEntrada.Add(cadEntrada.Last().Substring(1));


                    }
                    else
                    if (acciones.Last().Contains('r'))//al hacer una reduccion, se vienen varios eventos,
                                                      //uno de ellos es la accion  sintactica, la accion semantica y si genera o no arbol,
                                                      //con el arbol despues generamos los cuadruplos 

                    {
                        //aqui viene el switch

                        try
                        {
                            auxSw = acciones.Last().Replace("r", "");//nos quedamos solo con el numero
                            auxAccion = int.Parse(auxSw);
                            switch (auxAccion)
                            {
                                case 0:
                                    // MessageBox.Show(cadena);//reduccion de aceptacion
                                    break;

                                case 1://trivial
                                    
                                    break;

                                case 2://trivial
                                 
                                    break;

                                case 3://trivial
                                   
                                    break;

                                case 4:
                                 
                                    break;

                                case 5:
                                 
                                    break;

                                case 6:
                                    
                                    break;

                                case 7:
                                   
                                    break;

                                case 8:
                                   
                                    break;

                                case 9:
                                    
                                    break;

                                case 10:
                                  
                                    break;

                                case 11:
                                   
                                    break;

                                case 12:
                                   
                                    break;

                                case 13:
                                   
                                    break;

                                case 14:
                                   
                                    break;

                                case 15:
                                   
                                    break;

                                case 16:
                                  
                                    break;

                                case 17:
                                    
                                    break;

                                case 18:
                                   
                                    break;
                                case 19:
                                  
                                    break;

                                case 20:
                                    
                                    break;

                                case 21:
                                    
                                    break;

                                case 22:
                                  
                                    break;

                                case 23:
                                   
                                    break;

                                case 24:
                                   
                                    break;

                                case 25:
                                    
                                    break;

                                case 26:
                                   
                                    break;

                                case 27:
                                   
                                    break;

                                case 28:
                                  
                                    break;
                                case 29:
                                  
                                    break;
                                    //case 30:
                                    //    PilaLetras.Push("_");//_
                                    //    auxiliar = Originales[auxAccion];
                                    //    ReduceProduccion(auxiliar, pilaAS.Last());
                                    //    break;




                            }


                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Error en Esquema " + e);
                        }

                    }//while

                    for (int i = 0; i < pilaAS.Count; i++)
                    {
                        auxpilaCadenas += pilaAS[i];
                    }
                    pilaCadenasAS.Add(auxpilaCadenas);
                    auxpilaCadenas = "";
                }
                if (aceptado)
                {
                    ////////////////////////////////////////////////////////////////////////////////////////////////////
                    int auxCont = PilaLetras.Count;
                    for (int i = auxCont - 1; i >= 0; i--)
                    {
                        cadenaResult += PilaLetras.ToList()[i];//agregar final de transmision .-.-.
                    }
                    //    MessageBox.Show(cadenaResult);
                    return cadenaResult;
                }
                else
                    return "error";

            }
            catch (Exception e)
            {
                MessageBox.Show("Error en Esquema " + e);
                return "error";
            }

        }

        public List<string> generaCadEntrada(List<string> unaCadEntrada)
        {
            List<string> res=new List<string>();
            foreach(string cad in unaCadEntrada)
            {
                res.Add(cad.ToLower());
            }
            res.Add("$");

            return res;
        }
    }
        }

