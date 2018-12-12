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
        public LR1(Gramatica unaGramatica)
        {
            gramatica = unaGramatica;//llega la gramatica con los primeros calculados

        }
        public void aumentaGramatica()
        {

        }
    }
}
