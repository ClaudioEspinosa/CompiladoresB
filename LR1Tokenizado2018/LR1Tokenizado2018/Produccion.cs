using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1Tokenizado2018
{
    class Produccion
    {
        Token ladoIzq;///<Solo se tiene un Token del lado izquierdo por ser libre de contexto
        string stringDer;//primero guadare el lado derecho como cadena y luego lo ire separando por tokens
        List<Token> ladoDer;///<Lado der es una lista y en caso de que solo tenga una produccion la list es de longitud 1
        public Produccion()
        {
            ladoIzq = new Token();
            ladoDer = new List<Token>();

        }
        public Produccion(Token unLadoIzq,string unLadoDer)
        {
            ladoIzq = unLadoIzq;
            stringDer = unLadoDer;
            ladoDer = new List<Token>();
        }
        public Token getSetladoIzq
        {
            get { return ladoIzq; }
            set { ladoIzq = value; }
        }
        public List<Token> getSetladoDer
        {
            get { return ladoDer; }
            set { ladoDer = value; }
        }
        public string getSetStringladoDer
        {
            get { return stringDer; }
            set { stringDer = value; }
        }



    }
}
