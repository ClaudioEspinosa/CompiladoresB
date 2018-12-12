using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1Tokenizado2018
{
    class ElementoLR1
    {
        private string simbolo;///<Es la cadena que representa al token (identificador)
        private bool noTerminal;///<Bandera para saber si el simbolo es terminal o no
        private List<List<Token>> listaProducciones;///<Variable para manejar las diferentes producciones que puede manejar un simbolo, en caso de ser no terminal
        private List<string> primero;
        private Token be;
        private Token beta;
        private bool analizado;///<variable para indicar que el elemento ya termino de analizar
        private List<string> cAdelanto;
        public ElementoLR1()
        {
            analizado = false;
        }

       public ElementoLR1(string unSimbolo, List<List<Token>> unaListaProducciones,List<string>unCadelanto)
        {
            simbolo = unSimbolo;
            listaProducciones = unaListaProducciones;
            cAdelanto = unCadelanto;
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
    }
}

