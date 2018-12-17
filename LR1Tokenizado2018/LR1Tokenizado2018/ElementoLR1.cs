using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR1Tokenizado2018
{
    class ElementoLR1
    {
        private string simbolo;///<Es la cadena que representa al token (identificador)
        private bool noTerminal;///<Bandera para saber si el simbolo es terminal o no
        private List<Token> produccion;///<Variable para manejar las diferentes producciones que puede manejar un simbolo, en caso de ser no terminal
        private List<string> primero;
        private Token be;
        private Token beta;
        private bool analizado;///<variable para indicar que el elemento ya termino de analizar
      
        private List<string> cAdelanto;
        public ElementoLR1()
        {
            analizado = false;
            produccion = new List<Token>();
            cAdelanto = new List<string>();

        }

       public ElementoLR1(string unSimbolo, List<Token> unaListaProducciones,List<string>unCadelanto)
        {
            simbolo = unSimbolo;
            produccion = unaListaProducciones;
            cAdelanto = unCadelanto;
            analizado = false;

        }
        public ElementoLR1(ElementoLR1 unElemento)
        {
            simbolo = unElemento.getSetSimbolo;
            produccion = unElemento.getSetListaProduccion;
            primero = unElemento.getSetPrimero;
            analizado = unElemento.getSetAnalizado;
            noTerminal = unElemento.getSetnoTerminal;
            cAdelanto = unElemento.getSetLadocAdelanto;
        }
        /**
         * @brief Método que pone en false el analizador de todos los tokens que llegan como parametro
         * **/
        public void retornaAnalizador()
        {
            if (produccion != null)
            {
                foreach (Token t in produccion)//aqui sucede que si la bandera es falsa y le asigno falso se vuelve verdadera wtf!!!
                {
                    if (t.getSetAnalizador)//si es true, lo pasa al false
                      t.getSetAnalizador = false;
                }
            }
            else
            {
                MessageBox.Show("Error al retornar analizador, funcion llamada en un momento erroneo verifique en que momento llama a la funcion ");
            }

        }

        ///--------------------Gets y Sets----------------------------------------///

        public bool getSetnoTerminal
        {
            get { return noTerminal; }
           set { noTerminal = value; }
        }
        public List<string> getSetPrimero
        {
            get { return primero; }
            set { primero = value; }
        }
       public string getSetSimbolo
        {
            get { return simbolo; }
            set { simbolo = value; }
        }
        public Token getSetBe
        {
            get { return be; }
            set { be = value; }
        }
        public  Token getSetBeta
        {
            get { return beta; }
            set { beta = value; }
        }
        public bool getSetAnalizado
        {
            get { return analizado; }
            set { analizado = value; }
        }
        public List<string> getSetLadocAdelanto
        {
            get { return cAdelanto; }
            set { cAdelanto = value; }
        }
       
        public List<Token> getSetListaProduccion
        {
            get { return produccion; }
            set { produccion = value; }
        }
    }
}

