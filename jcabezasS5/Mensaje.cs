using System;
using System.Collections.Generic;
using System.Text;

namespace jcabezasS5
{
    public interface Mensaje //creamos la interfaz púbilca
    {
        void longAlert(string mensaje); // implementamos el mensaje largo 5s
        void shortAlert(string mensaje); // implementamos el mensaje corto 3s
    }
}
