using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryAgricultura
{
    class clsConexion
    {
        public static string getCadena()
        {
            string cadena = "provider=microsoft.jet.oledb.4.0;data source=AGRICULTURA.mdb";
            return cadena;
        }
    }
}
