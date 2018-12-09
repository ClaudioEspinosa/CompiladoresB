using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1Tokenizado2018
{
    class Token
    {
        private string simbolo;///<Es la cadena que representa al token (identificador)
        private Boolean terminal;///<Bandera para saber si el simbolo es terminal o no
        private List<Token> producciones;///<Variable para manejar las diferentes producciones que puede manejar un simbolo, en caso de ser no terminal

        public Token()
        {

        }
    }
}
