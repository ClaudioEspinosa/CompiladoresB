using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1Tokenizado2018
{
    class Gramatica
    {
        private List<string> listaRenglones;
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
        }
    }
}
