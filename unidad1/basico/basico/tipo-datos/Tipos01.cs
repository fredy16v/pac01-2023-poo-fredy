using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basico.tipo_datos
{
    internal class Tipos01
    {
        public String saludo { get; set; }

        public Tipos01(String v1)
        {
            this.saludo = v1; // para asignar un valor a saludo como el set
            String sNombre = this.saludo + ", Juan Perez"; //obtener el valor de saludo como el get
            
            Console.WriteLine(sNombre);
        }
    }
}
