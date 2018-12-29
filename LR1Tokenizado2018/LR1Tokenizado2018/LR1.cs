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
                                    ElementoLR1 nuevo;
                                    if (aBB[1].getSetNoTerminal)
                                        nuevo = new ElementoLR1(aBB[0].getSetSimbolo, copiaCadTokens(t), aBB[1].getSetPrimero);
                                    else
                                    {
                                        List<string> primeroTerminal = new List<string>();
                                        primeroTerminal.Add(aBB[1].getSetSimbolo);
                                        nuevo = new ElementoLR1(aBB[0].getSetSimbolo, copiaCadTokens(t), primeroTerminal);
                                    }
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
                    auxEdo.getSetCompleto = true;
                   
                }
            }
            return auxEdo;
        }
        public List<Token> copiaCadTokens(List<Token> listaAcopiar)
        {
            List<Token> res=new List<Token>();
            foreach(Token t in listaAcopiar)
            {
                res.Add((Token)t.Clone());
            }

            return res;
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
                    recorreP = (ElementoLR1)unEstado[i].Clone();
                    for (int j = 0; j < recorreP.getSetListaProduccion.Count; j++)
                    {

                        if (!recorreP.getSetListaProduccion[j].getSetAnalizador)
                        {
                            if (recorreP.getSetListaProduccion[j].getSetSimbolo == X.getSetSimbolo)
                            {
                                recorreP.getSetListaProduccion[j].getSetAnalizador = true;
                                J.getSetListElementos.Add(recorreP);
                                entro = true;
                               
                                break;
                            }
                            else
                                break;//si el analizador ya esta en esa posicion y el. simbolo no es igual entonces ya no recorro los demas 
                        }
                    }
                   // break;
                }
                
            }




            ///aqui se hace la parte de return cerradura de J
            if (entro)
                return cerradura(J);
            else
                return null;
        }
        /***
      * @brief Método principal del algoritmo LR1 manda invocar los metodos cerradura e ir_A para desarrollar todo el algorimo
      * */
        public void elementos()
        {
            EdoLR1 c;
            EdoLR1 primerEdo = new EdoLR1();
            EdoLR1 auxIR_A;
            string auxTransicion = "";//para formar la cadena de transicion que se guarda en una lista d strings
            //el formato es edo1-edo1-simbolo para asi hacer un split con - y separarlo 

            primerEdo.getSetListElementos.Add(listElemIniciales[0]);//SE INICIA EL ESTADO CON LA PRIMERA PRODUCCION
            c = cerradura(primerEdo);
            listEstadosLR1.Add(c);

            for(int i = 0; i < listEstadosLR1.Count; i++)//por cada conjunto de elementos I en C 
            {
                
                if (!listEstadosLR1[i].getSetCompleto)
                {
                    foreach (Token X in gramatica.getSetElemGramaticales)//por cada simbolo gramatical X
                    {
                        if (i == 5 && X.getSetSimbolo == "(")
                        {

                        }
                        auxIR_A = ir_A(listEstadosLR1[i].getSetListElementos, X);
                        if (auxIR_A != null && !contieneEstado(listEstadosLR1, auxIR_A))
                        {
                            if (X.getSetNoTerminal)
                            {
                                auxTransicion = i + "°" + X.getSetSimbolo + "°";//indicamos que es un desplazamiento
                                listEstadosLR1.Add(auxIR_A);//se agrega el ir a
                                auxTransicion += listEstadosLR1.Count - 1;//esto es porque es el estado siguiente, tam de lista de edos lr1 -1
                                transicionesLr1.Add(auxTransicion);
                                auxTransicion = "";
                            }
                            else
                            {
                                auxTransicion = i + "°" + X.getSetSimbolo + "°";
                                listEstadosLR1.Add(auxIR_A);//esta al ultimom pndejo
                                if (listEstadosLR1.Last().getSetListAccion.Contains('r'))
                                {
                                    listEstadosLR1.Last().getSetListAccion = listEstadosLR1[getIniceEstado(listEstadosLR1, auxIR_A)].getSetListAccion.Replace('r', 's');
                                }
                                auxTransicion += listEstadosLR1.Last().getSetListAccion + (listEstadosLR1.Count - 1);
                                transicionesLr1.Add(auxTransicion);
                                auxTransicion = "";
                            }
                        }
                        else
                        {
                            if (auxIR_A != null)
                            {
                                //este es el caso de las orejas
                                auxTransicion = i + "°" +X.getSetSimbolo + "°" + getListaEstadosLr1[getIniceEstado(listEstadosLR1, auxIR_A)].getSetListAccion + getIniceEstado(listEstadosLR1, auxIR_A);
                                // auxTransicion += 
                                transicionesLr1.Add(auxTransicion);
                                auxTransicion = "";
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < listEstadosLR1.Count; i++)
            {
                auxTransicion = "";
                if (listEstadosLR1[i].getSetCompleto)
                {
                    for (int j = 0; j < listEstadosLR1[i].getSetListElementos.Count; j++)
                    {
                        for (int k = 0; k < listEstadosLR1[i].getSetListElementos[j].getSetLadocAdelanto.Count; k++)
                        {
                            auxTransicion = i + "°" + listEstadosLR1[i].getSetListElementos[j].getSetLadocAdelanto[k] + "°" + "r" + listEstadosLR1[i].getSetIndiceReduccion.ToString();
                            transicionesLr1.Add(auxTransicion);
                        }
                    }
                }
            }

        }
        /***
     * @brief Método que retorna el indice de un  estado, si este se encuentra en una lista de estados
     * @param estados Lista de estados donde se buscará
     * @param unEstado Estado a buscar
     * @return indice
     * */
        public int getIniceEstado(List<EdoLR1> estados, EdoLR1 unEstado)
        {
            int res = -1;

            for (int i = 0; i < estados.Count; i++)
            {
                //  if(i!=indice)


                if (comparaEstados(estados[i], unEstado))
                    return i;
            }
            return res;
        }
        /**
         * @brief Método para verificar si un estado ya se encuentra en la lista de estados LR1
         * @param listaEstados lista de estados donde se buscará
         * @param unEdo estado a buscar 
         * @return retorna verdadero si el elemento ya se encuentra dentro del estado
         * **/
        public bool contieneEstado(List<EdoLR1> listaEstados,EdoLR1 unEdo)
        {   
            bool res = false;
            for (int i = 0; i < listaEstados.Count; i++)
            {
                if (i == 5)
                {

                }
                //  if(i!=indice)
                res = comparaEstados(listaEstados[i], unEdo);

                if (res)
                    break;
            }

            return res;
        }
        public bool comparaEstados(EdoLR1 estado1, EdoLR1 estado2)
        {
            bool res = false;
            bool noSonIguales = false;
            int contador = 0;//para ver si todos los elementos son iguales
            if (estado1.getSetListElementos.Count == estado2.getSetListElementos.Count)//para empezar deben de tener el mismo numero de elementos
            {
               for(int i = 0; i < estado1.getSetListElementos.Count; i++)
                { 

                        if (comparaElementosLR1(estado1.getSetListElementos[i], estado2.getSetListElementos[i]))
                        {
                            contador++;

                        }
                        else
                        {
                            noSonIguales = true;
                            break;
                            
                        }

                    }
                    
                
                if (contador == estado1.getSetListElementos.Count)
                    res = true;//se compara si el numero de veces que los elementos fueron iguales es la misma cantidad de elementos entonces los objetos son iguales 
                               //solo tienen los elementos en otro orden
            }
            return res;
        }
        public bool comparaElementosLR1(ElementoLR1 elem1,ElementoLR1 elem2)
        {
            bool res = true;

            if (elem1.getSetSimbolo == elem2.getSetSimbolo)// se compara si tienen el mismo simbolo
            {
                if (!elem1.getSetLadocAdelanto.SequenceEqual(elem2.getSetLadocAdelanto))//para que sea el mismo elemento debe de tener el mismo caracter de adelanto
                    return false;

                if (elem1.getSetListaProduccion.Count == elem2.getSetListaProduccion.Count)
                {
                    for(int i = 0; i < elem1.getSetListaProduccion.Count; i++)
                    {
                        if (elem1.getSetListaProduccion[i].getSetSimbolo != elem2.getSetListaProduccion[i].getSetSimbolo)
                            return false;
                        if (elem1.getSetListaProduccion[i].getSetAnalizador != elem2.getSetListaProduccion[i].getSetAnalizador)
                            return false;
                    }
                }
                else
                {
                    return false;//quiere decir que no producen lo mismo
                }
        
               
            }
            else
                return false;

            return res;
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
                            if (cadSeparar[i].getSetNoTerminal)//si beta es no terminal
                                res.Add(retornaTokenInicial(cadSeparar[i]));//este seria beta
                            else
                                res.Add(retornaTokenInicialTerminal(cadSeparar[i]));
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
        public Token retornaTokenInicialTerminal(Token unToken)
        {
            foreach (Token t in gramatica.getSetTerminales)
            {
                if (t.getSetSimbolo == unToken.getSetSimbolo)
                    return t;
            }
            return null;

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
        public List<EdoLR1> getListaEstadosLr1 //metodo que regresa al form la lista par visualizarla en el form
        {
            get { return listEstadosLR1; }
        }
    }
}
