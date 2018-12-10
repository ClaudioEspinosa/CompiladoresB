using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR1Tokenizado2018
{
    class Gramatica
    {
        private List<string> listaRenglones;
        private List<Produccion> listaProducciones;
        private List<Token> noTerminales;
        public Gramatica(List<string> unaListaRenglones)
        {
            init(unaListaRenglones);
            

        }
        /**
         * @brief Método para inicializar variables
         */
        public void init(List<string> unaListaRenglones)
        {
            listaRenglones = new List<string>() ;
            listaRenglones = unaListaRenglones;
            listaProducciones = new List<Produccion>();
            noTerminales = new List<Token>();
            obtenProducciones(unaListaRenglones);
        }
        /**
         * @brief este método obtendra el lado izquierdo y derecho de una produccion y creará Objetos tipo Produccion
         * @param unaListaProducciones
         * **/
        public void obtenProducciones(List<string>unaListaProducciones)
        {
            string[] auxSplit;//guarda el resultado del split claudiano
            bool loContiene = false;

            foreach(string s in unaListaProducciones)
            {
                loContiene = false;
               auxSplit=splitClaudiano(s);
                Produccion nueva = new Produccion();
                Token izq=new Token();
                izq.getSetSimbolo = auxSplit[0];
                izq.getSetTerminal = true;
                //hasta aqui sabemos que el lado izquierdo debe de ser un token, el lado derecho puede ser uno o más asi que mas adelante se separaran hasta ahora se guardara la cadena del lado derecho
                listaProducciones.Add(new Produccion(izq, auxSplit[1]));
                foreach(Token t in noTerminales)
                {
                    if (t.getSetSimbolo == izq.getSetSimbolo)
                        loContiene = true;
                }
                if (!loContiene)
                    noTerminales.Add(izq);
               // if(!noTerminales.Contains(izq))
                 //   noTerminales.Add(izq);//la parte izquierda siempre es el NT entonces lo agregamos a la lista de NT'S
                
            }
        }
        /**
         * @brief Método para clasificar como NT o T los tokens del lado derecho de las producciones
         * **/
        public void clasificaTokensIzq()
        {
            string[] auxSplitEspacios;
            for(int i = 0; i < listaProducciones.Count; i++)
            {
                auxSplitEspacios = listaProducciones[i].getSetStringladoDer.Split(' ');
                for (int ij = 0; ij < auxSplitEspacios.Length; ij++)//por cada cadena separa por espacio, debemos de hacer clasificacion
                {
                    if (checaNoTerminal(auxSplitEspacios[ij]))
                    {
                        Token nuevo = new Token();
                        nuevo.getSetSimbolo = auxSplitEspacios[ij];
                        nuevo.getSetTerminal = true;
                    }
                    else
                    {
                        Token nuevo = new Token();
                        nuevo.getSetSimbolo = auxSplitEspacios[ij];
                    }
                }
            }
        }

        public bool checaNoTerminal(string cadToken)
        {
            bool res = false;

            foreach(Token t in noTerminales)
            {
                if (t.getSetSimbolo == cadToken)
                    return true;
            }

            return res;
        }
        /**
         * @brief Método para separa el lado izquierdo del derecho, no se hace con split de c# porque en este caso separamos por dos caracteres '->'
         * y producciones ocupan el caracter '-' por lo que el split se haría doble, dando resultados totalmente erroneos
         * @param unaProduccion Cadena que representa una produccion a separar y convertir a un objeto Produccion
         * **/
        public string[] splitClaudiano(string unaCadena)
        {
            string[] resultado = new String[2];//regresaremos un arreglo de cadenas donde [0] es la parte izq de la produccion
            // y [1] es la parte derecha 
            bool error = true;//posible error si es que no se encuentran los caracteres -> seguidos
            char[] aux = { '-', '>' };// se hace un arreglo por los signos que queremos separar

            for (int i = 0; i < unaCadena.Length; i++)
            {
                if (unaCadena.ToCharArray()[i] == aux[0] && unaCadena.ToCharArray()[i + 1] == aux[1])//si se tiene ->
                {
                    error = false;//no hay error
                    for(int j = 0; j < i; j++)//ciclo para obtener el lado izquierdo
                    {
                        resultado[0] += unaCadena.ToCharArray()[j];
                    }
                    for(int k=i+2;k<unaCadena.Length;k++)//obtencion de lado derecho
                    {
                        resultado[1] += unaCadena.ToCharArray()[k];
                    }
                    break;//se rompe el ciclo ya que se repartio la produccion en lado izq y der
                }
            }
            if (!error)
                return resultado;
            else
            {
                MessageBox.Show("Error caracteres '->' no encontrados en alguna Produccion", "Compiladores B ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
