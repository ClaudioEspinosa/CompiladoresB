using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1Tokenizado2018
{
    class EdoLR1
    {
        private List<ElementoLR1> listaElementos;///<lista elementos de estado
        private string accion;///<String que represena si es estado de reduccion o desplazamiento
        private bool esCompleto;///<variable para indicar que el estado es un estado completo lr1
        private int indiceReduccion;//guarda el indice en la gramatica aumentada de la produccion por la cual se hara la reduccion

        public EdoLR1()
        {
            listaElementos = new List<ElementoLR1>();
            accion = "s";//n es un valor cualquiera solo para inicializar
            esCompleto = false;

        }
        public List<ElementoLR1> getSetListElementos
        {
            get { return listaElementos; }
            set { listaElementos = value; }
        }
        public string getSetListAccion
        {
            get { return accion; }
            set { accion = value; }
        }
        public bool getSetCompleto
        {
            get { return esCompleto; }
            set { esCompleto = value; }
        }
        public int getSetIndiceReduccion
        {
            get { return indiceReduccion; }
            set { indiceReduccion = value; }
        }

    }
}
