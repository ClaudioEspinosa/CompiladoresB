using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1Tokenizado2018
{
    [Serializable]
    public class tablaAnalisisS
    {
        private List<string> columnas;
        private int renglones;
        private List<string> transiciones;
        private Gramatica unaGramatica;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unasColumnas">Columnas del datagrid</param>
        /// <param name="unosRenglones">Los renglones son entero por que solo es el numero del estado, se puede llenar con un simple for</param>
        /// <param name="unasTransiciones">para volver a armar el datagrid es necesario saber las transiciones que tiene</param>
        public tablaAnalisisS(List<string> unasColumnas, int unosRenglones, List<string> unasTransiciones)
        {
            columnas = unasColumnas;
            renglones = unosRenglones;
            transiciones = unasTransiciones;
        }
        public List<string> getSetColumnas
        {
            get { return columnas; }
            set { columnas = value; }
        }
        public int getSetRenglones
        {
            get { return renglones; }
            set { renglones = value; }
        }
        public List<string> getSetTransiciones
        {
            get { return transiciones; }
            set { transiciones = value; }
        }

    }
}
