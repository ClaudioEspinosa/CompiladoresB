using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1Tokenizado2018
{
    class Token:ICloneable
    {
        private string simbolo;///<Es la cadena que representa al token (identificador)
        private bool noTerminal;///<Bandera para saber si el simbolo es terminal o no
        private List<List<Token>> listaProducciones;///<Variable para manejar las diferentes producciones que puede manejar un simbolo, en caso de ser no terminal
        private List<string> primero;
        private bool analizador;
        public Token()
        {
            primero = new List<string>();
            noTerminal = false;//valor por default
            listaProducciones = new List<List<Token>>();
            analizador = false;//tiene la misma funcion que el analizador ¬
        }
        public Token(string unSimbolo,List<string>unPrimero,bool unNoterminal, List<List<Token>>unListaProducciones,bool unAnalizador)
        {
            simbolo = unSimbolo;
            primero = unPrimero;
            noTerminal = unNoterminal;
            listaProducciones = unListaProducciones;
            analizador = unAnalizador;
        }
        
        public List<List<Token>> getSetListaProducciones
        {
            get { return listaProducciones; }
            set { listaProducciones = value; }
        }
        public bool getSetNoTerminal
        {
            get { return noTerminal; }
            set { noTerminal = value; }
        }
        public string getSetSimbolo
        {
            get { return simbolo; }
            set { simbolo = value; }
        }
        public List<string> getSetPrimero
        {
            get { return primero; }
            set { primero = value; }
        }
        public bool getSetAnalizador
        {
            get { return analizador; }
            set { analizador = value; }
        }

        public object Clone()
        {
            return new Token(this.getSetSimbolo,this.primero,this.noTerminal, this.listaProducciones,this.getSetAnalizador);
        }
    }
}
