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
        private List<Token> noTerminales;///<Lista de elementos no terminales de la gramática
        private List<Token> terminales;///<Lista de elementos terminales de a gramática
        private const Char epsilon = '~';///<Simboliza la cadena vácia 
        private List<Token> listaElemGramaticales;
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
            terminales = new List<Token>();
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
                izq.getSetSimbolo = auxSplit[0].Trim();
                izq.getSetNoTerminal = true;
                //hasta aqui sabemos que el lado izquierdo debe de ser un token, el lado derecho puede ser uno o más asi que mas adelante se separaran hasta ahora se guardara la cadena del lado derecho
                listaProducciones.Add(new Produccion(izq, auxSplit[1].Trim()));
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
            clasificaTokensDer();
        }
        /**
         * @brief Método para clasificar como NT o T los tokens del lado derecho de las producciones
         * **/
        public void clasificaTokensDer()
        {
            listaElemGramaticales = new List<Token>();
            string[] auxSplitEspacios;
            
            for (int i = 0; i < listaProducciones.Count; i++)
            {
                auxSplitEspacios = listaProducciones[i].getSetStringladoDer.Split(' ');
                for (int ij = 0; ij < auxSplitEspacios.Length; ij++)//por cada cadena separa por espacio, debemos de hacer clasificacion
                {
                    if (checaNoTerminal(auxSplitEspacios[ij]))
                    {
                        Token nuevo = new Token();
                        nuevo.getSetSimbolo = auxSplitEspacios[ij];
                        nuevo.getSetNoTerminal = true;//se marca que es no terminal
                        listaProducciones[i].getSetladoDer.Add(nuevo);
                        if (!containsListaToken(listaElemGramaticales, nuevo.getSetSimbolo))
                            listaElemGramaticales.Add(nuevo);//se agrega a la lista de elementos gramaticales

                    }
                    else
                    {
                        Token nuevo = new Token();
                        nuevo.getSetSimbolo = auxSplitEspacios[ij];//solo agregamos el simbolo porque por default se marca como terminal
                        listaProducciones[i].getSetladoDer.Add(nuevo);
                        if (!containsListaToken(listaElemGramaticales, nuevo.getSetSimbolo))
                            listaElemGramaticales.Add(nuevo);
                        if (!containsListaToken(terminales, nuevo.getSetSimbolo))
                            terminales.Add(nuevo);
                    }
                   
                }
            }
            generaProducNoTerminales();
        }
        /**
         * @brief Método que verifica la existencia de un token en una lista de tokens, no se hace con el contains normal ya que no identifica los tokens
         * @return retorna true cuando el token ya se encuentra en la lista
         * **/
        public bool containsListaToken(List<Token> unaListaToken,string unSimbolo)
        {
            foreach(Token t in unaListaToken)
            {
                if (t.getSetSimbolo == unSimbolo)
                {
                    return true;
                }
            }

            return false;
        }

        /**
         * @brief Método que verifica si un token pertenece al conjunto de los No Terminales
         * @param cadToken Párametro que representa un token
         * return Retorna verdadero cuando el token pertenece a los no terminales
         * */
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
        /**
         * @brief Método que generará en la lista de no terminales, la lista de producciones, es decir un no terminal puede tner varias producciones asociadas
         * 
         * **/
        public void generaProducNoTerminales()
        {
            try
            {
                for (int i = 0; i < noTerminales.Count; i++)//aqui se hace el ciclo para los no terminales
                {
                    for (int j = 0; j < listaProducciones.Count; j++)
                    {
                        if (listaProducciones[j].getSetladoIzq.getSetSimbolo == noTerminales[i].getSetSimbolo)
                        {
                            if (!listaProducciones[j].getSetVisitado)//si no ha sido visitado 
                            {
                                noTerminales[i].getSetListaProducciones.Add(listaProducciones[j].getSetladoDer);
                                listaProducciones[j].getSetVisitado = true;

                            }
                        }
                    }
                }
            }catch(Exception e)
            {
                MessageBox.Show("Error Generando Listas NT " + e, "Compiladores B", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     /*-----------------------------------Seccion de gets y sets------------------------------------------------*/
     public List<Token> getSetElemGramaticales
        {
            get { return listaElemGramaticales; }
            set { listaElemGramaticales =  value; }
        }

        public List<Token> getSetTerminales
        {

            get { return terminales; }
            set { terminales = value; }
        }
        public List<Token> getSetNoTerminales
        {

            get { return noTerminales; }
            set { noTerminales = value; }
        }
        public List<Produccion> getListaProducciones
        {
            get { return listaProducciones; }
            set { listaProducciones = value; }
        }

    //-----------------------------------------------------------------------------------------------------//
    /**
     * @brief Método que ejecuta el algoritmo de primeros
     * **/
    public void primero()
        {
            bool pasada = false;
           List< List<string>> auxPrimeroI=new List<List<string>>();//lista que se le asignan los primeros iniciales
           List<List<string>> auxPrimeroF = new List<List<string>>();//lista que se compara con los primeros iniciales y se ve si existe cambio

            do
            {
                pasada = false;
                foreach(Token t in noTerminales)
                {
                    Token aux = new Token();
                   
                    foreach(string s in t.getSetPrimero)
                    {
                        aux.getSetPrimero.Add(s);
                    }
                    
                    auxPrimeroI.Add(aux.getSetPrimero);//se recuperan los primeros
                }
                foreach(Token t in noTerminales)//los no terminales realmente contienen las producciones
                {       
                    foreach(List<Token> t0 in t.getSetListaProducciones)//lista de produciones de cada no terminal
                    {
                        if (t0[0].getSetNoTerminal)//checamos el primer elemento si es No terminal
                        {
                            Token auxiliarToken = buscaToken(noTerminales, t0[0].getSetSimbolo);
                            foreach (string s in auxiliarToken.getSetPrimero)//si tenemos A->B primero de A es primero B 
                            {
                                if (!t.getSetPrimero.Contains(s))
                                {
                                    t.getSetPrimero.Add(s);
                                    t0[0].getSetPrimero.Add(s);
                                }
                            }

                        }
                        else//si el primero es un T  caso A->xB donde primero de A es x
                        {
                            if (!t.getSetPrimero.Contains(t0[0].getSetSimbolo))
                                t.getSetPrimero.Add(t0[0].getSetSimbolo);
                        }
                    }
                }

                foreach (Token t in noTerminales)
                {
                    Token aux = new Token();
                    foreach (string s in t.getSetPrimero)
                    {
                        aux.getSetPrimero.Add(s);
                    }

                    auxPrimeroF.Add(aux.getSetPrimero);//se recuperan los primeros
                   // auxPrimeroF.Add(t.getSetPrimero);//se recuperan los primeros
                }

                for(int i=0;i<auxPrimeroI.Count;i++)
                {
                    if (!auxPrimeroI[i].SequenceEqual(auxPrimeroF[i]))
                    {
                        pasada = true;
                    }
                }
                auxPrimeroI.Clear();
                auxPrimeroF.Clear();
            } while (pasada);

        }

        public Token buscaToken(List<Token>unaListaToken,string unSimbolo)
        {
            foreach (Token t in unaListaToken)
            {
                if (t.getSetSimbolo == unSimbolo)
                {
                    return t;
                }
            }
            return null;
        }
    }
}
