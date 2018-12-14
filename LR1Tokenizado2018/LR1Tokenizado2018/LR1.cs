using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        ´private List<Token> listElemIniciales;
        private List<String> transicionesLr1;///< Transiciones del AFD
        public LR1(Gramatica unaGramatica)
        {
            gramatica = unaGramatica;//llega la gramatica con los primeros calculados
            generaElementosIniciales();
            transicionesLr1 = new List<String>();

        }
        public void generaElementosIniciales()
        {
            if (gramatica != null)
            {
                listElemIniciales = new List<Token>();
                foreach (Token t in gramatica.getSetNoTerminales)
                {
                    
                   foreach(List<Token> produc in t.getSetListaProducciones)
                    {
                        Token nuevo = new Token();
                        nuevo.getSetAnalizador = false;
                        nuevo.getSetNoTerminal = t.getSetNoTerminal;
                        nuevo.getSetPrimero = t.getSetPrimero;
                        nuevo.getSetSimbolo = t.getSetSimbolo;
                        nuevo.getSetListaProducciones.Add(produc);
                        listElemIniciales.Add(nuevo);

                    }
                }
            }

        }

        //-------------------------------Obtencion del AFD-----------------------------------------------------
        public void cerradura(EdoLR1 unEstado)
        {
            EdoLR1 auxEdo = unEstado;//AUXILIAR del estado que llega
            Token[] aBB;
            List<ElementoLR1> noTerminalesB;//aqui se guardaran las producciones de be (algoritmo del libro del dragon pag 265)

            for(int i = 0; i < auxEdo.getSetListElementos.Count; i++)
            {
                if(auxEdo.getSetListElementos.Last().getSetAnalizado)
            }

        }
    }
}
