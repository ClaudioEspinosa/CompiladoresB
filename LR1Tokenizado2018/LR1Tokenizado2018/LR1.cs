using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace LR1Tokenizado2018
{
    /**
  * @class  LR1
  * @brief Clase para realizar el análisis LR1
  */
    class LR1
    {
        private string analizador = "¬";///<separador de cadena, se utliza en el método ir_A
        private Gramatica gramatica;///<Grámatica para trabajar el algoritmo LR1
        private List<EdoLR1> listEstadosLR1;///<Estados del AFD de análisis sintáctico LR1
        private List<ElementoLR1> listElemIniciales;
        private List<String> transicionesLr1;///< Transiciones del AFD
        public LR1(Gramatica unaGramatica)
        {
            gramatica = unaGramatica;//llega la gramatica con los primeros calculados
            generaElementosIniciales();
            transicionesLr1 = new List<String>();
            listEstadosLR1 = new List<EdoLR1>();

        }
        public void generaElementosIniciales()
        {
            if (gramatica != null)
            {
                listElemIniciales = new List<ElementoLR1>();
                foreach (Token t in gramatica.getSetNoTerminales)
                {

                    foreach (List<Token> produc in t.getSetListaProducciones)
                    {
                        ElementoLR1 nuevo = new ElementoLR1();
                       // nuevo.getSetAnalizador = false;
                    //  nuevo.getSetNoTerminal = t.getSetNoTerminal;
                        nuevo.getSetPrimero = t.getSetPrimero;
                        nuevo.getSetSimbolo = t.getSetSimbolo;
                        foreach(Token t1 in produc)
                        {
                            nuevo.getSetListaProduccion.Add(t1);

                        }
                        
                        listElemIniciales.Add(nuevo);

                    }
                }
                if (listElemIniciales.Count > 0)
                    listElemIniciales[0].getSetLadocAdelanto.Add("$");//se pone el primer caracter de adelanto s'->s,$
            }

        }

        //-------------------------------Obtencion del AFD-----------------------------------------------------
        /***
     * @brief Método del algoritmo LR1 sacado del libro del dragon purpura página 287
     * @param unEstado representa al estado que se le aplicara la cerradura 
     * @return retorna un estado con la cerradura
     * */
        public EdoLR1 cerradura(EdoLR1 unEstado)
        {
            EdoLR1 auxEdo = unEstado;//AUXILIAR del estado que llega
            List<Token> aBB;
            List<ElementoLR1> noTerminalesB;//aqui se guardaran las producciones de be (algoritmo del libro del dragon pag 265)

            for(int i = 0; i < auxEdo.getSetListElementos.Count; i++)
            {
                if (!auxEdo.getSetListElementos[i].getSetListaProduccion.Last().getSetAnalizador)//es decir si no esta analizado se hace el proceso, si ya fue analizado el ultimo entonces es un elemento completo
                {
                    aBB = separaBeBeta(auxEdo.getSetListElementos[i].getSetListaProduccion);
                    if (aBB.Count > 0)
                    {
                        foreach(List<Token> t in aBB[0].getSetListaProducciones)////por cada elemento B->r en G´  r en este caso es una lista de tokens
                        {
                            try
                            {

                                if (aBB[1] != null)
                                {
                                    ElementoLR1 nuevo = new ElementoLR1(aBB[0].getSetSimbolo,t,aBB[1].getSetPrimero);
                                    nuevo.retornaAnalizador();
                                    if (!contieneEdoElemento(auxEdo, nuevo))
                                        auxEdo.getSetListElementos.Add(nuevo);
                                    


                                }
                                else
                                {
                                    ElementoLR1 nuevo = new ElementoLR1(aBB[0].getSetSimbolo, t, auxEdo.getSetListElementos[i].getSetLadocAdelanto);
                                    nuevo.retornaAnalizador();
                                    if (!contieneEdoElemento(auxEdo, nuevo))
                                        auxEdo.getSetListElementos.Add(nuevo);

                                }

                            } catch(Exception e)
                            { MessageBox.Show("Error En Método cerradura " + e, "Compiladores B", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                        }
                    }
                }
                else
                {
                    //retornar el false de analizado para que sevea igual que en el libro
                }
            }
            return auxEdo;
        }
        /**
         * @brief Método IR_A del algoritmo LR1 del libro del dragon purpura pag 287, lo que hace es recorrer el punto o en este caso la bandera de analizador y retornar la cerradura de J 
         * que es el estado que contiene las transiciones a un nuevo estado con el token X
         * @param unEstado estado del cual se quiere saber que transicion tiene con X 
         * @param X token con el cual se hara la transicion 
         * 
         * **/
        public EdoLR1 ir_A(List<ElementoLR1> unEstado, Token X)
        {
            EdoLR1 J = new EdoLR1();//estado J que es vacio
            ElementoLR1 recorreP;
            bool entro = false; //bandera para saber si entro, es decir si el estado tuvo transicion con X, si no entra regresará nulo

            for(int i = 0; i < unEstado.Count; i++)
            {

                if (!unEstado[i].getSetAnalizado)//es decir si el elemento aun no ha sido analizado en su totalidad
                {
                    recorreP = new ElementoLR1(unEstado[i]);
                    for (int j = 0; j < recorreP.getSetListaProduccion.Count; j++)
                    {

                        if (!recorreP.getSetListaProduccion[j].getSetAnalizador&&recorreP.getSetListaProduccion[j].getSetSimbolo==X.getSetSimbolo)
                        {
                            recorreP.getSetListaProduccion[j].getSetAnalizador = true;
                            J.getSetListElementos.Add(recorreP);
                            entro = true;
                        }
                    }
                }
            }




            return cerradura(J);
        }
        /***
      * @brief Método principal del algoritmo LR1 manda invocar los metodos cerradura e ir_A para desarrollar todo el algorimo
      * */
        public void elementos()
        {
            EdoLR1 c;
            EdoLR1 primerEdo = new EdoLR1();
            EdoLR1 auxIR_A;

            primerEdo.getSetListElementos.Add(listElemIniciales[0]);//SE INICIA EL ESTADO CON LA PRIMERA PRODUCCION
            c = cerradura(primerEdo);
            listEstadosLR1.Add(c);

        }
        public bool contieneEdoElemento(EdoLR1 unEdo,ElementoLR1 unElemento)
        {
            bool res = true;

            foreach(ElementoLR1 elem in unEdo.getSetListElementos)
            {
                res = true;
                if (elem.getSetSimbolo == unElemento.getSetSimbolo)
                {
                    if (elem.getSetListaProduccion.Count == unElemento.getSetListaProduccion.Count)
                    {
                        foreach (Token t1 in elem.getSetListaProduccion)
                        {
                            foreach (Token t2 in unElemento.getSetListaProduccion)
                            {
                                if (t1.getSetSimbolo != t2.getSetSimbolo)
                                    res = false;
                            }
                        }
                    }
                    else
                        res = false;
                }
                else
                    res = false;
            }

            return res;
        }
        /**
         *@brief Método que separa de una lista de tokens la parte be de la beta
         * @return Retorna un arreglo en que el elemento cero es be y el uno es beta
         * **/
        public List<Token> separaBeBeta(List<Token> cadSeparar)
        {
            List <Token> res= new List<Token> ();
            for (int i = 0; i < cadSeparar.Count; i++)
            {
                if (!cadSeparar[i].getSetAnalizador)
                {
                    if (cadSeparar[i].getSetNoTerminal)//si es no terminal, entonces es la parte be
                    {
                        res.Add(retornaTokenInicial(cadSeparar[i]));
                        i++;
                        if (i < cadSeparar.Count)
                        {
                            res.Add(retornaTokenInicial(cadSeparar[i]));//este seria beta
                        }
                        else
                        {
                            res.Add(null);
                        }

                    }
                    else
                        break;//si no tiene be no tiene caso buscar beta be debe de ser un no terminal
                }
            }

            return res;


        }

        public Token retornaTokenInicial(Token unToken)
        {
            foreach(Token t in gramatica.getSetNoTerminales)
            {
                if (t.getSetSimbolo == unToken.getSetSimbolo)
                    return t;
            }
            return null;

        }
    }
}
